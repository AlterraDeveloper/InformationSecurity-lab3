using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace InformationSecurity_lab3
{
    public partial class Form1 : Form
    {
        private readonly IntegrityChecker _integrityChecker;
        private Bitmap _bitmap;
        private int _lowBits;
        private string _extractedText;
        private bool _isNormalMode;
        private int _distortedBytes;
        public Form1()
        {
            InitializeComponent();
            cmbbxBits.SelectedItem = cmbbxBits.Items[0];
            progressBar.Visible = false;
            _isNormalMode = true;
            _integrityChecker = new IntegrityChecker();
        }

        private void btnLoadTextFromFile_Click(object sender, EventArgs e)
        {
            var explorer = new OpenFileDialog();

            if (explorer.ShowDialog() == DialogResult.OK)
            {
                var textFromFile = File.ReadAllText(explorer.FileName, Encoding.UTF8);

                txtbxInputOutput.Text = textFromFile;
            }
        }

        private void btnSaveTextToFile_Click(object sender, EventArgs e)
        {
            var explorer = new OpenFileDialog();

            if (explorer.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(explorer.FileName, txtbxInputOutput.Text, Encoding.UTF8);

                MessageBox.Show($"Файл {explorer.FileName}  успешно сохранен!", "Success", MessageBoxButtons.OK);

                txtbxInputOutput.Text = string.Empty;
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            var explorer = new OpenFileDialog();

            if (explorer.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var image = new Bitmap(explorer.FileName);
                    if (image.RawFormat.Guid == ImageFormat.Bmp.Guid)
                    {
                        pictureBox.Image = image;
                        _bitmap = image;

                        var imageBytes = (byte[])new ImageConverter().ConvertTo(_bitmap, typeof(byte[]));

                        _integrityChecker.SetMetrics(imageBytes);
                    }
                    else
                    {
                        throw new BadImageFormatException("Изображение должно быть в формате BMP");
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Файл не является изображением.");
                }
                catch (BadImageFormatException exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            var fileName = "container-" + DateTime.Now.Ticks;
            pictureBox.Image.Save(Path.ChangeExtension(fileName, ".bmp"), ImageFormat.Bmp);
            MessageBox.Show($"Файл {fileName} успешно сохранен");
        }

        private void cmbbxBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lowBits = int.Parse(cmbbxBits.SelectedItem.ToString());
        }

        private void btnHideTextIntoImage_Click(object sender, EventArgs e)
        {
            _bitmap = pictureBox.Image as Bitmap;

            if (_bitmap != null & !string.IsNullOrEmpty(txtbxInputOutput.Text))
            {
                if (backgroundWorker.IsBusy != true)
                {
                    progressBar.Visible = true;
                    progressBar.MarqueeAnimationSpeed = 30;
                    backgroundWorker.RunWorkerAsync(null);
                }
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные.\n1. Загрузите изображение...\n2. Введите текст...");
            }
        }

        private void btnExtractTextFromImage_Click(object sender, EventArgs e)
        {
            if (_bitmap != null)
            {
                if (backgroundWorker1.IsBusy != true)
                {
                    progressBar.Visible = true;
                    progressBar.MarqueeAnimationSpeed = 30;
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Загрузите изображение");
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _bitmap = Steganography.HideTextIntoImage(txtbxInputOutput.Text, _bitmap, _lowBits);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_bitmap != null)
            {
                pictureBox.Image = _bitmap;
                MessageBox.Show($"Текст успешно помещен в контейнер");

                var imageBytes = (byte[])new ImageConverter().ConvertTo(_bitmap, typeof(byte[]));

                _integrityChecker.SetMetrics(imageBytes);
            }
            else
            {
                MessageBox.Show($"Ошибка!\nВозможные причины :\n1) Данный текст не помещается в изображение.\nПопробуйте уменьшить длину текста или увеличить количество младших бит.\n2) Проверьте введенные данные (текст,изображение).");
            }
            progressBar.Visible = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            _extractedText = Steganography.ExtractTextFromImage(_bitmap);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            txtbxInputOutput.Text = _extractedText;
            progressBar.Visible = false;
        }

        private void btnDistortImage_Click(object sender, EventArgs e)
        {
            _isNormalMode = false;
            foreach (Control control in Controls)
            {
                if (control is PictureBox)
                {
                    control.Enabled = true;
                }
                else
                {
                    control.Enabled = false;
                }
            }
            label2.Text = "Режим искажения изображения, нажмите ESC для выхода";
            label2.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!_isNormalMode & e.KeyCode == Keys.Escape)
            {
                foreach (Control control in Controls)
                {
                    control.Enabled = true;
                }
                label2.Text = string.Empty;
                MessageBox.Show($"Искажено {_distortedBytes} байт.");
                _isNormalMode = true;
                _distortedBytes = 0;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_isNormalMode)
            {
                try
                {
                    Color cursorColor = Color.Green;

                    if (e.Button == MouseButtons.Left)
                    {
                        cursorColor = Color.Red;

                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        cursorColor = Color.Blue;
                    }

                    _bitmap.SetPixel(e.X, e.Y, cursorColor);
                    _distortedBytes += (int)Constants.COMPONENTS_IN_PIXEL;
                    pictureBox.Image = _bitmap;
                }
                catch (ArgumentOutOfRangeException)
                {

                }
            }
        }

        private void btnCheckIntegrity_Click(object sender, EventArgs e)
        {
            var imageBytes = (byte[])new ImageConverter().ConvertTo(_bitmap, typeof(byte[]));

            if (radioBtnCheckByXOR.Checked)
            {

                if (_integrityChecker.CheckByXOR(imageBytes))
                {
                    MessageBox.Show("Данные целостны", "Отлично");
                }
                else
                {
                    MessageBox.Show("Информация содержащаяся в контейнере повреждена", "Ошибка");
                }
            }
            else if (radioBtnCheckWithCyclicCodes.Checked)
            {
                if (_integrityChecker.CheckWithCyclicCodes(imageBytes))
                {
                    MessageBox.Show("Данные целостны", "Отлично");
                }
                else
                {
                    MessageBox.Show("Информация содержащаяся в контейнере повреждена", "Ошибка");
                }
            }
            else if (radioBtnCheckWithHemmingCode.Checked)
            {
                if (_integrityChecker.CheckWithHemmingCode(imageBytes))
                {
                    MessageBox.Show("Данные целостны", "Отлично");
                }
                else
                {
                    MessageBox.Show("Информация содержащаяся в контейнере повреждена", "Ошибка");
                }
            }
        }
    }
}

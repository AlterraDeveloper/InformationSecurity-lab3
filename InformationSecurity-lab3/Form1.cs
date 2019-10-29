using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSecurity_lab3
{
    public partial class Form1 : Form
    {
        private int _hiddenBits;
        private Bitmap _bitmap;
        private int _lowBits;
        private string _extractedText;
        public Form1()
        {
            InitializeComponent();
            cmbbxBits.SelectedItem = cmbbxBits.Items[0];
            progressBar.Visible = false;
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
                    }
                    else
                    {
                        throw new BadImageFormatException("Изображение должно быть в формате BMP");
                    }

                    var a = pictureBox.Image.RawFormat;
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
            _bitmap = Steganography.HideTextIntoImage(txtbxInputOutput.Text,_bitmap, _lowBits);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_bitmap != null)
            {
                pictureBox.Image = _bitmap;
                MessageBox.Show($"Успешно спрятано {_hiddenBits} бит");
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
    }
}

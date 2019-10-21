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
                    pictureBox.Image = new Bitmap(explorer.FileName);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Файл не является изображением");
                }
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            var fileName = "container-" + DateTime.Now.Ticks;
            pictureBox.Image.Save(Path.ChangeExtension(fileName, ".bmp"), ImageFormat.Bmp);
            MessageBox.Show($"Файл {fileName} успешно сохранен");
        }

        private void btnHideTextIntoImage_Click(object sender, EventArgs e)
        {
            _bitmap = pictureBox.Image as Bitmap;

            if (_bitmap != null)
            {
                if (backgroundWorker.IsBusy != true)
                {
                    progressBar.Visible = true;
                    progressBar.MarqueeAnimationSpeed = 30;
                    backgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Сначала загрузите изображение");
            }
        }

        private int _hiddenBits;
        private Bitmap _bitmap;
        private int _lowBits;

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            _hiddenBits = Steganography.HideTextIntoImage(txtbxInputOutput.Text, ref _bitmap, _lowBits);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_hiddenBits >= 0)
            {
                pictureBox.Image = _bitmap;
                progressBar.Visible = false;
                MessageBox.Show($"Успешно спрятано {_hiddenBits} бит");
            }
            else
            {
                MessageBox.Show($"Ошибка в данных:\n1. Проверьте введенный текст\n2. Проверьте изображение");
            }
        }

        private void cmbbxBits_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lowBits = int.Parse(cmbbxBits.SelectedItem.ToString());
        }

        private void btnExtractTextFromImage_Click(object sender, EventArgs e)
        {
            txtbxInputOutput.Text = Steganography.ExtractTextFromImage(pictureBox.Image as Bitmap, _lowBits, _hiddenBits);
        }
    }
}

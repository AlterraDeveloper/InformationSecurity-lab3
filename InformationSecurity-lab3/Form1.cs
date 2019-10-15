using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSecurity_lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadTextFromFile_Click(object sender, EventArgs e)
        {
            var explorer = new OpenFileDialog();

            if (explorer.ShowDialog() == DialogResult.OK)
            {
                var textFromFile = File.ReadAllText(explorer.FileName, Encoding.Default);

                txtbxInputOutput.Text = textFromFile;
            }
        }

        private void btnSaveTextToFile_Click(object sender, EventArgs e)
        {
            var explorer = new OpenFileDialog();

            if (explorer.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(explorer.FileName, txtbxInputOutput.Text);

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
            var fileName = "container-" + DateTime.Now.Ticks + ".bmp";
            var fs = File.Create(fileName);
            pictureBox.Image.Save(fs, ImageFormat.Bmp);
            MessageBox.Show($"Файл {fileName} успешно сохранен");
        }

        private void btnHideTextIntoImage_Click(object sender, EventArgs e)
        {
            var bitmap = pictureBox.Image as Bitmap;

            if (bitmap != null)
            {
                MessageBox.Show(bitmap.Width + "x" + bitmap.Height);
            }
        }
    }
}

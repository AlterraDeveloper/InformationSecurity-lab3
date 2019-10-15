namespace InformationSecurity_lab3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtbxInputOutput = new System.Windows.Forms.TextBox();
            this.btnLoadTextFromFile = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnHideTextIntoImage = new System.Windows.Forms.Button();
            this.cmbbxBits = new System.Windows.Forms.ComboBox();
            this.btnDistortImage = new System.Windows.Forms.Button();
            this.btnExtractTextFromImage = new System.Windows.Forms.Button();
            this.btnSaveTextToFile = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // txtbxInputOutput
            // 
            this.txtbxInputOutput.Location = new System.Drawing.Point(13, 13);
            this.txtbxInputOutput.Multiline = true;
            this.txtbxInputOutput.Name = "txtbxInputOutput";
            this.txtbxInputOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbxInputOutput.Size = new System.Drawing.Size(643, 103);
            this.txtbxInputOutput.TabIndex = 0;
            // 
            // btnLoadTextFromFile
            // 
            this.btnLoadTextFromFile.Location = new System.Drawing.Point(663, 13);
            this.btnLoadTextFromFile.Name = "btnLoadTextFromFile";
            this.btnLoadTextFromFile.Size = new System.Drawing.Size(125, 46);
            this.btnLoadTextFromFile.TabIndex = 1;
            this.btnLoadTextFromFile.Text = "Загрузить текст из файла";
            this.btnLoadTextFromFile.UseVisualStyleBackColor = true;
            this.btnLoadTextFromFile.Click += new System.EventHandler(this.btnLoadTextFromFile_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(13, 135);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(300, 300);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(333, 135);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(183, 23);
            this.btnLoadImage.TabIndex = 3;
            this.btnLoadImage.Text = "Загрузить изображение";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnHideTextIntoImage
            // 
            this.btnHideTextIntoImage.Location = new System.Drawing.Point(333, 258);
            this.btnHideTextIntoImage.Name = "btnHideTextIntoImage";
            this.btnHideTextIntoImage.Size = new System.Drawing.Size(183, 23);
            this.btnHideTextIntoImage.TabIndex = 4;
            this.btnHideTextIntoImage.Text = "Спрятать текст в контейнер";
            this.btnHideTextIntoImage.UseVisualStyleBackColor = true;
            this.btnHideTextIntoImage.Click += new System.EventHandler(this.btnHideTextIntoImage_Click);
            // 
            // cmbbxBits
            // 
            this.cmbbxBits.FormattingEnabled = true;
            this.cmbbxBits.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbbxBits.Location = new System.Drawing.Point(333, 231);
            this.cmbbxBits.Name = "cmbbxBits";
            this.cmbbxBits.Size = new System.Drawing.Size(121, 21);
            this.cmbbxBits.TabIndex = 5;
            // 
            // btnDistortImage
            // 
            this.btnDistortImage.Location = new System.Drawing.Point(333, 331);
            this.btnDistortImage.Name = "btnDistortImage";
            this.btnDistortImage.Size = new System.Drawing.Size(183, 23);
            this.btnDistortImage.TabIndex = 6;
            this.btnDistortImage.Text = "Испортить изображение";
            this.btnDistortImage.UseVisualStyleBackColor = true;
            // 
            // btnExtractTextFromImage
            // 
            this.btnExtractTextFromImage.Location = new System.Drawing.Point(333, 360);
            this.btnExtractTextFromImage.Name = "btnExtractTextFromImage";
            this.btnExtractTextFromImage.Size = new System.Drawing.Size(183, 23);
            this.btnExtractTextFromImage.TabIndex = 7;
            this.btnExtractTextFromImage.Text = "Извлечь текст из контейнера";
            this.btnExtractTextFromImage.UseVisualStyleBackColor = true;
            // 
            // btnSaveTextToFile
            // 
            this.btnSaveTextToFile.Location = new System.Drawing.Point(663, 65);
            this.btnSaveTextToFile.Name = "btnSaveTextToFile";
            this.btnSaveTextToFile.Size = new System.Drawing.Size(125, 41);
            this.btnSaveTextToFile.TabIndex = 8;
            this.btnSaveTextToFile.Text = "Сохранить текст в файл";
            this.btnSaveTextToFile.UseVisualStyleBackColor = true;
            this.btnSaveTextToFile.Click += new System.EventHandler(this.btnSaveTextToFile_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(333, 164);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(183, 23);
            this.btnSaveImage.TabIndex = 9;
            this.btnSaveImage.Text = "Сохранить изображение";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(330, 215);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Количество младших разрядов";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.btnSaveTextToFile);
            this.Controls.Add(this.btnExtractTextFromImage);
            this.Controls.Add(this.btnDistortImage);
            this.Controls.Add(this.cmbbxBits);
            this.Controls.Add(this.btnHideTextIntoImage);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.btnLoadTextFromFile);
            this.Controls.Add(this.txtbxInputOutput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtbxInputOutput;
        private System.Windows.Forms.Button btnLoadTextFromFile;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnHideTextIntoImage;
        private System.Windows.Forms.ComboBox cmbbxBits;
        private System.Windows.Forms.Button btnDistortImage;
        private System.Windows.Forms.Button btnExtractTextFromImage;
        private System.Windows.Forms.Button btnSaveTextToFile;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Label label1;
    }
}


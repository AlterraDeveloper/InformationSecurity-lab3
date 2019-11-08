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
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCheckIntegrity = new System.Windows.Forms.Button();
            this.radioBtnCheckWithHemmingCode = new System.Windows.Forms.RadioButton();
            this.radioBtnCheckWithCyclicCodes = new System.Windows.Forms.RadioButton();
            this.radioBtnCheckByXOR = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.pictureBox.ErrorImage = null;
            this.pictureBox.Location = new System.Drawing.Point(13, 135);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(300, 300);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
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
            this.cmbbxBits.SelectedIndexChanged += new System.EventHandler(this.cmbbxBits_SelectedIndexChanged);
            // 
            // btnDistortImage
            // 
            this.btnDistortImage.Location = new System.Drawing.Point(333, 331);
            this.btnDistortImage.Name = "btnDistortImage";
            this.btnDistortImage.Size = new System.Drawing.Size(183, 23);
            this.btnDistortImage.TabIndex = 6;
            this.btnDistortImage.Text = "Испортить изображение";
            this.btnDistortImage.UseVisualStyleBackColor = true;
            this.btnDistortImage.Click += new System.EventHandler(this.btnDistortImage_Click);
            // 
            // btnExtractTextFromImage
            // 
            this.btnExtractTextFromImage.Location = new System.Drawing.Point(333, 360);
            this.btnExtractTextFromImage.Name = "btnExtractTextFromImage";
            this.btnExtractTextFromImage.Size = new System.Drawing.Size(183, 23);
            this.btnExtractTextFromImage.TabIndex = 7;
            this.btnExtractTextFromImage.Text = "Извлечь текст из контейнера";
            this.btnExtractTextFromImage.UseVisualStyleBackColor = true;
            this.btnExtractTextFromImage.Click += new System.EventHandler(this.btnExtractTextFromImage_Click);
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
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar.Location = new System.Drawing.Point(45, 274);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(239, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 11;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(333, 421);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 18);
            this.label2.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCheckIntegrity);
            this.groupBox1.Controls.Add(this.radioBtnCheckWithHemmingCode);
            this.groupBox1.Controls.Add(this.radioBtnCheckWithCyclicCodes);
            this.groupBox1.Controls.Add(this.radioBtnCheckByXOR);
            this.groupBox1.Location = new System.Drawing.Point(549, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 248);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проверка на целостность";
            // 
            // btnCheckIntegrity
            // 
            this.btnCheckIntegrity.Location = new System.Drawing.Point(23, 123);
            this.btnCheckIntegrity.Name = "btnCheckIntegrity";
            this.btnCheckIntegrity.Size = new System.Drawing.Size(236, 23);
            this.btnCheckIntegrity.TabIndex = 3;
            this.btnCheckIntegrity.Text = "Проверить";
            this.btnCheckIntegrity.UseVisualStyleBackColor = true;
            this.btnCheckIntegrity.Click += new System.EventHandler(this.btnCheckIntegrity_Click);
            // 
            // radioBtnCheckWithHemmingCode
            // 
            this.radioBtnCheckWithHemmingCode.AutoSize = true;
            this.radioBtnCheckWithHemmingCode.Location = new System.Drawing.Point(23, 79);
            this.radioBtnCheckWithHemmingCode.Name = "radioBtnCheckWithHemmingCode";
            this.radioBtnCheckWithHemmingCode.Size = new System.Drawing.Size(222, 17);
            this.radioBtnCheckWithHemmingCode.TabIndex = 2;
            this.radioBtnCheckWithHemmingCode.TabStop = true;
            this.radioBtnCheckWithHemmingCode.Text = "*Проверка с помощью кода Хемминга";
            this.radioBtnCheckWithHemmingCode.UseVisualStyleBackColor = true;
            // 
            // radioBtnCheckWithCyclicCodes
            // 
            this.radioBtnCheckWithCyclicCodes.AutoSize = true;
            this.radioBtnCheckWithCyclicCodes.Location = new System.Drawing.Point(23, 54);
            this.radioBtnCheckWithCyclicCodes.Name = "radioBtnCheckWithCyclicCodes";
            this.radioBtnCheckWithCyclicCodes.Size = new System.Drawing.Size(236, 17);
            this.radioBtnCheckWithCyclicCodes.TabIndex = 1;
            this.radioBtnCheckWithCyclicCodes.TabStop = true;
            this.radioBtnCheckWithCyclicCodes.Text = "Проверка с помощью циклических кодов";
            this.radioBtnCheckWithCyclicCodes.UseVisualStyleBackColor = true;
            // 
            // radioBtnCheckByXOR
            // 
            this.radioBtnCheckByXOR.AutoSize = true;
            this.radioBtnCheckByXOR.Location = new System.Drawing.Point(23, 29);
            this.radioBtnCheckByXOR.Name = "radioBtnCheckByXOR";
            this.radioBtnCheckByXOR.Size = new System.Drawing.Size(116, 17);
            this.radioBtnCheckByXOR.TabIndex = 0;
            this.radioBtnCheckByXOR.TabStop = true;
            this.radioBtnCheckByXOR.Text = "Проверка по XOR";
            this.radioBtnCheckByXOR.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "*Данный метод помимо проверки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "на целостность  исправит одиночные ошибки";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar);
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnCheckWithHemmingCode;
        private System.Windows.Forms.RadioButton radioBtnCheckWithCyclicCodes;
        private System.Windows.Forms.RadioButton radioBtnCheckByXOR;
        private System.Windows.Forms.Button btnCheckIntegrity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}


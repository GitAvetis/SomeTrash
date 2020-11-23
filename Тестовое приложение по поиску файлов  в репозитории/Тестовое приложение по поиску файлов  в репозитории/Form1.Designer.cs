namespace Тестовое_приложение_по_поиску_файлов__в_репозитории
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.search = new System.Windows.Forms.Button();
            this.pathString = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.formatBackSpace = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pathBackSpace = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.fileExtension = new System.Windows.Forms.TextBox();
            this.fileExtensionBackSpace = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.counterTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(682, 10);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(97, 57);
            this.search.TabIndex = 0;
            this.search.Text = "Поиск";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.Search_Click);
            // 
            // pathString
            // 
            this.pathString.Location = new System.Drawing.Point(127, 12);
            this.pathString.Name = "pathString";
            this.pathString.Size = new System.Drawing.Size(496, 20);
            this.pathString.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Директория поиска";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Путь к файлу";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(127, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(155, 20);
            this.textBox2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Имя файла";
            // 
            // formatBackSpace
            // 
            this.formatBackSpace.BackColor = System.Drawing.SystemColors.Control;
            this.formatBackSpace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.formatBackSpace.Image = ((System.Drawing.Image)(resources.GetObject("formatBackSpace.Image")));
            this.formatBackSpace.Location = new System.Drawing.Point(300, 40);
            this.formatBackSpace.Name = "formatBackSpace";
            this.formatBackSpace.Size = new System.Drawing.Size(47, 37);
            this.formatBackSpace.TabIndex = 9;
            this.formatBackSpace.UseVisualStyleBackColor = false;
            this.formatBackSpace.Click += new System.EventHandler(this.FormatBackSpace_Click);
            // 
            // pathBackSpace
            // 
            this.pathBackSpace.BackColor = System.Drawing.SystemColors.Control;
            this.pathBackSpace.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.pathBackSpace.FlatAppearance.BorderSize = 0;
            this.pathBackSpace.ForeColor = System.Drawing.Color.DarkMagenta;
            this.pathBackSpace.Image = ((System.Drawing.Image)(resources.GetObject("pathBackSpace.Image")));
            this.pathBackSpace.Location = new System.Drawing.Point(629, 3);
            this.pathBackSpace.Name = "pathBackSpace";
            this.pathBackSpace.Size = new System.Drawing.Size(47, 37);
            this.pathBackSpace.TabIndex = 10;
            this.pathBackSpace.UseVisualStyleBackColor = false;
            this.pathBackSpace.Click += new System.EventHandler(this.PathBackSpace_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(127, 85);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(496, 227);
            this.treeView1.TabIndex = 12;
            // 
            // fileExtension
            // 
            this.fileExtension.Location = new System.Drawing.Point(468, 47);
            this.fileExtension.Name = "fileExtension";
            this.fileExtension.Size = new System.Drawing.Size(155, 20);
            this.fileExtension.TabIndex = 13;
            // 
            // fileExtensionBackSpace
            // 
            this.fileExtensionBackSpace.BackColor = System.Drawing.SystemColors.Control;
            this.fileExtensionBackSpace.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.fileExtensionBackSpace.FlatAppearance.BorderSize = 0;
            this.fileExtensionBackSpace.ForeColor = System.Drawing.Color.DarkMagenta;
            this.fileExtensionBackSpace.Image = ((System.Drawing.Image)(resources.GetObject("fileExtensionBackSpace.Image")));
            this.fileExtensionBackSpace.Location = new System.Drawing.Point(629, 42);
            this.fileExtensionBackSpace.Name = "fileExtensionBackSpace";
            this.fileExtensionBackSpace.Size = new System.Drawing.Size(47, 37);
            this.fileExtensionBackSpace.TabIndex = 14;
            this.fileExtensionBackSpace.UseVisualStyleBackColor = false;
            this.fileExtensionBackSpace.Click += new System.EventHandler(this.FileExtensionBackSpace_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(353, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Расширение файла";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(629, 170);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(155, 20);
            this.timeTextBox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(641, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "Затраченное время:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(641, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 23);
            this.label6.TabIndex = 18;
            this.label6.Text = "Колличество подходящих файлов ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.UseCompatibleTextRendering = true;
            // 
            // counterTextBox
            // 
            this.counterTextBox.Location = new System.Drawing.Point(629, 231);
            this.counterTextBox.Name = "counterTextBox";
            this.counterTextBox.Size = new System.Drawing.Size(155, 20);
            this.counterTextBox.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 459);
            this.Controls.Add(this.counterTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fileExtensionBackSpace);
            this.Controls.Add(this.fileExtension);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.pathBackSpace);
            this.Controls.Add(this.formatBackSpace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathString);
            this.Controls.Add(this.search);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Найти файл";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox pathString;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button formatBackSpace;
        private System.Windows.Forms.Button pathBackSpace;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox fileExtension;
        private System.Windows.Forms.Button fileExtensionBackSpace;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox counterTextBox;
    }
}
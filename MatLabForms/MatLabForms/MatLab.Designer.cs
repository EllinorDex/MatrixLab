namespace MatLabForms
{
    partial class MatLab
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Единичная матрица",
            "Матрица с нулевыми значениями",
            "Пользовательская"});
            this.comboBox1.Location = new System.Drawing.Point(26, 247);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(191, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Выберите тип первой матрицы...";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.button1.Location = new System.Drawing.Point(219, 332);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 41);
            this.button1.TabIndex = 2;
            this.button1.Text = "Вычислить!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 147);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Введите количество строк первой матрицы:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(250, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Введите количество столбцов первой матрицы:";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.openToolStripMenuItem.Text = "Open matrix...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // operationToolStripMenuItem
            // 
            this.operationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sumToolStripMenuItem,
            this.multToolStripMenuItem,
            this.invToolStripMenuItem,
            this.detToolStripMenuItem});
            this.operationToolStripMenuItem.Name = "operationToolStripMenuItem";
            this.operationToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.operationToolStripMenuItem.Text = "Operation";
            // 
            // sumToolStripMenuItem
            // 
            this.sumToolStripMenuItem.Name = "sumToolStripMenuItem";
            this.sumToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.sumToolStripMenuItem.Text = "Sum";
            // 
            // multToolStripMenuItem
            // 
            this.multToolStripMenuItem.Name = "multToolStripMenuItem";
            this.multToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.multToolStripMenuItem.Text = "Mult";
            // 
            // invToolStripMenuItem
            // 
            this.invToolStripMenuItem.Name = "invToolStripMenuItem";
            this.invToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.invToolStripMenuItem.Text = "Inv";
            // 
            // detToolStripMenuItem
            // 
            this.detToolStripMenuItem.Name = "detToolStripMenuItem";
            this.detToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.detToolStripMenuItem.Text = "Det";
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutUsToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "Info";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutUsToolStripMenuItem.Text = "About us";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.operationToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Выберите операцию:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(74, 51);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(101, 17);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Суммирование";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(74, 73);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(99, 17);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Произведение";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(255, 145);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(29, 20);
            this.numericUpDown2.TabIndex = 14;
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(280, 196);
            this.numericUpDown3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(29, 20);
            this.numericUpDown3.TabIndex = 15;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(32, 95);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(185, 17);
            this.radioButton3.TabIndex = 16;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Вычисление обратной матрицы";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(44, 117);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(161, 17);
            this.radioButton4.TabIndex = 17;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Вычисление определителя";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(374, 62);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(153, 130);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(363, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(178, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Результат выполнения операции:";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(374, 231);
            this.richTextBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(153, 73);
            this.richTextBox2.TabIndex = 21;
            this.richTextBox2.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(388, 210);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Сообщения об ошибках:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(255, 168);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(29, 20);
            this.numericUpDown1.TabIndex = 24;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 170);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Введите количество строк второй матрицы:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(280, 220);
            this.numericUpDown4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(29, 20);
            this.numericUpDown4.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 220);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Введите количество столбцов второй матрицы:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Единичная матрица",
            "Матрица с нулевыми значениями",
            "Пользовательская"});
            this.comboBox2.Location = new System.Drawing.Point(26, 283);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(191, 21);
            this.comboBox2.TabIndex = 27;
            this.comboBox2.Text = "Выберите тип второй матрицы...";
            // 
            // MatLab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 384);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MatLab";
            this.Text = "MatLab";
            this.Load += new System.EventHandler(this.MatLab_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox2;
    }
}
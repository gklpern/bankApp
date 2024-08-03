namespace AlbumStore
{
    partial class UrunTanimlamaForm
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
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button3 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            textBox3 = new TextBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(84, 34);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(330, 23);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(5, 37);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 1;
            label1.Text = "Urun Tanim";
            // 
            // button1
            // 
            button1.Location = new Point(35, 278);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Ekle";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(477, 278);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 4;
            button3.Text = "Çıkış";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(84, 74);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(330, 23);
            textBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(35, 77);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 9;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(35, 118);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 10;
            label3.Text = "KKDF";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(134, 118);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 11;
            label4.Text = "BSMV";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "E", "H" });
            comboBox2.Location = new Point(187, 115);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(28, 23);
            comboBox2.TabIndex = 13;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "E", "H " });
            comboBox3.Location = new Point(84, 115);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(31, 23);
            comboBox3.TabIndex = 14;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(338, 115);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(76, 23);
            textBox3.TabIndex = 15;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(233, 118);
            label5.Name = "label5";
            label5.Size = new Size(99, 15);
            label5.TabIndex = 16;
            label5.Text = "Maksimum Taksit";
            // 
            // UrunTanimlamaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(588, 313);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(button3);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "UrunTanimlamaForm";
            Text = "Urun Tanimlama";
            Load += UrunTanimlamaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button3;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private TextBox textBox3;
        private Label label5;
    }
}
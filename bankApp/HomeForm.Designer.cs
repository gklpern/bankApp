namespace AlbumStore
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
        public void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            button7 = new Button();
            txtSurName = new TextBox();
            txtName = new TextBox();
            txtCustomerID = new TextBox();
            txtKrediTutari = new TextBox();
            label3 = new Label();
            txtKredi = new TextBox();
            label4 = new Label();
            txtTaksit = new TextBox();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            label6 = new Label();
            comboBox1 = new ComboBox();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 23);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 0;
            label1.Text = "Müşteri No";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(371, 21);
            label2.Name = "label2";
            label2.Size = new Size(83, 20);
            label2.TabIndex = 1;
            label2.Text = "AD/SOYAD";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button7);
            panel1.Controls.Add(txtSurName);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(txtCustomerID);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(854, 71);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // button7
            // 
            button7.Location = new Point(712, 19);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(114, 31);
            button7.TabIndex = 5;
            button7.Text = "ARA";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // txtSurName
            // 
            txtSurName.Location = new Point(581, 19);
            txtSurName.Margin = new Padding(3, 4, 3, 4);
            txtSurName.Name = "txtSurName";
            txtSurName.ReadOnly = true;
            txtSurName.Size = new Size(114, 27);
            txtSurName.TabIndex = 4;
            txtSurName.TextChanged += txtSurName_TextChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(459, 19);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(114, 27);
            txtName.TabIndex = 3;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtCustomerID
            // 
            txtCustomerID.Location = new Point(150, 17);
            txtCustomerID.Margin = new Padding(3, 4, 3, 4);
            txtCustomerID.Name = "txtCustomerID";
            txtCustomerID.Size = new Size(183, 27);
            txtCustomerID.TabIndex = 2;
            txtCustomerID.TextChanged += txtMusteriNo_TextChanged;
            // 
            // txtKrediTutari
            // 
            txtKrediTutari.Location = new Point(103, 99);
            txtKrediTutari.Margin = new Padding(3, 4, 3, 4);
            txtKrediTutari.Name = "txtKrediTutari";
            txtKrediTutari.Size = new Size(158, 27);
            txtKrediTutari.TabIndex = 6;
            txtKrediTutari.TextChanged += txtKrediTutari_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 103);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 5;
            label3.Text = " Kredi Tutari";
            // 
            // txtKredi
            // 
            txtKredi.Location = new Point(373, 99);
            txtKredi.Margin = new Padding(3, 4, 3, 4);
            txtKredi.Name = "txtKredi";
            txtKredi.Size = new Size(158, 27);
            txtKredi.TabIndex = 8;
            txtKredi.TextChanged += txtKredi_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(288, 103);
            label4.Name = "label4";
            label4.Size = new Size(91, 20);
            label4.TabIndex = 7;
            label4.Text = "Kredi Vadesi";
            // 
            // txtTaksit
            // 
            txtTaksit.Location = new Point(646, 99);
            txtTaksit.Margin = new Padding(3, 4, 3, 4);
            txtTaksit.Name = "txtTaksit";
            txtTaksit.ReadOnly = true;
            txtTaksit.Size = new Size(158, 27);
            txtTaksit.TabIndex = 10;
            txtTaksit.TextChanged += txtTaksit_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(560, 103);
            label5.Name = "label5";
            label5.Size = new Size(87, 20);
            label5.TabIndex = 9;
            label5.Text = "Taksit Tutarı";
            // 
            // button1
            // 
            button1.Location = new Point(114, 23);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(102, 31);
            button1.TabIndex = 11;
            button1.Text = "Başvuru Onay";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(222, 23);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(103, 31);
            button2.TabIndex = 12;
            button2.Text = "İkinci Onay";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 36);
            label6.Name = "label6";
            label6.Size = new Size(129, 20);
            label6.TabIndex = 16;
            label6.Text = "Başvurulacak Ürün";
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteCustomSource.AddRange(new string[] { "Urun Seciniz", "Urun1", "Urun2", "Urun3", "Urun4", "Urun5" });
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(151, 33);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(298, 28);
            comboBox1.TabIndex = 17;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // button3
            // 
            button3.Location = new Point(331, 23);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(103, 31);
            button3.TabIndex = 18;
            button3.Text = "İptal";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(441, 23);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(103, 31);
            button4.TabIndex = 19;
            button4.Text = "Detay";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button5
            // 
            button5.Location = new Point(551, 23);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(103, 31);
            button5.TabIndex = 20;
            button5.Text = "Temizle";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(661, 23);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(96, 31);
            button6.TabIndex = 21;
            button6.Text = "Çıkış";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtKrediTutari);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(txtKredi);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtTaksit);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 71);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(854, 173);
            panel2.TabIndex = 22;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.RowTemplate.ReadOnly = true;
            dataGridView1.RowTemplate.Resizable = DataGridViewTriState.True;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(854, 284);
            dataGridView1.TabIndex = 23;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 244);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(854, 284);
            panel3.TabIndex = 23;
            // 
            // panel4
            // 
            panel4.Controls.Add(button1);
            panel4.Controls.Add(button2);
            panel4.Controls.Add(button6);
            panel4.Controls.Add(button3);
            panel4.Controls.Add(button5);
            panel4.Controls.Add(button4);
            panel4.Location = new Point(0, 537);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(854, 72);
            panel4.TabIndex = 24;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(854, 623);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "HomeForm";
            Text = "Kredi Uygulamasi";
            Load += HomeForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        public Label label1;
        public Label label2;
        public Panel panel1;
        public TextBox txtSurName;
        public TextBox txtName;
        public TextBox txtCustomerID;
        public Button button7;
        public TextBox txtKrediTutari;
        public Label label3;
        public TextBox txtKredi;
        public Label label4;
        public TextBox txtTaksit;
        public Label label5;
        public Button button1;
        public Button button2;
        public Label label6;
        public ComboBox comboBox1;
        public Button button3;
        public Button button4;
        public Button button5;
        public Button button6;
        public Panel panel2;
        public DataGridView dataGridView1;
        public DataGridViewTextBoxColumn BasvuruDurumuColumn;
        public Panel panel3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public Panel panel4;
    }
}
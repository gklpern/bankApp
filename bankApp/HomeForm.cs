using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace AlbumStore
{
    public partial class HomeForm : Form
    {

        private BindingList<info> Data
        {
            get;
            set;
        }

        public int counter = 0;
        public List<int> randomNumbers = new List<int>();

        public HomeForm()
        {
            InitializeComponent();
            txtKrediTutari.TextChanged += Txt1_TextChanged;
            txtKredi.TextChanged += Txt2_TextChanged;
        }


        public void HomeForm_Load(object sender, EventArgs e)
        {
            disablePanels();

            button1.Enabled = false;
            dataGridView1.ScrollBars = ScrollBars.Both;
            button4.Enabled = true;

            RefreshDataGridView();
        }






        private void Txt1_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();
        }

        private void Txt2_TextChanged(object sender, EventArgs e)
        {
            UpdateResult();



        }

       

        public void UpdateResult()
        {
            if (comboBox1.SelectedIndex != -1)
            {
                string selectedUrunName = comboBox1.SelectedItem.ToString();

                string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
                string sqlGetKKDF = "SELECT KKDFYUZDE FROM URUNLER WHERE ISIM = @urunName";
                string sqlGetBSMV = "SELECT BSMVYUZDE FROM URUNLER WHERE ISIM = @urunName";
                string sqlGetTaksit = "SELECT TAKSIT FROM URUNLER WHERE ISIM= @urunName";
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cnn.Open();
                        SqlCommand cmd = new SqlCommand(sqlGetKKDF, cnn);
                        cmd.Parameters.AddWithValue("@urunName", selectedUrunName);
                        SqlCommand cmd3 = new SqlCommand(sqlGetBSMV, cnn);
                        cmd3.Parameters.AddWithValue("@urunName", selectedUrunName);
                        SqlCommand cmd2=new SqlCommand(sqlGetTaksit, cnn);
                        cmd2.Parameters.AddWithValue("@urunName", selectedUrunName);
                        int taksit = (Int32)(cmd2.ExecuteScalar());
                        //object taksitSinir = cmd2.ExecuteScalar();
                        //float taksit = (float)taksitSinir;
                        object kkdfYuzde = cmd.ExecuteScalar();
                        object bsmvYuzde = cmd3.ExecuteScalar();


                        
                        if (!string.IsNullOrEmpty(txtKredi.Text) && float.TryParse(txtKredi.Text, out float txt2Value) && txt2Value != 0 && (txt2Value <= taksit))
                        {
                            if (float.TryParse(txtKrediTutari.Text, out float txt1Value))
                            {
                                if (kkdfYuzde != null && float.TryParse(kkdfYuzde.ToString(), out float yuzdeValue))
                                {
                                    if (bsmvYuzde != null && float.TryParse(bsmvYuzde.ToString(), out float yuzdeValue2))
                                    {  
                                        float result1 = (( txt1Value * (yuzdeValue / 100) ) + txt1Value);
                                        float result2 = (result1 + (result1 * (yuzdeValue2 / 100)))/txt2Value;
                                        txtTaksit.Text = result2.ToString();
                                    }
                                }
                            }
                            else
                            {
                                txtTaksit.Text = "Yanlis input";
                            }
                        }
                        else
                        {
                            txtTaksit.Text = "Uygun Kredi Vadesi Girin.";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
            else
            {
                txtTaksit.Text = "Bi Urun secin.";
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void txtMusteriNo_TextChanged(object sender, EventArgs e)
        {

        }
        public void button7_Click(object sender, EventArgs e)
        {

            string connectionString = null;
            connectionString = "server= DESKTOP-SOSBLFL\\MSSQLSERVER01 ; Database=PracticeDb;Trusted_Connection=Yes";
            string sqlGetAd = "SELECT AD FROM MUSTERILER WHERE MUSTERINO = @mNo ";
            string sqlGetSoyAd = "SELECT SOYAD FROM MUSTERILER WHERE MUSTERINO = @mNo";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetAd, cnn);
                    cmd.Parameters.AddWithValue("@mNo", txtCustomerID.Text);
                    object adResult = cmd.ExecuteScalar();
                    if (adResult != null)
                    {
                        string connectionStringDg = "server= DESKTOP-SOSBLFL\\MSSQLSERVER01 ; Database=PracticeDb;Trusted_Connection=Yes";
                        try
                        {
                            using (SqlConnection conn = new SqlConnection(connectionStringDg))
                            {
                                string sqlGetData = "SELECT * FROM BASVURULAR";
                                SqlCommand cmdDg = new SqlCommand(sqlGetData, conn);
                                SqlDataAdapter dAdapter = new SqlDataAdapter(cmdDg);
                                DataSet ds = new DataSet();

                                dAdapter.Fill(ds);
                                dataGridView1.ReadOnly = true;
                                dataGridView1.DataSource = ds.Tables[0];
                                conn.Close();


                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        txtName.Text = adResult.ToString();
                        logInEnablePanels();
                        button5.Enabled = true;
                        button4.Enabled = true;
                        txtKredi.Enabled = false;
                        txtKrediTutari.Enabled = false;
                        txtTaksit.Enabled= false;
                        SqlCommand cmdSoyad = new SqlCommand(sqlGetSoyAd, cnn);
                        cmdSoyad.Parameters.AddWithValue("@mNo", txtCustomerID.Text);
                        object soyadResult = cmdSoyad.ExecuteScalar();
                        fillComboBox();
                        if (soyadResult != null)
                        {
                            txtSurName.Text = soyadResult.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu Id ile data yok.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex.Message);
                }
            }
        }
        public void logInEnablePanels()
        {



            enablePanels();
            button1.Enabled = true;

            button4.Enabled = false;
            button5.Enabled = false;


        }
        public void disablePanels()
        {
            panel2.Enabled = false;
            button1.Enabled = false;


            button4.Enabled = false;
            button5.Enabled = false;
        }

        public void enablePanels()
        {
            panel2.Enabled = true;
            button1.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
        }

        public void disableTexts()
        {
            txtCustomerID.Text = null;
            txtName.Text = null;
            txtSurName.Text = null;
            comboBox1.SelectedIndex = 0;
            txtKredi.Text = null;
            txtKrediTutari.Text = null;
            txtTaksit.Text = null;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKredi.Enabled = true;
            txtKrediTutari.Enabled = true;
            txtTaksit.Enabled = true;
            UpdateResult();
        }

        private void txtTaksit_TextChanged(object sender, EventArgs e)
        {

        }

        private void fillComboBox()
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            //int sehir = Int32.Parse(comboBox1.SelectedItem.ToString());


            string getUrunler = "SELECT ISIM FROM URUNLER";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand cmd = new SqlCommand(getUrunler, cnn);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        comboBox1.Text = "";
                        comboBox1.Items.Clear();
                        while (reader.Read())
                        {
                            string ilce = reader["ISIM"].ToString();
                            comboBox1.Items.Add(ilce);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);


                }


            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!float.TryParse(txtKrediTutari.Text, out float krediTutariValue) ||
                !float.TryParse(txtKredi.Text, out float krediValue))
            {
                MessageBox.Show("Lütfen geçerli bir kredi tutarı ve kredi vadesi giriniz.");
                return;
            }

            if (comboBox1.SelectedIndex == 0 || string.IsNullOrEmpty(txtKrediTutari.Text) || string.IsNullOrEmpty(txtKredi.Text))
            {
                MessageBox.Show("Lütfen değerleri seçiniz.");
                return;
            }

            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";

            string sqlInsertBasvuru = "INSERT INTO BASVURULAR (MUSTERINO, AD, SOYAD, BASVURUTARIHI, URUNADI, URUNTUTARI, TAKSITTUTARI, VADE, REFERANSNO, BASVURUDURUMU,IPTALZAMANI) " +
                                      "VALUES (@musteriNo, @ad, @soyad, @basvurutarihi, @urunAdi, @uruntutari, @taksittutari, @vade, @referansno, @basvurudurumu, @iz)";



            DateTime dateTime = DateTime.Now;
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();


                    SqlCommand cmdInsert = new SqlCommand(sqlInsertBasvuru, cnn);
                    cmdInsert.Parameters.AddWithValue("@ad", txtName.Text);
                    cmdInsert.Parameters.AddWithValue("@soyad", txtSurName.Text);
                    cmdInsert.Parameters.AddWithValue("@basvurutarihi", dateTime);
                    cmdInsert.Parameters.AddWithValue("@musteriNo", txtCustomerID.Text);
                    cmdInsert.Parameters.AddWithValue("@urunadi", comboBox1.Text);
                    cmdInsert.Parameters.AddWithValue("@uruntutari", txtKrediTutari.Text);
                    cmdInsert.Parameters.AddWithValue("@taksittutari", txtTaksit.Text);
                    cmdInsert.Parameters.AddWithValue("@vade", txtKredi.Text);
                    cmdInsert.Parameters.AddWithValue("@referansno", RandomRNo());
                    cmdInsert.Parameters.AddWithValue("@basvurudurumu", "BO");
                    cmdInsert.Parameters.AddWithValue("@iz", " ");



                    int rowsInserted = cmdInsert.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        RefreshDataGridView();


                    }
                    else
                    {
                        MessageBox.Show("Başvuru eklenemedi.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }



        private int RandomRNo()
        {
            Random r = new Random();
            int referansNo;


            do
            {
                referansNo = r.Next(10000, 99999);
            }
            while (randomNumbers.Contains(referansNo));

            randomNumbers.Add(referansNo);
            return referansNo;
        }
        private void txtSurName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Temizlemek istediginize emin misiniz?", "Uyari", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                MessageBox.Show("Veriler Temizlendi");



                disableTexts();
                disablePanels();
                panel1.Enabled = true;
                comboBox1.SelectedIndex = -1;

            }


        }





        private void button3_Click(object sender, EventArgs e)
        {
            UpdateBasvuruDurumu("I", "Iptal");


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UpdateBasvuruDurumu("O", "Ikinci Onay");
            button3.Enabled = true;
        }


        private void RefreshDataGridView()
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlGetData = "SELECT MUSTERINO, AD, SOYAD, BASVURUTARIHI, URUNADI, URUNTUTARI, TAKSITTUTARI, VADE, REFERANSNO, BASVURUDURUMU , IPTALZAMANI " +
                                "FROM BASVURULAR";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetData, cnn);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;

                    }
                    else
                    {

                        dataGridView1.DataSource = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        public void disable_buttons()
        {


        }


        private void UpdateBasvuruDurumu(string status, string message)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string customerID = selectedRow.Cells["MUSTERINO"].Value.ToString();
                string checkBD = selectedRow.Cells["BASVURUDURUMU"].Value.ToString();
                string refNo = selectedRow.Cells["REFERANSNO"].Value.ToString();

                string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
                string sqlUpdateBasvurular = "UPDATE BASVURULAR SET IPTALZAMANI=@iz, BASVURUDURUMU = @basvurudurumu WHERE MUSTERINO = @musteriNo AND REFERANSNO=@refNo";


                if (checkBD == "BO" || checkBD == "O")
                {
                    using (SqlConnection cnn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            cnn.Open();

                            SqlCommand cmdUpdateBasvurular = new SqlCommand(sqlUpdateBasvurular, cnn);
                            cmdUpdateBasvurular.Parameters.AddWithValue("@basvurudurumu", status);
                            cmdUpdateBasvurular.Parameters.AddWithValue("@musteriNo", customerID);
                            cmdUpdateBasvurular.Parameters.AddWithValue("@refNo", refNo);



                            if (checkBD == "O" && status == "I")
                            {
                                cmdUpdateBasvurular.Parameters.AddWithValue("@iz", "Ikinci Onaydan Sonra");
                            }
                            else if (checkBD == "BO" && status == "I")
                            {
                                cmdUpdateBasvurular.Parameters.AddWithValue("@iz", "Birinci Onaydan Sonra");
                            }
                            else
                            {
                                cmdUpdateBasvurular.Parameters.AddWithValue("@iz", " ");
                            }

                            int rowsUpdatedBasvurular = cmdUpdateBasvurular.ExecuteNonQuery();

                            if (rowsUpdatedBasvurular > 0)
                            {
                                MessageBox.Show(message + " Yapildi.");
                                RefreshDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("Güncelleme başarısız.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Başvuru önceden iptal edilmiş.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Satır Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string customerID = selectedRow.Cells["MUSTERINO"].Value.ToString();
                string checkBD = selectedRow.Cells["BASVURUDURUMU"].Value.ToString();


                DetailForm detailForm = new DetailForm();
                detailForm.DisplayInfo(customerID);

                if (checkBD != "")
                {
                    detailForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Satır Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtKrediTutari_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKredi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

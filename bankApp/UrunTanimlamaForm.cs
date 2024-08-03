using System.Data.SqlClient;

namespace AlbumStore
{
    public partial class UrunTanimlamaForm : Form
    {
        public UrunTanimlamaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //if (comboBox2.SelectedIndex == 0 || comboBox3.SelectedIndex == 0 || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox1.Text))
            //{
            //    MessageBox.Show("Lütfen değerleri seçiniz.");
            //    return;
            //}

            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";

            string sqlInsertUrun = "INSERT INTO URUNLER (ID,ISIM,KKDF,BSMV,KKDFYUZDE,BSMVYUZDE,TAKSIT)" + "VALUES (@id,@isim,@kkdf,@bsmv,@kkdfyuzde,@bsmvyuzde,@taksit)";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    SqlCommand cmdInsertMusteri = new SqlCommand(sqlInsertUrun, cnn);
                    cmdInsertMusteri.Parameters.AddWithValue("@isim", textBox1.Text);
                    cmdInsertMusteri.Parameters.AddWithValue("@id", textBox2.Text);
                    cmdInsertMusteri.Parameters.AddWithValue("@kkdf", comboBox2.Text);
                    cmdInsertMusteri.Parameters.AddWithValue("@bsmv", comboBox3.Text);
                    cmdInsertMusteri.Parameters.AddWithValue("@kkdfyuzde", ReturnKKDF());
                    cmdInsertMusteri.Parameters.AddWithValue("@bsmvyuzde", ReturnBSMV());
                    cmdInsertMusteri.Parameters.AddWithValue("@taksit", textBox3.Text);

                    if (!string.IsNullOrWhiteSpace(textBox1.Text))
                    {
                        int rowsInserted = cmdInsertMusteri.ExecuteNonQuery();
                        if (rowsInserted > 0)
                        {
                            MessageBox.Show("Urun Eklendi.");
                        }


                    }

                    else
                    {
                        MessageBox.Show("Lutfen bir deger girin.");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        public int ReturnKKDF()
        {
            int KKDFYUZDE = 0;


            if (comboBox2.Text == "E")
            {
                KKDFYUZDE = 15;
            }
            else if (comboBox2.Text == "H")
            {

                KKDFYUZDE = 0;
            }

            return KKDFYUZDE;



        }

        public int ReturnBSMV()
        {

            int BSMVYUZDE = 0;


            if (comboBox3.Text == "E")
            {
                BSMVYUZDE = 5;
            }

            else if (comboBox3.Text == "H")
            {
                BSMVYUZDE = 0;
            }

            return BSMVYUZDE;


        }


        private void UrunTanimlamaForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

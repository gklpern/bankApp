using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace AlbumStore
{
    public partial class TanimlamaForm : Form
    {

        public List<int> randomNumbers = new List<int>();
        public TanimlamaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";

            string sqlInsertMusteri = "INSERT INTO MUSTERILER (MUSTERINO, AD, SOYAD, ACIKADRES, TCKN, TELEFONNO, DOGUMTARIHI, SEHIR, ILCE) " +
                                      "VALUES (@musteriNo, @ad, @soyad, @acikadres, @tckn, @telefonno, @dogumtarihi, @sehir, @ilce)";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    SqlCommand cmdInsertMusteri = new SqlCommand(sqlInsertMusteri, cnn);
                    cmdInsertMusteri.Parameters.AddWithValue("@musteriNo", RandomMNo());
                    cmdInsertMusteri.Parameters.AddWithValue("@ad", txtAdt.Text);
                    cmdInsertMusteri.Parameters.AddWithValue("@soyad", txtSoyadt.Text);
                    cmdInsertMusteri.Parameters.AddWithValue("@acikadres", txtAdrest.Text);
                    cmdInsertMusteri.Parameters.AddWithValue("@tckn", txtTCt.Text);
                    cmdInsertMusteri.Parameters.AddWithValue("@telefonno", txtTelefonNot.Text);
                    cmdInsertMusteri.Parameters.AddWithValue("@dogumtarihi", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    cmdInsertMusteri.Parameters.AddWithValue("@sehir", comboBox1.SelectedItem);
                    cmdInsertMusteri.Parameters.AddWithValue("@ilce", comboBox2.SelectedItem);

                    int rowsInserted = cmdInsertMusteri.ExecuteNonQuery();
                    if (rowsInserted > 0)
                    {
                        MessageBox.Show("Müşteri Eklendi.");
                        txtAdrest.Clear();
                        txtAdt.Clear();
                        txtSoyadt.Clear();
                        txtTCt.Clear();
                        txtTelefonNot.Clear();
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Müşteri eklenemedi.");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private int RandomMNo()
        {
            Random r2 = new Random();
            int musteriNo;


            do
            {
                musteriNo = r2.Next(10000, 99999);
            }
            while (randomNumbers.Contains(musteriNo));

            randomNumbers.Add(musteriNo);
            return musteriNo;
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem != null)
            {
                string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
                //int sehir = Int32.Parse(comboBox1.SelectedItem.ToString());


                string getIlce = "SELECT ILCE FROM ILCELER WHERE SEHIRAD = @sehir";

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    try
                    {
                        cnn.Open();
                        SqlCommand cmd = new SqlCommand(getIlce, cnn);
                        cmd.Parameters.AddWithValue("@sehir", comboBox1.SelectedItem);


                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            comboBox2.Text = "";
                            comboBox2.Items.Clear();
                            while (reader.Read())
                            {
                                string ilce = reader["ILCE"].ToString();
                                comboBox2.Items.Add(ilce);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message);


                    }


                }

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtAdrest.Clear();
            txtAdt.Clear();
            txtSoyadt.Clear();
            txtTCt.Clear();
            txtTelefonNot.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
    }

}
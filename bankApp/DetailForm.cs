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
using System.Xml.Linq;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace AlbumStore
{
    internal partial class DetailForm : Form
    {

        public DetailForm()
        {
            InitializeComponent();

        }
        private HomeForm mainForm = null;



        public void DisplayInfo(string customerID)
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlGetData = "SELECT * FROM BASVURULAR WHERE MUSTERINO = @musteriNo";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetData, cnn);
                    cmd.Parameters.AddWithValue("@musteriNo", customerID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {

                        textBox1.Text = reader["AD"].ToString() + " " + reader["SOYAD"].ToString();
                        textBox4.Text = reader["MUSTERINO"].ToString();
                        textBox3.Text = reader["BASVURUTARIHI"].ToString();
                        textBox5.Text = reader["URUNADI"].ToString();
                        textBox6.Text = reader["URUNTUTARI"].ToString();
                        textBox8.Text = reader["TAKSITTUTARI"].ToString();
                        textBox7.Text = reader["VADE"].ToString();
                        textBox2.Text = reader["REFERANSNO"].ToString();
                        textBox9.Text = reader["BASVURUDURUMU"].ToString();


                    }
                    else
                    {
                        MessageBox.Show("Seçilen Müşterinin Başvurusu Bulunmamaktadır.");


                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        public void button6_Click(object sender, EventArgs e)
        {


            this.Close();


        }

        public void enable_buttons()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void DetailForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

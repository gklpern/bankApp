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

namespace AlbumStore
{
    public partial class ÖdemeTablosuForm : Form
    {
        public ÖdemeTablosuForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
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


                        textBox1.Text = reader["MUSTERINO"].ToString();
                        textBox2.Text = reader["REFERANSNO"].ToString();

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ÖdemeTablosuForm_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}

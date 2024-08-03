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
    public partial class UrunGuncellemeForm : Form
    {
        public UrunGuncellemeForm()
        {
            InitializeComponent();
        }

        public void DisplayInfo(string urunID)
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlGetData = "SELECT * FROM URUNLER WHERE ID = @id";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetData, cnn);
                    cmd.Parameters.AddWithValue("@id", urunID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox1.Text = reader["ISIM"].ToString();
                        textBox2.Text = reader["ID"].ToString();
                        textBox3.Text = reader["TAKSIT"].ToString();
                        comboBox1.Text = reader["KKDF"].ToString();
                        comboBox2.Text = reader["BSMV"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("hata");


                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string urunID = selectedRow.Cells["ID"].Value.ToString();
                DisplayInfo(urunID);



            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Satır Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UrunGuncellemeForm_Load(object sender, EventArgs e)
        {
            RefreshDataGridView2();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public int ReturnKKDF()
        {
            int KKDFYUZDE = 0;


            if (comboBox1.Text == "E")
            {
                KKDFYUZDE = 15;
            }
            else if (comboBox1.Text == "H" || comboBox2.Text == "H")
            {

                KKDFYUZDE = 0;
            }

            return KKDFYUZDE;



        }

        public int ReturnBSMV()
        {

            int BSMVYUZDE = 0;


            if (comboBox2.Text == "E")
            {
                BSMVYUZDE = 5;
            }

            else if (comboBox2.Text == "H")
            {
                BSMVYUZDE = 0;
            }

            return BSMVYUZDE;


        }
        private void RefreshDataGridView2()
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlGetData = "SELECT * FROM URUNLER";


            var con = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(sqlGetData, con);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string urunID = selectedRow.Cells["ID"].Value.ToString();

            //string acikAdres = textBox4.Text;
            //string telNo = textBox6.Text;


            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlUpdateUrunler = "UPDATE URUNLER SET ISIM=@isim,KKDF=@kkdf,BSMV=@bsmv, KKDFYUZDE=@kkdfyuzde,BSMVYUZDE=@bsmvyuzde, TAKSIT=@taksit WHERE ID = @id";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();


                    SqlCommand cmdUpdateUrunler = new SqlCommand(sqlUpdateUrunler, cnn);
                    cmdUpdateUrunler.Parameters.AddWithValue("@id", urunID);
                    cmdUpdateUrunler.Parameters.AddWithValue("@ISIM", textBox1.Text);
                    cmdUpdateUrunler.Parameters.AddWithValue("@taksit", textBox3.Text);
                    cmdUpdateUrunler.Parameters.AddWithValue("@kkdf", comboBox1.SelectedItem);
                    cmdUpdateUrunler.Parameters.AddWithValue("@bsmv", comboBox2.SelectedItem);
                    cmdUpdateUrunler.Parameters.AddWithValue("@bsmvyuzde", ReturnBSMV());
                    cmdUpdateUrunler.Parameters.AddWithValue("@kkdfyuzde", ReturnKKDF());
                    int rowsUpdatedBasvurular = cmdUpdateUrunler.ExecuteNonQuery();



                    if (rowsUpdatedBasvurular > 0)
                    {
                        MessageBox.Show("Bilgiler Guncellendi");
                        //textBox1.Clear();
                        //textBox2.Clear();
                        //textBox3.Clear();
                        //textBox4.Clear();
                        //textBox5.Clear();
                        //textBox6.Clear();
                        //textBox7.Clear();
                        comboBox1.SelectedIndex = -1;
                        comboBox2.SelectedIndex = -1;
                        RefreshDataGridView2();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

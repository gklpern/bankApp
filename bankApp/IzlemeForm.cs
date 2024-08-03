using System.Data;
using System.Data.SqlClient;

namespace AlbumStore
{
    public partial class IzlemeForm : Form
    {
        public IzlemeForm()
        {
            
            InitializeComponent();

        }
        private void IzlemeForm_Load_1(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            button4.Enabled = false;
            RefreshDataGridView1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        public void DisplayInfo(string customerID)
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlGetData = "SELECT * FROM MUSTERILER WHERE MUSTERINO = @musteriNo";

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
                        textBox2.Text = reader["AD"].ToString();
                        textBox3.Text = reader["SOYAD"].ToString();
                        textBox4.Text = reader["ACIKADRES"].ToString();
                        textBox5.Text = reader["TCKN"].ToString();
                        textBox6.Text = reader["TELEFONNO"].ToString();
                        textBox7.Text = reader["DOGUMTARIHI"].ToString();
                        comboBox1.Text = reader["SEHIR"].ToString();
                        comboBox2.Text = reader["ILCE"].ToString();

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


        private void RefreshDataGridView1()
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlGetData = "SELECT * FROM MUSTERILER";


            var con = new SqlConnection(connectionString);
            var dataAdapter = new SqlDataAdapter(sqlGetData, con);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            string customerID = selectedRow.Cells["MUSTERINO"].Value.ToString();

            string acikAdres = textBox4.Text;
            string telNo = textBox6.Text;


            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlUpdateMusteriler = "UPDATE MUSTERILER SET TELEFONNO=@telNo, ACIKADRES=@aa,SEHIR=@sehir,ILCE=@ilce WHERE MUSTERINO = @musteriNo";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();


                    SqlCommand cmdUpdateMusteriler = new SqlCommand(sqlUpdateMusteriler, cnn);
                    cmdUpdateMusteriler.Parameters.AddWithValue("@musteriNo", customerID);
                    cmdUpdateMusteriler.Parameters.AddWithValue("@aa", acikAdres);
                    cmdUpdateMusteriler.Parameters.AddWithValue("@sehir", comboBox1.SelectedItem);
                    cmdUpdateMusteriler.Parameters.AddWithValue("@ilce", comboBox2.SelectedItem);
                    cmdUpdateMusteriler.Parameters.AddWithValue("@telNo", telNo);

                    int rowsUpdatedBasvurular = cmdUpdateMusteriler.ExecuteNonQuery();



                    if (rowsUpdatedBasvurular > 0)
                    {
                        MessageBox.Show("Bilgiler Guncellendi");
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        comboBox1.SelectedIndex = -1;
                        comboBox2.SelectedIndex = -1;
                        RefreshDataGridView1();
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            //    string customerID = selectedRow.Cells["MUSTERINO"].Value.ToString();

            //    DisplayInfo(customerID);
            //}
            //else
            //{
            //    MessageBox.Show("Lütfen bir satır seçin.", "Satır Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string customerID = selectedRow.Cells["MUSTERINO"].Value.ToString();

                DisplayInfo(customerID);
                button4.Enabled = true;

                
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Satır Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string connectionString1 = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
                //int sehir1 = comboBox1.SelectedItem;


                string getIlce = "SELECT ILCE FROM ILCELER WHERE SEHIRAD = @sehir";

                using (SqlConnection cnn = new SqlConnection(connectionString1))
                {
                    try
                    {
                        cnn.Open();
                        SqlCommand cmd = new SqlCommand(getIlce, cnn);
                        cmd.Parameters.AddWithValue("@sehir", comboBox1.SelectedItem);


                        using (SqlDataReader reader2 = cmd.ExecuteReader())
                        {
                            comboBox2.Text = "";
                            comboBox2.Items.Clear();
                            while (reader2.Read())
                            {
                                string ilce = reader2["ILCE"].ToString();
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
    }
}

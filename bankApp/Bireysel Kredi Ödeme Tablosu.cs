using System.Data;
using System.Data.SqlClient;

namespace AlbumStore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void RefreshDataGridView()
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlGetData = "SELECT MUSTERINO, AD, SOYAD, BASVURUTARIHI, URUNADI, URUNTUTARI, TAKSITTUTARI, VADE, REFERANSNO, BASVURUDURUMU, IPTALZAMANI " +
                                "FROM BASVURULAR WHERE MUSTERINO=@mNo";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetData, cnn);
                    cmd.Parameters.AddWithValue("@mNo", textBox2.Text);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                        button3.Enabled = true;
                        button2.Enabled = true;
                        button5.Enabled = true;
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
        private void button1_Click(object sender, EventArgs e)
        {

            RefreshDataGridView();







        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void DisplayInfo(string refNo, int vade)
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlGetData = "SELECT VADE, REFERANSNO, BASVURUTARIHI FROM BASVURULAR WHERE REFERANSNO = @refNo";

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetData, cnn);
                    cmd.Parameters.AddWithValue("@refNo", refNo);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        DateTime dateTime = DateTime.Parse(reader["BASVURUTARIHI"].ToString());
                        DateTime dateTime1 = DateTime.Parse(reader["BASVURUTARIHI"].ToString());
                        DateTime futureDateTime = dateTime.AddMonths(vade);
                        DateTime nextDateTime = dateTime1.AddMonths(1);
                        textBox1.Text = reader["REFERANSNO"].ToString();
                        textBox3.Text = nextDateTime.ToString("yyyy-MM-dd");
                        textBox4.Text = futureDateTime.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        MessageBox.Show("No data found for the given reference number.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string referansNO = selectedRow.Cells["REFERANSNO"].Value.ToString();
                int vade = Convert.ToInt32(selectedRow.Cells["VADE"].Value);
                DisplayInfo(referansNO, vade);



            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Satır Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }





        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            textBox2.Clear();
            textBox1.Clear();
            button3.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;

            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string refNo = selectedRow.Cells["REFERANSNO"].Value.ToString();
                string urunAd = selectedRow.Cells["URUNADI"].Value.ToString();

                
                KrediİzlemeForm krediİzlemeForm = new KrediİzlemeForm();

              
                krediİzlemeForm.TextBox7Value = textBox3.Text;
                krediİzlemeForm.TextBox8Value = textBox4.Text;

                
                krediİzlemeForm.DisplayInfo(refNo, urunAd);

                
                krediİzlemeForm.Show();
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.", "Satır Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //    if (dataGridView1.SelectedRows.Count > 0)
            //    {

            //        int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            //        DataGridViewRow selectedRow= dataGridView1.Rows[selectedRowIndex];
            //        string CellValue=Convert.ToString(selectedRow.Cells["REFERANSNO"].Value);
            //        //int vade = selectedRow.Cells["VADE"].Value;
            //        textBox1.Text=CellValue;


            //        string refNo = selectedRow.Cells["REFERANSNO"].Value.ToString();

            //        DisplayInfo(refNo, vade);



            //    }
            //    else
            //    {
            //        MessageBox.Show("Lütfen bir satır seçin.", "Satır Seçilmedi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

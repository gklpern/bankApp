using System.Data.SqlClient;
using System.Windows.Forms;

namespace AlbumStore
{
    public partial class KrediİzlemeForm : Form
    {
        public KrediİzlemeForm()
        {
            InitializeComponent();
            
        }

        public string TextBox7Value
        {
            get { return textBox7.Text; }
            set { textBox7.Text = value; }
        }

        public string TextBox8Value
        {
            get { return textBox8.Text; }
            set { textBox8.Text = value; }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public void DisplayInfo(string refNo,string urunAd)
        {
            string connectionString = "server=DESKTOP-SOSBLFL\\MSSQLSERVER01;Database=PracticeDb;Trusted_Connection=Yes";
            string sqlGetData = "SELECT * FROM BASVURULAR WHERE REFERANSNO = @refNo";
            string sqlGetFaiz = "SELECT KKDF,BSMV FROM URUNLER WHERE ISIM=@isim";

            using (SqlConnection cnn = new SqlConnection(connectionString) )
            {
                try
                {
                    

                    cnn.Open();

                    
                    SqlCommand cmd = new SqlCommand(sqlGetData, cnn);
                    cmd.Parameters.AddWithValue("@refNo", refNo);

                    SqlDataReader reader = cmd.ExecuteReader();
                    
                    if (reader.Read())
                    {

                        textBox6.Text = reader["AD"].ToString() + " " + reader["SOYAD"].ToString();
                        textBox1.Text = reader["MUSTERINO"].ToString();
                        textBox3.Text = reader["REFERANSNO"].ToString();
                        textBox4.Text = reader["URUNADI"].ToString();

                        textBox5.Text = reader["VADE"].ToString();
                        
                        


                    }
                    else
                    {
                        MessageBox.Show("Seçilen Müşterinin Başvurusu Bulunmamaktadır.");
                    }
                    reader.Close();


                    SqlCommand cmd2 = new SqlCommand(sqlGetFaiz, cnn);
                    cmd2.Parameters.AddWithValue("@isim", urunAd);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.Read())
                    {
                        string KKDFcheck = reader2["KKDF"].ToString();
                        string BSMVcheck = reader2["BSMV"].ToString();
                        //string check1 = KKDFcheck.ToString();
                        
                        
                        if (KKDFcheck == "E".ToString())
                        {
                            checkBox1.Checked = true;
                            if (BSMVcheck == "E".ToString())
                            {
                                checkBox2.Checked = true;
                            }
                        }

                        
                    }

                    
                    reader2.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void KrediİzlemeForm_Load(object sender, EventArgs e)
        {
            
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ÖdemeTablosuForm ödemeTablosuForm = new ÖdemeTablosuForm();
            ödemeTablosuForm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace AlbumStore
{
    public partial class SelectForm : Form
    {
        public SelectForm()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                HomeForm homeForm = new HomeForm();
                homeForm.Show();
            }
            if (radioButton1.Checked == true)
            {
                IzlemeForm izlemeForm = new IzlemeForm();
                izlemeForm.Show();
            }
            if (radioButton2.Checked == true)
            {
                TanimlamaForm tanimlamaForm = new TanimlamaForm();
                tanimlamaForm.Show();
            }
            if (radioButton4.Checked == true)
            {
                Form1 form1 = new Form1();
                form1.Show();
            }
            if (radioButton5.Checked == true)
            {
                UrunTanimlamaForm tanimlamaForm = new UrunTanimlamaForm();
                tanimlamaForm.Show();
            }
            if (radioButton6.Checked == true)
            {
                UrunGuncellemeForm urunGuncellemeForm = new UrunGuncellemeForm();
                urunGuncellemeForm.Show();
            }

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SelectForm_Load(object sender, EventArgs e)
        {
            Form1 forms = new Form1();
        }
    }
}

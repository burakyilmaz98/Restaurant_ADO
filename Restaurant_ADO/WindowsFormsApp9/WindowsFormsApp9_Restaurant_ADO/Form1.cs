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

namespace WindowsFormsApp9_Restaurant_ADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DNPJ28R;Initial Catalog=Marla;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

            panel3.Controls.Clear();

            button1.ImageIndex = 1;



        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtKullanici.Text == "1" && txtSifre.Text == "1")
            {
                this.BackColor = Color.Peru;
                //if (sender.GetType() == typeof(Button))
                //{
                //    button1.ImageIndex = 0;
                //}
                //else if (sender.GetType() == typeof(TextBox))
                //{
                //    txtKullanici.Text = "asd";
                //}


                panel2.Controls.Clear();
                Yönetici yntc = new Yönetici();
                yntc.TopLevel = false;
                yntc.Dock = DockStyle.Fill;
                panel2.Controls.Add(yntc);
                yntc.BringToFront();
                yntc.Show();
                label3.Text = "YÖNETİCİ";

                panel1.Controls.Clear();
                panel3.Controls.Add(button2);
                panel3.Controls.Add(label3);
                this.BackgroundImage = null;


            }
            else if (txtKullanici.Text == "2" && txtSifre.Text == "2")
            {
                panel2.Controls.Clear();
                Siparis clsn = new Siparis();
                clsn.TopLevel = false;
                clsn.Dock = DockStyle.Fill;
                panel2.Controls.Add(clsn);

                clsn.BringToFront();
                clsn.Show();
                label3.Text = "SİPARİS";
                panel1.Controls.Clear();
                panel3.Controls.Add(button2);
                panel3.Controls.Add(label3);
                this.BackColor = Color.SeaShell;
                this.BackgroundImage = null;
            }
            else
            {
                

               MessageBox.Show("Kullanıcı adı veya şifre hatalı girdiniz. Lütfen kontrol ediniz");
            }
            foreach (var item in panel1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
            }
                
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            Yönetici yntc = new Yönetici();
            yntc.TopLevel = false;
            yntc.Dock = DockStyle.Fill;
            panel2.Controls.Add(yntc);
            yntc.BringToFront();
            yntc.Show();
            label3.Text = "YÖNETİCİ";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel3.Controls.Clear();
            panel1.Controls.Add(txtKullanici);
            panel1.Controls.Add(txtSifre);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
         
            
            foreach (var item in panel1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
            }



        }


    }
}

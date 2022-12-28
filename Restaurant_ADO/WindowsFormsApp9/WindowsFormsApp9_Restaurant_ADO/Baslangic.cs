using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp9_Restaurant_ADO
{
    public partial class Baslangic : Form
    {
        public Baslangic()
        {
            InitializeComponent();
        }

        bool islem = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!islem)
            {
                this.Opacity += 0.005;
            }
            if (this.Opacity==1.0)
            {
                islem = true;
            }
            if (islem)
            {
                this.Opacity -= 0.005;
                if (this.Opacity==0)
                {
                    Form1 fm1 = new Form1();
                    fm1.Show();
                    timer1.Enabled = false;
                    this.Hide(); // kapattı
                }
            }
        }
    }
}

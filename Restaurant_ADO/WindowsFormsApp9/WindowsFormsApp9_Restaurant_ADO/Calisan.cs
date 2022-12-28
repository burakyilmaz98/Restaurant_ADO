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
    public partial class Calisan : Form
    {
        public Calisan()
        {
            InitializeComponent();
        }

        private void Calisan_Load(object sender, EventArgs e)
        {


            SqlDataAdapter dap2 = new SqlDataAdapter("select Fiyat , CONCAT(UrunAdi,'-',UrunID) as isim  from urun", conn);
            DataTable dt2 = new DataTable();
            dap2.Fill(dt2);
            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "isim";
            comboBox2.ValueMember = "Fiyat";

            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;

            label4.Text = "SiparisID";
            label3.Text = "Siparis Miktarı";
            label5.Text = "UrunID";
            label6.Text = "Ürün";

        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DNPJ28R;Initial Catalog=Marla;Integrated Security=True");
        private void btnSiparis_Click(object sender, EventArgs e)
        {
            Getir();
        }

        private void Getir()
        {
            SqlCommand cmd = new SqlCommand("select * from UrunSiparisDetay", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            //SqlCommand cmd = new SqlCommand("select a.AdisyonID,sum(usd.Fiyat*usd.SiparisMiktari) as [toplam fiyat] from Adisyon a join AdisyonSiparisDetay asd on a.AdisyonID = asd.AdisyonID join Siparis s on s.SiparisID = asd.SiparisID join UrunSiparisDetay usd on usd.SiparisID = s.SiparisID where s.SiparisID = @siparisID group by a.AdisyonID", conn);


            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            SqlDataAdapter dap = new SqlDataAdapter("select sum (s.Fiyat*s.SiparisMiktari) as ToplamFiyat from UrunSiparisDetay s  where SiparisID=@SiparisID group by SiparisID ", conn);
            int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
            dap.SelectCommand.Parameters.AddWithValue("@SiparisID", id);
            DataTable dt = new DataTable();
            dap.Fill(dt);



            listBox1.DataSource=dt;
            listBox1.DisplayMember = "ToplamFiyat";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("Insert UrunSiparisDetay (UrunID,SiparisID,SiparisMiktari,Fiyat) values(@UrunID,@SiparisID , @SiparisMiktari,@Fiyat)", conn);


            cmd.Parameters.AddWithValue("@Fiyat", comboBox2.SelectedValue);
            cmd.Parameters.AddWithValue("@SiparisID", textBox1.Text);
            cmd.Parameters.AddWithValue("@SiparisMiktari", textBox2.Text);
            cmd.Parameters.AddWithValue("@UrunID", textBox3.Text);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;

            Getir();

            Temizle();

        }

        private void Temizle()
        {
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM UrunSiparisDetay  WHERE UrunSiparisDetay=@UrunSiparisDetayID  ", conn);

            int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
            cmd.Parameters.AddWithValue("@UrunSiparisDetayID", id);



            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                MessageBox.Show(etkilenenSatirSayisi > 0 ? "Kayıt Silindi" : "Kayıt Silinemedi");

            }
            else
            {
                conn.Close();
            }
            Temizle();
        }
    }
}

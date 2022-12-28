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
    public partial class Siparis : Form
    {
        public Siparis()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DNPJ28R;Initial Catalog=Marla;Integrated Security=True");
        private void Siparis_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Red;
            //textBox1.SelectedText = "asdsa";
            //textBox1.HideSelection.ToString() = "asdsadsa";  

            textBox1.Text = "Adet Giriniz...";
            SqlDataAdapter dap = new SqlDataAdapter("select * from Siparis",conn);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember="SiparisID";
            comboBox1.ValueMember = "SiparisID";


        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=1", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;


        }

        private void button25_Click(object sender, EventArgs e)
        {
            Getirr();

        }

        private void Getirr()
        {
            SqlCommand cmd = new SqlCommand("select s.SiparisID,usd.SiparisMiktari,usd.UrunID,s.SiparisTarihi,usd.Fiyat from Siparis s JOIN UrunSiparisDetay usd on s.SiparisID=usd.SiparisID", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=2", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=3", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=4", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=5", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=6", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=7", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=8", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=9", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=10", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=11", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Urun	where KategoriID=12", conn);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Insert UrunSiparisDetay (UrunID,SiparisID,SiparisMiktari,Fiyat) values(@UrunID,@SiparisID , @SiparisMiktari,@Fiyat)", conn);

            Getirr();

            cmd.Parameters.AddWithValue("@Fiyat", dataGridView1.CurrentRow.Cells[4].Value);
            cmd.Parameters.AddWithValue("@SiparisID", comboBox1.SelectedValue);
            cmd.Parameters.AddWithValue("@SiparisMiktari", textBox1.Text);
            cmd.Parameters.AddWithValue("@UrunID", dataGridView1.CurrentRow.Cells[0].Value);

            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            dataGridView1.DataSource = dt;
            

        }

        private void button13_Click(object sender, EventArgs e)
        {
   

            if (textBox1.Text == "")
            { textBox1.Text = "1"; }
            else
            { textBox1.Text = textBox1.Text + "1"; }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "2"; }
            else
            { textBox1.Text = textBox1.Text + "2"; }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "3"; }
            else
            { textBox1.Text = textBox1.Text + "3"; }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "4"; }
            else
            { textBox1.Text = textBox1.Text + "4"; }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "5"; }
            else
            { textBox1.Text = textBox1.Text + "5"; }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "6"; }
            else
            { textBox1.Text = textBox1.Text + "6"; }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "7"; }
            else
            { textBox1.Text = textBox1.Text + "7"; }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "8"; }
            else
            { textBox1.Text = textBox1.Text + "8"; }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
            { textBox1.Text = "8"; }
            else
            { textBox1.Text = textBox1.Text + "8"; }
        }

        private void button24_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            { textBox1.Text = ""; }
            else
            { textBox1.Text = textBox1.Text + "0"; }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void button23_Click(object sender, EventArgs e)
        {
            // SİL
            SqlCommand cmd = new SqlCommand("DELETE FROM UrunSiparisDetay  WHERE UrunSiparisDetayID=@UrunSiparisDetayID  ", conn);

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

        }

  
    }
}

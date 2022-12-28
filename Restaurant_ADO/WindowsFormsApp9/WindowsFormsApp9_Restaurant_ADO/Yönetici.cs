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
    public partial class Yönetici : Form
    {
        public Yönetici()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-DNPJ28R;Initial Catalog=Marla;Integrated Security=True");
        private void Yönetici_Load(object sender, EventArgs e)
        {

            checkBox1.Enabled = false;
            comboBox2.Enabled = false;

            conn.Open();
            DataTable dt = conn.GetSchema("Tables");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i]["TABLE_NAME"]);
            }

            conn.Close();
            foreach (var item in this.Controls)
            {
                if (item is Label)
                {
                    if (item != label1)
                    {
                        Label lbl = (Label)item;
                        lbl.Text = "-";
                    }
                    else
                    {

                    }

                }
            }
            foreach (var item in this.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;


                    txt.Enabled = false;


                }
            }

        }




        SqlDataAdapter da;
        DataSet ds;
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

            string tablo = comboBox1.SelectedItem.ToString();
            //conn.Open();
            Getir(tablo);
            //conn.Close();

            if (tablo == "Calisan")
            {

                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;
                label2.Text = "İsim";
                label3.Text = "Soyisim";
                label4.Text = "Unvan";
                label5.Text = "RestaurantID";
                //label6.Text = "-";
                label6.Visible = false;

                label8.Visible = false;
                label9.Text = "Çalışan";
                //label7.Text = "-";
                //label8.Text = "-";


            }
            else if (tablo == "sysdiagrams")
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
            }
            else if (tablo == "CalisanDetay")
            {
                label9.Text = "Çalışan Detay";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = true;

                label2.Text = "Maas";
                label3.Text = "TcKNo";
                label4.Text = "TelNo";
                label5.Text = "Mail";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                label8.Visible = false;

                SqlDataAdapter dap2 = new SqlDataAdapter("select CalisanID , CONCAT (CalisanAdi , ' ' , CalisanSoyadi , '-' ,CalisanID ) as isim from Calisan", conn);
                DataTable dt2 = new DataTable();
                dap2.Fill(dt2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "isim";
                comboBox2.ValueMember = "CalisanID";
            }
            else if (tablo == "Restaurant")
            {
                label9.Text = "Restaurant";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                label2.Text = "Restaurant Adı";
                label3.Text = "Sehir";
                label4.Text = "Adres";
                label5.Text = "Tel";
                label6.Text = "MenuID";
                label6.Visible = true;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
            else if (tablo == "Urun")
            {
                label9.Text = "Ürün";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                label2.Text = "KategoriID";
                label3.Text = "Ürün Adı";
                label4.Text = "Açıklama";
                label5.Text = "Fiyat";
                label6.Visible = false;
                label8.Visible = true;
                label8.Text = "Durum";
                checkBox1.Enabled = true;
                comboBox2.Enabled = false;
            }
            else if (tablo == "Menu")
            {
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "Menu Adı";
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;
                label9.Text = "Menü";
            }
            else if (tablo == "MenuKategori")
            {
                label9.Text = "Menü Kategori";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "MenuKategori Adı";
                label3.Text = "Menu ID";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;

                checkBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
            else if (tablo == "Siparis")
            {
                label9.Text = "Siparis";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "Masa Numarası";
                label3.Text = "Musteri ID";
                label4.Text = "Teslim Süresi";
                label8.Text = "Siparis Türü";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = true;
                checkBox1.Enabled = true;
                comboBox2.Enabled = true;

                //if (checkBox1.Checked==true)
                //{
                //    textBox1.Enabled = false;
                //}
                //else 
                //{
                //    textBox1.Enabled = true;
                //}
                SqlDataAdapter dap2 = new SqlDataAdapter("select CalisanID , CONCAT (CalisanAdi , ' ' , CalisanSoyadi , '-' ,CalisanID ) as isim from Calisan", conn);
                DataTable dt2 = new DataTable();
                dap2.Fill(dt2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "isim";
                comboBox2.ValueMember = "CalisanID";
            }
            else if (tablo == "UrunSiparisDetay")
            {
                label9.Text = "Ürün Siparis Detay";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                label2.Text = "SiparisID";
                label3.Text = "Siparis Miktarı";
                label4.Text = "UrunID";

                checkBox1.Enabled = false;
                comboBox2.Enabled = true;

                SqlDataAdapter dap2 = new SqlDataAdapter("select Fiyat , CONCAT(UrunAdi,'-',UrunID) as isim  from urun", conn);
                DataTable dt2 = new DataTable();
                dap2.Fill(dt2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "isim";
                comboBox2.ValueMember = "Fiyat";
            }
            else if (tablo == "Depo")
            {
                label9.Text = "Depo";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "Depo Adı";
                label3.Text = "Adres";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;

                SqlDataAdapter dap2 = new SqlDataAdapter("select Fiyat , CONCAT(UrunAdi,'-',UrunID) as isim  from urun", conn);
                DataTable dt2 = new DataTable();
                dap2.Fill(dt2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "isim";
                comboBox2.ValueMember = "Fiyat";
            }
            else if (tablo == "Malzeme")
            {
                label9.Text = "Malzeme";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "Malzeme Adı";
                label3.Text = "Malzeme KategoriID";
                label8.Text = "Durum";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = true;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;
                checkBox1.Enabled = true;
                comboBox2.Enabled = true;


                SqlDataAdapter dap2 = new SqlDataAdapter("	 select t.TedarikciID, CONCAT(ma.MalzemeKategoriAdi, '-', ma.MalzemeKategoriID) as isim FROM Malzeme m JOIN MalzemeKategori ma on m.MalzemeKategoriID = ma.MalzemeKategoriID JOIN Tedarikci t on m.TedarikciID = t.TedarikciID group by ma.MalzemeKategoriAdi,ma.MalzemeKategoriID,t.TedarikciID", conn);
                // select t.TedarikciID, CONCAT(ma.MalzemeKategoriAdi, '-', ma.MalzemeKategoriID) as isim FROM Malzeme m JOIN MalzemeKategori ma on m.MalzemeKategoriID = ma.MalzemeKategoriID JOIN Tedarikci t on m.TedarikciID = t.TedarikciID
                DataTable dt2 = new DataTable();
                dap2.Fill(dt2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "isim";
                comboBox2.ValueMember = "t.TedarikciID";
            }
            else if (tablo == "MalzemeKategori")
            {
                label9.Text = "Malzeme Kategori";
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "Kategori Adı";
                label2.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;


            }
            else if (tablo == "UrunMalzemeDetay")
            {
                label9.Text = "Ürün Malzeme Detay";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "MalzemeID";
                label3.Text = "Malzeme Sayısı";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;

                checkBox1.Enabled = false;
                comboBox2.Enabled = true;


                SqlDataAdapter dap2 = new SqlDataAdapter("select UrunAdi,UrunID   from urun", conn);
                DataTable dt2 = new DataTable();
                dap2.Fill(dt2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "UrunAdi";
                comboBox2.ValueMember = "UrunID";

            }
            else if (tablo == "Tedarikci")
            {
                label9.Text = "Tedarikçi";
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "Tedarikci Adı";

                label2.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;


            }
            else if (tablo == "DepoMalzemeDetay")
            {
                label9.Text = "Depo Malzeme Detay";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "DepoID";
                label3.Text = "DepoStok";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = true;

                SqlDataAdapter dap2 = new SqlDataAdapter("select MalzemeID ,CONCAT(MalzemeAdi , '-' , MalzemeID) as isim   from Malzeme", conn);
                DataTable dt2 = new DataTable();
                dap2.Fill(dt2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "isim";
                comboBox2.ValueMember = "MalzemeID";


            }
            else if (tablo == "Musteri")
            {
                label9.Text = "Müşteri";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = false;
                label2.Text = "Adı : ";
                label3.Text = "Soyadı :";
                label4.Text = "Adres :";
                label5.Text = "Telefon";

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;


            }
            else if (tablo == "Adisyon")
            {
                label9.Text = "Adisyon";
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;


            }
            else if (tablo == "OdemeYontemi")
            {
                label9.Text = "Ödemi Yöntemi";
                textBox1.Enabled = true;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "Ödeme Yöntemi :";
                label2.Visible = true;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;


            }
            else if (tablo == "AdisyonOdemeDetay")
            {
                label9.Text = "Adisyon Ödeme Detay";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "Adisyon ID:";
                label3.Text = "Ödeme Adı:";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = true;

                SqlDataAdapter dap2 = new SqlDataAdapter("select OdemeYontemiID ,OdemeYontemiAdi  from OdemeYontemi", conn);
                DataTable dt2 = new DataTable();
                dap2.Fill(dt2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "OdemeYontemiAdi";
                comboBox2.ValueMember = "OdemeYontemiID";

            }
            else if (tablo == "AdisyonSiparisDetay")
            {
                label9.Text = "Adisyon Sipariş Detay";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "Siparis ID:";
                label3.Text = "Adisyon ID:";

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = false;


            }
            else if (tablo == "RestaurantMalzemeDetay")
            {
                label9.Text = "Restaurant Malzeme Detay";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                label2.Text = "Restaurant ID:";
                label3.Text = "Stok:";
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                checkBox1.Enabled = false;
                comboBox2.Enabled = true;

                SqlDataAdapter dap2 = new SqlDataAdapter("select MalzemeID ,MalzemeAdi  from malzeme", conn);
                DataTable dt2 = new DataTable();
                dap2.Fill(dt2);
                comboBox2.DataSource = dt2;
                comboBox2.DisplayMember = "MalzemeAdi";
                comboBox2.ValueMember = "MalzemeID";


            }


        }

        private void Getir(string tablo)
        {
            da = new SqlDataAdapter("select * from " + tablo, conn);
            ds = new DataSet();
            da.Fill(ds, tablo);
            dataGridView1.DataSource = ds.Tables[tablo];



        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string tablo = comboBox1.SelectedItem.ToString();
            if (tablo == "Calisan")
            {

                SqlCommand cmd = new SqlCommand("Insert Calisan (CalisanAdi, CalisanSoyadi,Unvan,RestaurantID) values(@isim, @Soyisim,@Unvan,@RestaurantID)", conn);
                cmd.Parameters.AddWithValue("@isim", textBox1.Text);

                cmd.Parameters.AddWithValue("@Soyisim", textBox2.Text);

                cmd.Parameters.AddWithValue("@Unvan", textBox3.Text);

                cmd.Parameters.AddWithValue("@RestaurantID", textBox4.Text);




                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                textBox5.Enabled = true;

                Getir(tablo);
                Temizle();
            }
            else if (tablo == "CalisanDetay")
            {
                SqlCommand cmd = new SqlCommand("Insert CalisanDetay (CalisanDetayID ,Maas, TcKn,TelNo,Mail) values(@ID,@Maas, @TcKn,@TelNo,@Mail)", conn);


                cmd.Parameters.AddWithValue("@ID", comboBox2.SelectedValue);

                cmd.Parameters.AddWithValue("@Maas", textBox1.Text);

                cmd.Parameters.AddWithValue("@TcKn", textBox2.Text);

                cmd.Parameters.AddWithValue("@TelNo", textBox3.Text);

                cmd.Parameters.AddWithValue("@Mail", textBox4.Text);


                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();
            }
            else if (tablo == "Restaurant")
            {
                SqlCommand cmd = new SqlCommand("Insert Restaurant (RestaurantAdi, Sehir,Adres,Tel,MenuID) values(@RestaurantAdi, @Sehir,@Adres,@Tel,@MenuID)", conn);
                cmd.Parameters.AddWithValue("@RestaurantAdi", textBox1.Text);

                cmd.Parameters.AddWithValue("@Sehir", textBox2.Text);

                cmd.Parameters.AddWithValue("@Adres", textBox3.Text);

                cmd.Parameters.AddWithValue("@Tel", textBox4.Text);

                cmd.Parameters.AddWithValue("@MenuID", textBox5.Text);



                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();
            }
            else if (tablo == "Urun")
            {
                SqlCommand cmd = new SqlCommand("Insert Urun (KategoriID, UrunAdi,UrunAciklamasi,Fiyat,Durum) values(@KategoriID, @UrunAdi,@UrunAciklamasi,@Fiyat,@Durum)", conn);

                cmd.Parameters.AddWithValue("@KategoriID", textBox1.Text);

                cmd.Parameters.AddWithValue("@UrunAdi", textBox2.Text);

                cmd.Parameters.AddWithValue("@UrunAciklamasi", textBox3.Text);

                cmd.Parameters.AddWithValue("@Fiyat", textBox4.Text);

                cmd.Parameters.AddWithValue("@Durum", checkBox1.Checked);


                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();
            }
            else if (tablo == "Menu")
            {

                SqlCommand cmd = new SqlCommand("Insert Menu (MenuAdi) values (@MenuAdi)", conn);

                cmd.Parameters.AddWithValue("@MenuAdi", textBox1.Text);




                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();
            }
            else if (tablo == "MenuKategori")
            {

                SqlCommand cmd = new SqlCommand("Insert MenuKategori (MenuKategoriAdi,MenuID) values(@MenuKategoriAdi , @MenuID)", conn);

                cmd.Parameters.AddWithValue("@MenuKategoriAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@MenuID", textBox2.Text);




                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();

            }
            else if (tablo == "Siparis")
            {

                if (checkBox1.Checked == true)
                {
                    SqlCommand cmd = new SqlCommand("Insert Siparis (SiparisTarihi,TeslimTarihi,SiparisTuru,MusteriID) values(@SiparisTarihi , @TeslimTarihi,@SiparisTuru,@MusteriID)", conn);


                    cmd.Parameters.AddWithValue("@SiparisTarihi", DateTime.Now);
                    cmd.Parameters.AddWithValue("@TeslimTarihi", DateTime.Now.AddMinutes(Convert.ToDouble(textBox3.Text)));
                    cmd.Parameters.AddWithValue("@SiparisTuru", checkBox1.Checked);
                    cmd.Parameters.AddWithValue("@MusteriID", textBox2.Text);


                    // check box durum kontrolü yapılacak

                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dap.Fill(dt);
                    dataGridView1.DataSource = dt;
                    Getir(tablo);
                    Temizle();

                }
                else if (checkBox1.Checked == false)
                {
                    SqlCommand cmd = new SqlCommand("Insert Siparis (SiparisTarihi,TeslimTarihi,SiparisTuru,MasaNumarası,MusteriID,CalisanID) values(@SiparisTarihi , @TeslimTarihi,@SiparisTuru,@MasaNumarası,@MusteriID,@CalisanID)", conn);


                    cmd.Parameters.AddWithValue("@SiparisTarihi", DateTime.Now);
                    cmd.Parameters.AddWithValue("@TeslimTarihi", DateTime.Now.AddMinutes(Convert.ToDouble(textBox3.Text)));
                    cmd.Parameters.AddWithValue("@SiparisTuru", checkBox1.Checked);
                    cmd.Parameters.AddWithValue("@MasaNumarası", textBox1.Text);
                    cmd.Parameters.AddWithValue("@MusteriID", textBox2.Text);
                    cmd.Parameters.AddWithValue("@CalisanID", comboBox2.SelectedValue);

                    SqlDataAdapter dap = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dap.Fill(dt);
                    dataGridView1.DataSource = dt;
                    Getir(tablo);
                    Temizle();

                }


            }
            else if (tablo == "UrunSiparisDetay")
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
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "Depo")
            {


                SqlCommand cmd = new SqlCommand("Insert Depo (DepoAdi,Adres) values(@DepoAdi,@Adres )", conn);



                cmd.Parameters.AddWithValue("@DepoAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@Adres", textBox2.Text);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "Malzeme")
            {

                SqlCommand cmd = new SqlCommand("Insert Malzeme (TedarikciID,MalzemeAdi,Durum,MalzemeKategoriID) values(@TedarikciID,@MalzemeAdi,@Durum,@MalzemeKategoriID )", conn);



                cmd.Parameters.AddWithValue("@TedarikciID", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@MalzemeAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@MalzemeKategoriID", textBox2.Text);
                cmd.Parameters.AddWithValue("@Durum", checkBox1.Checked);
                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "MalzemeKategori")
            {


                SqlCommand cmd = new SqlCommand("Insert MalzemeKategori (MalzemeKategoriAdi) values(@MalzemeKategoriAdi)", conn);



                cmd.Parameters.AddWithValue("@MalzemeKategoriAdi", textBox1.Text);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "UrunMalzemeDetay")
            {


                SqlCommand cmd = new SqlCommand("Insert UrunMalzemeDetay (UrunID,MalzemeID,MalzemeStok) values(@UrunID,@MalzemeID,@MalzemeStok)", conn);



                cmd.Parameters.AddWithValue("@MalzemeID", textBox1.Text);
                cmd.Parameters.AddWithValue("@MalzemeStok", textBox2.Text);
                cmd.Parameters.AddWithValue("@UrunID", comboBox2.SelectedValue);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "Tedarikci")
            {


                SqlCommand cmd = new SqlCommand("Insert Tedarikci (TedarikciAdi) values(@TedarikciAdi)", conn);



                cmd.Parameters.AddWithValue("@TedarikciAdi", textBox1.Text);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "DepoMalzemeDetay")
            {


                SqlCommand cmd = new SqlCommand("Insert DepoMalzemeDetay (DepoID,MalzemeID,DepoStok) values(@DepoID,@MalzemeID,@DepoStok)", conn);



                cmd.Parameters.AddWithValue("@DepoID", textBox1.Text);
                cmd.Parameters.AddWithValue("@DepoStok", textBox2.Text);
                cmd.Parameters.AddWithValue("@MalzemeID", comboBox2.SelectedValue);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "Musteri")
            {


                SqlCommand cmd = new SqlCommand("Insert Musteri (Adi,Soyadi,Adres,Telefon) values(@Adi,@Soyadi,@Adres,@Telefon)", conn);



                cmd.Parameters.AddWithValue("@Adi", textBox1.Text);
                cmd.Parameters.AddWithValue("@Soyadi", textBox2.Text);
                cmd.Parameters.AddWithValue("@Adres", textBox3.Text);
                cmd.Parameters.AddWithValue("@Telefon", textBox4.Text);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "Adisyon")
            {


                SqlCommand cmd = new SqlCommand("Insert Adisyon (Tarih) values(@Tarih)", conn);



                cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "OdemeYontemi")
            {


                SqlCommand cmd = new SqlCommand("Insert OdemeYontemi (OdemeYontemiAdi) values(@OdemeYontemiAdi)", conn);



                cmd.Parameters.AddWithValue("@OdemeYontemiAdi", textBox1.Text);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "AdisyonOdemeDetay")
            {


                SqlCommand cmd = new SqlCommand("Insert AdisyonOdemeDetay (OdemeYontemiID,OdemeYontemiAdi,AdisyonID) values(@OdemeYontemiID,@OdemeYontemiAdi,@AdisyonID)", conn);



                cmd.Parameters.AddWithValue("@AdisyonID", textBox1.Text);
                cmd.Parameters.AddWithValue("@OdemeYontemiID", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@OdemeYontemiAdi", textBox2.Text);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "AdisyonSiparisDetay")
            {


                SqlCommand cmd = new SqlCommand("Insert AdisyonSiparisDetay (SiparisID,AdisyonID) values(@SiparisID,@AdisyonID)", conn);



                cmd.Parameters.AddWithValue("@SiparisID", textBox1.Text);
                cmd.Parameters.AddWithValue("@AdisyonID", textBox2.Text);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }
            else if (tablo == "RestaurantMalzemeDetay")//
            {


                SqlCommand cmd = new SqlCommand("Insert RestaurantMalzemeDetay (MalzemeID,RestaurantID,RestaurantStok) values(@MalzemeID,@RestaurantID,@RestaurantStok)", conn);



                cmd.Parameters.AddWithValue("@RestaurantID", textBox1.Text);
                cmd.Parameters.AddWithValue("@RestaurantStok", textBox2.Text);
                cmd.Parameters.AddWithValue("@MalzemeID", comboBox2.SelectedValue);

                SqlDataAdapter dap = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                dap.Fill(dt);
                dataGridView1.DataSource = dt;
                Getir(tablo);
                Temizle();




            }





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


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int kolonSayisi;
           // kolonSayisi = dataGridView1.ColumnCount;

            string tablo = comboBox1.SelectedItem.ToString();

            if (tablo == "Menu" || tablo == "MalzemeKategori" || tablo == "Tedarikci" || tablo == "OdemeYontemi") //1
            {

                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();


            }
            else if (tablo == "UrunSiparisDetay") //3
            {

                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();



            }

            else if (tablo == "Calisan" || tablo == "CalisanDetay" || tablo == "Musteri") //4
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();


            }
            else if (tablo == "Restaurant")//5
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();


            }
            else if (tablo == "Urun")//6
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox5.Text = (dataGridView1.Rows[e.RowIndex].Cells[5].Value).ToString();
                checkBox1.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[5].Value;


            }
            else if (tablo == "MenuKategori" || tablo == "Depo" || tablo == "AdisyonSiparisDetay")//2
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();


            }
            else if (tablo == "Siparis")//6
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

                checkBox1.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[3].Value;


            }
            else if (tablo == "Malzeme")//5
            {


                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                checkBox1.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[2].Value;
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();


            }
            else if (tablo == "UrunMalzemeDetay")//3
            {

                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            }
            else if (tablo == "AdisyonOdemeDetay")//3
            {

                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
            else if (tablo == "DepoMalzemeDetay")
            {
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }

            else if (tablo == "Adisyon")//0
            {

                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

            }
            else if (tablo == "RestaurantMalzemeDetay")//3
            {

                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

            }


            //else if (kolonSayisi == 3)
            //{
            //    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //}

            //else if (kolonSayisi == 4)
            //{
            //    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();


            //}

            //else if (kolonSayisi == 5)
            //{
            //    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();


            //}

            //else if (kolonSayisi == 6)
            //{

            //    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //    if (tablo == "Urun")
            //    {
            //        checkBox1.Checked = (bool)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
            //    }
            //    else
            //    {
            //        textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //    }
            //}
            //else if (kolonSayisi == 7)
            //{
            //    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //    textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //    textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //    textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            //}




            //textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            //textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();




        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            string tablo = comboBox1.SelectedItem.ToString();

            if (tablo == "Calisan")
            {

                SqlCommand cmd = new SqlCommand("Update Calisan SET  CalisanAdi = @isim, CalisanSoyadi=@Soyisim,Unvan=@Unvan,RestaurantID=@RestaurantID where CalisanID=@CalisanID", conn);
                cmd.Parameters.AddWithValue("@isim", textBox1.Text);

                cmd.Parameters.AddWithValue("@Soyisim", textBox2.Text);

                cmd.Parameters.AddWithValue("@Unvan", textBox3.Text);

                cmd.Parameters.AddWithValue("@RestaurantID", textBox4.Text);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                cmd.Parameters.AddWithValue("@CalisanID", id);


                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }


                Getir(tablo);
                Temizle();
            }
            else if (tablo == "CalisanDetay")
            {
                SqlCommand cmd = new SqlCommand("Update CalisanDetay  SET Maas=@Maas, TcKn=@TcKn,TelNo=@TelNo,Mail=@Mail where CalisanDetayID=@CalisanDetayID", conn);



                cmd.Parameters.AddWithValue("@Maas", textBox1.Text);

                cmd.Parameters.AddWithValue("@TcKn", textBox2.Text);

                cmd.Parameters.AddWithValue("@TelNo", textBox3.Text);

                cmd.Parameters.AddWithValue("@Mail", textBox4.Text);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                cmd.Parameters.AddWithValue("@CalisanDetayID", id);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();
            }

            else if (tablo == "Restaurant")
            {
                SqlCommand cmd = new SqlCommand("Update Restaurant SET RestaurantAdi=@RestaurantAdi, Sehir=@Sehir,Adres=@Adres,Tel=@Tel,MenuID=@MenuID WHERE RestaurantID=@RestaurantID", conn);
                cmd.Parameters.AddWithValue("@RestaurantAdi", textBox1.Text);

                cmd.Parameters.AddWithValue("@Sehir", textBox2.Text);

                cmd.Parameters.AddWithValue("@Adres", textBox3.Text);

                cmd.Parameters.AddWithValue("@Tel", textBox4.Text);

                cmd.Parameters.AddWithValue("@MenuID", textBox5.Text);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                cmd.Parameters.AddWithValue("@RestaurantID", id);



                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();
            }
            else if (tablo == "Urun")
            {
                SqlCommand cmd = new SqlCommand("Update Urun SET KategoriID=@KategoriID, UrunAdi =@UrunAdi,UrunAciklamasi=@UrunAciklamasi,Fiyat=@Fiyat,Durum=@Durum  WHERE UrunID=@UrunID", conn);

                cmd.Parameters.AddWithValue("@KategoriID", textBox1.Text);

                cmd.Parameters.AddWithValue("@UrunAdi", textBox2.Text);

                cmd.Parameters.AddWithValue("@UrunAciklamasi", textBox3.Text);

                cmd.Parameters.AddWithValue("@Fiyat", textBox4.Text);

                cmd.Parameters.AddWithValue("@Durum", checkBox1.Checked);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                cmd.Parameters.AddWithValue("@UrunID", id);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();
            }
            else if (tablo == "Menu")
            {

                SqlCommand cmd = new SqlCommand("Update Menu  SET MenuAdi=@MenuAdi where MenuID=@MenuID ", conn);

                cmd.Parameters.AddWithValue("@MenuAdi", textBox1.Text);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                cmd.Parameters.AddWithValue("@MenuID", id);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();
            }
            else if (tablo == "MenuKategori")
            {

                SqlCommand cmd = new SqlCommand("Update MenuKategori SET MenuKategoriAdi=@MenuKategoriAdi , MenuID=@MenuID WHERE MenuKategoriID=@MenuKategoriID", conn);

                cmd.Parameters.AddWithValue("@MenuKategoriAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@MenuID", textBox2.Text);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                cmd.Parameters.AddWithValue("@MenuKategoriID", id);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();

            }
            else if (tablo == "Siparis")
            {

                if (checkBox1.Checked == true)
                {
                    SqlCommand cmd = new SqlCommand("Update Siparis SET TeslimTarihi=@TeslimTarihi,SiparisTuru=@SiparisTuru,MusteriID=@MusteriID WHERE SiparisID=@SiparisID", conn);
                    if (textBox3.Text != "")
                    {

                        cmd.Parameters.AddWithValue("@TeslimTarihi", ((DateTime)dataGridView1.CurrentRow.Cells[2].Value).AddMinutes(Convert.ToDouble(textBox3.Text)));
                        cmd.Parameters.AddWithValue("@SiparisTuru", checkBox1.Checked);
                        cmd.Parameters.AddWithValue("@MusteriID", textBox2.Text);

                        int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                        cmd.Parameters.AddWithValue("@SiparisID", id);

                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                            int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                            MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                        }
                        else
                        {
                            conn.Close();
                        }

                        Getir(tablo);
                        Temizle();
                    }
                    else
                    {
                        MessageBox.Show("Teslim Tarihi bos gecme Sıfır da yazabilirsin");
                    }

                }
                else if (checkBox1.Checked == false)
                {
                    SqlCommand cmd = new SqlCommand("Update Siparis SET TeslimTarihi=@TeslimTarihi,SiparisTuru=@SiparisTuru,MasaNumarası=@MasaNumarası,MusteriID=@MusteriID,CalisanID=@CalisanID WHERE SiparisID=@SiparisID", conn);
                    if (textBox3.Text != "")
                    {

                        cmd.Parameters.AddWithValue("@TeslimTarihi", ((DateTime)dataGridView1.CurrentRow.Cells[2].Value).AddMinutes(Convert.ToDouble(textBox3.Text)));
                        cmd.Parameters.AddWithValue("@SiparisTuru", checkBox1.Checked);
                        cmd.Parameters.AddWithValue("@MasaNumarası", textBox1.Text);
                        cmd.Parameters.AddWithValue("@MusteriID", textBox2.Text);
                        cmd.Parameters.AddWithValue("@CalisanID", comboBox2.SelectedValue);

                        int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                        cmd.Parameters.AddWithValue("@SiparisID", id);

                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                            int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                            MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                        }
                        else
                        {
                            conn.Close();
                        }

                        Getir(tablo);
                        Temizle();


                    }
                    else
                    {
                        MessageBox.Show("Teslim Tarihi bos gecme Sıfır da yazabilirsin");
                    }





                }







            }


            else if (tablo == "UrunSiparisDetay")
            {


                SqlCommand cmd = new SqlCommand("Update UrunSiparisDetay SET SiparisID=SiparisID ,UrunID=@UrunID,SiparisMiktari=@SiparisMiktari,Fiyat=@Fiyat WHERE  UrunSiparisDetay=@UrunSiparisDetayID  ", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@UrunSiparisDetayID", id);

                cmd.Parameters.AddWithValue("@SiparisID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Fiyat", Convert.ToInt32( comboBox2.SelectedValue));
                cmd.Parameters.AddWithValue("@SiparisMiktari",  textBox2.Text);
                cmd.Parameters.AddWithValue("@UrunID", textBox3.Text);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();




            }


            else if (tablo == "Depo")
            {


                SqlCommand cmd = new SqlCommand("Update Depo SET DepoAdi=@DepoAdi,Adres=@Adres WHERE DepoID=@DepoID ", conn);


                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@DepoID", id);
                cmd.Parameters.AddWithValue("@DepoAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@Adres", textBox2.Text);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();



            }
            else if (tablo == "Malzeme")
            {

                SqlCommand cmd = new SqlCommand("Update Malzeme SET TedarikciID=@TedarikciID,MalzemeAdi=@MalzemeAdi,Durum=@Durum,MalzemeKategoriID=@MalzemeKategoriID WHERE MalzemeID=@MalzemeID", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@MalzemeID", id);

                cmd.Parameters.AddWithValue("@TedarikciID", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@MalzemeAdi", textBox1.Text);
                cmd.Parameters.AddWithValue("@MalzemeKategoriID", textBox2.Text);
                cmd.Parameters.AddWithValue("@Durum", checkBox1.Checked);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();

            }
            else if (tablo == "MalzemeKategori")
            {


                SqlCommand cmd = new SqlCommand("Update MalzemeKategori SET MalzemeKategoriAdi=@MalzemeKategoriAdi WHERE MalzemeKategoriID=@MalzemeKategoriID ", conn);



                cmd.Parameters.AddWithValue("@MalzemeKategoriAdi", textBox1.Text);
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@MalzemeKategoriID", id);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();


            }

            else if (tablo == "UrunMalzemeDetay")
            {



                SqlCommand cmd = new SqlCommand("UPDATE UrunMalzemeDetay SET  UrunID=@UrunID,MalzemeID=@MalzemeID,MalzemeStok=@MalzemeStok WHERE UrunMalzemeID = @UrunMalzemeID", conn);
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@UrunMalzemeID", id);



                cmd.Parameters.AddWithValue("@MalzemeID", textBox1.Text);
                cmd.Parameters.AddWithValue("@MalzemeStok", textBox2.Text);
                cmd.Parameters.AddWithValue("@UrunID", comboBox2.SelectedValue);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();

            }
            else if (tablo == "Tedarikci")
            {


                SqlCommand cmd = new SqlCommand("Update Tedarikci SET TedarikciAdi=@TedarikciAdi WHERE TedarikciID=@TedarikciID ", conn);



                cmd.Parameters.AddWithValue("@TedarikciAdi", textBox1.Text);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@TedarikciID", id);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();



            }

            else if (tablo == "DepoMalzemeDetay")
            {


                SqlCommand cmd = new SqlCommand("Update DepoMalzemeDetay SET DepoID=@DepoID,MalzemeID=@MalzemeID,DepoStok=@DepoStok WHERE DepoMalzemeID=@DepoMalzemeID", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@DepoMalzemeID", id);


                cmd.Parameters.AddWithValue("@DepoID", textBox1.Text);
                cmd.Parameters.AddWithValue("@DepoStok", textBox2.Text);
                cmd.Parameters.AddWithValue("@MalzemeID", comboBox2.SelectedValue);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();



            }
            else if (tablo == "Musteri")
            {


                SqlCommand cmd = new SqlCommand("Update Musteri SET Adi=@Adi,Soyadi=@Soyadi,Adres=@Adres,Telefon=@Telefon WHERE MusteriID=@MusteriID", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@MusteriID", id);


                cmd.Parameters.AddWithValue("@Adi", textBox1.Text);
                cmd.Parameters.AddWithValue("@Soyadi", textBox2.Text);
                cmd.Parameters.AddWithValue("@Adres", textBox3.Text);
                cmd.Parameters.AddWithValue("@Telefon", textBox4.Text);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();



            }
            else if (tablo == "Adisyon")
            {

                MessageBox.Show("Bu Tablo Güncellenemez");




            }
            else if (tablo == "OdemeYontemi")
            {


                SqlCommand cmd = new SqlCommand("Update OdemeYontemi SET OdemeYontemiAdi =@OdemeYontemiAdi WHERE OdemeYontemiID=@OdemeYontemiID ", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@OdemeYontemiID", id);



                cmd.Parameters.AddWithValue("@OdemeYontemiAdi", textBox1.Text);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();




            }
            else if (tablo == "AdisyonOdemeDetay")
            {


                SqlCommand cmd = new SqlCommand("Update AdisyonOdemeDetay SET AdisyonID=@AdisyonID, OdemeYontemiID=@OdemeYontemiID,OdemeYontemiAdi=@OdemeYontemiAdi WHERE AdisyonOdemeDetayID=@AdisyonOdemeDetayID   ", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@AdisyonOdemeDetayID", id);


                cmd.Parameters.AddWithValue("@AdisyonID", textBox1.Text);
                cmd.Parameters.AddWithValue("@OdemeYontemiID", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@OdemeYontemiAdi", textBox2.Text);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();




            }
            else if (tablo == "AdisyonSiparisDetay")
            {


                SqlCommand cmd = new SqlCommand("UPDATE AdisyonSiparisDetay SET SiparisID=@SiparisID,AdisyonID=@AdisyonID WHERE AdisyonSiparisDetayID =@AdisyonSiparisDetay", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@AdisyonSiparisDetay", id);


                cmd.Parameters.AddWithValue("@SiparisID", textBox1.Text);
                cmd.Parameters.AddWithValue("@AdisyonID", textBox2.Text);


                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();
                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Güncellendi" : "Güncelleme Yapılamadı");

                }
                else
                {
                    conn.Close();
                }

                Getir(tablo);
                Temizle();




            }



        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)////////////////// texbox iç kontrol
        {
            // e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayi
            string tablo = comboBox1.SelectedItem.ToString();
            if (tablo == "Calisan" || tablo == "Restaurant" || tablo == "Menu" || tablo == "MenuKategori" || tablo == "Depo" || tablo == "Malzeme" || tablo == "MalzemeKategori" || tablo == "Tedarikci" || tablo == "Musteri" || tablo == "OdemeYontemi")
            {

                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);

            }//
            else if (tablo == "Urun" || tablo == "CalisanDetay" || tablo == "Siparis" || tablo == "UrunSiparisDetay" || tablo == "UrunMalzemeDetay" || tablo == "DepoMalzemeDetay" || tablo == "AdisyonOdemeDetay" || tablo == "AdisyonSiparisDetay" || tablo == "RestaurantMalzemeDetay")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }



        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string tablo = comboBox1.SelectedItem.ToString();


            if (tablo == "Calisan")
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM Calisan where CalisanID=@CalisanID", conn);

                int SecilenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                cmd.Parameters.AddWithValue("@CalisanID", SecilenId);

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    int etkilenenSatirSayisi = cmd.ExecuteNonQuery();

                    MessageBox.Show(etkilenenSatirSayisi > 0 ? "Kayıt Silindi" : "Kayıt Silindi");

                }
                else
                {
                    conn.Close();
                }


                Getir(tablo);
                Temizle();
            }
            else if (tablo == "CalisanDetay")
            {
                SqlCommand cmd = new SqlCommand(" DELETE FROM CalisanDetay where CalisanDetayID=@CalisanDetayID", conn);

                int SecilenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);



                cmd.Parameters.AddWithValue("@CalisanDetayID", SecilenId);

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

                Getir(tablo);
                Temizle();
            }


            else if (tablo == "Restaurant")
            {
                SqlCommand cmd = new SqlCommand(" DELETE FROM Restaurant where RestaurantID=@RestaurantID ", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                cmd.Parameters.AddWithValue("@RestaurantID", id);



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

                Getir(tablo);
                Temizle();
            }
            else if (tablo == "Urun")
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Urun where UrunID=@UrunID ", conn);


                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                cmd.Parameters.AddWithValue("@UrunID", id);

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

                Getir(tablo);
                Temizle();
            }
            else if (tablo == "Menu")
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM Menu where MenuID=@MenuID ", conn);


                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                cmd.Parameters.AddWithValue("@MenuID", id);

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

                Getir(tablo);
                Temizle();
            }
            else if (tablo == "MenuKategori")
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM MenuKategori WHERE MenuKategoriID=@MenuKategoriID", conn);


                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                cmd.Parameters.AddWithValue("@MenuKategoriID", id);

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

                Getir(tablo);
                Temizle();

            }
            else if (tablo == "Siparis")
            {


                SqlCommand cmd = new SqlCommand("DELETE FROM Siparis WHERE SiparisID=@SiparisID", conn);



                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@SiparisID", id);

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

                Getir(tablo);
                Temizle();


            }

            else if (tablo == "UrunSiparisDetay")
            {


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

                Getir(tablo);
                Temizle();




            }


            else if (tablo == "Depo")
            {


                SqlCommand cmd = new SqlCommand("DELETE FROM Depo  WHERE DepoID=@DepoID ", conn);


                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@DepoID", id);

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

                Getir(tablo);
                Temizle();



            }

            else if (tablo == "Malzeme")
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM Malzeme   WHERE MalzemeID=@MalzemeID", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@MalzemeID", id);

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

                Getir(tablo);
                Temizle();

            }
            else if (tablo == "MalzemeKategori")
            {


                SqlCommand cmd = new SqlCommand("DELETE FROM MalzemeKategori  WHERE MalzemeKategoriID=@MalzemeKategoriID ", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@MalzemeKategoriID", id);

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

                Getir(tablo);
                Temizle();


            }

            else if (tablo == "UrunMalzemeDetay")
            {



                SqlCommand cmd = new SqlCommand("DELETE FROM UrunMalzemeDetay  WHERE UrunMalzemeID = @UrunMalzemeID", conn);
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@UrunMalzemeID", id);
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

                Getir(tablo);
                Temizle();

            }
            else if (tablo == "Tedarikci")
            {


                SqlCommand cmd = new SqlCommand("DELETE FROM Tedarikci   WHERE TedarikciID=@TedarikciID ", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@TedarikciID", id);

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

                Getir(tablo);
                Temizle();



            }

            else if (tablo == "DepoMalzemeDetay")
            {


                SqlCommand cmd = new SqlCommand("DELETE FROM DepoMalzemeDetay  WHERE DepoMalzemeID=@DepoMalzemeID", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@DepoMalzemeID", id);

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

                Getir(tablo);
                Temizle();



            }
            else if (tablo == "Musteri")
            {


                SqlCommand cmd = new SqlCommand("DELETE FROM Musteri WHERE MusteriID=@MusteriID", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@MusteriID", id);

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

                Getir(tablo);
                Temizle();



            }
            else if (tablo == "Adisyon")
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM Adisyon WHERE AdisyonID=@AdisyonID", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@AdisyonID", id);

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

                Getir(tablo);
                Temizle();




            }
            else if (tablo == "OdemeYontemi")
            {


                SqlCommand cmd = new SqlCommand("DELETE FROM OdemeYontemi  WHERE OdemeYontemiID=@OdemeYontemiID ", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@OdemeYontemiID", id);

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

                Getir(tablo);
                Temizle();




            }
            else if (tablo == "AdisyonOdemeDetay")
            {


                SqlCommand cmd = new SqlCommand("DELETE FROM AdisyonOdemeDetay WHERE AdisyonOdemeDetayID=@AdisyonOdemeDetayID   ", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@AdisyonOdemeDetayID", id);


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

                Getir(tablo);
                Temizle();




            }
            else if (tablo == "AdisyonSiparisDetay")
            {


                SqlCommand cmd = new SqlCommand("UPDATE FROM AdisyonSiparisDetay  WHERE AdisyonSiparisDetayID =@AdisyonSiparisDetay", conn);

                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                cmd.Parameters.AddWithValue("@AdisyonSiparisDetay", id);

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

                Getir(tablo);
                Temizle();




            }










        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            // e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); // sadece sayi
            string tablo = comboBox1.SelectedItem.ToString();
            if (tablo == "Urun" || tablo == "Calisan" || tablo == "Restaurant" || tablo == "CalisanDetay" || tablo == "Menu" || tablo == "Depo" || tablo == "AdisyonOdemeDetay" || tablo == "MalzemeKategori" || tablo == "Tedarikci" || tablo == "Musteri" || tablo == "OdemeYontemi")
            {

                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);

            }//
            else if (tablo == "MenuKategori" || tablo == "Siparis" || tablo == "Malzeme" || tablo == "UrunSiparisDetay" || tablo == "UrunMalzemeDetay" || tablo == "DepoMalzemeDetay" || tablo == "AdisyonSiparisDetay" || tablo == "RestaurantMalzemeDetay")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }


        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tablo = comboBox1.SelectedItem.ToString();
            if (tablo == "Urun" || tablo == "Calisan" || tablo == "Restaurant" || tablo == "CalisanDetay" || tablo == "Menu" || tablo == "Depo" || tablo == "AdisyonOdemeDetay" || tablo == "MalzemeKategori" || tablo == "Tedarikci" || tablo == "Musteri" || tablo == "OdemeYontemi")
            {

                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);

            }//
            else if (tablo == "MenuKategori" || tablo == "Siparis" || tablo == "Malzeme" || tablo == "UrunSiparisDetay" || tablo == "UrunMalzemeDetay" || tablo == "DepoMalzemeDetay" || tablo == "AdisyonSiparisDetay" || tablo == "RestaurantMalzemeDetay")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

            string tablo = comboBox1.SelectedItem.ToString();
            if (tablo == "Musteri" || tablo == "Restaurant")
            {

                e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);

            }//
            else if (tablo == "Urun" || tablo == "Calisan" || tablo == "MenuKategori" || tablo == "Siparis" || tablo == "Malzeme")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            string tablo = comboBox1.SelectedItem.ToString();

            if (tablo == "Restaurant")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

        }


    }
}

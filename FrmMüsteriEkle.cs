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

namespace AracKiralamaOtomasyonu
{
    public partial class FrmMüsteriEkle : Form
    {
        Arac_Kiralama arac_kiralama = new Arac_Kiralama();
        public FrmMüsteriEkle()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cümle = "insert into müsteri(tc,adsoyad,telefon,adres,email) values(@tc,@adsoyad,@telefon,@adres,@email)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", textBox1.Text);
            komut2.Parameters.AddWithValue("@adsoyad", textBox2.Text);
            komut2.Parameters.AddWithValue("@telefon", textBox3.Text);
            komut2.Parameters.AddWithValue("@adres", textBox4.Text);
            komut2.Parameters.AddWithValue("@email", textBox5.Text);
            arac_kiralama.ekle_sil_guncelle(komut2, cümle);
            foreach (Control item in Controls) if (item is TextBox) item.Text = ""; 
        }

        private void FrmMüsteriEkle_Load(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class FrmAracKayit : Form
    {
        Arac_Kiralama arackiralama = new Arac_Kiralama();
        public FrmAracKayit()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                comboBox2.Items.Clear();
                if (comboBox1.SelectedIndex == 0)
                {
                    comboBox2.Items.Add("Astra");
                    comboBox2.Items.Add("Insignia");
                    comboBox2.Items.Add("Corsa");


                }
                else if (comboBox1.SelectedIndex==1)
                    {
                    comboBox2.Items.Add("S60");
                    comboBox2.Items.Add("V70");
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    comboBox2.Items.Add("Egea");
                    comboBox2.Items.Add("Linea");
                }
                else if (comboBox1.SelectedIndex == 3)
                {
                    comboBox2.Items.Add("Civic");
                    comboBox2.Items.Add("Jazz");
                }
            }
            catch
            {
                ;

            }


           
            



           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cümle = "insert into arac(plaka,marka,seri,yil,renk,km,yakit,kiraucreti,resim,tarih,durumu) values(@plaka,@marka,@seri,@yil,@renk,@km,@yakit,@kiraucreti,@resim,@tarih,@durumu) ";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka",textBox1.Text);
            komut2.Parameters.AddWithValue("@marka", comboBox1.Text);
            komut2.Parameters.AddWithValue("@seri", comboBox2.Text);
            komut2.Parameters.AddWithValue("@yil", textBox2.Text);
            komut2.Parameters.AddWithValue("@renk", textBox3.Text);
            komut2.Parameters.AddWithValue("@km", textBox4.Text);
            komut2.Parameters.AddWithValue("@yakit", comboBox3.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(textBox5.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            komut2.Parameters.AddWithValue("@durumu", "BOŞ");
            arackiralama.ekle_sil_guncelle(komut2,cümle);
            comboBox2.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox1.ImageLocation = "";

        }

        private void FrmAracKayit_Load(object sender, EventArgs e)
        {

        }
    }
}

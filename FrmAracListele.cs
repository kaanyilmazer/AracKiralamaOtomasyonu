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
    public partial class FrmAracListele : Form
    {
        Arac_Kiralama arackiralama = new Arac_Kiralama();
        public FrmAracListele()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            textBox1.Text = satır.Cells["plaka"].Value.ToString();
            comboBox4.Text = satır.Cells["marka"].Value.ToString();
            comboBox2.Text = satır.Cells["seri"].Value.ToString();
            textBox2.Text = satır.Cells["yil"].Value.ToString();
            textBox3.Text = satır.Cells["renk"].Value.ToString();
            textBox4.Text = satır.Cells["km"].Value.ToString();
            comboBox3.Text = satır.Cells["yakit"].Value.ToString();
            textBox5.Text = satır.Cells["kiraucreti"].Value.ToString();
            pictureBox1.ImageLocation = satır.Cells["resim"].Value.ToString();
            

        }

        private void FrmAracListele_Load(object sender, EventArgs e)
        {
            YenileAraclarListesi();
           
                comboBox1.SelectedIndex = 0;
           
           

        }

        private void YenileAraclarListesi()
        {
            string cümle = "select * from arac";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cümle = "update arac set marka=@marka,seri=@seri,yil=@yil,renk=@renk,km=@km,yakit=@yakit,kiraucreti=@kiraucreti,resim=@resim,tarih=@tarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", textBox1.Text);
            komut2.Parameters.AddWithValue("@marka", comboBox4.Text);
            komut2.Parameters.AddWithValue("@seri", comboBox2.Text);
            komut2.Parameters.AddWithValue("@yil", textBox2.Text);
            komut2.Parameters.AddWithValue("@renk", textBox3.Text);
            komut2.Parameters.AddWithValue("@km", textBox4.Text);
            komut2.Parameters.AddWithValue("@yakit", comboBox3.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(textBox5.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox1.ImageLocation);
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            arackiralama.ekle_sil_guncelle(komut2, cümle);
            comboBox2.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox1.ImageLocation = "";
            YenileAraclarListesi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;

            string cümle = "delete from arac where plaka= '" + satır.Cells["plaka"].Value.ToString() + "'";
            SqlCommand komut2 = new SqlCommand();
            arackiralama.ekle_sil_guncelle(komut2, cümle);
            //foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            YenileAraclarListesi();
            comboBox2.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox1.ImageLocation = "";
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
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
                else if (comboBox1.SelectedIndex == 1)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex==0)
                {
                    YenileAraclarListesi();
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    string cümle = "select * from arac where durumu='BOŞ'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    string cümle = "select * from arac where durumu='DOLU'";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                }
            }
            catch
            {
                ;
            }
        }
    }
}

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
    public partial class FrmMüsteriListele : Form
    {
        Arac_Kiralama arac_Kiralama = new Arac_Kiralama();
        public FrmMüsteriListele()
        {
            InitializeComponent();
        }

        private void FrmMüsteriListele_Load(object sender, EventArgs e)
        {
            YenileListele();
        }

        private void YenileListele()
        {
            string cümle = "select * from  müsteri";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
           
            dataGridView1.DataSource = arac_Kiralama.listele(adtr2, cümle);
            dataGridView1.Columns[0].HeaderText = "TC";
            dataGridView1.Columns[1].HeaderText = "Adı Soyadı";
            dataGridView1.Columns[2].HeaderText = "Telefon Numarası";
            dataGridView1.Columns[3].HeaderText = "Adres:";
            dataGridView1.Columns[4].HeaderText = "Email:";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

            string cümle = "select * from  müsteri where adsoyad  like '%" + textBox6.Text + "%' or tc like '"+textBox6.Text+"%' or telefon like '"+textBox6.Text+"%'";  


            SqlDataAdapter adtr1 = new SqlDataAdapter();
            dataGridView1.DataSource = arac_Kiralama.listele(adtr1, cümle);
            





        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            textBox1.Text = satır.Cells[0].Value.ToString();
            textBox2.Text = satır.Cells[1].Value.ToString();
            textBox3.Text = satır.Cells[2].Value.ToString();
            textBox4.Text = satır.Cells[3].Value.ToString();
            textBox5.Text = satır.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cümle = "Update müsteri set adsoyad=@adsoyad,telefon=@telefon,adres=@adres,email=@email where tc=@tc";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", textBox1.Text);
            komut2.Parameters.AddWithValue("@adsoyad", textBox2.Text);
            komut2.Parameters.AddWithValue("@telefon", textBox3.Text);
            komut2.Parameters.AddWithValue("@adres", textBox4.Text);
            komut2.Parameters.AddWithValue("@email", textBox5.Text);
            arac_Kiralama.ekle_sil_guncelle(komut2, cümle);
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            YenileListele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;

            string cümle = "delete from müsteri where tc= '" + satır.Cells["tc"].Value.ToString()+ "'";
            SqlCommand komut2 = new SqlCommand();
            arac_Kiralama.ekle_sil_guncelle(komut2, cümle);
            //foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            YenileListele();
        }
    }
}

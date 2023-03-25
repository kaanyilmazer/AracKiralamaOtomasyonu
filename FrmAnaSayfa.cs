using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralamaOtomasyonu
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmMüsteriEkle ekle = new FrmMüsteriEkle();
                ekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMüsteriListele listele = new FrmMüsteriListele();
            listele.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmAracKayit aracekle = new FrmAracKayit();
            aracekle.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FrmAracListele araclistele = new FrmAracListele();
                araclistele.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmSozlesme sozlesme = new FrmSozlesme();
            sozlesme.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSatis satis = new frmSatis();
            satis.ShowDialog();

        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {

        }
    }
}

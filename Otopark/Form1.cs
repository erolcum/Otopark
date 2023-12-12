using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otopark
{
    public partial class Form1 : Form
    {
        List<Arac> CikisYapanlar = new List<Arac>();

        public Form1()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Arac arc = new Arac();
            arc.Plaka = txtPlaka.Text;
            arc.Tip = (AracTip) lstAracTip.SelectedItem;
            arc.Kontak = chkKontak.Checked;
            arc.Abone = chkAbone.Checked;
            lstAraclar.Items.Add(arc);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstAracTip.Items.Add(new AracTip {Adi = "Otomobil(1)", Fiyat = 1 });
            lstAracTip.Items.Add(new AracTip { Adi = "Minibüs(2)", Fiyat = 2 });
            lstAracTip.Items.Add(new AracTip { Adi = "Otobüs(4)", Fiyat = 4 });
            lstAracTip.Items.Add(new AracTip { Adi = "Kamyon(4)", Fiyat = 4 });
            lstAracTip.Items.Add(new AracTip { Adi = "Tır(8)", Fiyat = 8 });
        }

        private void lstAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAraclar.SelectedItem == null)  return;
            Arac secim = (Arac) lstAraclar.SelectedItem;
            secim.Cikis = DateTime.Now;
            lblPlaka.Text = secim.Plaka;
            lblSure.Text = secim.Sure.ToString();
            lblUcret.Text = secim.Ucret.ToString("C2");

        }

        private void CikisYap_Click(object sender, EventArgs e)
        {
            if (lstAraclar.SelectedItem == null) return;
            Arac secim = (Arac) lstAraclar.SelectedItem;
            CikisYapanlar.Add(secim);
            lstAraclar.Items.Remove(secim);
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            Rapor form = new Rapor();
            decimal total = 0;
            foreach (var item in CikisYapanlar)
            {
                ListViewItem li = new ListViewItem();
                li.Text = item.Plaka;
                li.SubItems.Add(item.Tip.Adi);
                li.SubItems.Add(item.Abone ? "Abone" : "Değil");
                li.SubItems.Add(item.Sure.ToString());
                li.SubItems.Add(item.Ucret.ToString("C2"));
                form.listView1.Items.Add(li);
                total += item.Ucret;
            }
            form.lblToplamUcret.Text = total.ToString("C2");
            form.lblToplamArac.Text = CikisYapanlar.Count.ToString();
            form.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
namespace Doviz_ofis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);
            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'USD']/BanknoteBuying").InnerXml;
            lbldolaralis.Text = dolaralis;
            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'USD']/BanknoteSelling").InnerXml;
            lbldolarsatis.Text = dolarsatis;
            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'EUR']/BanknoteBuying").InnerXml;
            lbleurosatis.Text = eurosatis;
            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'EUR']/BanknoteSelling").InnerXml;
            lbleuroalis.Text = euroalis;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btndolaral_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldolaralis.Text;

        }

        private void btndolarsat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbldolarsatis.Text;
        }

        private void btneuroal_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleuroalis.Text;

        }

        private void btneurosat_Click(object sender, EventArgs e)
        {
            txtkur.Text = lbleurosatis.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double kur, miktar, toplam;
            kur = Convert.ToDouble(txtkur.Text);
            miktar = Convert.ToDouble(txtmiktar.Text);
            toplam = kur * miktar;
            txttutar.Text = toplam.ToString();


        }

        private void txtkur_TextChanged(object sender, EventArgs e)
        {
            txtkur.Text = txtkur.Text.Replace(".", ",");
        }
    }
}

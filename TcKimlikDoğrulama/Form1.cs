using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;

namespace TcKimlikDoğrulama
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            long TCKN = long.Parse(textBox3.Text);
            string Ad, Soyad;
            
            Ad = textBox1.Text;
            Soyad= textBox2.Text;
            int dogum_yili = dateTimePicker1.Value.Year;

            KimlikBilgileri.KPSPublicSoapClient KK = new KimlikBilgileri.KPSPublicSoapClient();
            bool Durum = KK.TCKimlikNoDogrula(TCKN, Ad,Soyad,dogum_yili);

            if (Durum)
            {
                MessageBox.Show("Girilen Kimlik Bilgileri Doğrulandı.", "Geçerli Durum", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Girilen Kimlik Bilgileri Yanlış.", "Geçersiz Durum", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}

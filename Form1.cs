using Deneme.Formlar;
using System;
using System.Windows.Forms;

namespace Deneme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void ActivateForm<T>() where T : Form, new()
        {
            // Mevcut açık formu bul
            foreach (Form form in this.MdiChildren)
            {
                if (form is T)
                {
                    // Eğer istenilen form zaten açıksa, işlem yapma
                    return;
                }
                // Mevcut formu kapat
                form.Close();
            }

            // Yeni formu oluştur ve aç
            T newForm = new T();
            newForm.MdiParent = this;
            newForm.Show();
        }
        private void BtnUrunListesi_Click(object sender, EventArgs e)
        {

            ActivateForm<ÜrünListesi>();
        }
    

        private void BtnYeniUrun_Click(object sender, EventArgs e)
        {
            ActivateForm<YeniÜrün>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnKategoriListesi_Click(object sender, EventArgs e)
        {
            ActivateForm<Kategori>();
            

        }

        private void BtnYeniKategori_Click(object sender, EventArgs e)
        {
            ActivateForm<YeniKategori>();
        }

        private void BtnUrunİstatistik_Click(object sender, EventArgs e)
        {
            ActivateForm<UrunIstatistikleri>();
        }

        private void BtnMarkaİstatistik_Click(object sender, EventArgs e)
        {
            ActivateForm<Markalar>();
        }


        private void BtnCariListe_Click_1(object sender, EventArgs e)
        {
            ActivateForm<CariListesi>();
        }

        private void BtnCariil_Click(object sender, EventArgs e)
        {
            ActivateForm<Cariiller>();
        }

        private void BtnYeniCari_Click(object sender, EventArgs e)
        {
            ActivateForm<CariEkle>();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            ActivateForm<DepartmanFormu>();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            ActivateForm<YeniDepartman>();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ActivateForm<PersonelForm>();
        }

        private void BtnArızalıUrun_Click(object sender, EventArgs e)
        {
            ActivateForm<ArizaListesi>();
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            ActivateForm<UrunSatis>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivateForm<Satislar>();
        }

        private void BtnArizaliUrunKayit_Click(object sender, EventArgs e)
        {
            ActivateForm<ArizaliUrunKaydi>();
        }

       

        private void BtnQrCode_Click(object sender, EventArgs e)
        {
            ActivateForm<QRCODE>();
        }

       
        private void button2_Click_1(object sender, EventArgs e)
        {
            ActivateForm<ANASAYFA>();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deneme.Formlar
{
    public partial class CariListesi : Form
    {
        public CariListesi()
        {
            InitializeComponent();
        }
        void metot2()
        {

            try
            {
                // Verileri çek
                var degerler = db.TBLCARI.Select(x => new
                {
                    ID = x.ID,
                    AD = x.AD,
                    SOYAD = x.SOYAD,
                    TELEFON = x.TELEFON,
                    MAIL = x.MAIL,
                    IL = x.IL,
                    ILCE = x.ILCE,
                    BANKA = x.BANKA,
                    VERGIDAIRESI = x.VERGIDAIRESI,
                    VERGINO = x.VERGINO,
                    STATU = x.STATU,
                    ADRES=x.ADRES
                }).ToList();

                // DataGridView'e verileri bağla
                dataGridView1.DataSource = degerler;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
        }
       Model3 db=new Model3();
        // TBLcarı nesnesi oluştur
        TBLCARI t1 = new TBLCARI();
        private void CariListesi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            metot2();   // Veritabanından kategorileri çek
            using (var dbContext = new Model3())
            {
                List<TBLCARI> categories = dbContext.TBLCARI.ToList();

                // Combobox'a çekilen kategori verilerini ekle
                foreach (TBLCARI category in categories)
                {
                    CmbCariil.Items.Add(category.IL);
                }
            }


            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLCARI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtCariID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }
        

        private void BtnCariKaydet_Click(object sender, EventArgs e)
        {
            // TextBox'ların değerlerini al
            string textBoxCariIDValue = TxtCariID.Text;
            string textBoxCariAdValue = TxtCariAd.Text;
            string textBoxCariSoyadValue = TxtCariSoyad.Text;
            string textBoxCariTelValue = TxtCariTel.Text;
            string textBoxCariMailValue = TxtCariMail.Text;
            string CmbCariilValue = CmbCariil.Text;
            string CmbCariilceValue = CmbCariilce.Text;
            string textBoxCariBankaValue = TxtCariBanka.Text;
            string textBoxCariVDaireValue = TxtCariVDaire.Text;
            string textBoxCariVergiNoValue = TxtCariVNo.Text;
            string textBoxCariStatuValue = TxtStatu.Text;
            string textBoxCariAdresValue = TxtCariAdres.Text;

            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxCariIDValue) ||
                string.IsNullOrWhiteSpace(textBoxCariAdValue) ||
                string.IsNullOrWhiteSpace(textBoxCariSoyadValue) ||
                string.IsNullOrWhiteSpace(textBoxCariTelValue) ||
                string.IsNullOrWhiteSpace(textBoxCariMailValue) ||
                string.IsNullOrWhiteSpace(CmbCariilValue) ||
                string.IsNullOrWhiteSpace(CmbCariilceValue)||
                 string.IsNullOrWhiteSpace(textBoxCariBankaValue) ||
                string.IsNullOrWhiteSpace(textBoxCariVDaireValue) ||
                string.IsNullOrWhiteSpace(textBoxCariVergiNoValue) ||
                 string.IsNullOrWhiteSpace(textBoxCariStatuValue) ||
                string.IsNullOrWhiteSpace(textBoxCariAdresValue) 


                )
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }

            // TextBox'lar dolu ise kayıt işlemini gerçekleştir
            try
            {
             

                // TextBox değerlerini TBLURUN nesnesine ata
                t1.ID = int.Parse(textBoxCariIDValue);
                t1.AD = textBoxCariAdValue;
                t1.SOYAD = textBoxCariSoyadValue;
                t1.TELEFON = textBoxCariTelValue;
                t1.MAIL= textBoxCariMailValue;
                t1.IL = CmbCariilValue;
                t1.ILCE = CmbCariilceValue;
                t1.BANKA = textBoxCariBankaValue;
                t1.VERGIDAIRESI = textBoxCariVDaireValue;
                t1.VERGINO = textBoxCariVergiNoValue;
                t1.STATU = textBoxCariStatuValue;
                t1.ADRES = textBoxCariAdresValue;

                // Veritabanına kaydet
                db.TBLCARI.Add(t1);
                db.SaveChanges();

                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var yeniID = byte.Parse(TxtCariID.Text) + 1; // Mevcut ID'yi bir artır
                TxtCariID.Text = yeniID.ToString(); // Yeni ID'yi Textbox'a atar


            }

            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLCARI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtCariID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtCariAd.Text = " ";
            TxtCariSoyad.Text = " ";
            TxtCariTel.Text = " ";
            TxtCariMail.Text = " ";
            CmbCariil.Text = " ";
            CmbCariilce.Text = " ";
            TxtCariBanka.Text = " ";
            TxtCariVDaire.Text = " ";
            TxtCariVNo.Text = " ";
            TxtStatu.Text = " ";
            TxtCariAdres.Text = " ";


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnCariListele_Click(object sender, EventArgs e)
        {
            metot2();
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLCARI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtCariID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }

        private void BtnCariSil_Click(object sender, EventArgs e)
        {
            // TextBox'ların değerlerini al
            string textBoxCariIDValue = TxtCariID.Text;
            string textBoxCariAdValue = TxtCariAd.Text;
            string textBoxCariSoyadValue = TxtCariSoyad.Text;
            string textBoxCariTelValue = TxtCariTel.Text;
            string textBoxCariMailValue = TxtCariMail.Text;
            string CmbCariilValue = CmbCariil.Text;
            string CmbCariilceValue = CmbCariilce.Text;
            string textBoxCariBankaValue = TxtCariBanka.Text;
            string textBoxCariVDaireValue = TxtCariVDaire.Text;
            string textBoxCariVergiNoValue = TxtCariVNo.Text;
            string textBoxCariStatuValue = TxtStatu.Text;
            string textBoxCariAdresValue = TxtCariAdres.Text;

            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxCariIDValue) ||
                string.IsNullOrWhiteSpace(textBoxCariAdValue) ||
                string.IsNullOrWhiteSpace(textBoxCariSoyadValue) ||
                string.IsNullOrWhiteSpace(textBoxCariTelValue) ||
                string.IsNullOrWhiteSpace(textBoxCariMailValue) ||
                string.IsNullOrWhiteSpace(CmbCariilValue) ||
                string.IsNullOrWhiteSpace(CmbCariilceValue) ||
                 string.IsNullOrWhiteSpace(textBoxCariBankaValue) ||
                string.IsNullOrWhiteSpace(textBoxCariVDaireValue) ||
                string.IsNullOrWhiteSpace(textBoxCariVergiNoValue) ||
                 string.IsNullOrWhiteSpace(textBoxCariStatuValue) ||
                string.IsNullOrWhiteSpace(textBoxCariAdresValue)


                )
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }
            // Silinecek ID'yi al
            int idToDelete = int.Parse(TxtCariID.Text);
            var deger = db.TBLCARI.Find(idToDelete);
            db.TBLCARI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            TxtCariID.Text = " ";
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLCARI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtCariID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }





            TxtCariAd.Text = " ";
            TxtCariSoyad.Text = " ";
            TxtCariTel.Text = " ";
            TxtCariMail.Text = " ";
            CmbCariil.Text = " ";
            CmbCariilce.Text = " ";
            TxtCariBanka.Text = " ";
            TxtCariVDaire.Text = " ";
            TxtCariVNo.Text = " ";
            TxtStatu.Text = " ";
            TxtCariAdres.Text = " ";
        }

        private void BtnCariGuncelle_Click(object sender, EventArgs e)
        {
            // TextBox'ların değerlerini al
            string textBoxCariIDValue = TxtCariID.Text;
            string textBoxCariAdValue = TxtCariAd.Text;
            string textBoxCariSoyadValue = TxtCariSoyad.Text;
            string textBoxCariTelValue = TxtCariTel.Text;
            string textBoxCariMailValue = TxtCariMail.Text;
            string CmbCariilValue = CmbCariil.Text;
            string CmbCariilceValue = CmbCariilce.Text;
            string textBoxCariBankaValue = TxtCariBanka.Text;
            string textBoxCariVDaireValue = TxtCariVDaire.Text;
            string textBoxCariVergiNoValue = TxtCariVNo.Text;
            string textBoxCariStatuValue = TxtStatu.Text;
            string textBoxCariAdresValue = TxtCariAdres.Text;

            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxCariIDValue) ||
                string.IsNullOrWhiteSpace(textBoxCariAdValue) ||
                string.IsNullOrWhiteSpace(textBoxCariSoyadValue) ||
                string.IsNullOrWhiteSpace(textBoxCariTelValue) ||
                string.IsNullOrWhiteSpace(textBoxCariMailValue) ||
                string.IsNullOrWhiteSpace(CmbCariilValue) ||
                string.IsNullOrWhiteSpace(CmbCariilceValue) ||
                 string.IsNullOrWhiteSpace(textBoxCariBankaValue) ||
                string.IsNullOrWhiteSpace(textBoxCariVDaireValue) ||
                string.IsNullOrWhiteSpace(textBoxCariVergiNoValue) ||
                 string.IsNullOrWhiteSpace(textBoxCariStatuValue) ||
                string.IsNullOrWhiteSpace(textBoxCariAdresValue)


                )
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }

            var urunID = byte.Parse(TxtCariID.Text);
            var urun = db.TBLCARI.Find(urunID);

            if (urun != null)
            {


                // Diğer özellikleri güncelle
                urun.AD = TxtCariAd.Text;
                urun.SOYAD=TxtCariSoyad.Text;
                urun.TELEFON=TxtCariTel.Text;
                urun.MAIL=TxtCariMail.Text;
                urun.IL=CmbCariil.Text;
                urun.ILCE=CmbCariilce.Text;
                urun.BANKA=TxtCariBanka.Text;
                urun.VERGIDAIRESI=TxtCariVDaire.Text;
                urun.VERGINO=TxtCariVNo.Text;
                urun.STATU=TxtStatu.Text;
                urun.ADRES=TxtCariAdres.Text;

                // Değişiklikleri kaydet
                db.SaveChanges();

                MessageBox.Show("Ürün başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Ürün bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLCARI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtCariID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
         
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
      
    

            try
            {
                // Satırın endeksini kontrol et
                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
                {
                    // Tıklanan hücrenin değerini al
                    DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                    // Hücrenin değerlerini farklı TextBox'lara atar
                    TxtCariID.Text = selectedRow.Cells["ID"].Value?.ToString();
                    TxtCariAd.Text = selectedRow.Cells["AD"].Value?.ToString();
                    TxtCariSoyad.Text = selectedRow.Cells["SOYAD"].Value?.ToString();
                    TxtCariTel.Text = selectedRow.Cells["TELEFON"].Value?.ToString();
                    TxtCariMail.Text = selectedRow.Cells["MAIL"].Value?.ToString();
                    CmbCariil.Text = selectedRow.Cells["IL"].Value?.ToString();
                    CmbCariilce.Text = selectedRow.Cells["ILCE"].Value?.ToString();
                    TxtCariBanka.Text = selectedRow.Cells["BANKA"].Value?.ToString();
                    TxtCariVDaire.Text = selectedRow.Cells["VERGIDAIRESI"].Value?.ToString();
                    TxtCariVNo.Text = selectedRow.Cells["VERGINO"].Value?.ToString();
                    TxtStatu.Text = selectedRow.Cells["STATU"].Value?.ToString();
                    TxtCariAdres.Text = selectedRow.Cells["ADRES"].Value?.ToString();
                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}

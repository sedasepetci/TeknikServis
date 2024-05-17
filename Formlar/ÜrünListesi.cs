using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace Deneme.Formlar
{
    public partial class ÜrünListesi : Form
    {
        public ÜrünListesi()
        {
            InitializeComponent();
        }

        Model3 db = new Model3();
        void metot1()
        {

            try
            {
                // Verileri çek
                var degerler = db.TBLURUN.Select(x => new
                {
                    ID = x.ID,
                    AD = x.AD,
                    MARKA = x.MARKA,
                    KATEGORI=x.TBLKATEGORI.AD,
                    STOK = x.STOK,
                    ALISFIYAT = x.ALISFIYAT,
                    SATISFIYAT = x.SATISFIYAT, 
                   
                   
                }).ToList();

                // DataGridView'e verileri bağla
                dataGridView1.DataSource = degerler;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {

            metot1();
           
            this.FormBorderStyle = FormBorderStyle.None;
            // Veritabanından kategorileri çek
            using (var dbContext = new Model3())
            {
                List<TBLKATEGORI> categories = dbContext.TBLKATEGORI.ToList();

                // Combobox'a çekilen kategori verilerini ekle
                foreach (TBLKATEGORI category in categories)
                {
                    CmbKategori.Items.Add(category.AD);
                }
            }
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                int sonID = db.TBLURUN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                int sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }


        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                int sonID = db.TBLURUN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                int sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtUrunAd.Text = " ";
            TxtMarka.Text = " ";
            TxtAlisFiyat.Text = " ";
            TxtSatisFiyat.Text = " ";
            TxtStok.Text = " ";
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {

            // TextBox'ların değerlerini al
            string textBoxIDValue = TxtID.Text;
            string textBoxUrunAdValue = TxtUrunAd.Text;
            string textBoxMarkaValue = TxtMarka.Text;
            string textBoxAlisFiyatValue = TxtAlisFiyat.Text;
            string textBoxSatisFiyatValue = TxtSatisFiyat.Text;
            string textBoxStokValue = TxtStok.Text;
            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxIDValue) ||
                string.IsNullOrWhiteSpace(textBoxUrunAdValue) ||
                string.IsNullOrWhiteSpace(textBoxMarkaValue) ||
                string.IsNullOrWhiteSpace(textBoxAlisFiyatValue) ||
                string.IsNullOrWhiteSpace(textBoxSatisFiyatValue) ||
                string.IsNullOrWhiteSpace(textBoxStokValue))
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }
            // Silinecek ID'yi al
            int idToDelete = int.Parse(TxtID.Text);
            var deger=db.TBLURUN.Find(idToDelete);
            db.TBLURUN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            TxtID.Text = " ";
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                int sonID = db.TBLURUN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                int sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtUrunAd.Text = " ";
            TxtMarka.Text = " ";
            TxtAlisFiyat.Text = " ";
            TxtSatisFiyat.Text = " ";
            TxtStok.Text = " ";
        }
    
        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {

            // TextBox'ların değerlerini al
            string textBoxIDValue = TxtID.Text;
            string textBoxUrunAdValue = TxtUrunAd.Text;
            string textBoxMarkaValue = TxtMarka.Text;
            string textBoxAlisFiyatValue = TxtAlisFiyat.Text;
            string textBoxSatisFiyatValue = TxtSatisFiyat.Text;
            string textBoxStokValue = TxtStok.Text;
            string comboBoxKategoriValue = CmbKategori.Text;

            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxIDValue) ||
                string.IsNullOrWhiteSpace(textBoxUrunAdValue) ||
                string.IsNullOrWhiteSpace(textBoxMarkaValue) ||
                string.IsNullOrWhiteSpace(textBoxAlisFiyatValue) ||
                string.IsNullOrWhiteSpace(textBoxSatisFiyatValue) ||
                string.IsNullOrWhiteSpace(textBoxStokValue) ||
                string.IsNullOrWhiteSpace(comboBoxKategoriValue)
                )
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }

            // CmbKategori'den seçilen kategori adını al
            string secilenKategoriAdi = CmbKategori.Text;

            // TBLKATEGORI tablosundan seçilen kategori adına göre ilgili kategori nesnesini bul
            var secilenKategori = db.TBLKATEGORI.FirstOrDefault(k => k.AD == secilenKategoriAdi);
            // TextBox'lar dolu ise kayıt işlemini gerçekleştir
            try
            {
                // TBLURUN nesnesi oluştur
                TBLURUN t1 = new TBLURUN();

                // TextBox değerlerini TBLURUN nesnesine ata
                t1.ID = int.Parse(textBoxIDValue);
                t1.AD = textBoxUrunAdValue;
                t1.MARKA = textBoxMarkaValue;
                t1.ALISFIYAT = decimal.Parse(textBoxAlisFiyatValue);
                t1.SATISFIYAT = decimal.Parse(textBoxSatisFiyatValue);
                t1.STOK = short.Parse(textBoxStokValue);
             
                    t1.KATEGORI = secilenKategori.ID;

                // Veritabanına kaydet
                db.TBLURUN.Add(t1);
                db.SaveChanges();

                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int yeniID = int.Parse(TxtID.Text) + 1; // Mevcut ID'yi bir artır
                TxtID.Text = yeniID.ToString(); // Yeni ID'yi Textbox'a atar


            }

            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TxtID.Text = " ";
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                int sonID = db.TBLURUN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
                
                // Bir sonraki ID'yi belirle
                int sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtUrunAd.Text = " ";
            TxtMarka.Text = " ";
            TxtAlisFiyat.Text = " ";
            TxtSatisFiyat.Text = " ";
            TxtStok.Text = " ";
           

          
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
                    TxtID.Text = selectedRow.Cells["ID"].Value?.ToString();
                    TxtUrunAd.Text = selectedRow.Cells["AD"].Value?.ToString();
                    TxtMarka.Text = selectedRow.Cells["MARKA"].Value?.ToString();
                    TxtAlisFiyat.Text = selectedRow.Cells["ALISFIYAT"].Value?.ToString();
                    TxtSatisFiyat.Text = selectedRow.Cells["SATISFIYAT"].Value?.ToString();
                    TxtStok.Text = selectedRow.Cells["STOK"].Value?.ToString();
                    CmbKategori.Text=selectedRow.Cells["KATEGORI"].Value?.ToString();
                    // Kategori ID'sini al
                    byte kategoriID;
                    if (byte.TryParse(selectedRow.Cells["KATEGORI"].Value?.ToString(), out kategoriID))
                    {
                        // Kategori ID'sine göre veritabanından ilgili kategori adını al
                        var kategoriAd = db.TBLKATEGORI.FirstOrDefault(cat => cat.ID == kategoriID)?.AD;

                        // Kategori adını CmbKategori'ye seçili olarak ayarla
                        if (kategoriAd != null)
                        {
                          
                            CmbKategori.Text = kategoriAd;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }
            
        

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            // TextBox'ların değerlerini al
            string textBoxIDValue = TxtID.Text;
            string textBoxUrunAdValue = TxtUrunAd.Text;
            string textBoxMarkaValue = TxtMarka.Text;
            string textBoxAlisFiyatValue = TxtAlisFiyat.Text;
            string textBoxSatisFiyatValue = TxtSatisFiyat.Text;
            string textBoxStokValue = TxtStok.Text;

            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxIDValue) ||
                string.IsNullOrWhiteSpace(textBoxUrunAdValue) ||
                string.IsNullOrWhiteSpace(textBoxMarkaValue) ||
                string.IsNullOrWhiteSpace(textBoxAlisFiyatValue) ||
                string.IsNullOrWhiteSpace(textBoxSatisFiyatValue) ||
                string.IsNullOrWhiteSpace(textBoxStokValue))
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tablodan seçim işlemini gerçekleştiriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }
           
            // CmbKategori'den seçilen kategori adını al
            string secilenKategoriAdi = CmbKategori.Text;

            // TBLKATEGORI tablosundan seçilen kategori adına göre ilgili kategori nesnesini bul
            var secilenKategori = db.TBLKATEGORI.FirstOrDefault(k => k.AD == secilenKategoriAdi);

            if (secilenKategori != null)
            {
                // Eğer seçilen kategori varsa, ilgili ürünün kategori ID'sini güncelle
                int urunID = int.Parse(TxtID.Text);
                var urun = db.TBLURUN.Find(urunID);

                if (urun != null)
                {
                    // Kategori adını kullanarak ilgili ürünün kategori sütununu güncelle
                    urun.KATEGORI = secilenKategori.ID;

                    // Diğer özellikleri güncelle
                    urun.AD = TxtUrunAd.Text;
                    urun.STOK = short.Parse(TxtStok.Text);
                    urun.MARKA = TxtMarka.Text;
                    urun.ALISFIYAT = decimal.Parse(TxtAlisFiyat.Text);
                    urun.SATISFIYAT = decimal.Parse(TxtSatisFiyat.Text);

                    // Değişiklikleri kaydet
                    db.SaveChanges();

                    MessageBox.Show("Ürün başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ürün bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seçilen kategori bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TxtID.Text = " ";
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                int sonID = db.TBLURUN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                int sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtUrunAd.Text = " ";
            TxtMarka.Text = " ";
            TxtAlisFiyat.Text = " ";
            TxtSatisFiyat.Text = " ";
            TxtStok.Text = " ";

        }

        private void ÜrünListesi_MouseDown(object sender, MouseEventArgs e)
        {
         
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deneme.Formlar
{
    public partial class DepartmanFormu : Form
    {
        public DepartmanFormu()
        {
            InitializeComponent();
        }
        void metot1()
        {

            try
            {
                // Verileri çek
                var degerler = db.TBLDEPARTMAN.Select(x => new
                {
                    ID = x.ID,
                    AD = x.AD,
                    ACIKLAMA = x.ACIKLAMA,
                 
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
        TBLDEPARTMAN t1 = new TBLDEPARTMAN();
        private void DepartmanFormu_Load(object sender, EventArgs e)
        {
          
            this.FormBorderStyle = FormBorderStyle.None;
            metot1();

            label14.Text=db.TBLDEPARTMAN.Count().ToString();
            label16.Text=db.TBLPERSONEL.Count().ToString();
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLDEPARTMAN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
         

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            
          // TextBox'ların değerlerini al
            string TextIDValue = TxtID.Text;
            string TextADValue = TxtAD.Text;
            string ListAciklamaValue = RichAciklama.Text;
       

            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(TextIDValue) ||
                string.IsNullOrWhiteSpace(TextADValue) ||
                string.IsNullOrWhiteSpace(ListAciklamaValue) 
           


                )
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }

            // TextBox'lar dolu ise kayıt işlemini gerçekleştir
            try
            {


                // TextBox değerlerini TBLDEPARTMAN nesnesine ata
                t1.ID = byte.Parse(TextIDValue);
                t1.AD = TextADValue;
                t1.ACIKLAMA = ListAciklamaValue;
         

                // Veritabanına kaydet
                db.TBLDEPARTMAN.Add(t1);
                db.SaveChanges();

                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int yeniID = int.Parse(TxtID.Text) + 1; // Mevcut ID'yi bir artır
                TxtID.Text = yeniID.ToString(); // Yeni ID'yi Textbox'a atar


            }

            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLDEPARTMAN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtAD.Text = " ";
            RichAciklama.Text = " ";
           
        

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            // TextBox'ların değerlerini al
            string TextIDValue = TxtID.Text;
            string TextADValue = TxtAD.Text;
            string ListAciklamaValue = RichAciklama.Text;


            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(TextIDValue) ||
                string.IsNullOrWhiteSpace(TextADValue) ||
                string.IsNullOrWhiteSpace(ListAciklamaValue)
                )

            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }
            // Silinecek ID'yi al
            int idToDelete = int.Parse(TxtID.Text);
            var deger = db.TBLDEPARTMAN.Find(idToDelete);
            db.TBLDEPARTMAN.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            TxtID.Text = " ";
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLDEPARTMAN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtAD.Text = " ";
            RichAciklama.Text = " ";
           
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
                    TxtAD.Text = selectedRow.Cells["AD"].Value?.ToString();
                    RichAciklama.Text = selectedRow.Cells["ACIKLAMA"].Value?.ToString();
                 

                
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLDEPARTMAN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtAD.Text = " ";
            RichAciklama.Text = " ";
         
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            // TextBox'ların değerlerini al
            string TextIDValue = TxtID.Text;
            string TextADValue = TxtAD.Text;
            string ListAciklamaValue = RichAciklama.Text;


            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(TextIDValue) ||
                string.IsNullOrWhiteSpace(TextADValue) ||
                string.IsNullOrWhiteSpace(ListAciklamaValue)
                )


            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tablodan seçim işlemini gerçekleştiriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }

            var urunID = byte.Parse(TxtID.Text);
            var urun = db.TBLDEPARTMAN.Find(urunID);

            if (urun != null)
            {


                // Diğer özellikleri güncelle
                urun.AD = TxtAD.Text;
                urun.ACIKLAMA = RichAciklama.Text;

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
                var sonID = db.TBLDEPARTMAN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtAD.Text = " ";

        }
    }
}


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
namespace Deneme.Formlar
{
    public partial class Kategori : Form
    {
        public Kategori()
        {
            InitializeComponent();
        }
       Model3 db = new Model3();
        void kategoritablo()
        {

            try
            {
                // Verileri çek
                var degerler = db.TBLKATEGORI.Select(k => new
                {
                    ID = k.ID,
                    AD = k.AD,



                }).ToList();

                // DataGridView'e verileri bağla
                dataGridView1.DataSource = degerler;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
        }
        private void Kategori_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.None;
            var degerler = db.TBLKATEGORI.ToList();
            dataGridView1.DataSource = degerler;
            kategoritablo();
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLKATEGORI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtKategoriID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
        }


        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            // TextBox'ların değerlerini al
            string textBoxKategoriIDValue = TxtKategoriID.Text;
            string textBoxKategoriAdValue = TxtKategoriAd.Text;


            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxKategoriIDValue) ||
                string.IsNullOrWhiteSpace(textBoxKategoriAdValue)

                )
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }

            // TextBox'lar dolu ise kayıt işlemini gerçekleştir
            try
            {
                // TBLKATEGORI nesnesi oluştur
                TBLKATEGORI t1 = new TBLKATEGORI();

                // TextBox değerlerini TBLKATEGORI nesnesine ata
                t1.ID = byte.Parse(textBoxKategoriIDValue);
                t1.AD = textBoxKategoriAdValue;


                // Veritabanına kaydet
                db.TBLKATEGORI.Add(t1);
                db.SaveChanges();

                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var yeniID = byte.Parse(TxtKategoriID.Text) + 1; // Mevcut ID'yi bir artır
                TxtKategoriID.Text = yeniID.ToString(); // Yeni ID'yi Textbox'a atar


            }

            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            TxtKategoriID.Text = " ";
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLKATEGORI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtKategoriID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtKategoriAd.Text = " ";




        }

        private void BtnListele_Click(object sender, EventArgs e)
        {

            kategoritablo();
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLKATEGORI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtKategoriID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtKategoriAd.Text = " ";

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
                    TxtKategoriID.Text = selectedRow.Cells["ID"].Value?.ToString();
                    TxtKategoriAd.Text = selectedRow.Cells["AD"].Value?.ToString();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }
        
        private void BtnSil_Click(object sender, EventArgs e)
        {

            // TextBox'ların değerlerini al
            string textBoxKategoriIDValue = TxtKategoriID.Text;
            string textBoxKategoriAdValue = TxtKategoriAd.Text;

            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxKategoriIDValue) ||
                string.IsNullOrWhiteSpace(textBoxKategoriAdValue)

                )
            { 
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }
            // Silinecek ID'yi al
            int idToDelete = int.Parse(TxtKategoriID.Text);
            var deger = db.TBLKATEGORI.Find(idToDelete);
            db.TBLKATEGORI.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            TxtKategoriID.Text = " ";
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLKATEGORI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtKategoriID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtKategoriAd.Text = " ";
        
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            // TextBox'ların değerlerini al
            string textBoxKategoriIDValue = TxtKategoriID.Text;
            string textBoxKategoriAdValue = TxtKategoriAd.Text;
         

            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxKategoriIDValue) ||
                string.IsNullOrWhiteSpace(textBoxKategoriAdValue) )
              
           
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tablodan seçim işlemini gerçekleştiriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }

                // Eğer seçilen kategori varsa, ilgili ürünün kategori ID'sini güncelle
                var urunID = byte.Parse(TxtKategoriID.Text);
                var urun = db.TBLKATEGORI.Find(urunID);

                if (urun != null)
                {
                 

                    // Diğer özellikleri güncelle
                    urun.AD = TxtKategoriAd.Text;
               

                    // Değişiklikleri kaydet
                    db.SaveChanges();

                    MessageBox.Show("Ürün başarıyla güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ürün bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
           
            TxtKategoriID.Text = " ";
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLKATEGORI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtKategoriID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            TxtKategoriAd.Text = " ";
         

        }

    }
}
    
    


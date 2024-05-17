using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Deneme.Formlar
{
    public partial class PersonelForm : Form
    {
        public PersonelForm()
        {
            InitializeComponent();
        }
        Model3 db=new Model3();
        void metot1()
        {

            try
            {
                // Verileri çek
                var degerler = db.TBLPERSONEL.Select(x => new
                {
                    ID = x.ID,
                    AD = x.AD,
                    SOYAD= x.SOYAD,
                    MAIL= x.MAIL,
                    TELEFON= x.TELEFON,
                    DEPARTMAN= x.TBLDEPARTMAN.AD,

                }).ToList();


                // DataGridView'e verileri bağla
                dataGridView1.DataSource = degerler;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
        }
       
        private void PersonelForm_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.None;
            metot1();
            // TBLDEPARTMAN tablosundan verileri al
            var departmanlar = db.TBLDEPARTMAN.ToList();

            // ComboBox'in DataSource özelliğini departmanlar listesiyle ayarla
            CmbDepartman.DataSource = departmanlar;

            // ComboBox'te görüntülenecek sütunları belirt
            CmbDepartman.DisplayMember = "AD"; // Departman adı varsayılan olarak görüntülenecek
            CmbDepartman.ValueMember = "ID"; // Departman ID'si değer olarak kullanılacak
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLPERSONEL.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }

            label4.Text=db.TBLPERSONEL.First(x=>x.ID==1).ToString();
            string ad1, soyad1;
            string ad2, soyad2;
            string ad3, soyad3;
            ad1 = db.TBLPERSONEL.First(x => x.ID == 1).AD;
            soyad1 = db.TBLPERSONEL.First(x => x.ID == 1).SOYAD;
            // İlgili personelin ID'si ile departman adını al
            var personelDepartmanAdi = (from personel in db.TBLPERSONEL
                                        join departman in db.TBLDEPARTMAN on personel.ID equals departman.ID
                                        where personel.ID == 1
                                        select departman.AD).FirstOrDefault();

            // Label'a departman adını atama
            label5.Text = personelDepartmanAdi ?? "Departman Bulunamadı";
            label8.Text = db.TBLPERSONEL.First(x => x.ID == 1).MAIL;
            label4.Text = ad1 + " " + soyad1;
            //---------------------->
            ad2 = db.TBLPERSONEL.First(x => x.ID == 5).AD;
            soyad2 = db.TBLPERSONEL.First(x => x.ID == 5).SOYAD;
            // İlgili personelin ID'si ile departman adını al
            var personelDepartmanAdi3 = (from personel in db.TBLPERSONEL
                                        join departman in db.TBLDEPARTMAN on personel.ID equals departman.ID
                                        where personel.ID == 3
                                        select departman.AD).FirstOrDefault();

            // Label'a departman adını atama
            label13.Text = personelDepartmanAdi3 ?? "Departman Bulunamadı";
            label10.Text = db.TBLPERSONEL.First(x => x.ID == 5).MAIL;
            label21.Text = ad2 + " " + soyad2;
            //---------------------->
            //---------------------->
            ad3 = db.TBLPERSONEL.First(x => x.ID == 2).AD;
            soyad3 = db.TBLPERSONEL.First(x => x.ID == 2).SOYAD;
            // İlgili personelin ID'si ile departman adını al
            var personelDepartmanAdi2 = (from personel in db.TBLPERSONEL
                                         join departman in db.TBLDEPARTMAN on personel.ID equals departman.ID
                                         where personel.ID == 2
                                         select departman.AD).FirstOrDefault();

            // Label'a departman adını atama
            label16.Text = personelDepartmanAdi2 ?? "Departman Bulunamadı";
            label14.Text = db.TBLPERSONEL.First(x => x.ID == 2).MAIL;
            label18.Text = ad3 + " " + soyad3;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            metot1();
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                int sonID = db.TBLPERSONEL.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                int sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }

            TxtAD.Text = " ";
            TxtSoyad.Text = " ";
            CmbDepartman.Text = " ";
            TxtMail.Text = " ";
            MskTel.Text = " ";
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            { 
                // TextBox'ların değerlerini al
                string textBoxIDValue = TxtID.Text;
                string textBoxAdValue = TxtAD.Text;
                string textBoxSoyadValue = TxtSoyad.Text;
                string comboBoxDepartmanValue = CmbDepartman.Text;
                string textBoxMailValue = TxtMail.Text;
                string maskBoxTelefonValue = MskTel.Text;

                // TextBox'ların boş olup olmadığını kontrol et
                if (string.IsNullOrWhiteSpace(textBoxIDValue) ||
                    string.IsNullOrWhiteSpace(textBoxAdValue) ||
                    string.IsNullOrWhiteSpace(textBoxSoyadValue) ||
                    string.IsNullOrWhiteSpace(comboBoxDepartmanValue) ||
                    string.IsNullOrWhiteSpace(textBoxMailValue) ||
                    string.IsNullOrWhiteSpace(maskBoxTelefonValue))
                {
                    // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                    MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // İşlemi durdur ve daha fazla ileri gitme
                }

                // TBLKATEGORI tablosundan seçilen kategori adına göre ilgili kategori nesnesini bul
                var secilenDepartman = db.TBLDEPARTMAN.FirstOrDefault(k => k.AD == comboBoxDepartmanValue);

                // TextBox'lar dolu ise kayıt işlemini gerçekleştir
                try
                {
                    // TBLURUN nesnesi oluştur
                    TBLPERSONEL t1 = new TBLPERSONEL();

                    // TextBox değerlerini TBLURUN nesnesine ata
                    t1.ID = byte.Parse(textBoxIDValue);
                    t1.AD = textBoxAdValue;
                    t1.SOYAD = textBoxSoyadValue;
                    t1.DEPARTMAN = secilenDepartman.ID;
                    t1.MAIL = textBoxMailValue;
                    t1.TELEFON = maskBoxTelefonValue;

                    // Veritabanına kaydet
                    db.TBLPERSONEL.Add(t1);
                    db.SaveChanges();
                 

                    MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Yeni bir ID atanması gerektiğinden, otomatik artış özelliği kullanıldıysa ID alanı boşaltılabilir.
                    TxtID.Clear();
                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kayıt eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Yeni bir ID atanması gerektiğinden, otomatik artış özelliği kullanıldıysa ID alanı yeniden doldurulabilir.
                try
                {
                    var sonID = db.TBLPERSONEL.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();
                    var sonrakiID = sonID + 1;
                    TxtID.Text = sonrakiID.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                }

                // Diğer alanları temizle
                TxtAD.Clear();
                TxtSoyad.Clear();
                CmbDepartman.SelectedIndex = -1; // ComboBox'ı temizle
                TxtMail.Clear();
                MskTel.Clear();
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
                    TxtID.Text = selectedRow.Cells["ID"].Value?.ToString();
                    TxtAD.Text = selectedRow.Cells["AD"].Value?.ToString();
                    TxtSoyad.Text = selectedRow.Cells["SOYAD"].Value?.ToString();
                  CmbDepartman.Text = selectedRow.Cells["DEPARTMAN"].Value?.ToString();
                    TxtMail.Text = selectedRow.Cells["MAIL"].Value?.ToString();
                    MskTel.Text = selectedRow.Cells["TELEFON"].Value?.ToString();


                  
                    // Kategori ID'sini al
                    byte kategoriID;
                    if (byte.TryParse(selectedRow.Cells["DEPARTMAN"].Value?.ToString(), out kategoriID))
                    {
                        // Kategori ID'sine göre veritabanından ilgili kategori adını al
                        var kategoriAd = db.TBLDEPARTMAN.FirstOrDefault(cat => cat.ID == kategoriID)?.AD;

                        // Kategori adını CmbKategori'ye seçili olarak ayarla
                        if (kategoriAd != null)
                        {

                            CmbDepartman.Text = kategoriAd;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            // TextBox'ların değerlerini al
            string textBoxIDValue = TxtID.Text;
            string textBoxAdValue = TxtAD.Text;
            string textBoxSoyadValue = TxtSoyad.Text;
            string comboBoxDepartmanValue = CmbDepartman.Text;
            string textBoxMailValue = TxtMail.Text;
            string maskBoxTelefonValue = MskTel.Text;
            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxIDValue) ||
                string.IsNullOrWhiteSpace(textBoxAdValue) ||
                string.IsNullOrWhiteSpace(textBoxSoyadValue) ||
                string.IsNullOrWhiteSpace(comboBoxDepartmanValue) ||
                string.IsNullOrWhiteSpace(textBoxMailValue) ||
                string.IsNullOrWhiteSpace(maskBoxTelefonValue))
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }
            // Silinecek ID'yi al
            var idToDelete = byte.Parse(TxtID.Text);
            var deger = db.TBLPERSONEL.Find(idToDelete);
            db.TBLPERSONEL.Remove(deger);
            db.SaveChanges();
            MessageBox.Show("Ürün başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            TxtID.Text = " ";
            try
            {
                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLPERSONEL.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TextBox'a yerleştir
                TxtID.Text = sonrakiID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message);
            }
            // Diğer alanları temizle
            TxtAD.Clear();
            TxtSoyad.Clear();
            CmbDepartman.SelectedIndex = -1; // ComboBox'ı temizle
            TxtMail.Clear();
            MskTel.Clear();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            // TextBox'ların değerlerini al
            string textBoxIDValue = TxtID.Text;
            string textBoxAdValue = TxtAD.Text;
            string textBoxSoyadValue = TxtSoyad.Text;
            string comboBoxDepartmanValue = CmbDepartman.Text;
            string textBoxMailValue = TxtMail.Text;
            string maskBoxTelefonValue = MskTel.Text;
            // TextBox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(textBoxIDValue) ||
                string.IsNullOrWhiteSpace(textBoxAdValue) ||
                string.IsNullOrWhiteSpace(textBoxSoyadValue) ||
                string.IsNullOrWhiteSpace(comboBoxDepartmanValue) ||
                string.IsNullOrWhiteSpace(textBoxMailValue) ||
                string.IsNullOrWhiteSpace(maskBoxTelefonValue))
            {
                // Bir veya daha fazla TextBox boşsa uyarı mesajı göster
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur ve daha fazla ileri gitme
            }

            // CmbKategori'den seçilen kategori adını al
            string secilenDepartmanAdi = CmbDepartman.Text;

            // TBLKATEGORI tablosundan seçilen kategori adına göre ilgili kategori nesnesini bul
            var secilenDepartman = db.TBLDEPARTMAN.FirstOrDefault(k => k.AD == secilenDepartmanAdi);

            if (secilenDepartman != null)
            {
                // Eğer seçilen kategori varsa, ilgili ürünün kategori ID'sini güncelle
                var urunID = byte.Parse(TxtID.Text);
                var urun = db.TBLPERSONEL.Find(urunID);

                if (urun != null)
                {
                    // Kategori adını kullanarak ilgili ürünün kategori sütununu güncelle
                    urun.DEPARTMAN = secilenDepartman.ID;

                    // Diğer özellikleri güncelle
                    urun.AD = TxtAD.Text;
                    urun.SOYAD =TxtSoyad.Text;
                   
                    urun.MAIL = TxtMail.Text;
                    urun.TELEFON = MskTel.Text;

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
            // Diğer alanları temizle
            TxtAD.Clear();
            TxtSoyad.Clear();
            CmbDepartman.SelectedIndex = -1; // ComboBox'ı temizle
            TxtMail.Clear();
            MskTel.Clear();
        }
    }
    }


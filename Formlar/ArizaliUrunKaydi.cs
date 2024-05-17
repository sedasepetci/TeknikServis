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
    public partial class ArizaliUrunKaydi : Form
    {
        public ArizaliUrunKaydi()
        {
            InitializeComponent();
        }
        Model3 db=new Model3();
        private int GetNextID()
        {
            using (var db = new Model3())
            {
                // TBLURUN tablosundaki en yüksek ID'yi al
                int maxID = db.TBLURUNKABUL.Max(x => (int?)x.ISLEMID) ?? 0;

                // Bir sonraki ID'yi belirle
                int nextID = maxID + 1;

                return nextID;
            }
        }
        private void ArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
           
        }

        private void BtnSatisYap_Click(object sender, EventArgs e)
        {

            try
            {
             
                TBLURUNKABUL t = new TBLURUNKABUL(); // Yeni bir TBLURUNKABUL nesnesi oluştur

                // ID'yi al
                int nextID = GetNextID();
                t.ISLEMID = nextID; // Yeni ID'yi ata

                // TextBox'lardan gerekli verileri al ve TBLURUN nesnesine ata
                t.CARI = int.Parse(TxtID.Text);
                t.GELISTARIHI = DateTime.Parse(maskedTextBox1.Text); 
                t.PERSONEL = short.Parse(TxtPersonel.Text);
                t.URUNSERINO = maskedTextBox2.Text;

                // Yeni nesneyi veritabanına ekleyerek kaydet
                db.TBLURUNKABUL.Add(t);
                db.SaveChanges();

                MessageBox.Show("Satış başarıyla yapıldı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Değişiklikleri kaydetmekten vazgeçmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Eğer kullanıcı "Evet" seçeneğini seçerse
            if (result == DialogResult.Yes)
            {
                // Formu yenileme işlemi
                this.Controls.Clear(); // Form üzerindeki tüm kontrolleri temizleme
                InitializeComponent(); // Yeniden başlatma


            }
        }
    }
}

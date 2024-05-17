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
    public partial class YeniÜrün : Form
    {
        public YeniÜrün()
        {
            InitializeComponent();
        }

        private void YeniÜrün_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
           

        }
        private int GetNextID()
        {
            using (var db = new Model3())
            {
                // TBLURUN tablosundaki en yüksek ID'yi al
                int maxID = db.TBLURUN.Max(x => (int?)x.ID) ?? 0;

                // Bir sonraki ID'yi belirle
                int nextID = maxID + 1;

                return nextID;
            }
        }

        private void BtnUrunKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Model3 db = new Model3();

                TBLURUN t = new TBLURUN(); // Yeni bir TBLURUN nesnesi oluştur

                // ID'yi al
                int nextID = GetNextID();
                t.ID = nextID; // Yeni ID'yi ata

                // TextBox'lardan gerekli verileri al ve TBLURUN nesnesine ata
                t.AD = TxtUrunAd.Text;
                t.MARKA = TxtUrunMarka.Text;
                t.ALISFIYAT = decimal.Parse(TxtUrunAlis.Text);
                t.SATISFIYAT = decimal.Parse(TxtUrunSatis.Text);
                t.STOK = short.Parse(TxtUrunStok.Text);
                t.KATEGORI = byte.Parse(TxtUrunKategori.Text);

                // Yeni nesneyi veritabanına ekleyerek kaydet
                db.TBLURUN.Add(t);
                db.SaveChanges();

                MessageBox.Show("Ürün başarıyla kaydedildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }

        private void BtnUrunVazgec_Click(object sender, EventArgs e)
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

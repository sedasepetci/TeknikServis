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
    public partial class UrunSatis : Form
    {
        public UrunSatis()
        {
            InitializeComponent();
        }
        Model3 db=new Model3();
        private int GetNextID()
        {
            using (var db = new Model3())
            {
                // TBLURUN tablosundaki en yüksek ID'yi al
                int maxID = db.TBLURUNHAREKET.Max(x => (int?)x.HAREKETID) ?? 0;

                // Bir sonraki ID'yi belirle
                int nextID = maxID + 1;

                return nextID;
            }
        }

        private void UrunSatis_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
         
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnSatisYap_Click(object sender, EventArgs e)
        {

            try
            {
                Model3 db = new Model3();
                TBLURUNHAREKET t = new TBLURUNHAREKET(); // Yeni bir TBLURUNHAREKET nesnesi oluştur

                // ID'yi al
                int nextID = GetNextID();
                t.HAREKETID = nextID; // Yeni ID'yi ata

                // TextBox'lardan gerekli verileri al ve TBLURUN nesnesine ata
                t.URUN=int.Parse(TxtID.Text);
                t.MUSTERI = int.Parse(TxtMusteri.Text);
                t.PERSONEL = short.Parse(TxtPersonel.Text);
                t.TARIH = DateTime.Parse(TxtTarih.Text);
                t.ADET = short.Parse(TxtAdet.Text);
                t.FIYAT = decimal.Parse(TxtSatisFiyati.Text);
                t.URUNSERINO = TxtSeriNo.Text;

                // Yeni nesneyi veritabanına ekleyerek kaydet
                db.TBLURUNHAREKET.Add(t);
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


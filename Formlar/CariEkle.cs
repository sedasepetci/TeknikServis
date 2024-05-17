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
    public partial class CariEkle : Form
    {
        public CariEkle()
        {
            InitializeComponent();
        }
        Model3 db=new Model3();
        private void CariEkle_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private int GetNextID()
        {
            using (var db = new Model3())
            {
                // TBLURUN tablosundaki en yüksek ID'yi al
                int maxID = db.TBLCARI.Max(x => (int?)x.ID) ?? 0;

                // Bir sonraki ID'yi belirle
                int nextID = maxID + 1;

                return nextID;
            }
        }
        private void BtnCariKaydet_Click(object sender, EventArgs e)
        {
            TBLCARI t=new TBLCARI();
            try
            {
              

               
                // ID'yi al
                int nextID = GetNextID();
                t.ID = nextID; // Yeni ID'yi ata

                // TextBox'lardan gerekli verileri al ve TBLURUN nesnesine ata
                t.AD = TxtAd.Text;
                t.SOYAD = TxtSoyad.Text;
                t.IL= Txtil.Text;
                t.ILCE = Txtilce.Text;
            

                // Yeni nesneyi veritabanına ekleyerek kaydet
                db.TBLCARI.Add(t);
                db.SaveChanges();

                MessageBox.Show("Yeni cari başarıyla kaydedildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }

        }

        private void BtnCariVazgec_Click(object sender, EventArgs e)
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
    


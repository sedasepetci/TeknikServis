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
    public partial class YeniKategori : Form
    {
        public YeniKategori()
        {
            InitializeComponent();
        }
        Model3 db=new Model3();
        private void YeniKategori_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

        }

       

        private void BtnKKaydet_Click_1(object sender, EventArgs e)
        {
            // TextBox'ların değerlerini al
           
            string textBoxKategoriAdValue = TxtKAd.Text;
            try
            {
              
                // Veritabanındaki en son kaydın ID'sini al
                int sonID = db.TBLKATEGORI.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                int sonrakiID = sonID + 1;

                // TBLKATEGORI nesnesi oluştur
                TBLKATEGORI t1 = new TBLKATEGORI();
                t1.ID = (byte)sonrakiID;
                // TextBox değerlerini TBLURUN nesnesine ata
              
                t1.AD = textBoxKategoriAdValue;

                // Veritabanına kaydet
                db.TBLKATEGORI.Add(t1);
                db.SaveChanges();

                MessageBox.Show("Kayıt başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt eklenirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

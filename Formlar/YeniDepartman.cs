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
    public partial class YeniDepartman : Form
    {
        public YeniDepartman()
        {
            InitializeComponent();
        }
       Model3 db=new Model3();
        private void YeniDepartman_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // TextBox'ların değerlerini al

            string textBoxDepartmanAdValue = TxtAd.Text;
            try
            {

                // Veritabanındaki en son kaydın ID'sini al
                var sonID = db.TBLDEPARTMAN.OrderByDescending(x => x.ID).Select(x => x.ID).FirstOrDefault();

                // Bir sonraki ID'yi belirle
                var sonrakiID = sonID + 1;

                // TBLKATEGORI nesnesi oluştur
                TBLDEPARTMAN t1 = new TBLDEPARTMAN();
                t1.ID = (byte)sonrakiID;
                // TextBox değerlerini TBLURUN nesnesine ata

                t1.AD = textBoxDepartmanAdValue;

                // Veritabanına kaydet
                db.TBLDEPARTMAN.Add(t1);
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

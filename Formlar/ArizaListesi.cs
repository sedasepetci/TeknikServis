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
    public partial class ArizaListesi : Form
    {
        public ArizaListesi()
        {
            InitializeComponent();
        }
        Model3 db=new Model3();
        void metot1()
        {

            try
            {
                // Verileri çek
                var degerler = db.TBLURUNKABUL.Select(x => new
                {
                    ID = x.ISLEMID,
                    CARI= x.TBLCARI.AD +" "+ x.TBLCARI.SOYAD,
                    PERSONEL = x.TBLPERSONEL.AD +" "+ x.TBLPERSONEL.SOYAD,
                    GELISTARIHI= x.GELISTARIHI,
                    CIKISTARIHI = x.CIKISTARIHI,
                    URUNSERINO=x.URUNSERINO,


                }).ToList();

                // DataGridView'e verileri bağla
                dataGridView1.DataSource = degerler;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme hatası: " + ex.Message);
            }
        }
        private void ArizaListesi_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            metot1();
         
        }
    }
}

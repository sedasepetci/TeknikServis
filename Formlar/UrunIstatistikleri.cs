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
    public partial class UrunIstatistikleri : Form
    {
        public UrunIstatistikleri()
        {
            InitializeComponent();
        }
        Model3 db = new Model3();
        TBLURUN t=new TBLURUN();
        TBLKATEGORI k=new TBLKATEGORI();
        private void UrunIstatistikleri_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            label2.Text = db.TBLURUN.Count().ToString();
            label3.Text=db.TBLKATEGORI.Count().ToString();
            label5.Text=db.TBLURUN.Sum(x=>x.STOK).ToString();
            
            label15.Text=(from x in db.TBLURUN 
                          orderby x.STOK descending
                          select x.AD).FirstOrDefault();
            label13.Text=(from x in db.TBLURUN
                          orderby x.STOK ascending
                          select x.AD).FirstOrDefault();
            label11.Text=(from x in db.TBLURUN
                          orderby x.SATISFIYAT ascending
                          select x.AD).FirstOrDefault();
            label27.Text=db.TBLURUN.Count(x=>x.KATEGORI==5).ToString();
            label25.Text = db.TBLURUN.Count(x => x.KATEGORI == 2).ToString();
            label23.Text=(from x in db.TBLURUN
                          select x.MARKA).Distinct().Count().ToString();
        }

    }
}

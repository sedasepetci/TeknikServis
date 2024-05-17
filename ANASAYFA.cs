using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deneme
{
    public partial class ANASAYFA : Form
    {
        public ANASAYFA()
        {
            InitializeComponent();
        }
        Model3 db = new Model3();
        private void ANASAYFA_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.AD,
                                            x.STOK,
                                        }).Where(x => x.STOK < 30).ToList();

            dataGridView2.DataSource = (from y in db.TBLCARI
                                        select new
                                        {
                                            y.AD,
                                            y.SOYAD,
                                            y.IL
                                        }).ToList();
        
                                     

                                      
                                       

        }
    }
}

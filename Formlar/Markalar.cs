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

namespace Deneme.Formlar
{
    public partial class Markalar : Form
    {
        public Markalar()
        {
            InitializeComponent();
        }
        Model3 db = new Model3();

        private void Markalar_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            var degerler = db.TBLURUN
                            .GroupBy(y => y.MARKA)
                            .Select(z => new
                            {
                                Marka = z.Key,
                                Toplam = z.Count() // Her markanın toplam sayısını alır
                            })
                            .OrderBy(x => x.Marka); // Marka adına göre sıralama ekledim, isteğe bağlıdır

            dataGridView1.DataSource = degerler.ToList();
            label2.Text = db.TBLURUN.Count().ToString();
            label3.Text = (from x in db.TBLURUN
                           select x.MARKA).Distinct().Count().ToString();
            label5.Text = (from x in db.TBLURUN
                           orderby x.SATISFIYAT descending
                           select x.MARKA).FirstOrDefault();
            // Seri yoksa, önce bir seri ekleyin
            if (chart1.Series.IndexOf("Series1") == -1)
            {
                chart1.Series.Add("Series1");
            }

            // Yeni veri noktasını ekleyin
            chart1.Series["Series1"].Points.AddXY("SIEMENS", 2);
            chart1.Series["Series1"].Points.AddXY("BEKO", 1);
            chart1.Series["Series1"].Points.AddXY("LENOVO", 1);
            chart1.Series["Series1"].Points.AddXY("TOSHIBA", 1);
            chart1.Series["Series1"].Points.AddXY("SAMSUNG", 2);

           
        }

        private void chart1_Click(object sender, EventArgs e)
        {
          
        }
    }
}


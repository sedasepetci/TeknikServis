using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Deneme.Formlar
{
    public partial class Cariiller : Form
    {
        public Cariiller()
        {
            InitializeComponent();
        }
        Model3 db= new Model3();
        SqlConnection baglanti= new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=DBTeknikServis;Integrated Security=True");
        private void Cariiller_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
          /*  chart1.Series["Series1"].Points.AddXY("Ankara", 10);
            chart1.Series["Series1"].Points.AddXY("İstanbul", 12);
            chart1.Series["Series1"].Points.AddXY("İzmir", 5);
            chart1.Series["Series1"].Points.AddXY("Bursa", 20); */
          
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("Select IL,COUNT(*)FROM TBLCARI group by IL", baglanti);
            SqlDataReader dr=cmd.ExecuteReader();
            // Verileri LINQ sorgusu kullanarak alıp DataGridView'e bağlama
            var cariListesi = db.TBLCARI
                                .GroupBy(y => y.IL)
                                .Select(z => new { IL = z.Key, TOPLAM = z.Count() })
                                .ToList();
            dataGridView1.DataSource = cariListesi;
          
            // Verileri Chart kontrolüne ekleme
            foreach (var cari in cariListesi)
            {
                chart1.Series["Series1"].Points.AddXY(cari.IL, cari.TOPLAM);
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Deneme.Formlar
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Model3 db=new Model3();
        private void Login_Load(object sender, EventArgs e)
        {
            // Daha önce hatırla seçeneği işaretlendi mi
            if (Properties.Settings.Default["BeniHatirla"] != null && (bool)Properties.Settings.Default["BeniHatirla"])
            {
                // Beni Hatırla seçeneğini işaretler
                BeniHatirla.Checked = true;

                // Kullanıcı adını ve şifreyi al
                if (Properties.Settings.Default["KULLANICIAD"] != null && Properties.Settings.Default["SIFRE"] != null)
                {
                    string kullaniciAdi = Properties.Settings.Default["KULLANICIAD"].ToString();
                    string sifre = Properties.Settings.Default["SIFRE"].ToString();

                    // Kullanıcı adı ve şifreyi kutulara yerleştir
                    textBox1.Text = kullaniciAdi;
                    textBox2.Text = sifre;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kullanıcı adı ve şifreyi al
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            // Hatırla seçeneği kontrol ediliyor mu
            if (BeniHatirla.Checked)
            {
                // Kullanıcı bilgilerini bellekte sakla
                Properties.Settings.Default["KULLANICIAD"] = kullaniciAdi;
              
                Properties.Settings.Default.Save();
            }

            // LINQ sorgusuyla kullanıcıyı kontrol et
            var sorgu = from admin in db.TBLADMIN
                        where admin.KULLANICIAD == kullaniciAdi && admin.SIFRE == sifre
                        select admin;

            // Kullanıcı varsa, giriş yap
            if (sorgu.Any())
            {
                // Kullanıcı bilgileri doğru, giriş yapılabilir
                MessageBox.Show("Giriş başarılı!");

                // İşlem yapmak istediğiniz formu açabilir veya bir sonraki adımları gerçekleştirebilirsiniz.
                Form1 form1 = new Form1(); // Açmak istediğiniz formun adı Form2 olarak varsayılmıştır
                form1.Show();
                this.Hide(); // Giriş formunu gizlemek isterseniz
            }
            else
            {
                // Kullanıcı bilgileri hatalı, giriş başarısız
                MessageBox.Show("Hatalı kullanıcı adı veya şifre!");
            }
        }

      

            private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Beni Hatırla seçeneği değiştiğinde yapılacak işlemler
            if (BeniHatirla.Checked)
            {
                // Kullanıcı, "Beni Hatırla" kutusunu işaretlediyse, bu seçeneği bellekte sakla
                Properties.Settings.Default["BeniHatirla"] = true;
                Properties.Settings.Default.Save();
            }
            else
            {
                // Kullanıcı, "Beni Hatırla" kutusunun işaretini kaldırdıysa, bellekten bu seçeneği kaldır
                Properties.Settings.Default["BeniHatirla"] = false;
                Properties.Settings.Default.Save();
            }
        }
    }
}

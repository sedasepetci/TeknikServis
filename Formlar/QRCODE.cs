using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
namespace Deneme.Formlar
{
    public partial class QRCODE : Form
    {
        public QRCODE()
        {
            InitializeComponent();
        }

        private void QRCODE_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void BtnQR_Click(object sender, EventArgs e)
        {
            QRCodeEncoder enc = new QRCodeEncoder();
            pictureBox1.Image = enc.Encode(maskedTextBox1.Text);
        }
    }
}

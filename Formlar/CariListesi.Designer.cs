namespace Deneme.Formlar
{
    partial class CariListesi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CariListesi));
            this.TxtCariID = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnCariListele = new System.Windows.Forms.Button();
            this.BtnCariGuncelle = new System.Windows.Forms.Button();
            this.BtnCariKaydet = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CmbCariil = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCariBanka = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCariTel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCariSoyad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCariAd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtCariMail = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CmbCariilce = new System.Windows.Forms.ComboBox();
            this.TxtCariAdres = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtStatu = new System.Windows.Forms.TextBox();
            this.TxtCariVDaire = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtCariVNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtCariID
            // 
            this.TxtCariID.Enabled = false;
            this.TxtCariID.Location = new System.Drawing.Point(111, 37);
            this.TxtCariID.Name = "TxtCariID";
            this.TxtCariID.Size = new System.Drawing.Size(176, 22);
            this.TxtCariID.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "CARI ID:";
            // 
            // BtnCariListele
            // 
            this.BtnCariListele.Image = ((System.Drawing.Image)(resources.GetObject("BtnCariListele.Image")));
            this.BtnCariListele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCariListele.Location = new System.Drawing.Point(111, 477);
            this.BtnCariListele.Name = "BtnCariListele";
            this.BtnCariListele.Size = new System.Drawing.Size(176, 44);
            this.BtnCariListele.TabIndex = 28;
            this.BtnCariListele.Text = "LİSTELE";
            this.BtnCariListele.UseVisualStyleBackColor = true;
            this.BtnCariListele.Click += new System.EventHandler(this.BtnCariListele_Click);
            // 
            // BtnCariGuncelle
            // 
            this.BtnCariGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("BtnCariGuncelle.Image")));
            this.BtnCariGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCariGuncelle.Location = new System.Drawing.Point(111, 427);
            this.BtnCariGuncelle.Name = "BtnCariGuncelle";
            this.BtnCariGuncelle.Size = new System.Drawing.Size(176, 44);
            this.BtnCariGuncelle.TabIndex = 27;
            this.BtnCariGuncelle.Text = "GÜNCELLE";
            this.BtnCariGuncelle.UseVisualStyleBackColor = true;
            this.BtnCariGuncelle.Click += new System.EventHandler(this.BtnCariGuncelle_Click);
            // 
            // BtnCariKaydet
            // 
            this.BtnCariKaydet.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BtnCariKaydet.Image = ((System.Drawing.Image)(resources.GetObject("BtnCariKaydet.Image")));
            this.BtnCariKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCariKaydet.Location = new System.Drawing.Point(111, 377);
            this.BtnCariKaydet.Name = "BtnCariKaydet";
            this.BtnCariKaydet.Size = new System.Drawing.Size(176, 44);
            this.BtnCariKaydet.TabIndex = 25;
            this.BtnCariKaydet.Text = "KAYDET";
            this.BtnCariKaydet.UseVisualStyleBackColor = false;
            this.BtnCariKaydet.Click += new System.EventHandler(this.BtnCariKaydet_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "BANKA:";
            // 
            // CmbCariil
            // 
            this.CmbCariil.FormattingEnabled = true;
            this.CmbCariil.Location = new System.Drawing.Point(111, 176);
            this.CmbCariil.Name = "CmbCariil";
            this.CmbCariil.Size = new System.Drawing.Size(176, 24);
            this.CmbCariil.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "İLÇE:";
            // 
            // TxtCariBanka
            // 
            this.TxtCariBanka.Location = new System.Drawing.Point(111, 237);
            this.TxtCariBanka.Name = "TxtCariBanka";
            this.TxtCariBanka.Size = new System.Drawing.Size(176, 22);
            this.TxtCariBanka.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "İL:";
            // 
            // TxtCariTel
            // 
            this.TxtCariTel.Location = new System.Drawing.Point(111, 121);
            this.TxtCariTel.Name = "TxtCariTel";
            this.TxtCariTel.Size = new System.Drawing.Size(176, 22);
            this.TxtCariTel.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "TELEFON:";
            // 
            // TxtCariSoyad
            // 
            this.TxtCariSoyad.Location = new System.Drawing.Point(111, 93);
            this.TxtCariSoyad.Name = "TxtCariSoyad";
            this.TxtCariSoyad.Size = new System.Drawing.Size(176, 22);
            this.TxtCariSoyad.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "SOYAD:";
            // 
            // TxtCariAd
            // 
            this.TxtCariAd.Location = new System.Drawing.Point(111, 65);
            this.TxtCariAd.Name = "TxtCariAd";
            this.TxtCariAd.Size = new System.Drawing.Size(176, 22);
            this.TxtCariAd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "AD:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.TxtCariMail);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.CmbCariilce);
            this.groupBox1.Controls.Add(this.TxtCariAdres);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.TxtStatu);
            this.groupBox1.Controls.Add(this.TxtCariVDaire);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.TxtCariVNo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.TxtCariID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.BtnCariListele);
            this.groupBox1.Controls.Add(this.BtnCariGuncelle);
            this.groupBox1.Controls.Add(this.BtnCariKaydet);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.CmbCariil);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.TxtCariBanka);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TxtCariTel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtCariSoyad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtCariAd);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(701, 221);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(319, 597);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CARİ İŞLEMLERİ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(52, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 50;
            this.label13.Text = "MAIL:";
            // 
            // TxtCariMail
            // 
            this.TxtCariMail.Location = new System.Drawing.Point(111, 148);
            this.TxtCariMail.Name = "TxtCariMail";
            this.TxtCariMail.Size = new System.Drawing.Size(176, 22);
            this.TxtCariMail.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 16);
            this.label12.TabIndex = 49;
            // 
            // CmbCariilce
            // 
            this.CmbCariilce.FormattingEnabled = true;
            this.CmbCariilce.Location = new System.Drawing.Point(111, 206);
            this.CmbCariilce.Name = "CmbCariilce";
            this.CmbCariilce.Size = new System.Drawing.Size(176, 24);
            this.CmbCariilce.TabIndex = 47;
            // 
            // TxtCariAdres
            // 
            this.TxtCariAdres.Location = new System.Drawing.Point(111, 349);
            this.TxtCariAdres.Name = "TxtCariAdres";
            this.TxtCariAdres.Size = new System.Drawing.Size(176, 22);
            this.TxtCariAdres.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 357);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 45;
            this.label8.Text = "ADRES:";
            // 
            // TxtStatu
            // 
            this.TxtStatu.Location = new System.Drawing.Point(111, 321);
            this.TxtStatu.Name = "TxtStatu";
            this.TxtStatu.Size = new System.Drawing.Size(176, 22);
            this.TxtStatu.TabIndex = 40;
            // 
            // TxtCariVDaire
            // 
            this.TxtCariVDaire.Location = new System.Drawing.Point(111, 265);
            this.TxtCariVDaire.Name = "TxtCariVDaire";
            this.TxtCariVDaire.Size = new System.Drawing.Size(176, 22);
            this.TxtCariVDaire.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 324);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 44;
            this.label9.Text = "STATU:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 268);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 42;
            this.label11.Text = "V.DAİRESİ:";
            // 
            // TxtCariVNo
            // 
            this.TxtCariVNo.Location = new System.Drawing.Point(111, 293);
            this.TxtCariVNo.Name = "TxtCariVNo";
            this.TxtCariVNo.Size = new System.Drawing.Size(176, 22);
            this.TxtCariVNo.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 296);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 43;
            this.label10.Text = "VERGİ NO:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 221);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(648, 597);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // CariListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 861);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CariListesi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CariListesi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CariListesi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCariID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnCariListele;
        private System.Windows.Forms.Button BtnCariGuncelle;
        private System.Windows.Forms.Button BtnCariKaydet;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbCariil;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCariBanka;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCariTel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCariSoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtCariAd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtStatu;
        private System.Windows.Forms.TextBox TxtCariVDaire;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtCariVNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtCariAdres;
        private System.Windows.Forms.ComboBox CmbCariilce;
        private System.Windows.Forms.TextBox TxtCariMail;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}
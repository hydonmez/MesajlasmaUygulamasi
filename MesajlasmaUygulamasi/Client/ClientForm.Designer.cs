namespace Client
{
    partial class ClientForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.BtnSifreleSikistirGonder = new MetroFramework.Controls.MetroButton();
            this.txtDosyaYolu = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.BtnZipAc = new MetroFramework.Controls.MetroButton();
            this.BtnSifreCoz = new MetroFramework.Controls.MetroButton();
            this.BtnDosyaZiple = new MetroFramework.Controls.MetroButton();
            this.BtnDosyaSifrele = new MetroFramework.Controls.MetroButton();
            this.txtIslemYapilacakDosyaYolu = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel4 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtSifresiCozulmus = new MetroFramework.Controls.MetroTextBox();
            this.BtnGonder = new MetroFramework.Controls.MetroButton();
            this.txtMesaj = new MetroFramework.Controls.MetroTextBox();
            this.chckBoxSnp = new MetroFramework.Controls.MetroCheckBox();
            this.chckBoxSha256 = new MetroFramework.Controls.MetroCheckBox();
            this.txtSohbetEkrani = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.BtnSifreleSikistirGonder);
            this.metroPanel1.Controls.Add(this.txtDosyaYolu);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 8;
            this.metroPanel1.Location = new System.Drawing.Point(452, 32);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(340, 168);
            this.metroPanel1.TabIndex = 21;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.UseCustomForeColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 8;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(14, 15);
            this.metroLabel3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(73, 19);
            this.metroLabel3.TabIndex = 23;
            this.metroLabel3.Text = "Dosya Yolu";
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            // 
            // BtnSifreleSikistirGonder
            // 
            this.BtnSifreleSikistirGonder.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnSifreleSikistirGonder.Location = new System.Drawing.Point(123, 61);
            this.BtnSifreleSikistirGonder.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSifreleSikistirGonder.Name = "BtnSifreleSikistirGonder";
            this.BtnSifreleSikistirGonder.Size = new System.Drawing.Size(159, 35);
            this.BtnSifreleSikistirGonder.TabIndex = 22;
            this.BtnSifreleSikistirGonder.Text = "Dosyayı Şifrele ve Sıkıştır";
            this.BtnSifreleSikistirGonder.UseCustomBackColor = true;
            this.BtnSifreleSikistirGonder.UseSelectable = true;
            this.BtnSifreleSikistirGonder.Click += new System.EventHandler(this.BtnSifreleSikistirGonder_Click);
            // 
            // txtDosyaYolu
            // 
            // 
            // 
            // 
            this.txtDosyaYolu.CustomButton.Image = null;
            this.txtDosyaYolu.CustomButton.Location = new System.Drawing.Point(248, 1);
            this.txtDosyaYolu.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtDosyaYolu.CustomButton.Name = "";
            this.txtDosyaYolu.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtDosyaYolu.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtDosyaYolu.CustomButton.TabIndex = 1;
            this.txtDosyaYolu.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtDosyaYolu.CustomButton.UseSelectable = true;
            this.txtDosyaYolu.CustomButton.Visible = false;
            this.txtDosyaYolu.Lines = new string[0];
            this.txtDosyaYolu.Location = new System.Drawing.Point(14, 36);
            this.txtDosyaYolu.Margin = new System.Windows.Forms.Padding(2);
            this.txtDosyaYolu.MaxLength = 32767;
            this.txtDosyaYolu.Multiline = true;
            this.txtDosyaYolu.Name = "txtDosyaYolu";
            this.txtDosyaYolu.PasswordChar = '\0';
            this.txtDosyaYolu.ReadOnly = true;
            this.txtDosyaYolu.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDosyaYolu.SelectedText = "";
            this.txtDosyaYolu.SelectionLength = 0;
            this.txtDosyaYolu.SelectionStart = 0;
            this.txtDosyaYolu.ShortcutsEnabled = true;
            this.txtDosyaYolu.Size = new System.Drawing.Size(268, 21);
            this.txtDosyaYolu.TabIndex = 21;
            this.txtDosyaYolu.UseSelectable = true;
            this.txtDosyaYolu.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtDosyaYolu.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtDosyaYolu.Click += new System.EventHandler(this.txtSifrelenecekDosyaKonumu_Click);
            // 
            // metroPanel2
            // 
            this.metroPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.metroPanel2.Controls.Add(this.metroLabel4);
            this.metroPanel2.Controls.Add(this.BtnZipAc);
            this.metroPanel2.Controls.Add(this.BtnSifreCoz);
            this.metroPanel2.Controls.Add(this.BtnDosyaZiple);
            this.metroPanel2.Controls.Add(this.BtnDosyaSifrele);
            this.metroPanel2.Controls.Add(this.txtIslemYapilacakDosyaYolu);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 8;
            this.metroPanel2.Location = new System.Drawing.Point(452, 280);
            this.metroPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(340, 159);
            this.metroPanel2.TabIndex = 22;
            this.metroPanel2.UseCustomBackColor = true;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 8;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(14, 20);
            this.metroLabel4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(73, 19);
            this.metroLabel4.TabIndex = 37;
            this.metroLabel4.Text = "Dosya Yolu";
            this.metroLabel4.UseCustomBackColor = true;
            this.metroLabel4.UseCustomForeColor = true;
            // 
            // BtnZipAc
            // 
            this.BtnZipAc.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnZipAc.Location = new System.Drawing.Point(163, 104);
            this.BtnZipAc.Margin = new System.Windows.Forms.Padding(2);
            this.BtnZipAc.Name = "BtnZipAc";
            this.BtnZipAc.Size = new System.Drawing.Size(119, 35);
            this.BtnZipAc.TabIndex = 36;
            this.BtnZipAc.Text = "Dosya Zip Aç";
            this.BtnZipAc.UseCustomBackColor = true;
            this.BtnZipAc.UseSelectable = true;
            this.BtnZipAc.Click += new System.EventHandler(this.BtnZipAc_Click);
            // 
            // BtnSifreCoz
            // 
            this.BtnSifreCoz.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnSifreCoz.Location = new System.Drawing.Point(14, 106);
            this.BtnSifreCoz.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSifreCoz.Name = "BtnSifreCoz";
            this.BtnSifreCoz.Size = new System.Drawing.Size(132, 35);
            this.BtnSifreCoz.TabIndex = 35;
            this.BtnSifreCoz.Text = "Şifre Çöz";
            this.BtnSifreCoz.UseCustomBackColor = true;
            this.BtnSifreCoz.UseSelectable = true;
            this.BtnSifreCoz.Click += new System.EventHandler(this.BtnSifreCoz_Click);
            // 
            // BtnDosyaZiple
            // 
            this.BtnDosyaZiple.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnDosyaZiple.Location = new System.Drawing.Point(163, 64);
            this.BtnDosyaZiple.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDosyaZiple.Name = "BtnDosyaZiple";
            this.BtnDosyaZiple.Size = new System.Drawing.Size(119, 35);
            this.BtnDosyaZiple.TabIndex = 34;
            this.BtnDosyaZiple.Text = "Dosya Ziple";
            this.BtnDosyaZiple.UseCustomBackColor = true;
            this.BtnDosyaZiple.UseSelectable = true;
            this.BtnDosyaZiple.Click += new System.EventHandler(this.BtnDosyaZiple_Click);
            // 
            // BtnDosyaSifrele
            // 
            this.BtnDosyaSifrele.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnDosyaSifrele.Location = new System.Drawing.Point(14, 67);
            this.BtnDosyaSifrele.Margin = new System.Windows.Forms.Padding(2);
            this.BtnDosyaSifrele.Name = "BtnDosyaSifrele";
            this.BtnDosyaSifrele.Size = new System.Drawing.Size(132, 35);
            this.BtnDosyaSifrele.TabIndex = 33;
            this.BtnDosyaSifrele.Text = "Dosya Şifrele";
            this.BtnDosyaSifrele.UseCustomBackColor = true;
            this.BtnDosyaSifrele.UseSelectable = true;
            this.BtnDosyaSifrele.Click += new System.EventHandler(this.BtnDosyaSifrele_Click);
            // 
            // txtIslemYapilacakDosyaYolu
            // 
            // 
            // 
            // 
            this.txtIslemYapilacakDosyaYolu.CustomButton.Image = null;
            this.txtIslemYapilacakDosyaYolu.CustomButton.Location = new System.Drawing.Point(248, 1);
            this.txtIslemYapilacakDosyaYolu.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtIslemYapilacakDosyaYolu.CustomButton.Name = "";
            this.txtIslemYapilacakDosyaYolu.CustomButton.Size = new System.Drawing.Size(19, 19);
            this.txtIslemYapilacakDosyaYolu.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtIslemYapilacakDosyaYolu.CustomButton.TabIndex = 1;
            this.txtIslemYapilacakDosyaYolu.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtIslemYapilacakDosyaYolu.CustomButton.UseSelectable = true;
            this.txtIslemYapilacakDosyaYolu.CustomButton.Visible = false;
            this.txtIslemYapilacakDosyaYolu.Lines = new string[0];
            this.txtIslemYapilacakDosyaYolu.Location = new System.Drawing.Point(14, 39);
            this.txtIslemYapilacakDosyaYolu.Margin = new System.Windows.Forms.Padding(2);
            this.txtIslemYapilacakDosyaYolu.MaxLength = 32767;
            this.txtIslemYapilacakDosyaYolu.Multiline = true;
            this.txtIslemYapilacakDosyaYolu.Name = "txtIslemYapilacakDosyaYolu";
            this.txtIslemYapilacakDosyaYolu.PasswordChar = '\0';
            this.txtIslemYapilacakDosyaYolu.ReadOnly = true;
            this.txtIslemYapilacakDosyaYolu.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtIslemYapilacakDosyaYolu.SelectedText = "";
            this.txtIslemYapilacakDosyaYolu.SelectionLength = 0;
            this.txtIslemYapilacakDosyaYolu.SelectionStart = 0;
            this.txtIslemYapilacakDosyaYolu.ShortcutsEnabled = true;
            this.txtIslemYapilacakDosyaYolu.Size = new System.Drawing.Size(268, 21);
            this.txtIslemYapilacakDosyaYolu.TabIndex = 32;
            this.txtIslemYapilacakDosyaYolu.UseSelectable = true;
            this.txtIslemYapilacakDosyaYolu.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtIslemYapilacakDosyaYolu.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtIslemYapilacakDosyaYolu.Click += new System.EventHandler(this.txtIslemYapilacakDosya_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.metroLabel5.Location = new System.Drawing.Point(452, 11);
            this.metroLabel5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(231, 19);
            this.metroLabel5.TabIndex = 24;
            this.metroLabel5.Text = "Dosya Şifreleme ve Sıkıştırma İşlemleri";
            this.metroLabel5.UseCustomBackColor = true;
            this.metroLabel5.UseCustomForeColor = true;
            // 
            // metroPanel3
            // 
            this.metroPanel3.BackColor = System.Drawing.Color.SlateGray;
            this.metroPanel3.Controls.Add(this.metroLabel7);
            this.metroPanel3.Controls.Add(this.metroLabel6);
            this.metroPanel3.Controls.Add(this.metroLabel5);
            this.metroPanel3.Controls.Add(this.metroPanel4);
            this.metroPanel3.Controls.Add(this.metroPanel2);
            this.metroPanel3.Controls.Add(this.metroPanel1);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 8;
            this.metroPanel3.Location = new System.Drawing.Point(-2, 55);
            this.metroPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(804, 455);
            this.metroPanel3.TabIndex = 23;
            this.metroPanel3.UseCustomBackColor = true;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 8;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.metroLabel7.Location = new System.Drawing.Point(17, 11);
            this.metroLabel7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(162, 19);
            this.metroLabel7.TabIndex = 26;
            this.metroLabel7.Text = "Mesaj Gönderme İşlemleri";
            this.metroLabel7.UseCustomBackColor = true;
            this.metroLabel7.UseCustomForeColor = true;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.metroLabel6.Location = new System.Drawing.Point(452, 258);
            this.metroLabel6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(131, 19);
            this.metroLabel6.TabIndex = 25;
            this.metroLabel6.Text = "Ekstra Dosya Araçları";
            this.metroLabel6.UseCustomBackColor = true;
            this.metroLabel6.UseCustomForeColor = true;
            // 
            // metroPanel4
            // 
            this.metroPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.metroPanel4.Controls.Add(this.metroLabel2);
            this.metroPanel4.Controls.Add(this.metroLabel1);
            this.metroPanel4.Controls.Add(this.txtSifresiCozulmus);
            this.metroPanel4.Controls.Add(this.BtnGonder);
            this.metroPanel4.Controls.Add(this.txtMesaj);
            this.metroPanel4.Controls.Add(this.chckBoxSnp);
            this.metroPanel4.Controls.Add(this.chckBoxSha256);
            this.metroPanel4.Controls.Add(this.txtSohbetEkrani);
            this.metroPanel4.HorizontalScrollbarBarColor = true;
            this.metroPanel4.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel4.HorizontalScrollbarSize = 8;
            this.metroPanel4.Location = new System.Drawing.Point(17, 32);
            this.metroPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.metroPanel4.Name = "metroPanel4";
            this.metroPanel4.Size = new System.Drawing.Size(419, 407);
            this.metroPanel4.TabIndex = 24;
            this.metroPanel4.UseCustomBackColor = true;
            this.metroPanel4.VerticalScrollbarBarColor = true;
            this.metroPanel4.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel4.VerticalScrollbarSize = 8;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(14, 269);
            this.metroLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(157, 19);
            this.metroLabel2.TabIndex = 46;
            this.metroLabel2.Text = "Şifresi Çözülmüş Mesajlar";
            this.metroLabel2.UseCustomBackColor = true;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(14, 170);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(43, 19);
            this.metroLabel1.TabIndex = 45;
            this.metroLabel1.Text = "Mesaj";
            this.metroLabel1.UseCustomBackColor = true;
            // 
            // txtSifresiCozulmus
            // 
            // 
            // 
            // 
            this.txtSifresiCozulmus.CustomButton.Image = null;
            this.txtSifresiCozulmus.CustomButton.Location = new System.Drawing.Point(235, 1);
            this.txtSifresiCozulmus.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtSifresiCozulmus.CustomButton.Name = "";
            this.txtSifresiCozulmus.CustomButton.Size = new System.Drawing.Size(89, 89);
            this.txtSifresiCozulmus.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSifresiCozulmus.CustomButton.TabIndex = 1;
            this.txtSifresiCozulmus.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSifresiCozulmus.CustomButton.UseSelectable = true;
            this.txtSifresiCozulmus.CustomButton.Visible = false;
            this.txtSifresiCozulmus.Lines = new string[0];
            this.txtSifresiCozulmus.Location = new System.Drawing.Point(14, 295);
            this.txtSifresiCozulmus.Margin = new System.Windows.Forms.Padding(2);
            this.txtSifresiCozulmus.MaxLength = 32767;
            this.txtSifresiCozulmus.Multiline = true;
            this.txtSifresiCozulmus.Name = "txtSifresiCozulmus";
            this.txtSifresiCozulmus.PasswordChar = '\0';
            this.txtSifresiCozulmus.ReadOnly = true;
            this.txtSifresiCozulmus.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSifresiCozulmus.SelectedText = "";
            this.txtSifresiCozulmus.SelectionLength = 0;
            this.txtSifresiCozulmus.SelectionStart = 0;
            this.txtSifresiCozulmus.ShortcutsEnabled = true;
            this.txtSifresiCozulmus.Size = new System.Drawing.Size(325, 91);
            this.txtSifresiCozulmus.TabIndex = 44;
            this.txtSifresiCozulmus.UseSelectable = true;
            this.txtSifresiCozulmus.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSifresiCozulmus.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BtnGonder
            // 
            this.BtnGonder.BackColor = System.Drawing.Color.DarkOrange;
            this.BtnGonder.Location = new System.Drawing.Point(230, 232);
            this.BtnGonder.Margin = new System.Windows.Forms.Padding(2);
            this.BtnGonder.Name = "BtnGonder";
            this.BtnGonder.Size = new System.Drawing.Size(110, 35);
            this.BtnGonder.TabIndex = 43;
            this.BtnGonder.Text = "Gönder";
            this.BtnGonder.UseCustomBackColor = true;
            this.BtnGonder.UseSelectable = true;
            this.BtnGonder.Click += new System.EventHandler(this.BtnGonder_Click);
            // 
            // txtMesaj
            // 
            // 
            // 
            // 
            this.txtMesaj.CustomButton.Image = null;
            this.txtMesaj.CustomButton.Location = new System.Drawing.Point(289, 2);
            this.txtMesaj.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtMesaj.CustomButton.Name = "";
            this.txtMesaj.CustomButton.Size = new System.Drawing.Size(33, 33);
            this.txtMesaj.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMesaj.CustomButton.TabIndex = 1;
            this.txtMesaj.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMesaj.CustomButton.UseSelectable = true;
            this.txtMesaj.CustomButton.Visible = false;
            this.txtMesaj.Lines = new string[0];
            this.txtMesaj.Location = new System.Drawing.Point(14, 189);
            this.txtMesaj.Margin = new System.Windows.Forms.Padding(2);
            this.txtMesaj.MaxLength = 32767;
            this.txtMesaj.Multiline = true;
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.PasswordChar = '\0';
            this.txtMesaj.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMesaj.SelectedText = "";
            this.txtMesaj.SelectionLength = 0;
            this.txtMesaj.SelectionStart = 0;
            this.txtMesaj.ShortcutsEnabled = true;
            this.txtMesaj.Size = new System.Drawing.Size(325, 38);
            this.txtMesaj.TabIndex = 42;
            this.txtMesaj.UseSelectable = true;
            this.txtMesaj.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMesaj.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // chckBoxSnp
            // 
            this.chckBoxSnp.AutoSize = true;
            this.chckBoxSnp.Location = new System.Drawing.Point(343, 33);
            this.chckBoxSnp.Margin = new System.Windows.Forms.Padding(2);
            this.chckBoxSnp.Name = "chckBoxSnp";
            this.chckBoxSnp.Size = new System.Drawing.Size(45, 15);
            this.chckBoxSnp.TabIndex = 41;
            this.chckBoxSnp.Text = "SPN";
            this.chckBoxSnp.UseCustomBackColor = true;
            this.chckBoxSnp.UseCustomForeColor = true;
            this.chckBoxSnp.UseSelectable = true;
            // 
            // chckBoxSha256
            // 
            this.chckBoxSha256.AutoSize = true;
            this.chckBoxSha256.Location = new System.Drawing.Point(343, 15);
            this.chckBoxSha256.Margin = new System.Windows.Forms.Padding(2);
            this.chckBoxSha256.Name = "chckBoxSha256";
            this.chckBoxSha256.Size = new System.Drawing.Size(69, 15);
            this.chckBoxSha256.TabIndex = 40;
            this.chckBoxSha256.Text = "SHA-256";
            this.chckBoxSha256.UseCustomBackColor = true;
            this.chckBoxSha256.UseCustomForeColor = true;
            this.chckBoxSha256.UseSelectable = true;
            // 
            // txtSohbetEkrani
            // 
            // 
            // 
            // 
            this.txtSohbetEkrani.CustomButton.Image = null;
            this.txtSohbetEkrani.CustomButton.Location = new System.Drawing.Point(172, 2);
            this.txtSohbetEkrani.CustomButton.Margin = new System.Windows.Forms.Padding(2);
            this.txtSohbetEkrani.CustomButton.Name = "";
            this.txtSohbetEkrani.CustomButton.Size = new System.Drawing.Size(149, 149);
            this.txtSohbetEkrani.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSohbetEkrani.CustomButton.TabIndex = 1;
            this.txtSohbetEkrani.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSohbetEkrani.CustomButton.UseSelectable = true;
            this.txtSohbetEkrani.CustomButton.Visible = false;
            this.txtSohbetEkrani.Lines = new string[0];
            this.txtSohbetEkrani.Location = new System.Drawing.Point(14, 15);
            this.txtSohbetEkrani.Margin = new System.Windows.Forms.Padding(2);
            this.txtSohbetEkrani.MaxLength = 32767;
            this.txtSohbetEkrani.Multiline = true;
            this.txtSohbetEkrani.Name = "txtSohbetEkrani";
            this.txtSohbetEkrani.PasswordChar = '\0';
            this.txtSohbetEkrani.ReadOnly = true;
            this.txtSohbetEkrani.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSohbetEkrani.SelectedText = "";
            this.txtSohbetEkrani.SelectionLength = 0;
            this.txtSohbetEkrani.SelectionStart = 0;
            this.txtSohbetEkrani.ShortcutsEnabled = true;
            this.txtSohbetEkrani.Size = new System.Drawing.Size(324, 154);
            this.txtSohbetEkrani.TabIndex = 39;
            this.txtSohbetEkrani.UseSelectable = true;
            this.txtSohbetEkrani.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSohbetEkrani.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 509);
            this.Controls.Add(this.metroPanel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientForm";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Style = MetroFramework.MetroColorStyle.Magenta;
            this.Text = "CLIENT";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroPanel4.ResumeLayout(false);
            this.metroPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton BtnSifreleSikistirGonder;
        private MetroFramework.Controls.MetroTextBox txtDosyaYolu;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton BtnZipAc;
        private MetroFramework.Controls.MetroButton BtnSifreCoz;
        private MetroFramework.Controls.MetroButton BtnDosyaZiple;
        private MetroFramework.Controls.MetroButton BtnDosyaSifrele;
        private MetroFramework.Controls.MetroTextBox txtIslemYapilacakDosyaYolu;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroPanel metroPanel4;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtSifresiCozulmus;
        private MetroFramework.Controls.MetroButton BtnGonder;
        private MetroFramework.Controls.MetroTextBox txtMesaj;
        private MetroFramework.Controls.MetroCheckBox chckBoxSnp;
        private MetroFramework.Controls.MetroCheckBox chckBoxSha256;
        private MetroFramework.Controls.MetroTextBox txtSohbetEkrani;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroLabel metroLabel7;
    }
}


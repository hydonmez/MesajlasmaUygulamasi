using SimpleTcp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syroot.Windows.IO;
using System.IO;

namespace Server
{
    public partial class ServerForm : MetroFramework.Forms.MetroForm
    {
        public ServerForm()
        {
            InitializeComponent();
        }
        SimpleTcpServer server; //socket programlama icin server nesnesi yaratildi
        SpnSifreleme spn = new SpnSifreleme();//spn sifreleme algoritmasi icin bir nesne yaratildi

        private string Mesaj { get; set; } //Uygulama icin gerekli olan değişkenler
        private string Sifre { get; set; }
        private string GelenMesaj { get; set; }

        private void ServerForm_Load(object sender, EventArgs e)
        {

            try
            {
                Mesaj = "";//degiskenlere ilk degerler atanadı 
                Sifre = "";
                GelenMesaj = "";

                lstClientIp.Visible = false;
                server = new SimpleTcpServer("127.0.0.1:100");//yerel ip atamasi yapilldi
                server.Events.ClientConnected += Events_ClientConnected;//server nesnesinin evetleri text eventleriyle baglandi ??
                server.Events.ClientDisconnected += Events_ClientDisconnected;
                server.Events.DataReceived += Events_DataReceived;

                server.Start(); //server nesnesini başlat
                txtSohbetEkrani.Text += $"Server Başladı...{Environment.NewLine}"; //Server başladı yaz bir alt satıra geç             
            }
            catch (Exception) //herhangi bir olumsuz durumda server başlatılması engellendi ve uyarı mesajı verildi.
            {
                MessageBox.Show("Birden fazla Server başlatmayınız Sorununuz hala devam ediyorsa lütfen yöneticinize başvurunuz");
                Environment.Exit(0);
            }

        }

        private void Events_DataReceived(object sender, DataReceivedEventArgs e)//herhangi bir data akışı olup olmadığı kontro ediliyor data gelirse burası tetiklenir
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    GelenMesaj = Encoding.UTF8.GetString(e.Data);
                    if (GelenMesaj.Substring(0, 3) != "sha") // gelen mesajın başında sha yoksa spn ile calisilacaktir
                    {
                        txtSohbetEkrani.Text += $"Client: {spn.sifreliMesajYaz((GelenMesaj))}{ Environment.NewLine}"; //sifreli mesaj ilgili sınıfın metodunda yararlanılarak ekrana yazdirilir
                        GelenMesaj = spn.sifreliMesajYaz(spn.SifreyiCOZ(GelenMesaj));//sifreli mesajın çözülmüş hali ilgili sınıfın metodu kullanılarak yazdırılmak için bir değişkene atılır yazdirilir
                        txtSifresiCozulmus.Text += $"Client: {GelenMesaj}{ Environment.NewLine}";//şifreli mesajın çözülmüş hali ekrana yazdırılır
                    }

                    else //SHA için çalışacak kısım
                    {
                        GelenMesaj = (Encoding.UTF8.GetString(e.Data).Substring(3));//sha etiketi atılır
                        txtSohbetEkrani.Text += $"Client: {GelenMesaj}{ Environment.NewLine}";//sha ise sha'lı hali direk yazdirilir
                    }

                });
            }
            catch (Exception ex)//herhangi bir hatada hatada yapilacaklar
            {
                MessageBox.Show(ex + " Yöneticinizle İletişime Geçiniz! ");
            }
        }

        private void Events_ClientDisconnected(object sender, ClientDisconnectedEventArgs e)//baglantı koparıldığında çalışacak kısım
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtSohbetEkrani.Text += $"{e.IpPort} Bağlantı Koptu.{Environment.NewLine}";
                lstClientIp.Items.Remove(e.IpPort);//client kapatıldıysa port listboxtan silinir
            });
        }

        private void Events_ClientConnected(object sender, ClientConnectedEventArgs e)//baglantı sağlandığında çalışılacak kısım
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtSohbetEkrani.Text += $"{e.IpPort} Bağlandı.{Environment.NewLine}";
                lstClientIp.Items.Add(e.IpPort);//clienttin bağlantısı tetiklendiyse clientin portu listboxa eklenir
            });
        }

        private void BtnGonder_Click(object sender, EventArgs e)//mesaj gönderme islemlerri icin
        {
            try
            {

                if (lstClientIp.Items.Count != 0)//client açık ise yapilacaklar 
                {
                    if (txtMesaj.Text == "")//textbox boş ise uyarı verildi
                    {
                        MessageBox.Show(" Mesaj Kutusu Boş Geçilemez! ");
                    }
                    else if (chckBoxSha256.Checked == true && chckBoxSnp.Checked == true)//birden fazla secim varsa herhangi bir islem yapmaz
                    {
                        MessageBox.Show(" Lütfen Sadece Bir Şifreleme Algoritması Seçiniz! ");
                    }
                    else if (chckBoxSha256.Checked == true)//sha 256 secilmisse sha256 sifrelemesi yapar
                    {
                        Sha256Sifreleme sha256 = new Sha256Sifreleme();//sha sifreleme algoritmasi icin bir nesne yaratildi

                        lstClientIp.SelectedIndex = 0;
                        Mesaj = "sha" + sha256.MetniSifrele(txtMesaj.Text);//mesaj sha ile sifrelendi ve başına sha olduğu belli olması için etiket eklendi
                        if (server.IsListening) //server dinliyorsa
                        {
                            lstClientIp.SelectedIndex = 0;
                            server.Send(lstClientIp.SelectedItem.ToString(), Mesaj);//secilen ıp ye mesajı gönder
                            txtSohbetEkrani.Text += $"Server: {txtMesaj.Text}{Environment.NewLine}";//Server: mesajı
                            txtMesaj.Text = string.Empty;
                            GC.Collect();
                        }
                    }
                    else if (chckBoxSnp.Checked == true)//spn secilmisse spn ile ilgili sifreleme yapar
                    {
                        MesajIslemleri mesajIslemleri = new MesajIslemleri();//mesajdaki turkce karakterlerini duzeltmek icin
                        Sifre = spn.sifrele(mesajIslemleri.TurkceKarakterDuzelt(txtMesaj.Text));//txtboxa girilen mesaj ilk once ascii karakterler uygun hale getirilir sonra ve sifrele metodundan yararlanilarak bitli sifresi daaha sonra kullanilmak uzere bir stringe atilir
                        Mesaj = spn.sifreliMesajYaz(Sifre);//sifre degiskeninde sifrelenmis 2 lik sistemde olusan mesaj karakter seklinde gosterilmek uzere sifreliMesaj yaz fonksiyonuna gonderilir
                        lstClientIp.SelectedIndex = 0;
                        if (server.IsListening) //server dinliyorsa
                        {
                            server.Send(lstClientIp.SelectedItem.ToString(), Sifre);//secilen ıp ye mesajı gönder
                            txtSohbetEkrani.Text += $"Server: {txtMesaj.Text}{Environment.NewLine}";//Server: mesajı
                            txtMesaj.Text = string.Empty;
                        }
                    }

                    else//hicbir sifreleme algoritmasi secilmemisse yapilacak durum
                    {
                        MessageBox.Show(" Lütfen Sadece Bir Şifreleme Algoritması Seçiniz! ");
                    }

                }
                else
                {
                    MessageBox.Show(" Lütfen Client'i Başlatınız ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
            }
        }

        private void BtnSifreleSikistirGonder_Click(object sender, EventArgs e)//secilen dosya sifrelenir sıkıştırılır ve masaüstüne kayıt edilir
        {
            if (txtDosyaYolu.Text == "")
            {
                MessageBox.Show(" Lütfen Dosya Konumunu Seçiniz! !");
            }
            else
            {
                DosyaSifreleSikistirVeGondermeIslemleri dosyaSifreleSikistirVeGonder = new DosyaSifreleSikistirVeGondermeIslemleri();
                dosyaSifreleSikistirVeGonder.OtomatikİslemBaslat(txtDosyaYolu.Text);
                GC.Collect();
            }

        }

        private void BtnDosyaSifrele_Click(object sender, EventArgs e)//secilen dosya sifrelenir  ve masaüstüne kayıt edilir
        {
            if (txtIslemYapilacakDosyaYolu.Text == "")
            {
                MessageBox.Show(" Lütfen Dosya Konumunu Seçiniz! !");
            }
            else
            {
                try
                {
                    DosyaSifrelemeIslemleri dosyaSifrelemeIslemleri = new DosyaSifrelemeIslemleri("yazilimmuhendisi");
                    dosyaSifrelemeIslemleri.DosyaSifrele(txtIslemYapilacakDosyaYolu.Text);
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
                }
            }
        }

        private void BtnZipAc_Click(object sender, EventArgs e)//secilen dosya  rardan cıkarilir ve masaüstüne kayıt edilir
        {
            if (txtIslemYapilacakDosyaYolu.Text == "")
            {
                MessageBox.Show(" Lütfen Dosya Konumunu Seçiniz! ");
            }
            else
            {
                try
                {
                    DosyaSikistirmaIslemleri dosyaSikistir = new DosyaSikistirmaIslemleri();
                    dosyaSikistir.DosyaSikistirmaAc(txtIslemYapilacakDosyaYolu.Text);
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
                }
            }
        }

        private void BtnDosyaZiple_Click(object sender, EventArgs e)//secilen dosya  sıkıştırılır ve masaüstüne kayıt edilir
        {
            if (txtIslemYapilacakDosyaYolu.Text == "")
            {
                MessageBox.Show(" Lütfen Dosya Konumunu Seçiniz!  ");
            }
            else
            {
                try
                {
                    DosyaSikistirmaIslemleri dosyaSikistir = new DosyaSikistirmaIslemleri();
                    dosyaSikistir.Sikistir(txtIslemYapilacakDosyaYolu.Text);
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
                }
            }
        }

        private void BtnSifreCoz_Click(object sender, EventArgs e)//secilen dosya sifresi cozulur  ve masaüstüne kayıt edilir
        {
            if (txtIslemYapilacakDosyaYolu.Text == "")
            {
                MessageBox.Show(" Lütfen Dosya Konumunu Seçiniz!  ");
            }
            else
            {
                try
                {
                    DosyaSifrelemeIslemleri dosyaSifrelemeIslemleri = new DosyaSifrelemeIslemleri("yazilimmuhendisi");
                    dosyaSifrelemeIslemleri.DosyaSifresiCoz(txtIslemYapilacakDosyaYolu.Text);
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
                }
            }
        }

        private void txtSifrelenecekDosyaKonumu_Click(object sender, EventArgs e)//txt tıklandığında openfiledialog açılarak dosya konumu alınır
        {
            try
            {
                OpenFileDialog od = new OpenFileDialog(); od.Filter = "ALL files|*"; od.FileName = "";
                if (od.ShowDialog() == DialogResult.OK)
                { txtDosyaYolu.Text = od.FileName; }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
            }
        }

        private void txtIslemYapilacakDosya_Click(object sender, EventArgs e)//txt tıklandığında openfiledialog açılarak dosya konumu alınır
        {
            try
            {
                OpenFileDialog od = new OpenFileDialog(); od.Filter = "ALL files|*"; od.FileName = "";
                if (od.ShowDialog() == DialogResult.OK)
                { txtIslemYapilacakDosyaYolu.Text = od.FileName; }
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
            }
        }
    }
}

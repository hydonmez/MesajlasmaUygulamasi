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
using Server;//Server sınıfının dosyalarini kullanabilmek icin eklendi
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Client
{
    public partial class ClientForm : MetroFramework.Forms.MetroForm
    {
        public ClientForm()
        {
            InitializeComponent();
        }
        SimpleTcpClient client; //bir client nesnesi yaratılır
        SpnSifreleme spn = new SpnSifreleme();//spn sifrelemeyle ilgili islemler icin spn nesnesi yaratildi.

        public string Mesaj { get; set; } //kullanilacak degiskenler.
        public string Sifre { get; set; }
        public string GelenMesaj { get; set; }


        private void ClientForm_Load(object sender, EventArgs e)
        {
            Mesaj = ""; //il degerler atanır
            Sifre = "";
            GelenMesaj = "";
            client = new SimpleTcpClient("127.0.0.1:100"); //yerel ip adresimiz atanır b
            client.Events.Connected += Events_Connected; //client nesnesinin evetleri text eventleriyle baglandi ??
            client.Events.DataReceived += Events_DataReceived;
            client.Events.Disconnected += Events_Disconnected;

            try
            {
                client.Connect(); //client servere bağlanılır

            }
            catch (Exception ex) //baglantı sonrasında hata çıkacaksa yapilacak isler
            {
                MessageBox.Show(ex.Message + "\nİlk Önce Serveri Başlatmadıysanız Server'ı Başlatıp Sonra Client'ı Başlatınız." +
                                              "\nSorunuz Hala Devam Ediyorsa Yöneticinize Başvurunuz! ");
                Environment.Exit(0); //herhangi bir hata oluşursa client kapatılır

            }
        }
        private void Events_Connected(object sender, ClientConnectedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtSohbetEkrani.Text += $"Server Bağlandı.{ Environment.NewLine}";
            });
        }
        private void Events_Disconnected(object sender, ClientDisconnectedEventArgs e)//baglantı koparıldığında çalışacak kısım
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtSohbetEkrani.Text += $"Server'ın Bağlantısı Koptu.{ Environment.NewLine}";
            });
        }


        private void Events_DataReceived(object sender, DataReceivedEventArgs e)//herhangi bir data akışı olup olmadığı kontro ediliyor data gelirse burası tetiklenir
        {
            this.Invoke((MethodInvoker)delegate
            {
                GelenMesaj = Encoding.UTF8.GetString(e.Data);
                if (GelenMesaj.Substring(0, 3) != "sha") //gelen mesajın ilk 3 karakterinde  sha yoksa spn ile calisilacaktir
                {
                    txtSohbetEkrani.Text += $"Server: {spn.sifreliMesajYaz((GelenMesaj))}{ Environment.NewLine}";//sifreli mesaj ilgili sınıfın metodunda yararlanılarak ekrana yazdirilir
                    GelenMesaj = spn.sifreliMesajYaz(spn.SifreyiCOZ(GelenMesaj));//sifreli mesajın çözülmüş hali ilgili sınıfın metodu kullanılarak yazdırılmak için bir değişkene atılır yazdirilir
                    txtSifresiCozulmus.Text += $"Server: {GelenMesaj}{ Environment.NewLine}";//şifreli mesajın çözülmüş hali ekrana yazdırılır
                }
                else
                {
                    GelenMesaj = (Encoding.UTF8.GetString(e.Data).Substring(3));//sha etiketi atılır
                    txtSohbetEkrani.Text += $"Server: {GelenMesaj}{ Environment.NewLine}";//sha ise sha'lı hali direk yazdirilir
                }
            });
        }
        private void BtnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                client.Connect();//serverle bağlantı sağlanır
                if (client.IsConnected)//servere baglanti varsa yapilacaklar
                {
                    if (txtMesaj.Text == "") //mesaj boşsa izin verilmez
                    {
                        MessageBox.Show(" Mesaj Kutusu Boş Geçilemez! ");
                    }
                    else if (chckBoxSha256.Checked == true && chckBoxSnp.Checked == true)//birden fazla secim varsa herhangi bir islem yapmaz
                    {
                        MessageBox.Show(" Lütfen Sadece Bir Şifreleme Algoritması Seçiniz! ");
                    }
                    else if (chckBoxSha256.Checked == true)//sha 256 secilmisse sha256 sifrelemesi yapar
                    {
                        Sha256Sifreleme sha256 = new Sha256Sifreleme();
                        Mesaj = "sha" + sha256.MetniSifrele(txtMesaj.Text); //karşı tarafın sha olup olmadığını anlamasi icin başına sha eklenir
                        if (client.IsConnected)
                        {
                            client.Send(Mesaj);//mesaj gönderilir
                            txtSohbetEkrani.Text += $"Client: {txtMesaj.Text}{Environment.NewLine}";
                            txtMesaj.Text = string.Empty;//mesaj ekranı temizlenir
                        }
                        GC.Collect();
                    }
                    else if (chckBoxSnp.Checked == true)//spn secilmisse spn ile ilgili sifreleme yapar
                    {
                        MesajIslemleri mesajDuzelt = new MesajIslemleri();
                        Sifre = spn.sifrele(mesajDuzelt.TurkceKarakterDuzelt(txtMesaj.Text));//txtboxa girilen mesaj ilk once ascii karakterler uygun hale getirilir sonra ve sifrele metodundan yararlanilarak bitli sifresi daaha sonra kullanilmak uzere bir stringe atilir
                        Mesaj = spn.sifreliMesajYaz(Sifre);//sifre degiskeninde sifrelenmis 2 lik sistemde olusan mesaj karakter seklinde gosterilmek uzere sifreliMesaj yaz fonksiyonuna gonderilir
                        if (client.IsConnected)
                        {
                            client.Send(Sifre);//mesaj client nesnesiyle gonderilir
                            txtSohbetEkrani.Text += $"Client: {txtMesaj.Text}{Environment.NewLine}";
                            txtMesaj.Text = string.Empty;
                        }
                        GC.Collect();
                    }

                    else//hic bir sifreleme algoritmasi secilmemisse yapilacak durum
                    {
                        MessageBox.Show(" Lütfen Bir Şifreleme Algoritması Seçiniz! ");
                    }
                }
                else//servere baglanti yoksa yappilacakklarr
                {
                    MessageBox.Show("Serveri Kapattığınız İçin Mesaj Atamazsınız Lütfen Server'ı Başlatınız! ");
                }
            }
            catch (Exception ex)//herhangi bir hatalı durum olursa yapilacaklar
            {
                MessageBox.Show(ex.Message + " Server'ı Kapattıysanız Lütfen Server'ı Tekrar Başlatınız Sorununuz Devam Ediyorsa Yöneticinizle İletişime Geçiniz! ");
            }
        }

        private void BtnZipAc_Click(object sender, EventArgs e)//zipli olan dosyayı açmak için 
        {
            if (txtIslemYapilacakDosyaYolu.Text != "")
            {
                try
                {
                    DosyaSikistirmaIslemleri dosyaSikistir = new DosyaSikistirmaIslemleri();
                    dosyaSikistir.DosyaSikistirmaAc(txtIslemYapilacakDosyaYolu.Text);//zipli dosyanın konumu dosyasıkıştırmaAc gönderilir
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Dosya Konumunu Seçiniz! ");
            }
        }

        private void BtnDosyaZiple_Click(object sender, EventArgs e)//secilen dosyayı ziplemek icin olan dosyayı açmak için 
        {
            if (txtIslemYapilacakDosyaYolu.Text != "")//secilen dosya varsa  yapılcaklar
            {
                try
                {
                    DosyaSikistirmaIslemleri dosyaSikistir = new DosyaSikistirmaIslemleri();
                    dosyaSikistir.Sikistir(txtIslemYapilacakDosyaYolu.Text);//secilen dosya metot yardımıyla sıkıştırılır
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
                }
            }
            else
            {
                MessageBox.Show(" Lütfen Dosya Konumunu Seçiniz! ");
            }
        }

        private void BtnSifreCoz_Click(object sender, EventArgs e)//Secilen dosyanin sifresini cozer
        {
            if (txtIslemYapilacakDosyaYolu.Text != "")//secilen dosya varsa  yapılcaklar
            {
                try
                {
                    DosyaSifrelemeIslemleri dsifreleme = new DosyaSifrelemeIslemleri("yazilimmuhendisi");
                    dsifreleme.DosyaSifresiCoz(txtIslemYapilacakDosyaYolu.Text);//secilen dosya metot yardımıyla sifrelenir
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
                }
            }
            else
            {
                MessageBox.Show(" Lütfen Dosya Konumunu Seçiniz! ");
            }

        }

        private void BtnDosyaSifrele_Click(object sender, EventArgs e)
        {
            if (txtIslemYapilacakDosyaYolu.Text != "")
            {
                try
                {
                    DosyaSifrelemeIslemleri dosyaSifreleme = new DosyaSifrelemeIslemleri("yazilimmuhendisi");
                    dosyaSifreleme.DosyaSifrele(txtIslemYapilacakDosyaYolu.Text);//secilen dosyanın şifresi metot yardımıyla cozulur
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
                }
            }
            else
            {
                MessageBox.Show(" Lütfen Dosya Konumunu Seçiniz! ");
            }
        }

        private void BtnSifreleSikistirGonder_Click(object sender, EventArgs e) //secilen dosya sifrelenir sıkıştırılır ve masaüstüne kayıt edilir
        {
            try
            {
                if (txtDosyaYolu.Text == "")
                {
                    MessageBox.Show(" Lütfen Dosya Konumunu Seçiniz! ");
                }
                else
                {
                    DosyaSifreleSikistirVeGondermeIslemleri dosyaSifreleSikistirVeGonder = new DosyaSifreleSikistirVeGondermeIslemleri();
                    dosyaSifreleSikistirVeGonder.OtomatikİslemBaslat(txtDosyaYolu.Text);
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
            }
        }

        private void txtSifrelenecekDosyaKonumu_Click(object sender, EventArgs e)//sifelenecekk dosyanın konumu alınır ve konum texte aktarılır
        {
            try
            {
                OpenFileDialog od = new OpenFileDialog(); od.Filter = "ALL files|*"; od.FileName = "";
                if (od.ShowDialog() == DialogResult.OK)
                { txtDosyaYolu.Text = od.FileName; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
            }
        }

        private void txtIslemYapilacakDosya_Click(object sender, EventArgs e)//islem yapılacak dosyanın konumu alınır ve konum texte aktarılır
        {
            try
            {
                OpenFileDialog od = new OpenFileDialog();
                od.Filter = "ALL files|*";
                od.FileName = "";
                if (od.ShowDialog() == DialogResult.OK)
                {
                    txtIslemYapilacakDosyaYolu.Text = od.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
  public  class DosyaSifreleSikistirVeGondermeIslemleri
    {
        public void OtomatikİslemBaslat(string islemYapilacakDosyaYolu) //sifrenecek ve sıkıştırılacak dosyanın konumu alınarak gerekli sınıfların metotlarından yararlanırlır
        { //once sifreleme islemi gerceklesir daha sonra ise sifrelenmis dosya sıkıştırılarak rar haline getirilir ve masaustune kayit edilir
            try
            {
                DosyaSifrelemeIslemleri dsifreleme = new DosyaSifrelemeIslemleri("yazilimmuhendisi");//Kurucu metoda parametre olarak key gönderildi
                dsifreleme.DosyaSifrele(islemYapilacakDosyaYolu);
                GC.Collect(); 
                DosyaSikistirmaIslemleri dosyaSikistir = new DosyaSikistirmaIslemleri();
                dosyaSikistir.Sikistir(islemYapilacakDosyaYolu);
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
            }                  
        }
    }
}

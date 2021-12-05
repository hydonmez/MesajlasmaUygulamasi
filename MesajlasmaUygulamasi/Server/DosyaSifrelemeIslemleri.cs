using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Server
{
    public class DosyaSifrelemeIslemleri
    {
        //yararlanilan kaynak https://www.youtube.com/watch?v=8oqSLvHj1SY 
        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        public DosyaSifrelemeIslemleri(string key) //dosya sifrelme icin gerekli key alınır
        {
            des.Key = UTF8Encoding.UTF8.GetBytes(key);//key  bytlara cevrilir
            des.Mode = CipherMode.ECB; //elektronik kod kitabi 
            des.Padding = PaddingMode.PKCS7; //gerekli ayarlama yapılır
        }
        public void DosyaSifrele(string filepath) //gelen dosyanın konumu alınarak ilgili dosya sifrelenir ve aynı konuma tekrar kayıt edilir
        {
            try
            {
                byte[] Bytes = File.ReadAllBytes(filepath);//dosyanin iceriği byte hale getiriliyor
                byte[] ebytes = des.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);//sifreleniyor ve sifreli bytler kullanılmak uzere bir dizide tutulur
                File.WriteAllBytes(filepath, ebytes);//sifrelenmis bitler dosya yoluna tekrar kayıt edilliyor
                MessageBox.Show(" Dosya Şifreleme İşlemi Başarıyla Gerçekleşti ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz ");
            }
        }
        public void DosyaSifresiCoz(string filepath)//gelen dosyanın konumu alınarak ilgili dosyanın şifresi çözülür  ve aynı konuma tekrar kayıt edilir
        {
            try
            {
                byte[] Bytes = File.ReadAllBytes(filepath);//dosyanin iceriği byte hale getiriliyor
                byte[] dbytes = des.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);//geri cozumleme yapiliyor
                File.WriteAllBytes(filepath, dbytes); //cozumlenmis hal tekrar yaziliyor
                MessageBox.Show(" Şifre Çözme İşlemi Başarıyla Gerçekleşti ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz ");
            }
        }
    }
}

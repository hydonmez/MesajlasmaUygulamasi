using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Windows.Forms;
using System.IO;
using Syroot.Windows.IO;

namespace Server
{
    public class DosyaSikistirmaIslemleri
    {
        // https://stackoverflow.com/questions/10667012/getting-downloads-folder-in-c  yararlanılan kaynak syroot her pcnin dowloand adresi
        public string Sikistir(string sikistiralacakDosyaYolu)
        {
            try
            {
                string masaUstuYolu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Ziplenmiş Dosyanız" + ".zip";// zipli hali nereye kayit edilece

                // string zipPath = @"C:\\Users\\hydon\\Desktop\\Dosyaniz.zip";// zipli hali nereye kayit edilece
                string uzantı = sikistiralacakDosyaYolu.Substring(sikistiralacakDosyaYolu.IndexOf('.'), 4);//dosya uzantısı alınır

                using (ZipArchive archive = ZipFile.Open(masaUstuYolu, ZipArchiveMode.Create)) //yeni dosya olarak yaatılır
                {
                    archive.CreateEntryFromFile(sikistiralacakDosyaYolu, "ziplidosya" + uzantı, CompressionLevel.Fastest);//yeni dosyanın adı uzantısı gibi ozellikleri belirlenir
                    MessageBox.Show("Sıkıştırma İşleminiz Başarıyla Gerçekleştirildi. \nMasaüstünü Kontrol Ediniz! ");
                    return masaUstuYolu;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
                return "";
            }
        }
        public void DosyaSikistirmaAc(string acilacakDosyanınKonumu)
        {
            try
            {
                string masaUstu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";// Masaustu konumu alınır

                ZipArchive zipArchive = ZipFile.OpenRead(acilacakDosyanınKonumu);
                foreach (ZipArchiveEntry entry in zipArchive.Entries) //zipteki tum dosyalar bir değişkene atılarak cikarilir
                {
                    entry.ExtractToFile(masaUstu + entry.Name, true);//cıkartilacakk dosya konumu ve dosyanın adları alınır
                }
                MessageBox.Show("Zipli Dosya Açıldı. Masaüstünü Kontrol Ediniz! ");
                zipArchive.Dispose(); //dosyalar çıkartılır
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Yöneticinizle İletişime Geçiniz! ");
            }
        }
    }
}

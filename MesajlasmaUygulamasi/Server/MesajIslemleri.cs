using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class MesajIslemleri
    {
        public string TurkceKarakterDuzelt(string mesaj) //mesaji asciiye uygun hale getirir
        {
            mesaj = mesaj.Replace("İ", "I"); //mesajdaki tüm İ harflerini I ile değiştirir.
            mesaj = mesaj.Replace("ı", "i");
            mesaj = mesaj.Replace("Ğ", "G");
            mesaj = mesaj.Replace("ğ", "g");
            mesaj = mesaj.Replace("Ö", "O");
            mesaj = mesaj.Replace("ö", "o");
            mesaj = mesaj.Replace("Ü", "U");
            mesaj = mesaj.Replace("ü", "u");
            mesaj = mesaj.Replace("Ş", "S");
            mesaj = mesaj.Replace("ş", "s");
            mesaj = mesaj.Replace("Ç", "C");
            mesaj = mesaj.Replace("ç", "c");
            return mesaj;
        }
    }
}

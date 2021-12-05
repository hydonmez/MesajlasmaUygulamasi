using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
namespace Server
{
    public class SpnSifreleme
    {
        string sifre = "konusmak";// sifre belirlenir
        public string[] BitlereAyir(string metin)// sifrebitlimetin ve şifre ={10000011,1100111,....}
        {
            if (metin.Length % 2 == 1)//gelen metnin uzunlugu cift haneden olusmuyorsa sonuna yildiz eklenir
            {
                metin += " ";
            }

            char[] sifrelenecekmetin = metin.ToCharArray();//gelen mesaj char dizine cevrilir
            string[] sifrelibitlimetin = new string[sifrelenecekmetin.Length];
            for (int i = 0; i < sifrelenecekmetin.Length; i++)
            {
                sifrelibitlimetin[i] = Convert.ToString(sifrelenecekmetin[i], 2).PadLeft(8, '0');//ilgili harf ikilik sisteme cevrilir ve basına 0 eklenir asciiden dolayı
            }
            return sifrelibitlimetin; //geri dönüş değerin string  bir dizidir
        }
        public string sifrele(string mesaj)//mesaj sifreleme islemi bu foksiyonda gerceklesir kendine gelen mesaji gerekli algoritmayi calistirarak sifreler
        {

            string[] bitlimesaj = BitlereAyir(mesaj);//gelen mesajı ve sifreyi bitli string hale getirdim(00110100,00110011.. gibi)
            string[] bitlisifre = BitlereAyir(sifre);//daha onceden tanimli olan private key ikilik sisteme cevrilerek bitlerine ayrilir(0010101,0101010..)
            string sonuc = "";

            //K0
            for (int i = 0; i < bitlimesaj.Length; i = i + 2)//karakter sayisinin yarisi kadar bu islem terkar edilir 8 karakterlik bir mesaj icin 4 kez doner
            {
                string k0 = "";
                var gecici = (bitlimesaj[i] + bitlimesaj[i + 1]).ToCharArray();  //metnin ilk iki harfinin bitli hali alinir ve bir degiskende tutulur
                var sifregecici = (bitlisifre[0] + bitlisifre[1]).ToCharArray(); // k0 yani sifrenin ilk iki harfinin bitli hali alinir ve bir degiskende tutulur
                k0 = new String(Xorla(gecici, sifregecici));//metnin ilk 2 karakteriyle Yani k0' nun xorlarlanmis halini döner

                string k1 = "";
                sifregecici = (bitlisifre[2] + bitlisifre[3]).ToCharArray();//sifrenin 3 ve 4 karakterlerinin bitleri cevrilmis galini alır
                k1 = new String(Xorla(karistir(k0), sifregecici));// bir onceki adimda ortaya cikan 16 bitlik karakter once karistirilir sonra 3 ve 4 karakterle xorlanır,nu ile orlanmış döner 

                string k2 = "";
                sifregecici = (bitlisifre[4] + bitlisifre[5]).ToCharArray();// yukarıdaki adimlar tekrarlanir
                k2 = new String(Xorla(karistir(k1), sifregecici));

                string k3 = "";
                sifregecici = (bitlisifre[6] + bitlisifre[7]).ToCharArray();
                k3 = new String(Xorla(karistir(k2), sifregecici)); //yukari adimlar tekrarlanir

                sonuc += k3;//olusan en son 16 bitlik sonuc metnin ilk 2 karakteri icin sifrelenmis hali olur ve sonuca eklenir
            }
            return sonuc;
        }
        public string sifreliMesajYaz(string sifreBitli)//ikilik sisteme olusan sifre parametre olarak alinir ve ekrana ascii karsiliklari dondurulur
        {
            var data = GetBytesFromBinaryString(sifreBitli);
            var text = Encoding.ASCII.GetString(data);
            return text;
        }
        public Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8) //sifrelenmis bitler 8-8 ayrıalrak  byte haline cevrilir ve biz dizi olarak dondurulur 
            {
                String t = binary.Substring(i, 8).PadLeft(8, '0');
                list.Add(Convert.ToByte(t, 2));
            }
            return list.ToArray();
        }
        public string SifreyiCOZ(string mesaj)//mesaj olarak gelen 2 lik sistemde olusan mesaji cozerek sifrelenmeden onceki 2 lik sisteme geri cevirir
        {

            string[] bitlimesaj = bitleriAyır(mesaj);// sifrelenmis mesajin bitli hali  8'erli gruplar haline hale getirilir(00110100, 00110011..gibi)
            string[] bitlisifre = BitlereAyir(sifre);//sifrenin string hali 8'erli bitler haline donusturulur
            string sonuc = "";

            //K0
            for (int i = 0; i < bitlimesaj.Length; i = i + 2)//cozulecek sifre boyutun yarisi kadar doner
            {
                string k3 = "";
                var gecici = (bitlimesaj[i] + bitlimesaj[i + 1]).ToCharArray(); //sifrelenmis 2 lik sistemdeki mesajın ilk 16 bit alinir
                var sifregecici = (bitlisifre[6] + bitlisifre[7]).ToCharArray();//sifrenin son 16 biti alinir yani 7 ve 8 harflerin bitli hali
                k3 = new String(Xnorla(gecici, sifregecici)); //Xnorlanarak bir onceki adima geri cevrilir

                string k2 = "";
                sifregecici = (bitlisifre[4] + bitlisifre[5]).ToCharArray();// k3 ten geri cevrilmis sifre karistirma isleminin tersi olan cozumlemeye sokularak eski haline getirilir ve xorun tersine xnora sokularak bir onceki hale cevrilir
                k2 = new String(Xnorla(Cozumle(k3), sifregecici));// 

                string k1 = "";
                sifregecici = (bitlisifre[2] + bitlisifre[3]).ToCharArray();//
                k1 = new String(Xnorla(Cozumle(k2), sifregecici)); //yukaridaki islemler tekrar edilir

                string k0 = "";
                sifregecici = (bitlisifre[0] + bitlisifre[1]).ToCharArray();//ak
                k0 = new String(Xnorla(Cozumle(k1), sifregecici));//yukardaki islemler tekrar edilir bir onceki islemin sonucu cozumlenir ve sifrenin ilk 16 bitiyle xnorlarak ilk haline getirilmis olunur 

                sonuc += k0; //ilk 16 bitin sifrelenmemis haline geri getirilir ve sonuca eklenir bu islem tekrar edilir
            }
            return sonuc;// cozumlenmis sifre 2lik sistemede geri donderilir
        }

        public char[] Xorla(char[] mesaj, char[] sifre)//algoritma geregi sifre ve mesajin uygun 16 bitleri xorlanır
        {
            char[] sonuc = new char[16];
            for (int i = 0; i < mesaj.Length; i++)
            {
                sonuc[i] = (mesaj[i] == sifre[i]) ? '0' : '1';
            }
            return sonuc; //xorlanmis sonuc geri donderilir
        }
        public char[] karistir(string mesaj) //algoritmadaki kurallara uygun olarak xorlanmis veri kendi icide karistirilir
        {
            char[] charliMesaj = mesaj.ToCharArray();
            char[] sonucChar = new char[16];
            int[] algoritma = { 5, 9, 0, 12, 7, 3, 11, 14, 1, 4, 13, 8, 2, 15, 6, 10 };//karistirma algoritmasi kolaylik olsun diye bir diziye atilir

            for (int i = 0; i < 16; i++)
            {
                sonucChar[i] = charliMesaj[algoritma[i]];//degistirme islemi gerceklesir

            }
            return sonucChar; //karistirma sonucu geri donderilir
        }
        public char[] Cozumle(string acilacak)//daha once karistirilmis 16'lik bitler sifreyi cozebilmek icin tam tersi isleme tutularak cozumlenir
        {

            char[] sonucChar = new char[16];
            int[] algoritma = { 2, 8, 12, 5, 9, 0, 14, 4, 11, 1, 15, 6, 3, 10, 7, 13 }; //cozumleme algoritmasi kolaylik olsun diye bir diziye atilir

            for (int i = 0; i < 16; i++)
            {
                sonucChar[i] = acilacak[algoritma[i]];//cozumleme islemi gerceklesir

            }
            return sonucChar; //cozumlenmis sonuc geri donderilir

        }
        public char[] Xnorla(char[] messages, char[] sifre)//cozumleme icin xorun tersi olan xnor islemi gerceklesir
        {
            char[] donecek = new char[16];
            for (int i = 0; i < messages.Length; i++)
            {
                donecek[i] = (messages[i] != sifre[i]) ? '0' : '1';//iki bit ayni degilse 0 ayni ise 1 yapilir
            }
            return donecek;
        }
        public string[] bitleriAyır(String binary)//sifreyi cozmmek icin sifrelenmis bitler uygun formatta 8'er 8'er ayrilir ve bir string olarak geri donderillir
        {
            var list = new List<string>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8).PadLeft(8, '0');//eksik bit varsa sola 0 konur

                list.Add(Convert.ToString(t));
            }
            return list.ToArray();//bitlerin ayrilmis hali liste olarak geri donderilir
        }
    }
}


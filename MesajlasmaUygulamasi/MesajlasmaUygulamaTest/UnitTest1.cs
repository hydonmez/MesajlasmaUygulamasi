using NUnit.Framework;
using Server;
namespace MesajlasmaUygulamaTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

       
        [Test]
        public void TurkceKarakterDuzelt() //turkce karakterler asciye uygun hale getirildi mi ?
        {
            MesajIslemleri mesajIslemleri = new MesajIslemleri();
            Assert.AreEqual("omer canakkalede semsi yemek ismarla",mesajIslemleri.TurkceKarakterDuzelt("ömer çanakkalede þemsi yemek ýsmarla"));
        }
        [Test]
        public void SpnDuzgunSifreUretiyormu()
        {
            SpnSifreleme spn = new SpnSifreleme();           
            Assert.AreEqual("0100010010110110", spn.sifrele("ah")); //sifreleme islemi dogru mu ?
        }
      
        [Test]
        public void ShaDuzgunSifreUretiyormu() //Sha Duzgun Sifre Uretiyor mu ?
        {
            Sha256Sifreleme sha = new Sha256Sifreleme();
            Assert.AreEqual("4cf6829aa93728e8f3c97df913fb1bfa95fe5810e2933a05943f8312a98d9cf2", sha.MetniSifrele("sa"));
        }
        [Test]
        public void SifreliMetinDogruSekildeCozumleniyorMu()// Sifreli Metin Dogru bir Sekilde Cozumleniyor Mu ?
        {
            SpnSifreleme spnSifreleme = new SpnSifreleme();            
            Assert.AreEqual(spnSifreleme.SifreyiCOZ("0100010010110110"), "0110000101101000"); //sifreli mesaj doðru cozumlenebiliyor mu?  //ah karakterleri icin
        }
        [Test]

        public void CanInstantieateSha256Sifreleme()//Sha256Sifreleme sýnýfýndan nesne yaratilabiliyor mu
        {
            Sha256Sifreleme sha = new Sha256Sifreleme();
        }
        [Test]
        public void CanInstantieateSpnSifreleme()// SpnSifreleme sýnýfýndan nesne yaratilabiliyor mu
        {
            SpnSifreleme spn = new SpnSifreleme();
        }

        [Test]
        public void CanInstantieateMesajIslemleri()// MesajIslemleri sýnýfýndan nesne yaratilabiliyor mu
        {
            MesajIslemleri mesajIslemleri = new MesajIslemleri();
        }

        [Test]
        public void CanInstantieateDosyaSifreleme()// DosyaSifrelemeIslemleri sýnýfýndan nesne yaratilabiliyor mu
        {
            DosyaSifrelemeIslemleri dosyaSifrelemeIslemleri = new DosyaSifrelemeIslemleri("yazilimmuhendisi");//parametre olarak key 16 karakterden olusmali
        }
        [Test]
        public void CanInstantieateDosyaSikistirma()//DosyaSikistirmaIslemlerie sýnýfýndan nesne yaratilabiliyor mu
        {
            DosyaSikistirmaIslemleri dosyaSikistirma = new DosyaSikistirmaIslemleri();
        }
        [Test]
        public void CanInstantieateDosyaSifreleSikistirVeGondermeIslemleri()//DosyaSifreleSikistirVeGondermeIslemleri sýnýfýndan nesne yaratilabiliyor mu
        {
            DosyaSifreleSikistirVeGondermeIslemleri dosyaSikistirmav = new DosyaSifreleSikistirVeGondermeIslemleri();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;



namespace Server
{
    public class Sha256Sifreleme
    {
        public string MetniSifrele(string metin)//string mesa değeri  alınır ve sha ile sifrelenir
        {
            using (SHA256 sha256Hash = SHA256.Create()) //bir sha nesnesi yaratılır ve sha için gerekli prosedür izlenerek sifrelenmis mesaj geri dönderilir
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(metin));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

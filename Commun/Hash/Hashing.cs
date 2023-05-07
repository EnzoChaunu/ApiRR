using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Commun.Hash
{
    public class Hashing
    {

        public static string HashToken(string token)
        {

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convertir la chaîne d'entrée en tableau de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(token));

                // Convertir le tableau de bytes en chaîne hexadécimale
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace ApiGTT.Helpers
{
    public class Encrypt
    {

        public static string Hash(string value)
        {
            StringBuilder hash = new StringBuilder();

            MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5Provider.ComputeHash(new UTF8Encoding().GetBytes(value));

            for (int i = 0; i<bytes.Length; i++) {

                hash.Append(bytes[i].ToString("x2"));
            }

            return hash.ToString();
        }

    }
}

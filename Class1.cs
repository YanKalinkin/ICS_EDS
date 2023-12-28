using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ICS_Lab_4_dll;

namespace ICS_EDS
{
    public static class MyEDS
    {
        public static string GetHash(string input)
        {
            var check_md5 = MD5.Create();
            var hash_m = check_md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash_m);
        }

        public static string crypt_hash(char input, int d, int n)
        {
            return MyRSA.RSA_encrypt((int)input, d, n).ToString();
        }

        public static string get_s(string input, int e, int n)
        {
            string put_here = "";
            string decrypted = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != ' ')
                {
                    put_here += input[i];
                }
                else
                {
                    decrypted += MyRSA.RSA_decrypt(Convert.ToInt32(put_here), e, n).ToString();
                    put_here = "";
                }
            }
            return decrypted;
        }
    }
}

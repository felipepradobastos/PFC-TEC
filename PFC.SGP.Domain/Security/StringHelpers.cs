using System;
using System.Security.Cryptography;
using System.Text;

namespace PFC.SGP.Domain.Security
{
    public static class StringHelpers
    {
        public static string Encrypt(this string senha)
        {
            //Aqui ficaria o sistema de criptografia das senhas,
            //que foi modificado antes do commit.

            var arrayBytes = Encoding.UTF8.GetBytes(senha);

            byte[] hashBytes;
            using (var sha = SHA512.Create())
            {
                hashBytes = sha.ComputeHash(arrayBytes);
            }
            return Convert.ToBase64String(hashBytes);
        }
    }
}

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Servicios
{
    public class Seguridad
    {
        public static string Encriptar(string Dato)
        {
            byte[] TextoEncriptado;
            var DatoEntrada = Encoding.UTF8.GetBytes(Dato);
            using (var AlgAes = new RijndaelManaged())
            {
                AlgAes.Key = Encoding.ASCII.GetBytes("{M[3]}{R(C)}{4(D)}{3[R]}{50(63)}");
                AlgAes.IV = Encoding.ASCII.GetBytes("{.[N](3){T}[VS]}");
                using (var MS = new MemoryStream(DatoEntrada.Length))
                {
                    using (var CS = new CryptoStream(MS, AlgAes.CreateEncryptor(AlgAes.Key, AlgAes.IV), CryptoStreamMode.Write))
                    {
                        CS.Write(DatoEntrada, 0, DatoEntrada.Length);
                    }

                    TextoEncriptado = MS.ToArray();
                }
            }

            return Convert.ToBase64String(TextoEncriptado);
        }

        public static string Desencriptar(string Dato)
        {
            string TextoDesencriptado = string.Empty;
            var DatoEntrada = Convert.FromBase64String(Dato);
            using (var AlgAes = new RijndaelManaged())
            {
                AlgAes.Key = Encoding.ASCII.GetBytes("{M[3]}{R(C)}{4(D)}{3[R]}{50(63)}");
                AlgAes.IV = Encoding.ASCII.GetBytes("{.[N](3){T}[VS]}");
                var MS = new MemoryStream(DatoEntrada);
                var CS = new CryptoStream(MS, AlgAes.CreateDecryptor(AlgAes.Key, AlgAes.IV), CryptoStreamMode.Read);
                var SR = new StreamReader(CS);
                TextoDesencriptado = SR.ReadToEnd();
            }

            return TextoDesencriptado;
        }

        public static string EncriptarMD5(string Dato)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] resultado;
            resultado = md5.ComputeHash(Encoding.ASCII.GetBytes(Dato));
            var Cadena = new StringBuilder();
            for (int i = 0, loopTo = resultado.Length - 1; i <= loopTo; i++)
                Cadena.Append(resultado[i].ToString("x2"));
            return Cadena.ToString();
        }
    }
}
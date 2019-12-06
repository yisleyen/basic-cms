using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Data.Helper
{
    public class CryptoHelper
    {
        private static string AC_KEY = "*****";

        /// <summary>
        /// Cryptography Helper
        /// </summary>
        public CryptoHelper()
        {

        }

        /// <summary>
        /// Cryptography Helper
        /// </summary>
        /// <param name="StrKey">Enter a specified key.</param>
        public CryptoHelper(string strKey)
        {
            AC_KEY = strKey;
        }

        /// <summary>
        /// Encrypt the given string using the specified key.
        /// </summary>
        /// <param name="strToEncrypt">The string to be encrypted.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string strToEncrypt)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;

                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(AC_KEY));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB

                byteBuff = ASCIIEncoding.ASCII.GetBytes(strToEncrypt);
                return Convert.ToBase64String(objDESCrypto.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            }
            catch (Exception ex)
            {
                return "HATA : " + ex.Message;
            }
        }

        /// <summary>
        /// Decrypt the given string using the specified key.
        /// </summary>
        /// <param name="strEncrypted">The string to be decrypted.</param>
        /// <returns>The decrypted string.</returns>
        public static string Decrypt(string strEncrypted)
        {
            try
            {
                TripleDESCryptoServiceProvider objDESCrypto = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider objHashMD5 = new MD5CryptoServiceProvider();

                byte[] byteHash, byteBuff;

                byteHash = objHashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(AC_KEY));
                objHashMD5 = null;
                objDESCrypto.Key = byteHash;
                objDESCrypto.Mode = CipherMode.ECB; //CBC, CFB

                byteBuff = Convert.FromBase64String(strEncrypted.Replace(" ", "+"));
                string strDecrypted = ASCIIEncoding.ASCII.GetString(objDESCrypto.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                objDESCrypto = null;

                return strDecrypted;
            }
            catch (Exception ex)
            {
                return "HATA : " + ex.Message;
            }
        }

        /// <summary>
        /// Convert the given string to MD5 hash.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>The MD5 Hash</returns>
        public static string GetMD5Hash(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("X2"));
            }

            return s.ToString();
        }

        /// <summary>
        /// Convert the given string to Base64String.
        /// </summary>
        /// <param name="toEncode">The string to be encoded.</param>
        /// <returns>Encoded Base64String</returns>
        public static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.Encoding.UTF8.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        /// <summary>
        /// Decode from Base64String to orginal string
        /// </summary>
        /// <param name="encodedData">Base64String</param>
        /// <returns>The decoded string.</returns>
        public static string DecodeFrom64(string encodedData)
        {
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
            string returnValue = System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
            return returnValue;
        }

        /// <summary>
        /// Get unique key value
        /// </summary>
        /// <param name="lenght">Length is what you get?</param>
        /// <returns></returns>
        public static string GetUniqueKey(int lenght)
        {
            char[] chars = new char[36];
            string a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            chars = a.ToCharArray();
            int size = lenght;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = lenght;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);

            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length - 1)]);
            }

            return result.ToString();
        }


    }//end class
}

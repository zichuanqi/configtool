using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace configtool
{
    public class License
    {
        /// <summary>
        /// 获取License
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetLicense(string code)
        {
            return MD5Encrypt(code);
        }

        ///   <summary>
        ///   给一个字符串进行MD5加密
        ///   </summary>
        ///   <param   name="strText">待加密字符串</param>
        ///   <returns>加密后的字符串</returns>
        private string MD5Encrypt(string strText)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string strPass = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(strText)), 0);
            strPass = strPass.Replace("-", "");
            return strPass;
        }

        #region DES加密解密

        //默认密钥向量
        /// <summary>
        /// 
        /// </summary>
        private readonly byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        //默认加密、解密密钥
        /// <summary>
        /// 
        /// </summary>
        private const string DEFAULT_ENCRYPT_KEY = "ABCDabcd";

        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        /// <remarks></remarks>
        public string EncryptDES(string encryptString, string encryptKey)
        {
            if (encryptKey == "" || encryptKey.Length < 8) encryptKey = DEFAULT_ENCRYPT_KEY;

            try
            {
                var byteKeys = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                //var rgbIV = Keys;
                var bytesEncrypt = Encoding.UTF8.GetBytes(encryptString);
                var desCrySerProvider = new DESCryptoServiceProvider();
                var memoryStream = new MemoryStream();
                var cryptoStream = new CryptoStream(memoryStream, desCrySerProvider.CreateEncryptor(byteKeys, Keys), CryptoStreamMode.Write);
                cryptoStream.Write(bytesEncrypt, 0, bytesEncrypt.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// 使用默认密钥加密
        /// </summary>
        /// <param name="encryptString">The encrypt string.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string EncryptDES(string encryptString)
        {
            try
            {
                var bytesKeys = Encoding.UTF8.GetBytes(DEFAULT_ENCRYPT_KEY.Substring(0, 8));
                //var rgbIV = Keys;
                var bytesEncrypt = Encoding.UTF8.GetBytes(encryptString);
                var desProvider = new DESCryptoServiceProvider();
                var memoryStream = new MemoryStream();
                var cryptoStream = new CryptoStream(memoryStream, desProvider.CreateEncryptor(bytesKeys, Keys), CryptoStreamMode.Write);
                cryptoStream.Write(bytesEncrypt, 0, bytesEncrypt.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(memoryStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        /// <remarks></remarks>
        public string DecryptDES(string decryptString, string decryptKey)
        {
            if (decryptKey == "" || decryptKey.Length < 8)
                decryptKey = DEFAULT_ENCRYPT_KEY;
            try
            {
                var bytesKeys = Encoding.UTF8.GetBytes(decryptKey);
                //var rgbIV = Keys;
                var bytesDecrypt = Convert.FromBase64String(decryptString);
                var desProvider = new DESCryptoServiceProvider();
                var memoryStream = new MemoryStream();
                var cryptoStream = new CryptoStream(memoryStream, desProvider.CreateDecryptor(bytesKeys, Keys), CryptoStreamMode.Write);
                cryptoStream.Write(bytesDecrypt, 0, bytesDecrypt.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        //使用默认密钥解密
        /// <summary>
        /// Decrypts the DES.
        /// </summary>
        /// <param name="decryptString">The decrypt string.</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string DecryptDES(string decryptString)
        {
            try
            {
                var bytesKeys = Encoding.UTF8.GetBytes(DEFAULT_ENCRYPT_KEY);
                //var rgbIV = Keys;
                var bytesDecrypt = Convert.FromBase64String(decryptString);
                var desProvider = new DESCryptoServiceProvider();
                var memoryStream = new MemoryStream();
                var cryptoStream = new CryptoStream(memoryStream, desProvider.CreateDecryptor(bytesKeys, Keys), CryptoStreamMode.Write);
                cryptoStream.Write(bytesDecrypt, 0, bytesDecrypt.Length);
                cryptoStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }

        #endregion
    }
}

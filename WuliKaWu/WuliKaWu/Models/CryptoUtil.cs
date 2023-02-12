using Microsoft.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;

namespace WuliKaWu.Models
{
    /// <summary>
    /// 藍新加解密 Util
    /// </summary>
    public class CryptoUtil
    {
        /// <summary>
        /// 字串加密 AES
        /// </summary>
        /// <param name="source">加密前字串</param>
        /// <param name="cryptoKey">加密金鑰</param>
        /// <param name="cryptoIV">crytoIV</param>
        /// <returns>加密後字串</returns>
        public static byte[] EncryptAES(byte[] source, string cryptoKey, string cryptoIV)
        {
            byte[] dataKey = Encoding.UTF8.GetBytes(cryptoKey);
            byte[] dataIV = Encoding.UTF8.GetBytes(cryptoIV);

            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = dataKey;
                aes.IV = dataIV;

                using (var encryptor = aes.CreateEncryptor())
                {
                    return
                        encryptor.TransformFinalBlock(source, 0, source.Length);
                }
            }
        }

        /// <summary>
        /// 字串解密 AES
        /// </summary>
        /// <param name="source">解密前字串</param>
        /// <param name="cryptoKey">解密金鑰</param>
        /// <param name="crytoIV">crytoIV</param>
        /// <returns>解密後字串</returns>
        public static byte[] DecryptAES(byte[] source, string cryptoKey, string crytoIV)
        {
            byte[] dataKey = Encoding.UTF8.GetBytes(cryptoKey);
            byte[] dataIV = Encoding.UTF8.GetBytes(crytoIV);

            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                //無法直接用 PaddingMode.PKCS7 會跳"填補無效 而且無法移除"
                //所以改為 PaddingMode.None 並搭配RemovePKCS7Padding
                aes.Padding = PaddingMode.None;
                aes.Key = dataKey;
                aes.IV = dataIV;

                using (var decryptor = aes.CreateDecryptor())
                {
                    return RemovePKCS7Padding(decryptor.TransformFinalBlock(source, 0, source.Length));
                }
            }
        }

        //private static byte[] RemovePKCS7Padding(byte[] bytes)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// 加密後再轉 16 進制字串
        /// </summary>
        /// <param name="source">加密前字串</param>
        /// <param name="cryptoKey">加密金鑰</param>
        /// <param name="cryptoIV">cryptoIV</param>
        /// <returns></returns>
        public static string EncryptAESHex(string source, string cryptoKey, string cryptoIV)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(source))
            {
                var encryptValue = EncryptAES(Encoding.UTF8.GetBytes(source), cryptoKey, cryptoIV);

                if (encryptValue != null)
                {
                    result = BitConverter.ToString(encryptValue)?.Replace("-", string.Empty)?.ToLower();
                }
            }
            return result;
        }

        /// <summary>
        /// 16 進制字串解密
        /// </summary>
        /// <param name="source">加密前字串</param>
        /// <param name="cryptoKey">加密金鑰</param>
        /// <param name="cryptIV">cryptIV</param>
        /// <returns>解密後的字串</returns>
        public static string DecryptAESHex(string source, string cryptoKey, string cryptIV)
        {
            string result = string.Empty;

            if (!string.IsNullOrEmpty(source))
            {
                //將 16進制字串 轉為byte[]後
                byte[] sourceBytes = GetByteArray(source);
                if (sourceBytes != null)
                //使用金鑰解密後 轉回加密前value
                {
                    result = Encoding.UTF8.GetString(DecryptAES(sourceBytes, cryptoKey, cryptIV)).Trim();
                }
            }
            return result;
        }

        /// <summary>
        /// 字串加密 SHA256
        /// </summary>
        /// <param name="source">加密前字串</param>
        /// <returns>加密後字串</returns>
        public static string EncryptSHA256(string source)
        {
            string result = string.Empty;
            using (SHA256 alogorithm = SHA256.Create())
            {
                var hash = alogorithm.ComputeHash(Encoding.UTF8.GetBytes(source));
                if (hash != null)
                {
                    result = BitConverter.ToString(hash)?.Replace("-", string.Empty)?.ToUpper();
                }
            }
            return result;
        }

        /// <summary>
        /// 將 16 進位字串轉換為 byteArray
        /// </summary>
        /// <param name="source">欲轉換之字串</param>
        /// <returns></returns>
        public static byte[] GetByteArray(string source)
        {
            byte[] result = null;

            if (!string.IsNullOrWhiteSpace(source))
            {
                var outputLength = source.Length / 2;
                var output = new byte[outputLength];

                for (var i = 0; i < outputLength; i++)
                {
                    output[i] = Convert.ToByte(source.Substring(i * 2, 2), 16);
                }
                result = output;
            }
            return result;
        }

        private static byte[] RemovePKCS7Padding(byte[] data)
        {
            int iLength = data[data.Length - 1];
            var output = new byte[data.Length - iLength];
            Buffer.BlockCopy(data, 0, output, 0, output.Length);
            return output;
        }
    }
}
using Newtonsoft.Json;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;

namespace Fund_API.Framework.Helper
{
    public static class CommonMethods
    {
        private static readonly string EncryptionKey = "AppEncKEY";
        private static Random random = new();

        /// <summary>
        /// Serializes the object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectValue">The object value.</param>
        /// <returns></returns>
        public static string SerializeObject<T>(T objectValue)
        {
            return JsonConvert.SerializeObject(objectValue);
        }

        /// <summary>
        /// Deserializes the string to intended object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectValue">The object value.</param>
        /// <returns>Serialized target object</returns>
        public static T DeserializeObject<T>(string objectValue)
        {
            return JsonConvert.DeserializeObject<T>(objectValue);
        }
        public static string EncryptValue(string sEncryptionData)
        {
            string sEncryptionValue = string.Empty;
            try
            {
                byte[] clearBytes = Encoding.Unicode.GetBytes(sEncryptionData);
                using (Aes encryptor = Aes.Create())
                {
                    // encryptor.Padding = PaddingMode.None;
                    using (Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, clearBytes, 10000, HashAlgorithmName.SHA256))
                    {

                        // encryptor.Key = pdb.GetBytes(24);
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        sEncryptionValue = Convert.ToBase64String(ms.ToArray());
                        sEncryptionValue = sEncryptionValue.Replace("/", "♥");
                    }
                }
            }
            catch (Exception Ex)
            {
                new ErrorLog().WriteLog(Ex);
            }
            return sEncryptionValue;
        }

        /// <summary>
        /// accepts an encrypted string and returns the string as plain text
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string DecryptValue(string cipherText)
        {
            string sDecrpytText = "";
            try
            {
                if (cipherText != null && EncryptionKey != "" && cipherText != "")
                {
                    cipherText = cipherText.Replace("♥", "/");

                    cipherText = cipherText.Replace(" ", "+");// Replace the Empty string with. Becase FromBase64String won't accept the Empty string
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    using (Aes encryptor = Aes.Create())
                    {
                        // encryptor.Padding = PaddingMode.Zeros;
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, cipherBytes, 10000, HashAlgorithmName.SHA256);
                        //encryptor.Key = pdb.GetBytes(24);
                        encryptor.Key = pdb.GetBytes(32);
                        encryptor.IV = pdb.GetBytes(16);
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                cs.Write(cipherBytes, 0, cipherBytes.Length);
                                cs.Close();
                            }
                            sDecrpytText = Encoding.Unicode.GetString(ms.ToArray());
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                new ErrorLog().WriteLog(Ex);
            }
            return sDecrpytText;
        }

        public static string ReadFile(string path)
        {
            string fileData = string.Empty;
            try
            {
                if (File.Exists(path))
                {
                    fileData = File.ReadAllText(path);
                }
            }
            catch (Exception)
            {
            }
            return fileData;
        }

        public static string GenerateLicenseKey(int totalLength = 25, int segmentLength = 5)
        {

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string newKey;
            int numberOfSegments = (totalLength + 1) / (segmentLength + 1); // Calculate the number of segments

            newKey = string.Join("-", Enumerable.Range(0, numberOfSegments)
                .Select(_ => new string(Enumerable.Repeat(chars, segmentLength)
                .Select(s => s[random.Next(s.Length)]).ToArray())));

            return newKey;
        }
        /// <summary>
        /// To generate unique File name
        /// </summary>
        /// <param name="fileExtension">File extention</param>
        /// <returns>generated file name</returns>
        public static string GenerateUniqueFileName(string fileExtension)
        {
            string uniqueFileName = Guid.NewGuid().ToString();
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return $"{uniqueFileName}_{timestamp}{fileExtension}";
        }
    }
}
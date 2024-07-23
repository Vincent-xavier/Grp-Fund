using System.Security.Cryptography;
using System.Text;

namespace Fund_API.Framework.Helper
{
    public static class EncryptionHelperHelpers
    {
        public static string DefaultEncryptPassword = "Ld1SC263goR2mM0qVdPrSwmlRIGKWLj4mHlT08LWf54dl1IH6y4YHQ=="; //"Fund_APIs"
        public static string DefaultPassword = "Fund_APIs";
        public static string EncryptionKey = "office@ai";
    }

    public static class HashEncryption
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return null;
            }

            if (password.Length < 1)
            {
                return null;
            }

            byte[] salt = new byte[20];
            byte[] key = new byte[20];
            byte[] ret = new byte[40];

            try
            {
                RNGCryptoServiceProvider randomBytes = new RNGCryptoServiceProvider();
                randomBytes.GetBytes(salt);
                var hashBytes = new Rfc2898DeriveBytes(password, salt, 10000);
                key = hashBytes.GetBytes(20);
                Buffer.BlockCopy(salt, 0, ret, 0, 20);
                Buffer.BlockCopy(key, 0, ret, 20, 20);
                // returns salt/key pair
                return Convert.ToBase64String(ret);
            }
            finally
            {
                if (salt != null)
                {
                    Array.Clear(salt, 0, salt.Length);
                }

                if (key != null)
                {
                    Array.Clear(key, 0, key.Length);
                }

                if (ret != null)
                {
                    Array.Clear(ret, 0, ret.Length);
                }
            }
        }

        public static bool VerifyPassword(string passwordHash, string password)
        {
            if (string.IsNullOrEmpty(passwordHash) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            if (passwordHash.Length < 40 || password.Length < 1)
            {
                return false;
            }

            byte[] salt = new byte[20];
            byte[] key = new byte[20];
            byte[] hash = Convert.FromBase64String(passwordHash);

            try
            {
                Buffer.BlockCopy(hash, 0, salt, 0, 20);
                Buffer.BlockCopy(hash, 20, key, 0, 20);

                var hashBytes = new Rfc2898DeriveBytes(password, salt, 10000);

                byte[] newKey = hashBytes.GetBytes(20);

                if (newKey != null)
                {
                    if (newKey.SequenceEqual(key))
                    {
                        return true;
                    }
                }

                return false;
            }
            finally
            {
                if (salt != null)
                {
                    Array.Clear(salt, 0, salt.Length);
                }

                if (key != null)
                {
                    Array.Clear(key, 0, key.Length);
                }

                if (hash != null)
                {
                    Array.Clear(hash, 0, hash.Length);
                }
            }
        }
    }

    public static class EncryptionHelper
    {
        public static string EncryptValue(string sEncryptionData)
        {
            string sEncryptionValue = string.Empty;
            try
            {

                byte[] clearBytes = Encoding.Unicode.GetBytes(sEncryptionData);
                using (Aes encryptor = Aes.Create())
                {
                    // encryptor.Padding = PaddingMode.None;
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionHelperHelpers.EncryptionKey, [0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76]);

                    // encryptor.Key = pdb.GetBytes(24);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        sEncryptionValue = Convert.ToBase64String(ms.ToArray());
                        sEncryptionValue = sEncryptionValue.Replace("/", "♥");
                        sEncryptionValue = sEncryptionValue.Replace("&", "◆");
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
                if (cipherText != null && EncryptionHelperHelpers.EncryptionKey != "" && cipherText != "")
                {
                    cipherText = cipherText.Replace("♥", "/");
                    cipherText = cipherText.Replace("◆", "&");

                    cipherText = cipherText.Replace(" ", "+");// Replace the Empty string with. Becase FromBase64String won't accept the Empty string
                    byte[] cipherBytes = Convert.FromBase64String(cipherText);
                    using (Aes encryptor = Aes.Create())
                    {
                        // encryptor.Padding = PaddingMode.Zeros;
                        Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionHelperHelpers.EncryptionKey, [0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76]);
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

        public static string DecryptJSValue(string base64Encoded)
        {
            var decodedValue = string.Empty;
            try
            {
                // Decode the base64-encoded string
                var base64EncodedBytes = Convert.FromBase64String(base64Encoded);
                decodedValue = Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception ex)
            {
                ErrorLog errorLog = new ErrorLog();
                errorLog.WriteLog(ex);
            }
            return decodedValue;
        }
        public static string GetRandomPassword(int iLen = 8)
        {
            char[] chars = "abcdefghijklmnopqrstuvwxyz0123456989#@!ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            string password = string.Empty;
            Random random = new Random();

            for (int i = 0; i < iLen; i++)
            {
                int x = random.Next(1, chars.Length);
                //Don't Allow repeation of Characters
                if (!password.Contains(chars.GetValue(x).ToString()))
                {
                    password += chars.GetValue(x);
                }
                else
                {
                    i--;
                }
            }
            return password;
        }

        public static string GetRandomNumber(int iLen = 6)
        {
            char[] chars = "0123456989".ToCharArray();
            string password = string.Empty;
            Random random = new Random();

            for (int i = 0; i < iLen; i++)
            {
                int x = random.Next(1, chars.Length);
                //Don't Allow repeation of Characters
                if (!password.Contains(chars.GetValue(x).ToString()))
                {
                    password += chars.GetValue(x);
                }
                else
                {
                    i--;
                }
            }
            return password;
        }

        // AES decryption method
        public static string DecryptStringAES(string cipherText)
        {
            var keybytes = Encoding.UTF8.GetBytes("8080808080808080");
            var iv = Encoding.UTF8.GetBytes("8080808080808080");

            cipherText = cipherText.Replace(" ", "+");
            var encrypted = Convert.FromBase64String(cipherText);
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
            return string.Format(decriptedFromJavascript);
        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException(nameof(key));
            }
            // Declare the string used to hold
            // the decrypted text.
            string? plaintext = null;
            // Create an RijndaelManaged object
            // with the specified key and IV.
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;
                rijAlg.Key = key;
                rijAlg.IV = iv;
                // Create a decrytor to perform the stream transform.
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
                try
                {
                    // Create the streams used for decryption.
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }
            return plaintext;
        }
    }

}

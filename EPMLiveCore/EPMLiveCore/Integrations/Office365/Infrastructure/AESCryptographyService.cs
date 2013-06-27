using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EPMLiveCore.Integrations.Office365.Infrastructure
{
    internal class AESCryptographyService
    {
        #region Fields (5) 

        private static readonly byte[] Key =
            {
                77, 72, 250, 87, 203, 51, 197, 46, 47, 138, 50, 53, 180, 18, 235, 173,
                217, 83, 7, 52, 134, 127, 239, 11, 83, 200, 24, 196, 255, 135, 51, 81
            };

        private static readonly byte[] Vector =
            {
                51, 102, 16, 170, 191, 238, 20, 90, 243, 71, 35, 52, 60, 105, 18, 215
            };

        private readonly ICryptoTransform _decryptor;
        private readonly UTF8Encoding _encoder;
        private readonly ICryptoTransform _encryptor;

        #endregion Fields 

        #region Constructors (1) 

        public AESCryptographyService()
        {
            var rm = new RijndaelManaged();
            _encryptor = rm.CreateEncryptor(Key, Vector);
            _decryptor = rm.CreateDecryptor(Key, Vector);
            _encoder = new UTF8Encoding();
        }

        #endregion Constructors 

        #region Methods (7) 

        // Public Methods (6) 

        public string Decrypt(string encrypted)
        {
            return _encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
        }

        public byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, _decryptor);
        }

        public string DecryptFromUrl(string encrypted)
        {
            return Decrypt(HttpUtility.UrlDecode(encrypted));
        }

        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(_encoder.GetBytes(unencrypted)));
        }

        public byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, _encryptor);
        }

        public string EncryptToUrl(string unencrypted)
        {
            return HttpUtility.UrlEncode(Encrypt(unencrypted));
        }

        // Protected Methods (1) 

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            var stream = new MemoryStream();

            using (var cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }

            return stream.ToArray();
        }

        #endregion Methods 
    }
}
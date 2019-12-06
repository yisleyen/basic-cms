using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace CMS.Data
{
    public static partial class Extensions
    {
        public static string ToJSON<T>(this T value)
        {
            if (value == null) return string.Empty;

            string json = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple
            });

            return json;
        }

        public static string ToXML<T>(this T value)
        {
            if (value == null) return string.Empty;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

            using (StringWriter stringWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Indent = true }))
                {
                    xmlSerializer.Serialize(xmlWriter, value);
                    return stringWriter.ToString();
                }
            }
        }

        public static Guid ToGuid<T>(this T value)
        {
            if (value == null) return Guid.Empty;

            byte[] stringbytes = Encoding.UTF8.GetBytes(Convert.ToString(value));
            byte[] hashedBytes = new System.Security.Cryptography
                .SHA1CryptoServiceProvider()
                .ComputeHash(stringbytes);
            Array.Resize(ref hashedBytes, 16);
            return new Guid(hashedBytes);
        }

        public static string ToMD5<T>(this T value)
        {
            if (value == null) return string.Empty;

            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(value.ToString()));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("X2"));
            }

            return hash.ToString();
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Port3435.Core.Helper
{
    public class FileHelper
    {
        public static void Add2TextFile(string FilePath, string Content)
        {
            try
            {
                using (StreamWriter stream = new FileInfo(FilePath).CreateText())
                {
                    stream.WriteLine(Content);
                }
            }
            catch (Exception)
            {
            }
        }

        public static string ReadTextFile(string FilePath)
        {
            string result = string.Empty;

            using (StreamReader sr = File.OpenText(FilePath))
            {
                result = sr.ReadToEnd();
            }

            return result;
        }

        public static void CreateDirectory(string dbFolder)
        {
            if (!Directory.Exists(dbFolder))
            {
                Directory.CreateDirectory(dbFolder);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Helper
{
    public class CustomHelper
    {
        public static string GetNewFileName(string name, string filename)
        {
            string NewFilename = string.Empty;

            name = name + "-" + Guid.NewGuid();

            string SlugUrl = name.ToUrlSlug();

            int ExtensionStart = filename.IndexOf(".");
            int ExtensionEnd = filename.Length;

            string Extension = filename.Substring(ExtensionStart, ExtensionEnd - ExtensionStart);

            NewFilename = SlugUrl + Extension;

            return NewFilename;
        }
    }
}

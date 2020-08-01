using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Extensions
{
    public static class StringExtension
    {
        public static string ConvertToMD5(this string text)
        {
            if (string.IsNullOrEmpty(text)) return "";
            var pasword = (text += "|2d331cca-f6c0-40c0-bb43-6e3289c2889c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(pasword));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}

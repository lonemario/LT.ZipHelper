using System.IO;

namespace LT.ZipHelper.Utilities
{
    public static class FileNameNormalizer
    {
        public static string Normalize(string fileName)
        {
            string res = fileName;
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                res = res.Replace(c, '-');
            }
            return res;
        }
    }
}

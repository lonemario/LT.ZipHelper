using System;

namespace LT.ZipHelper.Data
{
    public class SourceFile
    {
        /// <summary>
        /// File Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// File Extension
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// File
        /// </summary>
        public Byte[] FileBytes { get; set; }
    }
}

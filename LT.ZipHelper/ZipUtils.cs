using LT.ZipHelper.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace LT.ZipHelper
{
    public static class ZipUtils
    {
        public static byte[] Compress(IList<SourceFile> sourceFiles)
        {
            // get the source files
            //List<SourceFile> sourceFiles = new List<SourceFile>();
            // ...

            // the output bytes of the zip
            //byte[] fileBytes = null;

            string FileName;

            // create a working memory stream
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                // create a zip
                using (System.IO.Compression.ZipArchive zip = new System.IO.Compression.ZipArchive(memoryStream, System.IO.Compression.ZipArchiveMode.Create, true))
                {
                    // interate through the source files
                    foreach (SourceFile f in sourceFiles)
                    {
                        //VALIDAZIONE
                        if (string.IsNullOrWhiteSpace(f.Name))
                            throw new ArgumentNullException(nameof(f.Name));
                        if (string.IsNullOrWhiteSpace(f.Extension))
                            throw new ArgumentNullException(nameof(f.Extension));
                        if (f.FileBytes == null)
                            throw new ArgumentNullException(nameof(f.FileBytes));
                            
                        //NORMALIZZO NOME ED ESTENSIONE
                        FileName = f.Name.Trim();
                        if (FileName.Substring(FileName.Length - 1) == ".")
                            FileName = FileName.Substring(0, FileName.Length - 2);

                        if (f.Extension.Trim().Substring(0,1)==".")
                            FileName = FileName + f.Extension.Trim();
                        else
                            FileName = $"{FileName}.{f.Extension}";

                        //CONTROLLO CHE IL NOME DEL FILE O L'ESTENSIONE NO  CONTENGANO CARATTERI NON VALIDI
                        Regex containsABadCharacter = new Regex("["+ Regex.Escape(new string(Path.GetInvalidPathChars())) + "]");
                        if (containsABadCharacter.IsMatch(FileName))
                            throw new Exception("File Name or Extension constains invalid characters");

                        // add the item name to the zip
                        System.IO.Compression.ZipArchiveEntry zipItem = zip.CreateEntry(f.Name + "." + f.Extension);
                        // add the item bytes to the zip entry by opening the original file and copying the bytes 
                        using (MemoryStream originalFileMemoryStream = new MemoryStream(f.FileBytes))
                        {
                            using (Stream entryStream = zipItem.Open())
                            {
                                originalFileMemoryStream.CopyTo(entryStream);
                            }
                        }
                    }
                }
                //fileBytes = memoryStream.ToArray();
                return memoryStream.ToArray();
            }

            // download the constructed zip
            //Response.AddHeader("Content-Disposition", "attachment; filename=download.zip");
            //return File(fileBytes, "application/zip");
        }
    }
}

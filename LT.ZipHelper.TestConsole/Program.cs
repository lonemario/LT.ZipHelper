using LT.ZipHelper.Data;
using LT.ZipHelper.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace LT.ZipHelper.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<SourceFile> list = new List<SourceFile>();
            list.Add(new SourceFile {
                Extension = "pdf",
                Name = FileNameNormalizer.Normalize("N.CREDITO VENDITA_12/01/2018_877_VD"),
                FileBytes = File.ReadAllBytes(@"c:\Temp\EsCC.pdf")
            });
            list.Add(new SourceFile
            {
                Extension = "pdf",
                Name = "pippo1/",
                FileBytes = File.ReadAllBytes(@"c:\Temp\EsFattura.pdf")
            });
            list.Add(new SourceFile
            {
                Extension = "pdf",
                Name = "pippo2;",
                FileBytes = File.ReadAllBytes(@"c:\Temp\EsDocumentoI.pdf")
            });
            list.Add(new SourceFile
            {
                Extension = ".pdf",
                Name = "pippo3",
                FileBytes = File.ReadAllBytes(@"c:\Temp\EsCC.pdf")
            });
            list.Add(new SourceFile
            {
                Extension = "pdf",
                Name = "pippo4",
                FileBytes = File.ReadAllBytes(@"c:\Temp\EsFattura.pdf")
            });
            list.Add(new SourceFile
            {
                Extension = "pdf",
                Name = "pippo5",
                FileBytes = File.ReadAllBytes(@"c:\Temp\EsDocumentoI.pdf")
            });

            var res = ZipUtils.Compress(list);
            File.WriteAllBytes(@"c:\Temp\Doc.zip", res);

            Console.WriteLine("Compressione avvenuta!");
            Console.ReadKey();
        }
    }
}

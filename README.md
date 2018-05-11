# LT.ZipHelper
[![NuGet](https://img.shields.io/nuget/v/Nuget.Core.svg)](https://www.nuget.org/packages/LT.ZipHelper)

A cross platform library for compress files in a Zip Archive

## Prerequisites

### .NETStandard 2.0
```
System.IO.Compression (>= 4.3.0)
```

## Example 


```c#
static void Main(string[] args)
{
    //Normalize File Name
    var correctFileName = FileNameNormalizer.Normalize("N.CREDITO VENDITA_12/01/2018_877_VD");

    IList<SourceFile> list = new List<SourceFile>();
    list.Add(new SourceFile {
        Extension = "pdf",
        Name = correctFileName,
        FileBytes = File.ReadAllBytes(@"c:\Temp\EsCC.pdf")
    });
    list.Add(new SourceFile
    {
        Extension = "pdf",
        Name = "pippo1",
        FileBytes = File.ReadAllBytes(@"c:\Temp\EsFattura.pdf")
    });
    list.Add(new SourceFile
    {
        Extension = "pdf",
        Name = "pippo2",
        FileBytes = File.ReadAllBytes(@"c:\Temp\EsDocumentoI.pdf")
    });
    list.Add(new SourceFile
    {
        Extension = "pdf",
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
```

### Authors

- [Mario Righi](http://www.mariorighi.com)

### License

This project is licensed under the [MIT License](https://choosealicense.com/licenses/mit/)

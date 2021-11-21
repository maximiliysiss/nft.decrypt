using System;
using System.Drawing;

namespace Nft.Decrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length is < 1 or > 1)
                PrintHelp("Incorrect arguments");

            var bitmap = (Bitmap) Bitmap.FromFile(args[0]);
            var extractText = CryptImage.ExtractText(bitmap);
            Console.WriteLine(extractText);
        }

        private static void PrintHelp(string message = null)
        {
            Console.WriteLine($@"
{message}
Format execute:
nft.decrypt.exe @filePath
");
        }
    }
}
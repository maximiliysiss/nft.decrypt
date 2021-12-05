using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.PixelFormats;

namespace Nft.Decrypt
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length is < 1 or > 1)
                PrintHelp("Incorrect arguments");

            var bitmap = Image.Load<Rgb24>(args[0], new BmpDecoder());
            var extractText = CryptImage.ExtractText(bitmap);
            Console.WriteLine(extractText);
        }

        private static void PrintHelp(string message = null) =>
            Console.WriteLine($"{message}\nFormat execute:\nnft.decrypt.exe @filePath");
    }
}
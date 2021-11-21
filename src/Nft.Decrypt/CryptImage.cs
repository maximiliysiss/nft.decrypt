using System.Drawing;

namespace Nft.Decrypt
{
    public enum State
    {
        Hiding,
        FillingWithZeros
    };

    public static class CryptImage
    {
        public static string ExtractText(Bitmap bmp)
        {
            var colorUnitIndex = 0;
            var charValue = 0;
            var extractedText = string.Empty;

            for (var i = 0; i < bmp.Height; i++)
            {
                for (var j = 0; j < bmp.Width; j++)
                {
                    var pixel = bmp.GetPixel(j, i);

                    for (var n = 0; n < 3; n++)
                    {
                        charValue = (colorUnitIndex % 3) switch
                        {
                            0 => charValue * 2 + pixel.R % 2,
                            1 => charValue * 2 + pixel.G % 2,
                            2 => charValue * 2 + pixel.B % 2,
                            _ => charValue
                        };

                        colorUnitIndex++;

                        if (colorUnitIndex % 8 != 0)
                            continue;

                        charValue = ReverseBits(charValue);
                        if (charValue == 0)
                            return extractedText;
                        var c = (char) charValue;
                        extractedText += c.ToString();
                    }
                }
            }

            return extractedText;
        }

        private static int ReverseBits(int n)
        {
            var result = 0;

            for (var i = 0; i < 8; i++)
            {
                result = result * 2 + n % 2;
                n /= 2;
            }

            return result;
        }
    }
}
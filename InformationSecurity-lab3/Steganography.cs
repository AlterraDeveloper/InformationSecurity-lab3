using System;
using System.Drawing;
using System.Linq;

namespace InformationSecurity_lab3
{
    internal static class Steganography
    {
        public static int HideTextIntoImage(string text,ref Bitmap image, int lowBits)
        {
            int hiddenBits = -1;

            if (string.IsNullOrEmpty(text) | image == null | lowBits <= 0 | lowBits > 8)
            {
                return hiddenBits;
            }
            if (text.Length <= image.Width * image.Height * 3 * lowBits / 16)
            {
                text = IncreaseTextToHideInImage(text, lowBits);
                var bitStream = TextToBitStream(text);
                hiddenBits = bitStream.Length;
                byte byteFromStream;

                for (int i = 0; i < image.Width; i++)
                {
                    try
                    {
                        for (int j = 0; j < image.Height; j++)
                        {
                            var pixel = image.GetPixel(i, j);

                            byteFromStream = Convert.ToByte(bitStream.Substring(0, lowBits).PadRight(8, '0'), 2);
                            bitStream.Remove(0, lowBits);
                            var newR = PutByteToPixelColor(byteFromStream, pixel.R, lowBits);

                            byteFromStream = Convert.ToByte(bitStream.Substring(0, lowBits).PadRight(8, '0'), 2);
                            bitStream.Remove(0, lowBits);
                            var newG = PutByteToPixelColor(byteFromStream, pixel.G, lowBits);

                            byteFromStream = Convert.ToByte(bitStream.Substring(0, lowBits).PadRight(8, '0'), 2);
                            bitStream.Remove(0, lowBits);
                            var newB = PutByteToPixelColor(byteFromStream, pixel.B, lowBits);

                            image.SetPixel(i, j, Color.FromArgb(byte.MaxValue,newR, newG, newB));
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        break;
                    }
                }
            }

            return hiddenBits;
        }

        private static byte PutByteToPixelColor(byte myByte,byte color,int lowBits)
        {
            color >>= lowBits;
            color <<= lowBits;
            color |= myByte;
            return color;
        }
        
        private static string TextToBitStream(string text)
        {
            string bitStream = "";
            foreach (var c in text)
            {
                bitStream += Convert.ToString(c, 2).PadLeft(16, '0');
            }
            return bitStream;
        }

        private static string IncreaseTextToHideInImage(string originalText, int numberOfBits)
        {
            var desiredLength = originalText.Length * 16;
            while (desiredLength % numberOfBits != 0)
            {
                desiredLength += 16;
            }
            return originalText.PadRight(desiredLength / 16);
        }
    }
}

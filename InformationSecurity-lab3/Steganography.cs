using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace InformationSecurity_lab3
{
    internal static class Steganography
    {
        public static int HideTextIntoImage(string text, ref Bitmap image, int lowBits)
        {
            int hiddenBits = -1;

            if (string.IsNullOrEmpty(text) | image == null | lowBits <= 0 | lowBits > 8)
            {
                return hiddenBits;
            }

            text = IncreaseTextToHideInImage(text, lowBits);

            if (text.Length <= image.Width * image.Height * (int)Constants.COMPONENTS_IN_PIXEL * lowBits / (int)Constants.CHAR_LENGTH)
            {
                var textBitStream = TextToBitStream(text);
                hiddenBits = textBitStream.Length;
                //byte byteFromStream;
                //byte[] imageByteStream;
                ImageConverter converter = new ImageConverter();
                var imageByteStream = (byte[])converter.ConvertTo(image, typeof(byte[]));

                //using (var stream = new MemoryStream())
                //{
                //    image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                //    imageByteStream = stream.ToArray();
                //}

                for (int i = 0, j = 54; i < textBitStream.Length; i += lowBits, j++)
                {
                    byte textByte = Convert.ToByte(textBitStream.Substring(i, lowBits).PadLeft(8, '0'), 2);
                    imageByteStream[j] >>= lowBits;
                    imageByteStream[j] <<= lowBits;
                    imageByteStream[j] |= textByte;
                }

                image = (Bitmap)Image.FromStream(new MemoryStream(imageByteStream));
                //var tmpFileName = "tmpimg.bmp";
                //using(var fs = new FileStream(tmpFileName, FileMode.OpenOrCreate, FileAccess.Write))
                //{
                //    fs.Write(imageByteStream,0,imageByteStream.Length);
                //}
                //image = new Bitmap(tmpFileName);
                //File.Delete(tmpFileName);

                //for (int i = 0; i < image.Width; i++)
                //{
                //    try
                //    {
                //        for (int j = 0; j < image.Height; j++)
                //        {
                //            var pixel = image.GetPixel(i, j);

                //            byteFromStream = Convert.ToByte(bitStream.Substring(0, lowBits).PadRight(8, '0'), 2);
                //            bitStream = bitStream.Remove(0, lowBits);
                //            var newR = PutByteToPixelColor(byteFromStream, pixel.R, lowBits);

                //            byteFromStream = Convert.ToByte(bitStream.Substring(0, lowBits).PadRight(8, '0'), 2);
                //            bitStream = bitStream.Remove(0, lowBits);
                //            var newG = PutByteToPixelColor(byteFromStream, pixel.G, lowBits);

                //            byteFromStream = Convert.ToByte(bitStream.Substring(0, lowBits).PadRight(8, '0'), 2);
                //            bitStream = bitStream.Remove(0, lowBits);
                //            var newB = PutByteToPixelColor(byteFromStream, pixel.B, lowBits);

                //            image.SetPixel(i, j, Color.FromArgb(byte.MaxValue, newR, newG, newB));
                //        }
                //    }
                //    catch (ArgumentOutOfRangeException)
                //    {
                //        break;
                //    }
                //}
            }

            return hiddenBits;
        }

        private static byte PutByteToPixelColor(byte myByte, byte color, int lowBits)
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
                bitStream += Convert.ToString(c, 2).PadLeft((int)Constants.CHAR_LENGTH, '0');
            }
            return bitStream;
        }

        private static string IncreaseTextToHideInImage(string originalText, int numberOfBits)
        {
            var desiredLength = originalText.Length * (int)Constants.CHAR_LENGTH;
            while (desiredLength % numberOfBits != 0)
            {
                desiredLength += (int)Constants.CHAR_LENGTH;
            }
            return originalText.PadRight(desiredLength / (int)Constants.CHAR_LENGTH);
        }

        public static string ExtractTextFromImage(Bitmap image, int lowBits, int bitsLength)
        {
            char[] bitStream = new char[bitsLength];
            int streamIdx = 0;

            for (int i = 0; i < image.Width; i++)
            {
                try
                {
                    for (int j = 0; j < image.Height; j++)
                    {
                        var pixel = image.GetPixel(i, j);

                        foreach (var ch in GetNLowBitsInByte(pixel.R, lowBits))
                        {
                            bitStream[streamIdx++] = ch;
                        }
                        foreach (var ch in GetNLowBitsInByte(pixel.G, lowBits))
                        {
                            bitStream[streamIdx++] = ch;
                        }
                        foreach (var ch in GetNLowBitsInByte(pixel.B, lowBits))
                        {
                            bitStream[streamIdx++] = ch;
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }

            return BitStreamToText(new string(bitStream));
        }

        private static string BitStreamToText(string bitStream)
        {
            var text = string.Empty;
            for (int i = 0; i < bitStream.Length; i += (int)Constants.CHAR_LENGTH)
            {
                text += Convert.ToChar(Convert.ToInt16(bitStream.Substring(i, (int)Constants.CHAR_LENGTH), 2));
            }
            return text;
        }

        private static string GetNLowBitsInByte(byte myByte, int lowBits)
        {
            var masks = new byte[] { 0b00000001, 0b00000011, 0b00000111, 0b00001111, 0b00011111 };
            myByte &= masks[lowBits - 1];
            var byteAsString = Convert.ToString(myByte, 2).PadLeft(8, '0');
            return byteAsString.Substring(byteAsString.Length - lowBits, lowBits);
        }
    }
}

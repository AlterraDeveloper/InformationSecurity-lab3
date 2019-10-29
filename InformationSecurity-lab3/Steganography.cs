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

                ImageConverter converter = new ImageConverter();
                var imageByteStream = (byte[])converter.ConvertTo(image, typeof(byte[]));

                for (int i = 0, j = (int)Constants.FIRST_BYTE_OF_BMP_FILE; i < textBitStream.Length; i += lowBits, j++)
                {
                    byte textByte = Convert.ToByte(textBitStream.Substring(i, lowBits).PadLeft(8, '0'), 2);
                    imageByteStream[j] >>= lowBits;
                    imageByteStream[j] <<= lowBits;
                    imageByteStream[j] |= textByte;
                }

                image = (Bitmap)Image.FromStream(new MemoryStream(imageByteStream));
            }

            return hiddenBits;
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
            ImageConverter converter = new ImageConverter();
            var imageByteStream = (byte[])converter.ConvertTo(image, typeof(byte[]));

            var bitStreamOfText = string.Empty;

            for (int i = (int)Constants.FIRST_BYTE_OF_BMP_FILE;  bitStreamOfText.Length < bitsLength; i++)
            {
                bitStreamOfText += GetNLowBitsInByte(imageByteStream[i], lowBits);
            }
            return BitStreamToText(bitStreamOfText);
        }

        private static string BitStreamToText(string bitStream)
        {
            var text = string.Empty;

            for (int i = 0; i < bitStream.Length; i += (int)Constants.CHAR_LENGTH)
            {
                try
                {
                    var bitsOfSymbol = bitStream.Substring(i, (int)Constants.CHAR_LENGTH);
                    var symbolAsNumber = Convert.ToInt16(bitsOfSymbol, 2);
                    text += Convert.ToChar(symbolAsNumber);
                }
                catch (OverflowException){}
            }
            return text;
        }

        private static string GetNLowBitsInByte(byte myByte, int lowBits)
        {
            var byteAsString = Convert.ToString(myByte, 2).PadLeft(8, '0');
            return byteAsString.Substring(byteAsString.Length - lowBits, lowBits);
        }
    }
}

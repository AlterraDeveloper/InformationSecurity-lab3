using System;
using System.Drawing;
using System.IO;

namespace InformationSecurity_lab3
{
    internal static class Steganography
    {
        public static Bitmap HideTextIntoImage(string text, Bitmap image, int lowBits)
        {
            const int BmpFileStartByte = (int)Constants.FIRST_BYTE_OF_BMP_FILE;
            
            Bitmap stegoContainer = null;

            if (string.IsNullOrEmpty(text) | image == null | lowBits <= 0 | lowBits > 8)
            {
                return null;
            }

            text = IncreaseTextToHideInImage(text, lowBits);

            if (text.Length <= image.Width * image.Height * (int)Constants.COMPONENTS_IN_PIXEL * lowBits / (int)Constants.CHAR_LENGTH - (sizeof(int) / sizeof(char) + sizeof(byte)))
            {
                var textBitStream = TextToBitStream(text);

                var hiddenBits = textBitStream.Length;

                ImageConverter converter = new ImageConverter();
                var imageByteStream = (byte[])converter.ConvertTo(image, typeof(byte[]));

                var hiddenBitsStream = Convert.ToString(hiddenBits, 2).PadLeft(sizeof(int) * (int)Constants.BYTE_LENGTH, '0');

                for (int i = BmpFileStartByte, j = 0; i < BmpFileStartByte + sizeof(int); i++, j += (int)Constants.BYTE_LENGTH)
                {
                    byte _byte = Convert.ToByte(hiddenBitsStream.Substring(j, (int)Constants.BYTE_LENGTH).PadLeft((int)Constants.BYTE_LENGTH, '0'), 2);
                    imageByteStream[i] = _byte;
                }

                imageByteStream[(int)Constants.FIRST_BYTE_OF_BMP_FILE + sizeof(int)] = (byte)lowBits;

                for (int i = 0, j = BmpFileStartByte + sizeof(int) + sizeof(byte); i < textBitStream.Length; i += lowBits, j++)
                {
                    byte textByte = Convert.ToByte(textBitStream.Substring(i, lowBits).PadLeft(8, '0'), 2);
                    imageByteStream[j] >>= lowBits;
                    imageByteStream[j] <<= lowBits;
                    imageByteStream[j] |= textByte;
                }

                stegoContainer = (Bitmap)Image.FromStream(new MemoryStream(imageByteStream));
            }
            return stegoContainer;
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

        public static string ExtractTextFromImage(Bitmap image)
        {
            ImageConverter converter = new ImageConverter();
            var imageByteStream = (byte[])converter.ConvertTo(image, typeof(byte[]));

            var bitStreamOfText = string.Empty;

            var lengthOFHiddenTextAsBitStream = "";

            for (int i = (int)Constants.FIRST_BYTE_OF_BMP_FILE; i < (int)Constants.FIRST_BYTE_OF_BMP_FILE + sizeof(int); i++)
            {
                lengthOFHiddenTextAsBitStream += Convert.ToString(imageByteStream[i], 2).PadLeft((int)Constants.BYTE_LENGTH, '0');
            }

            var lengthOfHiddenText = Convert.ToInt32(lengthOFHiddenTextAsBitStream, 2);

            var lowBits = imageByteStream[(int)Constants.FIRST_BYTE_OF_BMP_FILE + sizeof(int)];

            for (int i = (int)Constants.FIRST_BYTE_OF_BMP_FILE + sizeof(int) + sizeof(byte); bitStreamOfText.Length < lengthOfHiddenText; i++)
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
                catch (OverflowException) { }
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

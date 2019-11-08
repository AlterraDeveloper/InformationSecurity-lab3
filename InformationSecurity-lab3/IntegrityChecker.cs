using System;
using System.Linq;
using System.Text;

namespace InformationSecurity_lab3
{
    class IntegrityChecker
    {
        public byte ResultXOR { get; private set; }

        public int[] ResultOfCyclicCode { get; private set; }

        public string[] ResultOfHemmingCode { get; private set; }

        private byte CalculateCheckByXOR(byte[] bytes)
        {
            byte resultXOR = 0;

            foreach (var b in bytes)
            {
                resultXOR ^= b;
            }
            return resultXOR;
        }

        private int GetBinaryNumberLength(int number)
        {
            return Convert.ToString(number, 2).Length;
        }

        private int GetSindrom(int _number)
        {
            var number = _number;

            var sindrom = 0;
            const int polinom = 11;

            var polinomPower = GetBinaryNumberLength(polinom) - 1;
            number <<= polinomPower;

            var numberPower = GetBinaryNumberLength(number);

            for (; numberPower - 1 >= polinomPower;)
            {
                var delta = numberPower - (polinomPower + 1);
                var deltaPolinom = polinom << delta;
                number ^= deltaPolinom;
                numberPower = GetBinaryNumberLength(number);
            }
            return number;
        }

        private int GetAnotherSindrom(int word24Bit, int _sindrom)
        {
            var number = word24Bit;

            var sindrom = 0;
            const int polinom = 11;

            var polinomPower = GetBinaryNumberLength(polinom) - 1;
            number <<= polinomPower;
            number ^= _sindrom;

            var numberPower = GetBinaryNumberLength(number);

            for (; numberPower - 1 >= polinomPower;)
            {
                var delta = numberPower - (polinomPower + 1);
                var deltaPolinom = polinom << delta;
                number ^= deltaPolinom;
                numberPower = GetBinaryNumberLength(number);
            }
            return number;
        }

        public void SetMetrics(byte[] bytes)
        {
            ResultXOR = CalculateCheckByXOR(bytes);
            ResultOfCyclicCode = CalculateSindroms(bytes);
            ResultOfHemmingCode = CalculateHemmingCodes(bytes);
        }

        private string[] CalculateHemmingCodes(byte[] bytes)
        {
            var resultOfHemmingCode = new string[bytes.Length / 2];

            for (int i = 0, j = 0; i < bytes.Length; i += 2, j++)
            {
                var word = "";
                word += Convert.ToString(bytes[i], 2).PadLeft(8, '0');
                word += Convert.ToString(bytes[i + 1], 2).PadLeft(8, '0');

                resultOfHemmingCode[j] = GetHemmingCode(word);
            }

            return resultOfHemmingCode;
        }

        public bool CheckByXOR(byte[] bytes)
        {
            var result = CalculateCheckByXOR(bytes);
            return result == ResultXOR;
        }

        public bool CheckWithCyclicCodes(byte[] bytes)
        {
            const int bytePortionLength = (int)Constants.COMPONENTS_IN_PIXEL;
            var sindroms = new int[bytes.Length / bytePortionLength];
            var word24Bit = 0;

            for (int i = 0, j = 0; i < bytes.Length; i += bytePortionLength, j++)
            {
                word24Bit ^= bytes[i];
                word24Bit ^= bytes[i + 1];
                word24Bit ^= bytes[i + 2];

                sindroms[j] = GetAnotherSindrom(word24Bit, ResultOfCyclicCode[j]);
                word24Bit = 0;
            }

            return sindroms.All(s => s == 0);
        }

        private int[] CalculateSindroms(byte[] bytes)
        {
            const int bytePortionLength = (int)Constants.COMPONENTS_IN_PIXEL;
            var sindroms = new int[bytes.Length / bytePortionLength];
            var word24Bit = 0;

            for (int i = 0, j = 0; i < bytes.Length; i += bytePortionLength, j++)
            {
                word24Bit ^= bytes[i];
                word24Bit ^= bytes[i + 1];
                word24Bit ^= bytes[i + 2];

                sindroms[j] = GetSindrom(word24Bit);
                word24Bit = 0;
            }
            return sindroms;
        }

        public bool CheckWithHemmingCode(byte[] bytes)
        {
            var checkResult = true;

            for (int i = 0, j = 0; i < bytes.Length; i += 2, j++)
            {
                var word = "";
                word += Convert.ToString(bytes[i], 2).PadLeft(8, '0');
                word += Convert.ToString(bytes[i + 1], 2).PadLeft(8, '0');

                checkResult &= GetHemmingCode(word).Equals(ResultOfHemmingCode[j]);
            }

            return checkResult;
        }

        private string GetHemmingCode(string word)
        {
            var builder = new StringBuilder();

            var controlBitsPositions = new [] {0, 1, 3, 7, 15};

            var resultStr = "";

            //extend word (+5 bit)
            for (int i = 0; i < 21; i++)
            {
                if (controlBitsPositions.Contains(i)) builder.Append('0');
                else
                {
                    builder.Append(word[0]);
                    word = word.Remove(0, 1);
                }
            }

            word = builder.ToString();

            for (int i = 0; i < 5; i++)
            {
                var k = (int)Math.Pow(2, i);
                var tmp = string.Empty;
                for (int j = k - 1; j < word.Length; j += 2 * k)
                {
                    tmp += word.Substring(j, Math.Min(k, word.Length - j));
                }

                resultStr += tmp.Count(c => c == '1') % 2== 0 ? "0" : "1";
            }

            return resultStr;
        }
    }
}

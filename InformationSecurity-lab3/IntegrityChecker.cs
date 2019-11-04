using System;
using System.Linq;

namespace InformationSecurity_lab3
{
    class IntegrityChecker
    {
        public byte ResultXOR { get; private set; }

        public int[] ResultOfCyclicCode { get; private set; }

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

            for (; numberPower - 1 < polinomPower;)
            {
                var delta = numberPower - (polinomPower + 1);
                var deltaPolinom = polinom << delta;
                number ^= deltaPolinom;
                numberPower = GetBinaryNumberLength(number);
            }
            return number;
            //if (number != 0) sindrom = number ^ polinom;

            //return sindrom;
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

            for (;numberPower - 1 < polinomPower;)
            {
                var delta = numberPower - (polinomPower + 1);
                var deltaPolinom = polinom << delta;
                number ^= deltaPolinom;
                numberPower = GetBinaryNumberLength(number);
            }
            return number;
            //if (number != 0) sindrom = number ^ polinom;

            //return sindrom;
        }

        public void SetMetrics(byte[] bytes)
        {
            ResultXOR = CalculateCheckByXOR(bytes);
            ResultOfCyclicCode = CalculateSindroms(bytes);
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
                word24Bit ^= bytes[i+1];
                word24Bit ^= bytes[i+2];

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
    }
}

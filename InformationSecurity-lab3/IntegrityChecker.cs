using System;

namespace InformationSecurity_lab3
{
    class IntegrityChecker
    {
        public byte ResultXOR { get; set; }
        public int[] ResultOfCyclicCode { get; set; }

        public byte CheckByXOR(byte[] bytes)
        {
            byte result = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                result ^= bytes[i];
            }
            return result;
        }

        public int[] CheckWithCyclicCodes(byte[] bytes)
        {
            var sindroms = new int[bytes.Length / sizeof(int)];
            int word32bit = 0;

            for (int i = 0,j = 0; i < bytes.Length; i+=sizeof(int),j++)
            {
                word32bit |= (bytes[i] << (8 * 3));
                word32bit |= (bytes[i+1] << (8 * 2));
                word32bit |= (bytes[i+2] << (8 * 1));
                word32bit |= (bytes[i+3] << (8 * 0));

                sindroms[j] = GetSindrom(word32bit);
            }

            return sindroms;
        }

        private int GetBinaryNumberLength(int number)
        {
            return Convert.ToString(number, 2).Length;
        }
        private int GetBinaryNumberLength(long number)
        {
            return Convert.ToString(number, 2).Length;
        }

        private int GetSindrom(int _number)
        {
            long number = _number;
            var sindrom = 0;
            var polinom = 1165191;

            var polinomPower = GetBinaryNumberLength(polinom) - 1;
            number <<= polinomPower;

            var deltaPolinom = polinom;
            var delta = 0;
            var numberPower = GetBinaryNumberLength(number);

            for (; ; )
            {
                delta = numberPower - (polinomPower + 1);
                deltaPolinom = polinom << delta;
                number ^= deltaPolinom;
                numberPower = GetBinaryNumberLength(number);
                if (numberPower == (polinomPower + 1) || number == 0) break;
            }

            if (number != 0) sindrom = (int)(number ^ polinom);

            return sindrom;
        }
    }
}

using System;

namespace InformationSecurity_lab3
{
    class IntegrityChecker
    {
        public byte ResultXOR { get; private set; }

        public int[] ResultOfCyclicCode { get; private set; }

        public byte CheckByXOR(byte[] bytes)
        {
            byte result = 0;
            foreach (var b in bytes)
            {
                result ^= b;
            }
            return result;
        }

        private int GetBinaryNumberLength(int number)
        {
            return Convert.ToString(number, 2).Length;
        }

        public int[] GetSindroms(byte[] bytes)
        {
            const int bytePortionLength = (int)Constants.COMPONENTS_IN_PIXEL;
            var sindroms = new int[bytes.Length / bytePortionLength];
            var word24Bit = 0;

            for (int i = 0, j = 0; i < bytes.Length; i += bytePortionLength, j++)
            {
                word24Bit |= (bytes[i] << (8 * 2));
                word24Bit |= (bytes[i + 1] << (8 * 1));
                word24Bit |= (bytes[i + 2] << (8 * 0));

                sindroms[j] = GetSindrom(word24Bit);

            }

            return sindroms;
        }

        private int GetSindrom(int _number)
        {
            var number = _number;
            var sindrom = 0;
            const int polinom = 98;

            var polinomPower = GetBinaryNumberLength(polinom) - 1;
            number <<= polinomPower;

            var numberPower = GetBinaryNumberLength(number);

            for (; ; )
            {
                var delta = numberPower - (polinomPower + 1);
                var deltaPolinom = polinom << delta;
                number ^= deltaPolinom;
                numberPower = GetBinaryNumberLength(number);
                if (numberPower == polinomPower || number == 0) break;
            }

            if (number != 0) sindrom = number ^ polinom;

            return sindrom;
        }

        public void SetMetrics(byte[] bytes)
        {
            ResultXOR = CheckByXOR(bytes);
            ResultOfCyclicCode = GetSindroms(bytes);
        }

        public int[] CheckWithCyclicCodes(byte[] bytes)
        {
            const int bytePortionLength = (int)Constants.COMPONENTS_IN_PIXEL;
            var sindroms = new int[bytes.Length / bytePortionLength];
            var word24Bit = 0;

            for (int i = 0, j = 0; i < bytes.Length; i += bytePortionLength, j++)
            {
                word24Bit |= (bytes[i] << (8 * 2));
                word24Bit |= (bytes[i + 1] << (8 * 1));
                word24Bit |= (bytes[i + 2] << (8 * 0));

                sindroms[j] = GetAnotherSindrom(word24Bit,ResultOfCyclicCode[j]);

            }

            return sindroms;
        }

        private int GetAnotherSindrom(int word24Bit, int _sindrom)
        {
            var number = word24Bit;
            var sindrom = 0;
            const int polinom = 98;

            var polinomPower = GetBinaryNumberLength(polinom) - 1;
            number <<= polinomPower;
            number ^= _sindrom;

            var numberPower = GetBinaryNumberLength(number);

            for (; ; )
            {
                var delta = numberPower - (polinomPower + 1);
                var deltaPolinom = polinom << delta;
                number ^= deltaPolinom;
                numberPower = GetBinaryNumberLength(number);
                if (numberPower == polinomPower || number == 0) break;
            }

            if (number != 0) sindrom = number ^ polinom;

            return sindrom;
        }
    }
}

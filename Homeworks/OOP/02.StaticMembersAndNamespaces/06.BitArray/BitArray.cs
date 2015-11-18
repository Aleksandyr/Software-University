namespace BitArray
{
    using System;
    using System.Numerics;

    public class BitArray
    {
        private byte[] bits;

        public BitArray(int n)
        {
            if (n < 0 || n > 100000)
            {
                throw new IndexOutOfRangeException("Size of array should be between [1...100 000]");
            }

            this.bits = new byte[n];
        }

        public byte this[int index]
        { 
            get
            {
                return this.bits[index];
            }
            set
            {
                if (index < 0 || index > this.bits.Length - 1)
                {
                    throw new IndexOutOfRangeException("The value mut be between [1..." + (this.bits.Length - 1) + "]");
                }

                if (value != 0 && value != 1)
                {
                    throw new ArgumentException("Value must be 0 or 1 only!");
                }

                this.bits[index] = value;
            }
        }

        public override string ToString()
        {
            BigInteger number = 0;
            for (int i = 0; i < this.bits.Length; i++)
            {
                if (this.bits[i] == 1)
                {
                    number += BigInteger.Pow(2, i);
                }
            }

            return number.ToString();
        }
    }
}

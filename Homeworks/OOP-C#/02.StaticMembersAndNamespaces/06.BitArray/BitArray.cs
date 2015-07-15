namespace BitArrayInfo
{
    using System;


    public class BitArray
    {
        private byte[] bitArr;
        private int length;

        public BitArray(int length)
        {
            this.Length = length;
            this.BitArr = new byte[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                BitArr[i] = 0;
            }
        }

        public byte[] BitArr { get; set; }

        public int Length
        {
            get { return this.length; }
            set
            {
                if (value < 0 || value > 100000)
                {
                    throw new ArgumentOutOfRangeException("Length must be between 0... 100 000");
                }

                this.length = value;
            }
        }

        public byte this[int index]
        {
            get { return this.BitArr[index]; }
            set
            {
                if (index < 0 || index > 100000)
                {
                    throw new ArgumentOutOfRangeException("Index must be between 0... 100 000");
                }

                this.BitArr[index] = value;
            }
        }

        public override string ToString()
        {
            return string.Join("", BitArr);
        }
    }
}

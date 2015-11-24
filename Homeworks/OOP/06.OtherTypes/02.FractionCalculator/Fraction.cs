﻿namespace FractionCalculator
{
    using System;

    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator 
        { 
            get
            {
                return this.numerator;
            }
            set
            {
                this.numerator = value;
            }
        }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator cannot be 0!");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction fr1, Fraction fr2)
        {
            fr1.Numerator *= fr2.Denominator;
            fr2.Numerator *= fr1.Denominator;
            long commonDenom = fr1.Denominator * fr2.Denominator;

            return new Fraction(fr1.Numerator + fr2.Numerator, commonDenom);
        }

        public static Fraction operator -(Fraction fr1, Fraction fr2)
        {
            fr1.Numerator *= fr2.Denominator;
            fr2.Numerator *= fr1.Denominator;
            long commonDenom = fr1.Denominator * fr2.Denominator;

            return new Fraction(fr1.Numerator - fr2.Numerator, commonDenom);
        }

        public override string ToString()
        {
            decimal result = (decimal)this.Numerator / (decimal)this.Denominator;

            return result.ToString();
        }
    }
}

namespace StringDisparser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class StringDisperserCs : ICloneable, IComparable<StringDisperserCs>, IEnumerable
    {
        public StringDisperserCs(params string[] parameters)
        {
            this.Parameters = parameters;
        }

        public string[] Parameters { get; set; }


        public override bool Equals(object obj)
        {
            StringDisperserCs stringDisp = obj as StringDisperserCs;

            if (stringDisp == null)
            {
                return false;
            }

            for (int i = 0; i < this.Parameters.Length; i++)
            {
                if (!object.Equals(this.Parameters[i], stringDisp.Parameters[i]))
                {
                    return false;
                }
            }

 	        return true;
        }

        public static bool operator ==(StringDisperserCs s1, StringDisperserCs s2)
        {
            return StringDisperserCs.Equals(s1, s2);
        }

        public static bool operator !=(StringDisperserCs s1, StringDisperserCs s2)
        {
            return !(StringDisperserCs.Equals(s1, s2));
        }

        public override int GetHashCode()
        {
            int result = 0;
            
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                result ^= this.Parameters[i].GetHashCode();   
            }

            return result;
        }

        public object Clone()
        {
            StringDisperserCs deepCopyStrDisp = new StringDisperserCs(Parameters = this.Parameters);

            return deepCopyStrDisp;
        }

        public int CompareTo(StringDisperserCs other)
        {
            string firstString = string.Empty;
            string secondString = string.Empty;

            for (int i = 0; i < this.Parameters.Length; i++)
            {
                firstString += this.Parameters[i];
            }

            for (int i = 0; i < other.Parameters.Length; i++)
            {
                secondString += other.Parameters[i];
            }

            return string.Compare(firstString, secondString);
        }

        public IEnumerator GetEnumerator()
        {
            string concatedString = string.Empty;
            
            for (int i = 0; i < this.Parameters.Length; i++)
            {
                concatedString += this.Parameters[i];
            }

            foreach (var character in concatedString)
            {
                yield return character + " ";
            }
        }

        public override string ToString()
        {
            return string.Join(", ", this.Parameters);
        }
    }
}

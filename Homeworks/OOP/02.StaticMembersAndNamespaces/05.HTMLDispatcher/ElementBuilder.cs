namespace HTMLDispatcher
{
    using System;
    using System.Collections.Generic;

    public class ElementBuilder
    {
        private string element;
        private string content;
        private Dictionary<string, string> attributes;
        private bool isCloseSelf = false;

        public ElementBuilder(string element)
        {
            this.element = element;
            this.attributes = new Dictionary<string, string>();
            this.content = string.Empty;
        }

        public void AddAttribute(string attribute, string value)
        {
            this.attributes.Add(attribute, value);
        }

        public void AddContent(string content)
        {
            this.content = content;
        }

        public void CloseSelf(bool isCloseSelf)
        {
            this.isCloseSelf = isCloseSelf;
        }

        public override string ToString()
        {
            string result = "<" + element;
            
            if (attributes.Count != 0)
            {
                foreach (var attribute in this.attributes)
                {
                    result += @" " + attribute.Key + "= \"" + attribute.Value + "\"";
                }
            }

            if (!this.isCloseSelf)
            {
                result += ">";
            }

            if (this.content != string.Empty)
            {
                result += content;
            }

            if (this.isCloseSelf)
            {
                result += " />";
            }
            else
            {
                result += "</" + this.element + ">";   
            }

            return result;
        }

        public static string operator *(ElementBuilder elemnt, int n)
        {
            string result = string.Empty;
            for (int i = 0; i < n; i++)
            {
                result += elemnt.ToString() + "\n";
            }

            return result;
        }
    }
}

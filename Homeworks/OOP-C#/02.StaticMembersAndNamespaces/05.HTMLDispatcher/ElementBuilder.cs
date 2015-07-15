using System;
using System.Collections.Generic;
using System.Text;

namespace ElementBuilderInfo
{
    public class ElementBuilder
    {
        private string elemName;

        public ElementBuilder(string elemName)
        {
            this.ElementName = elemName;
            this.Content = string.Empty;
            this.Attributes = new Dictionary<string, string>();
        }

        public string ElementName 
        { 
            get
            {
                return this.elemName;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Element can not be null or empty!");
                }

                this.elemName = value;
            }
        }

        public string Content { get; set; }

        public Dictionary<string, string> Attributes { get; private set; }

        public static string operator *(ElementBuilder element, int count)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                result.Append(element);
            }

            return result.ToString();
        }
        
        public void AddAtribute(string atribute, string value)
        {
            if(string.IsNullOrEmpty(atribute))
            {
                throw new ArgumentNullException("Atribute can not be empty!");
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Value can not be empty!");
            }

            this.Attributes.Add(atribute, value);
        }

        public void AddContent(string elemContent)
        {
            this.Content += elemContent;
        }

        public override string ToString()
        {
            var attributes = new StringBuilder();

            foreach (var attribute in this.Attributes)
	        {
		        attributes.AppendFormat(" {0}=\"{1}\"", attribute.Key, attribute.Value);
	        }
            

            string result = string.Format("<{0}{1}>{2}</{0}>", this.elemName, attributes.ToString(), this.Content, this.elemName);
            return result;
        }
    }
}

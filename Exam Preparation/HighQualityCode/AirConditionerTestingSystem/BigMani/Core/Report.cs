namespace BigMani.Core
{
    using BigMani.Interfaces;

    public class Report : IReport
    {
        public Report(string manufacturer, string model, int mark)
        {
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Mark = mark;
        }

        public string Manufacturer { get; private set; }

        public string Model { get; private set; }

        public int Mark { get; private set; }

        public override string ToString()
        {
            string result = string.Empty;
            string isPassed = string.Empty;
            if (this.Mark == 0)
            {
                isPassed = "Failed";
            }
            else if (this.Mark == 1)
            {
                isPassed = "Passed";
            }

            result += "Report" + "\r\n" + "====================" + "\r\n" + "Manufacturer: " + this.Manufacturer + "\r\n" +
                      "Model: " + this.Model + "\r\n" + "Mark: " + isPassed + "\r\n" + "====================";

            return result;
        }
    }
}

namespace _04.StudentClass
{
    class Student
    {
        public delegate void PropertyChangedHandler(object sender, PropertyChangedEventArgs args);

        public event PropertyChangedHandler OnPropertyChanged;

        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name
        {
            get
            {
                return this.name;
                
            }
            set
            {
                var eventArgs = new PropertyChangedEventArgs("Name", this.name, value);
                this.name = value;
                var onPropertyChanged = this.OnPropertyChanged;
                if (onPropertyChanged != null)
                {
                    onPropertyChanged(this.Name, eventArgs);
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age; 
                
            }
            set
            {
                var eventArgs = new PropertyChangedEventArgs("Age", this.Age, value);
                this.age = value;
                var onPropertuChanged = this.OnPropertyChanged;
                if (onPropertuChanged != null)
                {
                    onPropertuChanged(this.Name, eventArgs);
                }
            }
        }
    }
}

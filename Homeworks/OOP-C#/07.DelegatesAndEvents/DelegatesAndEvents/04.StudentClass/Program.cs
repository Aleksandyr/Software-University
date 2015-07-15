using System;

namespace _04.StudentClass
{
    class Program
    {
        static void Main()
        {
            Student student = new Student("Pesho", 25);

            student.OnPropertyChanged += PropertyHandler;

            student.Name = "Ivan";
            student.Age = 22;
        }

        public static void PropertyHandler(object sender, PropertyChangedEventArgs eventArgs)
        {
            Console.WriteLine("Property changed: {0} (from {1} to {2})", 
                eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
        }
    }
}

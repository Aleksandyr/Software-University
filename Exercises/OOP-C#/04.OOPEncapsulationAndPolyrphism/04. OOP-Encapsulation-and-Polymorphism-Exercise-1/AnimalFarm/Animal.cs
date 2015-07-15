﻿namespace AnimalFarm
{
    using System;

    public abstract class Animal
    {
        private const int MinAnimalAge = 0;
        private const int MaxAnimalAge = 15;

        private string name;
        private int age;

        protected Animal(string name, int age)
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
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name can not be null or empty!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            private set
            {
                if (value < MinAnimalAge || value > MaxAnimalAge)
                {
                    throw new ArgumentOutOfRangeException("value", "Age cannot be negative or more than " + MaxAnimalAge + ".");
                }

                this.age = value;
            }
        }

        public double ProductPerDay
        {
            get
            {
                return this.CalculateProductPerDay();
            }
        }

        public abstract Product ProduceProduct();

        public abstract double GetHumanAge();

        private double CalculateProductPerDay()
        {
            switch (this.age)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                    return 1.5;
                case 4:
                case 5:
                case 6:
                case 7:
                    return 2;
                case 8:
                case 9:
                case 10:
                case 11:
                    return 1;
                default:
                    return 0.75;
            }
        }
    }
}


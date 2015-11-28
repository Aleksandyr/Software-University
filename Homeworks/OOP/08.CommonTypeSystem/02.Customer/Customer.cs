namespace Customer
{
    using System;
    using System.Collections.Generic;

    public class Customer : ICloneable, IComparable<Customer>
    {
        public Customer(int id, string firstName, string middleName, 
            string LastName, string PermanentAddress, string PhoneNumber,
                string email, CustomerType customerType, List<Payment> payments)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = LastName;
            this.PermanentAddress = PermanentAddress;
            this.PhoneNumber = PhoneNumber;
            this.Email = email;
            this.Type = customerType;
            this.Payments = payments;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string PermanentAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public List<Payment> Payments { get; set; }

        public CustomerType Type { get; set; }


        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;
            
            if (customer == null)
            {
                return false;
            }
            if (!object.Equals(this.Id, customer.Id))
            {
                return false;
            }
            if (!object.Equals(this.FirstName, customer.FirstName))
            {
                return false;
            }
            if (!object.Equals(this.MiddleName, customer.MiddleName))
            {
                return false;
            }
            if (!object.Equals(this.LastName, customer.LastName))
            {
                return false;
            }
            if (!object.Equals(this.PermanentAddress, customer.PermanentAddress))
            {
                return false;
            }
            if (!object.Equals(this.Email, customer.Email))
            {
                return false;
            }
            if (!object.Equals(this.Type, customer.Type))
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Customer cs1, Customer cs2)
        {
            return Customer.Equals(cs1, cs2);
        }

        public static bool operator !=(Customer cs1, Customer cs2)
        {
            return !(Customer.Equals(cs1, cs2));
        }

        public override int GetHashCode()
        {
            return this.FirstName.GetHashCode() ^ this.Id.GetHashCode();
        }

        public override string ToString()
        {
            string customerFullName = this.FirstName + " " + this.MiddleName + " " + this.LastName;

            return String.Format(
                "Customer(Name: {0}, ID: {1}, Permanent address: {2}, Mobile phone: {3}, Email: {4}, Payment: {5}, Type: {6})",
                customerFullName, this.Id, this.PermanentAddress, this.PhoneNumber, this.Email, String.Join(", ", this.Payments), this.Type);
        }

        public object Clone()
        {
            Customer deepCopyCustomer = new Customer(
               Id = this.Id,
               FirstName = this.FirstName,
               MiddleName = this.MiddleName,
               LastName = this.LastName,
               PermanentAddress = this.PermanentAddress,
               PhoneNumber = this.PhoneNumber,
               Email = this.Email,
               Type = this.Type,
               Payments = this.Payments);

            return deepCopyCustomer;
            
        }
        public int CompareTo(Customer other)
        {
            string firstCustomerName = this.FirstName + " " + this.MiddleName + " " + this.LastName;
            string secondCustomerName = other.FirstName + " " + other.MiddleName + " " + other.LastName;
            
            int result = string.Compare(firstCustomerName, secondCustomerName);

            if (result == 0)
            {
                return this.Id - other.Id;
            }

            return result;
        }
    }
}

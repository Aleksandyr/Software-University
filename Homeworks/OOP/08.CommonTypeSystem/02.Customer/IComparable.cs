namespace Customer
{
    public interface IComparable<Customer>
    {
        int CompareTo(Customer other);
    }
}

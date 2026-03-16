class Product
{
    private double _price;
    private string _name;

    public double Price
    {
        get { return _price; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("No negative price is Allowed");
                _price = 0;
            }
            else
            {
                _price = value;
            }
        }
    }
    public virtual double CalDiscount()
    {
        return _price;
    }
}
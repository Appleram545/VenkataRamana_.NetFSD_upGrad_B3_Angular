using System;

class product
{

    private int _productId;
    private string _productName;
    private double _price;
    private int _quantity;


    public product(int _productId)
    {
        this._productId = _productId;
    }

    public int productId
    {
        get { return _productId; }
    }

    public string productName
    {
        get { return _productName; }
        set { _productName = value; }
    }
    public int quantity
    {
        get { return _quantity; }
        set
        {
            if (value >= 0)
            {
                _quantity = value;

            }
            else
            {
                Console.WriteLine(" Quantity Can not be Negative");
                return;
            }
        }
    }
    public double price
    {
        get { return _price; }
        set
        {
            if (value >= 0)
            {
                _price = value;

            }
            else
            {
                Console.WriteLine("Price Can not be Negative");
                return;
            }
        }
    }

    public void Details()
    {
        double total = _price * _quantity;

        Console.WriteLine("Product Id :" + _productId);
        Console.WriteLine("Product Name :" + _productName);
        Console.WriteLine("Price:" + _price);
        Console.WriteLine("Quantity :" + _quantity);
        Console.WriteLine("Total Amount :" + total);
    }


}
class B
{
    static void Main()
    {
        Console.Write("Enter Product Id: ");
        int id = int.Parse(Console.ReadLine());

        product obj = new product(id);

        Console.Write("Enter Product Name: ");
        obj.productName = Console.ReadLine();

        Console.Write("Enter Price: ");
        obj.price = double.Parse(Console.ReadLine());

        Console.Write("Enter Quantity: ");
        obj.quantity = int.Parse(Console.ReadLine());

        obj.Details();
    }
}
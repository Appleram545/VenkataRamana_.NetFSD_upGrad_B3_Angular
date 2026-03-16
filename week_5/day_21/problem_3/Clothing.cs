class Clothing : Product
{
    public override double CalDiscount()
    {
        return Price - (Price * 0.15);
    }
}
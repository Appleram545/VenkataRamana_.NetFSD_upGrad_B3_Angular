class Car : Vehicle
{
    public override double calrental(int days)
    {
        double total = base.calrental(days);
        return total + 500;
    }
}

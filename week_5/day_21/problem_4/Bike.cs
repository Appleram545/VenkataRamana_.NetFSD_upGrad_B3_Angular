class Bike : Vehicle
{
    public override double calrental(int days)
    {
        double total = base.calrental(days);
        return total - (total * 0.05);
    }
}
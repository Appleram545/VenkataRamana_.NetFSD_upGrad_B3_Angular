class Vehicle
{
    private int _rentalRatePerDay;

    public string _brand { get; set; }

    public int RentalRatePerDay
    {
        get { return _rentalRatePerDay; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Rate cannot be negative");
                _rentalRatePerDay = 0;
            }
            else
            {
                _rentalRatePerDay = value;
            }
        }
    }
    public virtual double calrental(int days)
    {
        if (days <= 0)
        {
            Console.WriteLine("Invalid rental days");
            return 0;
        }

        return RentalRatePerDay * days;
    }

}
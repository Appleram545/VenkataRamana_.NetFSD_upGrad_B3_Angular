using System;

class Program
{
    
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter Employee Name :");
        string name =Console.ReadLine();

        Console.WriteLine("Enter sales Amount");
        double sales = double.Parse(Console.ReadLine());

        Console.WriteLine("enter Rating 1-5");
        int rating = int.Parse(Console.ReadLine());


        var result = GetPerfomance(sales,rating);    //getting tuple from method


        string perfomance = result switch      //pattern matching
        {
            (>= 100000, >=4)=>"High performance",
            (>=50000,>=3)=>"Average Perfomance",
            _=>"Need improvement"
        };



        Console.WriteLine("Employee Name: " + name);
        Console.WriteLine("Sales Amount: " + result.sales);
        Console.WriteLine("Rating: " + result.rating);
        Console.WriteLine("Performance: " + perfomance);
    }

    static(double sales,int rating)GetPerfomance(double sales,int rating)
    {
        return(sales,rating);
    }

}
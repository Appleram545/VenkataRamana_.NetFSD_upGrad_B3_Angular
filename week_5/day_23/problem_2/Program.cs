using System;
using System.Collections.Generic;
using System.Linq;

class Product
{

    public int Code { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Mrp { get; set; }

}
class Program
{

    static void Main()
    {
        List<Product> list = new List<Product>()
        {
            new Product{Code=1, Name="Soap", Category="FMCG", Mrp=30},
            new Product{Code=2, Name="Rice", Category="Grain", Mrp=60},
            new Product{Code=3, Name="Oil", Category="FMCG", Mrp=110},
            new Product{Code=4, Name="Wheat", Category="Grain", Mrp=45},
            new Product{Code=5, Name="Shampoo", Category="FMCG", Mrp=50}
        };

        // display all products with category “FMCG”

        Console.WriteLine("FMCG Products :");
        var s1 = from x in list
                 where x.Category == "FMCG"
                 select x;

        print(s1);

        Console.WriteLine("---------------------");

        // display all products with category “Grain”
        Console.WriteLine("Grain Products :");
        var s2 = from x in list
                 where x.Category == "Grain"
                 select x;

        print(s2);

        Console.WriteLine("---------------------");

        // sort products in ascending order by product code.
        Console.WriteLine("Sort Producst By Code");
        var s3 = from x in list
                 orderby x.Code
                 select x;
        print(s3);

        Console.WriteLine("---------------------");

        // sort products in ascending order by Category .
        Console.WriteLine("Sort Producst By Category");
        var s4 = from x in list
                 orderby x.Category
                 select x;
        print(s4);

        Console.WriteLine("---------------------");

        // sort products in ascending order by MRP .
        Console.WriteLine("Sort Producst By MRP in Ascending Order");
        var s5 = from x in list
                 orderby x.Mrp
                 select x;
        print(s5);


        Console.WriteLine("---------------------");

        // sort products in descending order by MRP .
        Console.WriteLine("Sort Producst By MRP in Descedning Order");
        var s6 = from x in list
                 orderby x.Mrp descending
                 select x;
        print(s6);


        Console.WriteLine("---------------------");

        // Group BY category
        Console.WriteLine("Group By Category ");
         var s7 = from x in list
                  group x by x.Category;

        foreach (var s in s7)
        {
            Console.WriteLine("Category :"+s.Key);
            foreach(var i in s)
            {
                Console.WriteLine(i.Name + " " + i.Mrp);
            }
        }


        Console.WriteLine("---------------------");

        // Group BY MRP
        Console.WriteLine("Group By Mrp ");
        var s8 = from x in list
                 group x by x.Mrp;

        foreach (var s in s8)
        {
            Console.WriteLine("Mrp :" + s.Key);
            foreach (var i in s)
            {
                Console.WriteLine(i.Name);
            }
        }


        Console.WriteLine("---------------------");
        // highest price in FMCG category

        Console.WriteLine("Highest Price in FMCG:");
        var s9 = (from x in list
                  where x.Category == "FMCG"
                  orderby x.Mrp descending
                  select x).FirstOrDefault();  // first higer price
        Console.WriteLine(s9.Name + " " + s9.Mrp);

        Console.WriteLine("---------------------");

        // Totall count 
        Console.WriteLine("Total Products: " + list.Count());

        Console.WriteLine("---------------------");

        //  FMCG Count
        Console.WriteLine("FMCG Count: "+list.Count(x=>x.Category=="FMCG"));

        Console.WriteLine("---------------------");


        // 12. Max Price
        Console.WriteLine("Max Price: " + list.Max(x => x.Mrp));

        Console.WriteLine("---------------------");

        // Min Price

        Console.WriteLine("Min Price: " + list.Min(x => x.Mrp));

        Console.WriteLine("---------------------");

        //  below Mrp Rs.30 __ all
        Console.WriteLine("All below 30: " + list.All(x => x.Mrp < 30));


        Console.WriteLine("---------------------");
        // Any < 30. 
        Console.WriteLine("Any below 30: " + list.Any(x => x.Mrp < 30));



    }
    static void print(IEnumerable<Product> st)
    {
        foreach (var x in st)
        {
            Console.WriteLine(x.Code + " " + x.Name + " " + x.Category + " " + x.Mrp);
        }
    }
}
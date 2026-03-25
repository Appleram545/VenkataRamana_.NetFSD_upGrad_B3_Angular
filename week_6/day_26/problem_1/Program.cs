using System;
using problem_1.Data;
using problem_1.Model;

namespace problem_1
{
    class Program
    {
        static void Main()
        {
            ProductRepository repo = new ProductRepository();

            while (true)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. get element by Id");
                Console.WriteLine("6. Exit");

                Console.Write("Choose: ");
                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            var p = new Product();

                            Console.Write("Name: ");
                            p.ProductName = Console.ReadLine();

                            Console.Write("Category: ");
                            p.Category = Console.ReadLine();

                            Console.Write("Price: ");
                            p.Price = decimal.Parse(Console.ReadLine());

                            Console.Write("Stock: ");
                            p.Stock = int.Parse(Console.ReadLine());

                            repo.InsertProduct(p);
                            Console.WriteLine(" Added!");
                            break;

                        case 2:
                            var list = repo.GetAllProducts();
                            foreach (var item in list)
                            {
                                Console.WriteLine($"{item.ProductId} | {item.ProductName} | {item.Category} | {item.Price} | {item.Stock}");
                            }
                            break;

                        case 3:
                            var u = new Product();

                            Console.Write("Enter ID: ");
                            u.ProductId = int.Parse(Console.ReadLine());

                            Console.Write("New Name: ");
                            u.ProductName = Console.ReadLine();

                            Console.Write("New Category: ");
                            u.Category = Console.ReadLine();

                            Console.Write("New Price: ");
                            u.Price = decimal.Parse(Console.ReadLine());

                            Console.Write("New Stock: ");
                            u.Stock = int.Parse(Console.ReadLine());

                            repo.UpdateProduct(u);
                            Console.WriteLine(" Updated!");
                            break;

                        case 4:
                            Console.Write("Enter ID: ");
                            int id = int.Parse(Console.ReadLine());

                            repo.DeleteProduct(id);
                            Console.WriteLine(" Deleted!");
                            break;
                        case 5:
                            Console.Write("Enter Product ID: ");
                            int searchId = int.Parse(Console.ReadLine());
                            var foundProduct = repo.GetProductById(searchId);
                            if (foundProduct != null)
                            {
                                Console.WriteLine($" Found: {foundProduct.ProductName} - ${foundProduct.Price}");
                            }
                            else
                            {
                                Console.WriteLine("Product not found!");
                            }
                            break;
                        case 6:
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(" Error: " + ex.Message);
                }
            }
        }
    }
}
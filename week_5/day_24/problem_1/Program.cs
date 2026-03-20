using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string [] args)
    {
        string path= "log.txt";

        try
        {
            char ch;

            do
            {
                Console.WriteLine("Enter Message : ");
                string msg = Console.ReadLine();

                byte [] data = Encoding.UTF8.GetBytes(msg + Environment.NewLine);  // converts text to bytes.  insted of \n we using environment

                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    fs.Write(data,0,data.Length);

                }
                Console.WriteLine("Sucessfull ..");

                Console.Write("Continue (y/n): ");
                ch = Convert.ToChar(Console.ReadLine());


            }
            while(ch =='y'|| ch=='Y');
        }
        catch(IOException e)
        {
            Console.WriteLine("File Error: " + e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
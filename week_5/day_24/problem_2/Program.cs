using System;
using System.IO;

class Program
{
    static void Main(string [] args)
    {
        try
        {
            Console.WriteLine("Enter path Name");
            string path = Console.ReadLine();


            if (!Directory.Exists(path))
            {
                Console.WriteLine("Invalid Path");
                return;
            }
            string[] files = Directory.GetFiles(path);

            int c =0;

            foreach(string file in files)
            {
                FileInfo f = new FileInfo(file);  // class to get  file details

                Console.WriteLine("File Name : "+ f.Name);
                Console.WriteLine("File Size : " + f.Length);
                Console.WriteLine("File Created Date : " + f.CreationTime);

                c++;
            }
            Console.WriteLine("Total Files : "+c);
            
        }
        catch(Exception e)
        {
            Console.WriteLine("Error Message"+e.Message);
        }
    }
}

using System;
using System.IO;

class Program
{
    
    static void Main(string [] args)
    {

        try
        {
            
            Console.WriteLine("enter root path :");
            string path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Not found");
                return;
            }

            DirectoryInfo root = new DirectoryInfo(path);   // class
            DirectoryInfo[] dirs = root.GetDirectories();

            foreach(DirectoryInfo dir in dirs)
            {
                FileInfo[]files = dir.GetFiles();

                Console.WriteLine("Folder Name : " + dir.Name);
                Console.WriteLine("File Count  : " + files.Length);
          
            }

        }
        catch(Exception e)
        {
            Console.WriteLine("Error "+e.Message);
        }
    }
}
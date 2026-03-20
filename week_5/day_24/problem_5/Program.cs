using System;
using System.IO;

class Program
{
    static void Main()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();

        foreach (DriveInfo drive in drives)
        {
            try
            {

                if (drive.IsReady)
                {
                    Console.WriteLine("Drive Name: " + drive.Name);
                    Console.WriteLine("Drive Type: " + drive.DriveType);

                    long totalSize = drive.TotalSize;
                    long freeSpace = drive.AvailableFreeSpace;

                    Console.WriteLine("Total Size: " + (totalSize / (1024 * 1024 * 1024)) + " GB");
                    Console.WriteLine("Free Space: " + (freeSpace / (1024 * 1024 * 1024)) + " GB");


                    double freePercent = (freeSpace * 100.0) / totalSize;
                    Console.WriteLine("Free Space %: " + freePercent.ToString("F2") + "%");


                    if (freePercent < 15)
                    {
                        Console.WriteLine("⚠ WARNING: Low Disk Space!");
                    }

                    Console.WriteLine("--------------------------------");
                }
                else
                {
                    Console.WriteLine("Drive " + drive.Name + " is not ready.");
                    Console.WriteLine("--------------------------------");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error accessing drive: " + ex.Message);
            }
        }
    }
}
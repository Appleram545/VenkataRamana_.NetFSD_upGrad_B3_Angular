using System;



    class Program
    {
        static void Main(string[] args)
        {
            // First call
            var config1 = ConfigurationManager.GetInstance();

            Console.WriteLine("First Call:");
            PrintConfig(config1);

            Console.WriteLine();

            // Second call
            var config2 = ConfigurationManager.GetInstance();

            Console.WriteLine("Second Call:");
            PrintConfig(config2);

            Console.WriteLine();

            // Check same instance
            Console.WriteLine($"Same Instance? {ReferenceEquals(config1, config2)}");

            Console.ReadLine();
        }

        static void PrintConfig(ConfigurationManager config)
        {
            Console.WriteLine($"App Name: {config.ApplicationName}");
            Console.WriteLine($"Version: {config.Version}");
            Console.WriteLine($"Connection: {config.DatabaseConnectionString}");
        }
    }

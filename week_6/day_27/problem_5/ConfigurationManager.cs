using System;


    public sealed class ConfigurationManager
    {
        private static ConfigurationManager _instance;
        private static readonly object _lock = new object();

        
        public string ApplicationName { get; private set; }
        public string Version { get; private set; }
        public string DatabaseConnectionString { get; private set; }

        // Private Constructor
        private ConfigurationManager()
        {
            Console.WriteLine("Loading configuration...");

            ApplicationName = "InventoryApp";
            Version = "1.0.0";
            DatabaseConnectionString = "Server=localhost;Database=InventoryDB;";
        }

        // Public Method to get instance
        public static ConfigurationManager GetInstance()
        {
            // Thread-safe
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ConfigurationManager();
                    }
                }
            }

            return _instance;
        }
    }

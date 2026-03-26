using System;

    class Program
    {
        static void Main(string[] args)
        {
            NotificationFactory factory = new NotificationFactory();

        
            INotification notification1 = factory.CreateNotification("email");
            notification1.Send("Welcome to our service!");

            Console.WriteLine();

          
            INotification notification2 = factory.CreateNotification("sms");
            notification2.Send("Your OTP is 1234");

            Console.WriteLine();

           
            INotification notification3 = factory.CreateNotification("push");
            notification3.Send("You have a new message!");

            Console.ReadLine();
        }
    }

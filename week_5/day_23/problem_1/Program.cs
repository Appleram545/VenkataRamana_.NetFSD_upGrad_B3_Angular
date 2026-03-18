using System;
using System.Collections.Generic;

class Program
{
    
    static void Main(string [] args)
    {
        List<string> Tasks = new List<string>();

        bool ok = true;

        while (ok)
        {
            Console.WriteLine("To-DO List Management");
            Console.WriteLine("1 - Add Task");
            Console.WriteLine("2 - View Tasks");
            Console.WriteLine("3 - Delete Task");
            Console.WriteLine("4 - Exit");

            Console.WriteLine("Select Option : ");

            string selected = Console.ReadLine();

            switch (selected)
            {
                case "1":
                AddTask(Tasks);
                    break;
                case "2":
                    ViewTasks(Tasks);
                    break;
                case "3":
                    RemoveTask(Tasks);
                    break;
                case "4":
                    ok= false;
                    break;
                 default:
                    Console.WriteLine("Invalid Input");
                 break;   
            }


        }
    }
    static void AddTask(List<string> Tasks)
    {
        Console.WriteLine("Enter To ADd Task :");
        string task = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(task))
        {
            Tasks.Add(task);
            Console.WriteLine("Task addedd");
        }
        else
        {
            Console.WriteLine("Task Can not be empty");
        }
    }
    static void ViewTasks(List<string> Tasks)
    {

        if (Tasks.Count == 0)
        {
            Console.WriteLine("No Tasks");
        }
        else
        {
            Console.WriteLine("Tasks you added : ");
            int index=1;
            foreach(var task in Tasks)
            {
                Console.WriteLine(index +"."+task);
                index++;
            }
        }
    }
    static void RemoveTask(List<string> Tasks)
    {
        if(Tasks.Count == 0)
        {
            Console.WriteLine("No tasks to remove");
            return;
        }
        Console.WriteLine("Enter task To remove ");

        int n = int.Parse(Console.ReadLine());

        if( n>=1 && n <= Tasks.Count)
        {
            Console.WriteLine("Removed task :"+ Tasks[n-1]);
            Tasks.RemoveAt(n-1);
        }
        else
        {
            Console.WriteLine("Invalid Task number : ");
        }

    }
}
using System;

class Program
{
    static string[] stack = new string[10];
    static int top = -1; // empty stack

    
    static void Push(string action)
    {
        if (top == stack.Length - 1)
        {
            Console.WriteLine("Stack Overflow");
            return;
        }

        top++;
        stack[top] = action;
        Display();
    }


    static void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Nothing to Undo (Stack Empty)");
            return;
        }

        Console.WriteLine("Undo: " + stack[top]);
        top--;
        Display();
    }

    static void Display()
    {
        if (top == -1)
        {
            Console.WriteLine("Current State: Empty");
            return;
        }

        Console.Write("Current State: ");
        for (int i = 0; i <= top; i++)
        {
            Console.Write(stack[i] + " ");
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Push("Type A");
        Push("Type B");
        Push("Type C");

        Pop(); 
        Pop(); 
    }
}
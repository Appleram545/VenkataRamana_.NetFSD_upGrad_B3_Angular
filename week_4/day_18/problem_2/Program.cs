// Level - 1 Problem 2: Simple Calculator Using Switch
// Scenario
// Create a simple calculator application that performs basic arithmetic operations.
// Requirements
// • Accept two numbers from user. • Accept operator (+, -, *, /). • Use switch statement to perform operation. • Display result.

using System;

class A
{
    static void Main(string[] args)
    {
        double num1, num2;
        char op;

        Console.WriteLine("Enter First Number:");
        num1 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Second Number:");
        num2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Operator (+, -, *, /):");
        op = char.Parse(Console.ReadLine());

        switch (op)
        {
            case '+':
                Console.WriteLine("Result: " + (num1 + num2));
                break;

            case '-':
                Console.WriteLine("Result: " + (num1 - num2));
                break;

            case '*':
                Console.WriteLine("Result: " + (num1 * num2));
                break;

            case '/':
                Console.WriteLine("Result: " + (num1 / num2));
                break;

            default:
                Console.WriteLine("Invalid Operator");
              
        }
    }
}
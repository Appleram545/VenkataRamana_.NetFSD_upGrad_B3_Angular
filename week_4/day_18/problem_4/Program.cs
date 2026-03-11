// Level - 2 Problem 2: Number Analysis Using Loops
// Scenario
// Create a .NET 8 console application that analyzes numbers between 1 and N.
// Requirements
// • Accept a number N from user. • Use loops to:    - Count even numbers    - Count odd numbers    - Calculate sum of all numbers • Display results.


using System;

class A
{
    static void Main(string[] args)
    {
        int n, evenCount = 0, oddCount = 0, sum = 0;

        Console.WriteLine("Enter Number: ");
        n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            sum = sum + i;

            if (i % 2 == 0)
                evenCount++;
            else
                oddCount++;
        }

        Console.WriteLine("Even Count: " + evenCount);
        Console.WriteLine("Odd Count: " + oddCount);
        Console.WriteLine("Sum: " + sum);
    }
}
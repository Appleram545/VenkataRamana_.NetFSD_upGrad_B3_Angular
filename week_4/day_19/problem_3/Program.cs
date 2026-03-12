// 1.Create a class Student.
// 2.Create method CalculateAverage(int m1, int m2, int m3).
// 3.Return the average marks.
// 4. Display grade based on average.



using System;

class student
{
    public double cal(int m1, int m2, int m3)
    {
        return (m1 + m2 + m3) / 3.0;
    }
}

class B
{
    static void Main()
    {
        student obj = new student();

        Console.Write("Enter mark 1: ");
        int m1 = int.Parse(Console.ReadLine());

        Console.Write("Enter mark 2: ");
        int m2 = int.Parse(Console.ReadLine());

        Console.Write("Enter mark 3: ");
        int m3 = int.Parse(Console.ReadLine());

        double avg = obj.cal(m1, m2, m3);

        Console.WriteLine("Average = " + avg);

        if (avg >= 80)
            Console.WriteLine("Grade = student");
        else if (avg >= 60)
            Console.WriteLine("Grade = B");
        else if (avg >= 50)
            Console.WriteLine("Grade = C");
        else
            Console.WriteLine("Grade = Fail");
    }
}
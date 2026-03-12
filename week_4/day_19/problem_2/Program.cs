// 1.Create a class named Calculator.
// 2.Create methods Add(int a, int b) and Subtract(int a, int b).
// 3.Each method should return the result.
// 4. In Main(), create an object and call the methods.
// 5. Display the output.




using System;

class A
{
    public int add(int a,int b)
    {
        return a+b;
    }
     public int sub(int a, int b)
    {
        return a-b;;
    }

}
class B
{
    static void Main()
    {
        A obj = new A();

        Console.Write("Enter first number : ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter Second number : ");
        int b = int.Parse(Console.ReadLine());

        int sum = obj.add(a,b);
        int sub = obj.sub(a,b);

        Console.WriteLine("SUM IS : "+ sum);
        Console.WriteLine("SUBTRACTION IS : " + sub);


    }
}
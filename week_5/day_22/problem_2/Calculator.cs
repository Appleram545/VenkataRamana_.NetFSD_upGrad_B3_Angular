
class Cal
{
    public void Division(int num,int den)
    {
        try
        {
            int result = num/den;
            Console.WriteLine("Result :"+ result);
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Can not divide with Zero");
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid Input");
        }
        finally
        {
            Console.WriteLine("Completed");
        }
    }
}
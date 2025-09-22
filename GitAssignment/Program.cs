using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Calculator Demo");
        Console.WriteLine("1 + 2 = " + Plus(1, 2));
        Console.WriteLine("Calculator Demo");
      
    }



     static int Minus(int a, int b) => throw new NotImplementedException();
    static int Plus(int a, int b) => a + b;
}

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Calculator Demo");
        Console.WriteLine("1 + 2 = " + Plus(1, 2));
        Console.WriteLine("5 - 3 = " + Minus(5, 3));
        Console.WriteLine("4 * 3 = " + Multiply(4, 3));
        Console.WriteLine("10 / 2 = " + Divide(10, 2));
    }

    static int Plus(int a, int b) => a + b;
    static int Minus(int a, int b) => a - b;
    static int Multiply(int a, int b) => a * b;
    static int Divide(int a, int b) => a / b;
}

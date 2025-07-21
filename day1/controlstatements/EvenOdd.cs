using System;

class OddEvenProgram
{
    static void OddEven()
    {
        Console.WriteLine("Enter a Number:");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number % 2 == 0)
        {
            Console.WriteLine("This is a Even Number");
        }
        else
        {
            Console.WriteLine("This is a  Odd Number");
        }
    }
}
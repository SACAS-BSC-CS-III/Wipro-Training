using System;

class Employee
{
    public void Input()
    {

        Console.WriteLine("Enter the First Number: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the Second Number:");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("The sum of the two digit is" + (a + b));
        Console.ReadKey();
    }

    public void Display()
    {
        Console.WriteLine("The Employee ID is Displaying");
    }
}

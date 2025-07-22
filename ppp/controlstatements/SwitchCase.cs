using System;

class Switch
{
    static void Main()
    {
        Console.WriteLine("Enter 1 To Check the number is whether a Factor of 3.");
        Console.WriteLine("Enter 2 To Check the number is whether a Odd Number.");
        Console.WriteLine("Enter 3 To Check the number is whether a Even Number.");

        Console.WriteLine("Enter Your Choice: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Enter the  number to be checked : ");
        int number = Convert.ToInt32(Console.ReadLine());

        switch (choice)
        {
            case 1:
                if (IsPrime(number))
                {
                    Console.WriteLine("Yes, It is a Prime Number.");
                }
                else
                {
                    Console.WriteLine("No, It is not a Prime Number.");
                }

                break;
            case 2:
                if (number % 2 == 0)
                {
                    Console.WriteLine("Yes, It is a Even Number.");
                }
                else
                {
                    Console.WriteLine("No, It is not a Even Number.");
                }
                break;
            case 3:
                if (number % 2 == 0)
                {
                    Console.WriteLine("No, It is a not a Odd Number.");
                }
                else
                {
                    Console.WriteLine("Yes, It is a Odd Number.");
                }
                break;
            default:
                Console.WriteLine("Enter a valid choice from 1 , 2 , 3 ------");
                break;
        }
    }


}
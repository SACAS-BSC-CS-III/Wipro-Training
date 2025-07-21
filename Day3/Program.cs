using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the Number of Students");
        int noOfStudents = Convert.ToInt32(Console.ReadLine());
        string[,] students = new string[noOfStudents,2];

        for (int i = 0; i < noOfStudents; i++)
        {
            Console.WriteLine("Enter the " + (i + 1) + " Student Name");
            students[i, 0] = Console.ReadLine();

            Console.WriteLine("Enter " + students[i, 0] + "'s Age : ");
            students[i, 1] = Console.ReadLine();
        }

        for (int j = 0; j < noOfStudents; j++)
        {
            Console.WriteLine("The "+(j+1) + " Student Name is " + students[j,0] + " and the age is "+ students[j,1]);
        }
    }
}
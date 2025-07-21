using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the Number of Students");
        int noOfStudents = Convert.ToInt32(Console.ReadLine());

        string[,] studentName = new string[noOfStudents,2];
        string[][] studentSubjects = new string[noOfStudents][];


        for (int i = 0; i < noOfStudents; i++)
        {
            Console.WriteLine("Enter the " + (i + 1) + " Student Name");
            studentName[i, 0] = Console.ReadLine();

            Console.WriteLine("Enter the " + studentName[i, 0] + "'s Age : ");
            studentName[i, 1] = Console.ReadLine();

            Console.WriteLine("How many subjects you want to store : ");
            int subCount = Convert.ToInt32(Console.ReadLine());

            studentSubjects[i] = new string[subCount];
            for (int j = 0; j < subCount; j++)
            {
                Console.WriteLine("Enter the Subject No " + (j + 1) + " : ");
                studentSubjects[i][j] = Console.ReadLine();
            }
        }

        for (int i = 0; i < noOfStudents; i++)
        {
            Console.WriteLine("");
            Console.WriteLine("The Student " + (i + 1) + " Name is " + studentName[i, 0]);
            Console.WriteLine(studentName[i, 0] + "'s Age is : " + studentName[i, 1]);
            Console.WriteLine(studentName[i, 0] + " has Selected " + studentSubjects[i].Length + " Subjuects.");
            Console.WriteLine("");

            for (int j = 0; j < studentSubjects[i].Length; j++)
            {

                Console.WriteLine("The Subject Number " + (j + 1) + " is : " + studentSubjects[i][j]);
            }
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }
    }
}
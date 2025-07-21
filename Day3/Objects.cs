using System;
using studentProgram;

class StudentArray
{
    static void Main()
    {
        int studentCount = 3;
        Student[] students = new Student[studentCount]; //Created an Array of Student Class

        for (int i = 0; i < studentCount; i++)
        {
            students[i] = new Student(); //with new keyword object will created and stored in a student class

            Console.WriteLine("Enter the Student Name: ");
            students[i].Name = Console.ReadLine();

            Console.WriteLine("Enter the Student Age: ");
            students[i].Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How Many Subjects you want to store ?");
            int subjectCount = Convert.ToInt32(Console.ReadLine());

            students[i].SubjectMarks = new int[subjectCount];

            for (int j = 0; j < subjectCount; j++)
            {
                Console.Write("Enter Marks of the subjects");
                students[i].SubjectMarks[j] = Convert.ToInt32(Console.ReadLine());

            }


        }

        Console.WriteLine("Students Obj are Given Below");  
        
    }
    
}
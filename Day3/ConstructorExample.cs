using System;

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }

    public static int count = 0;

    static Employee()
    {
        count++;
        Console.WriteLine("The Static Count is " + count);

        string Name = "Niti";
        int Age = 30;
    }

    public Employee()
    {
        string Name = "Saravanan";
        int Age = 32;
    }

    public Employee(string Name, int Age)
    {
        string Name = name;
        int Age = Age;
    }

    public void Display()
    {
        Console.WriteLine("The Name : " + Name + ", Age : ");
    }

    public void Main()
    {
        Employee e1 = new Employee();

        e1.Display();
    }
}


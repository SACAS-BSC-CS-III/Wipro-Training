using System;

class Employee
{
    public string Name { get; set; }
    public int Age { get; set; }

    public static int count = 0;

    public Employee()
    {
        count++;
        Console.WriteLine("The Static Count is " + count);
        Name = "Saravanan";
        Age = 32;
    }

    public Employee(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Employee(string name)
    {
        Name = name;
    }

    public void Display()
    {
        Console.WriteLine("The Name : " + Name + ", Age : " + Age);
    }

    
}

class ConstructorProgram
{
    public static void Main()
    {
        Employee e1 = new Employee();
        Employee e2 = new Employee();
        Employee e3 = new Employee();

        e1.Display();
        e2.Display();
        e3.Display();
    }
}
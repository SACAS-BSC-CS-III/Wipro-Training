using System; //package/namespace  name -- > imported the built in packag
using ProgramUsage;
     class Hello
    {
        //main is the entry point of your program
        
        public static void Main(string[] args)
        {
            Program.PrintMessage();
                // int - 4bytes ,
                //  long - 8 bytes , 
                // float -4 bytes ,
                // double - 8 bytes ,
                //  bool - 1 byte ,
                // char - 2bytes ,
                //  string - 2bytes per character

            {
                // datatype declaration with initialization 
                // variable is a container contains value
                int number = 456;
                int a ;
                int b;
                
                char ch = 'B';
                //Int16
                short num1 = 234;
               
                

                Console.WriteLine($"Value1 : {number} second number : {num1} ");

                Console.WriteLine("Char : " + ch);

                Console.WriteLine("Equivalent Number : " + (byte)ch); // conversion implicit & explicit
                Console.WriteLine("The minimum and maximum value size : " + char.MinValue + " " + char.MaxValue);
                Console.WriteLine("The char size : " + sizeof(char));
                Console.WriteLine("Enter first number");
                a = Convert.ToInt32(Console.ReadLine());
                 Console.WriteLine("Enter second number");
                b = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Sum of 2 numbers : " + (a+b));
                Console.ReadKey();
            }
        }

    }
  
    
    
    
    
    
    
    
    
    
    
    
    
    
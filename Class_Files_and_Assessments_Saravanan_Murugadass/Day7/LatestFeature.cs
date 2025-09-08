using System;
using System.Collections.Generic;


using System;

class Account
{
    // Define properties
    // Complete Step 1:............
    public string AccountNumber{get; set;}
    public string OwnerName {get; set;}
    private decimal Balance {get; set;} 

    public Account(string accountNumber, string ownerName)
    {
        AccountNumber= accountNumber;
        OwnerName = ownerName;
        Balance = 0 ;
    }
    // Define methods
    // Complete Step 2:............

    public void Deposit(decimal amount)
    {
        if(amount > 0)
        {
            Balance = Balance + amount;
            Console.WriteLine("Deposited : $"+amount);
            Console.WriteLine("Account Balance : $"+Balance);        }
        else
        {
            Console.WriteLine("Deposit amount must be Positive.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if(amount <=0)
        {
            Console.WriteLine("Withdrawl amount must be positive.");
        }
        else if (amount > Balance)
        {
            Console.WriteLine("Insufficient Balance");
        }
        else
        {
            Balance = Balance - amount;
            Console.WriteLine("Withdrew : $"+amount);
            Console.WriteLine("Account Balance : $"+Balance);
        }
    }

    public void DisplayBalance()
    {
        Console.WriteLine("Account Balance : $"+Balance);
    }
    
}

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user to enter account details
        Console.WriteLine("Enter account number:");
        // Complete Step 3:............
        string accNumber = Console.ReadLine();        

        Console.WriteLine("Enter owner name:");
        // Complete Step 4:............
        string ownerName = Console.ReadLine();

        // Create an instance of the Account class
        // Complete Step 5:............
        Account myAccount = new Account(accNumber, ownerName); 

        // Perform transactions
        // Complete Step 6:............
        bool running = true;

        while(running)
        {
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();


            switch(choice)
            {
                case "1":
                Console.Write("Enter Amount to be Deposit :");
                decimal depositAmount;
                if (decimal.TryParse(Console.ReadLine(), out depositAmount))
                {
                    myAccount.Deposit(depositAmount);
                }
                else{
                    Console.WriteLine("Invalid Amount.");
                }
                break;

                case "2":
                Console.Write("Enter Amount to be Widthdraw: ");
                decimal withdrawAmount;
                if (decimal.TryParse(Console.ReadLine(), out withdrawAmount))
                {
                    myAccount.Withdraw(withdrawAmount);
                }
                else {
                    Console.WriteLine("Invalid Amount.");
                }
                break;

                case "3":
                myAccount.DisplayBalance();
                break;

                case "4":
                running = false;
                break;

                default:
                Console.WriteLine("Invalid Choice. Please Try Again.");
                break;

            }
        }
    }
}

using System;
using System.Collections.Generic;

public class cardHolder
{
    public string CardNum { get; private set; }
    public int Pin { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public double Balance { get; private set; }

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        CardNum = cardNum;
        Pin = pin;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
    }

    public void SetBalance(double newBalance) => Balance = newBalance;
}

public class Program
{
    static void PrintOptions()
    {
        Console.WriteLine("\nPlease choose from the following options:");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");
        Console.WriteLine("3. Show Balance");
        Console.WriteLine("4. Exit");
    }

    static void Deposit(cardHolder currentUser)
    {
        try
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double depositAmount = double.Parse(Console.ReadLine());
            currentUser.SetBalance(currentUser.Balance + depositAmount);
            Console.WriteLine("Thank you for your deposit. Your new balance is: $" + currentUser.Balance);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
    }

    static void Withdraw(cardHolder currentUser)
    {
        try
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawalAmount = double.Parse(Console.ReadLine());
            if (withdrawalAmount > currentUser.Balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                currentUser.SetBalance(currentUser.Balance - withdrawalAmount);
                Console.WriteLine("You're good to go! Your new balance is: $" + currentUser.Balance);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
    }

    static void CheckBalance(cardHolder currentUser)
    {
        Console.WriteLine("Current balance: $" + currentUser.Balance);
    }

    public static void Main(string[] args)
    {
        List<cardHolder> list = new List<cardHolder>
        {
            new cardHolder("4532772818527395", 1234, "John", "Griffith", 150.31),
            new cardHolder("4532761841325282", 4321, "Ashley", "Janes", 321.13),
            new cardHolder("6011188364697109", 9999, "Frida", "Dickerson", 851.84),
            new cardHolder("3498693153147110", 4826, "Dawn", "Smith", 54.27)
        };

        Console.WriteLine("Welcome to the ATM!");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = Console.ReadLine();
        cardHolder currentUser = list.Find(user => user.CardNum == debitCardNum);

        if (currentUser == null)
        {
            Console.WriteLine("Card not recognized. Exiting...");
            return;
        }

        Console.WriteLine("Please enter your PIN: ");
        try
        {
            int userPin = int.Parse(Console.ReadLine());
            if (currentUser.Pin != userPin)
            {
                Console.WriteLine("Incorrect PIN. Exiting...");
                return;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid PIN format. Exiting...");
            return;
        }

        Console.WriteLine($"Welcome, {currentUser.FirstName}!");

        int option;
        do
        {
            PrintOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Deposit(currentUser);
                        break;
                    case 2:
                        Withdraw(currentUser);
                        break;
                    case 3:
                        CheckBalance(currentUser);
                        break;
                    case 4:
                        Console.WriteLine("Thank you! Have a nice day.");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
                option = 0; // Keeps the loop running in case of invalid input.
            }
        } while (option != 4);
    }


}





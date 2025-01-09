using  System;
using System.Collections.Generic;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getCardNum() => cardNum;
    public int getPin() => pin;
    public string getFirstName() => firstName;
    public string getLastName() => lastName;
    public double getBalance() => balance;

    public void setPin(int newPin) => pin = newPin;
    public void setFirstName(string newFirstName) => firstName = newFirstName;
    public void setLastName(string newLastName) => lastName = newLastName;
    public void setBalance(double newBalance) => balance = newBalance;

    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("\nPlease choose from the following options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit: ");
            double depositAmount = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + depositAmount);
            Console.WriteLine("Thank you for your deposit. Your new balance is: $" + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawalAmount = double.Parse(Console.ReadLine());
            if (withdrawalAmount > currentUser.getBalance())
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawalAmount);
                Console.WriteLine("You're good to go! Your new balance is: $" + currentUser.getBalance());
            }
        }

        void checkBalance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: $" + currentUser.getBalance());
        }

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
        cardHolder currentUser = list.Find(user => user.getCardNum() == debitCardNum);

        if (currentUser == null)
        {
            Console.WriteLine("Card not recognized. Exiting...");
            return;
        }

        Console.WriteLine("Please enter your PIN: ");
        int userPin = int.Parse(Console.ReadLine());

        if (currentUser.getPin() != userPin)
        {
            Console.WriteLine("Incorrect PIN. Exiting...");
            return;
        }

        Console.WriteLine($"Welcome, {currentUser.getFirstName()}!");

        int option;
        do
        {
            printOptions();
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    deposit(currentUser);
                    break;
                case 2:
                    withdraw(currentUser);
                    break;
                case 3:
                    checkBalance(currentUser);
                    break;
                case 4:
                    Console.WriteLine("Thank you! Have a nice day.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (option != 4);
    }
}




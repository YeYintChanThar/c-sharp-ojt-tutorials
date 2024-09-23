using System;
using System.Text.RegularExpressions;

class Program
{
    static int cardID = 0;

    static void Main()
    {
        MemberCardInfo();
    }

    static void MemberCardInfo()
    {
        string name;
        string email;
        string phoneNumber;

        while (true)
        {
            Console.Write("Enter your name: ");
            name = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(name))
            {
                break; 
            }
            else
            {
                Console.WriteLine("Name is required.");
            }
        }

        email = GetValidEmail();

        phoneNumber = GetValidPhoneNumber();


        Console.WriteLine($"Member Name: {name}");
        Console.WriteLine($"Email: {email}");
        Console.WriteLine($"Phone No: {phoneNumber}");
        GetMemberCardID();
        Console.WriteLine();
        Console.WriteLine();
        ExitOrNot();
    }

    static string GetValidEmail()
    {
        string email;
        Regex regex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        while (true)
        {
            Console.Write("Enter your email: ");
            email = Console.ReadLine();

            if (email != null && regex.IsMatch(email))
            {
                return email;
            }
            else
            {
                Console.WriteLine("Invalid email format. Please enter a valid email address.");
            }
        }
    }

    static string GetValidPhoneNumber()
    {
        string phoneNumber;
        Regex regex = new(@"^[\d()+-]+$");

        while (true)
        {
            Console.Write("Enter your phone number: ");
            phoneNumber = Console.ReadLine();

            if (phoneNumber != null && regex.IsMatch(phoneNumber) && phoneNumber.Length <=15)
            {
                return phoneNumber;
            }
            else
            {
                Console.WriteLine("Invalid phone number.");
            }
        }
    }

    static void GetMemberCardID()
    {
        cardID += 1;
        string memberID = $"MC-{cardID:D4}";
        Console.WriteLine("Member Card ID: " + memberID);
    }

    static void ExitOrNot()
    {
        Console.WriteLine("Type N for the next, E for exit");
        char state = Console.ReadKey(true).KeyChar;
        Console.WriteLine(); 
        if (state == 'n' || state == 'N')
        {
            MemberCardInfo();
        }
        else if (state == 'e' || state == 'E')
        {
            Environment.Exit(0);
        }
        else
        {
            ExitOrNot();
        }
    }
}

using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        PhoneBook phonebook = new PhoneBook();
        phonebook.AddContact("Zaur", "0502739237");
        phonebook.AddContact("Ali", "0551328765");

        phonebook.AllContacts();

        Console.WriteLine($"Find Zaur: {phonebook.FindNumber("Zaur")}");
        phonebook.RemoveContact("Zaur");
        Console.WriteLine($"Find Zaur: {phonebook.FindNumber("Zaur")}");
    }
}

using System;
using System.Collections.Generic;

public class PhoneBook
{
    private Dictionary<string, string> contacts;

    public PhoneBook()
    {
        contacts = new Dictionary<string, string>();
    }

    public void AddContact(string name, string number)
    {
        if (contacts.ContainsKey(name))
        {
            Console.WriteLine($"Contact '{name}' exists.");
        }
        else
        {
            contacts[name] = number;
            Console.WriteLine($"Contact '{name}' added (number: {number}).");
        }
    }

    public void RemoveContact(string name)
    {
        if (contacts.Remove(name))
        {
            Console.WriteLine($"Contact '{name}' removed.");
        }
        else
        {
            Console.WriteLine($"Contact '{name}' not found.");
        }
    }

    public string FindNumber(string name)
    {
        if (contacts.TryGetValue(name, out string number))
        {
            return number;
        }
        else
        {
            return "Contact not found.";
        }
    }

    public void AllContacts()
    {
        Console.WriteLine("All Contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{contact.Key}: {contact.Value}");
        }
    }
}

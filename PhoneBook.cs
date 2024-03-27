using System;
using System.Collections.Generic;

class PhoneBook
{
    Dictionary<string, string> contacts = new Dictionary<string, string>();

    public void AddContact(string name, string phoneNumber)
    {
        contacts[name] = phoneNumber;
    }

    public string SearchContact(string name)
    {
        if (contacts.ContainsKey(name))
        {
            return contacts[name];
        }
        else
        {
            return "Contact not found";
        }
    }

    public bool DeleteContact(string name)
    {
        if (contacts.ContainsKey(name))
        {
            contacts.Remove(name);
            return true;
        }
        else
        {
            return false;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        PhoneBook phoneBook = new PhoneBook();

        // Input 1
        phoneBook.AddContact("John Doe", "123-456-7890");
        Console.WriteLine("Input 1:");
        Console.WriteLine("Search Result: " + phoneBook.SearchContact("John Doe"));
        Console.WriteLine();

        // Input 2
        phoneBook.AddContact("John Doe", "123-456-7890");
        Console.WriteLine("Input 2:");
        Console.WriteLine("Search Result: " + phoneBook.SearchContact("Jane Doe"));
        Console.WriteLine();

        // Input 3
        phoneBook.AddContact("John Doe", "123-456-7890");
        Console.WriteLine("Input 3:");
        if (phoneBook.DeleteContact("John Doe"))
        {
            Console.WriteLine("Contact deleted successfully");
        }
        else
        {
            Console.WriteLine("Contact not found");
        }
        Console.WriteLine("Search Result: " + phoneBook.SearchContact("John Doe"));
        Console.WriteLine();

        // Input 4
        Console.WriteLine("Input 4:");
        if (phoneBook.DeleteContact("Jane Doe"))
        {
            Console.WriteLine("Contact deleted successfully");
        }
        else
        {
            Console.WriteLine("Contact not found");
        }
    }
}

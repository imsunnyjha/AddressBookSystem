using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Address Book System!");

            // Create a list of contacts.
            List <Contact> contacts = new List<Contact>();
            Contact contact = new Contact();

            //Add New Contact
            contact.AddNewContact();

            //Display entered contacts
            contact.DisplayContact();
        }
    }
}

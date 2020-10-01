using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class Contact 
    {
        List <Contact> contacts = new List <Contact>();
        // Creating setter and getter for each property  
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
        public long phoneNumber { get; set; }
        public string emailId { get; set; }

        public Contact()
        {

        }
        public Contact(string firstName, string lastName, string address, string city, string state, int zipCode, long phoneNumber, string emailId)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.phoneNumber = phoneNumber; 
            this.emailId = emailId;

        }
        
        public void AddNewContact()
        {
            Contact contact = new Contact();
            Console.Write("Enter First Name: ");
            contact.firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            contact.lastName = Console.ReadLine();
            Console.Write("Enter Address:");
            contact.address = Console.ReadLine();
            Console.Write("Enter City: ");
            contact.city = Console.ReadLine();
            Console.Write("Enter State: ");
            contact.state = Console.ReadLine();
            Console.Write("Enter ZIP Code: ");
            contact.zipCode = int.Parse(Console.ReadLine());
            Console.Write("Enter Phone Number: ");
            contact.phoneNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter Email Id: ");
            contact.emailId = Console.ReadLine();

            contacts.Add(contact);
            Console.WriteLine("New Contact added successfully");
        }
        public void DisplayContact()
        {
            Console.WriteLine("\nDisplaying Contacts - \nFirst Name\tLast Name\tAddress\tCity\tState\tZIP Code\tPhone Number\tEmailId");
            foreach (Contact contact in contacts)
            {
                Console.WriteLine(contact.firstName + "\t\t" + contact.lastName + "\t\t" + contact.address + "\t" + contact.city + "\t" + contact.state + "\t" + contact.zipCode + "\t\t" + contact.phoneNumber + "\t\t" + contact.emailId);
            }
        }
    }
}

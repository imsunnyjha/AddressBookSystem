﻿using System;
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

        public void EditContact()
        {
            Console.WriteLine("Enter the first name of the person: ");
            string fName = Console.ReadLine();
            foreach (Contact c in contacts)
            {
                if (c.firstName.Equals(fName))
                {
                    int editChoice = 0;
                    while (editChoice != 9)
                    {
                        Console.WriteLine("Enter the following choice");
                        Console.WriteLine("1. Edit First Name");
                        Console.WriteLine("2. Edit Last Name");
                        Console.WriteLine("3. Edit Address");
                        Console.WriteLine("4. Edit City");
                        Console.WriteLine("5. Edit State");
                        Console.WriteLine("6. Edit Zip");
                        Console.WriteLine("7. Edit Phone Number");
                        Console.WriteLine("8. Edit E-mail");
                        Console.WriteLine("9. Exit");
                        Console.WriteLine("Enter your choice: ");
                        editChoice = Convert.ToInt32(Console.ReadLine());

                        switch (editChoice)
                        {
                            case 1:
                                Console.WriteLine("1. Edit First Name");
                                string fname = Console.ReadLine();
                                c.firstName = fname;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 2:
                                Console.WriteLine("1. Edit Last Name");
                                string lname = Console.ReadLine();
                                c.lastName = lname;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 3:
                                Console.WriteLine("1. Edit Address Name");
                                string aAddress = Console.ReadLine();
                                c.address = aAddress;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 4:
                                Console.WriteLine("1. Edit City Name");
                                string cCity = Console.ReadLine();
                                c.city = cCity;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 5:
                                Console.WriteLine("1. Edit State");
                                string sState = Console.ReadLine();
                                c.state = sState;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 6:
                                Console.WriteLine("1. Edit Zip");
                                int zCode = Convert.ToInt32(Console.ReadLine());
                                c.zipCode = zCode;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 7:
                                Console.WriteLine("1. Edit Phone Number");
                                long phNum = Convert.ToInt64(Console.ReadLine());
                                c.phoneNumber = phNum;
                                Console.WriteLine("Edited Successfully");
                                break;
                            case 8:
                                Console.WriteLine("1. Edit Email");
                                string mail = Console.ReadLine();
                                c.emailId = mail;
                                Console.WriteLine("Edited Successfully");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Enter a valid name");
                }
            }
        }

        public void DeleteContact()
        {
            Console.WriteLine("Enter the first name of the person: ");
            string fName = Console.ReadLine();
            List<Contact> con = new List<Contact>();
            foreach (Contact c in contacts)
            {
                if (c.firstName.Equals(fName))
                {
                    con.Add(c);             
                }
            }
            contacts.RemoveAll(i => con.Contains(i));
            Console.WriteLine("Contact Removed Successfully");
        }
    }
}

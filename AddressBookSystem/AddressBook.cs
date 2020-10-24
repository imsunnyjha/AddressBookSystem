﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookSystem
{
    class AddressBook
    {
        public List<Contact> contactList;
        string path = @"C:\Users\lenovo\Desktop\BridgeLabz\AddressBookSystem\AddressBookSystem\contacts.txt";

        public AddressBook()
        {
            contactList = new List<Contact>();

        }
        public string AddContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string emailId)
        {
            if (CheckName(firstName, lastName) == false)
            {
                Contact contact = new Contact(firstName, lastName, address, city, state, zipCode, phoneNo, emailId);
                contactList.Add(contact);
                return "Details Added Successfully";
            }
            return "Name already exists";
        }
        public void EditContact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNo, string emailId)
        {
            foreach (Contact c in contactList)
            {
                if (c.firstName.Equals(firstName))
                {
                    c.lastName = lastName;
                    c.address = address;
                    c.city = city;
                    c.state = state;
                    c.zipCode = zipCode;
                    c.phoneNo = phoneNo;
                    c.emailId = emailId;

                    return;
                }
            }
        }
        public void RemoveContact(string firstName, string lastName)
        {
            foreach (Contact c in contactList)
            {
                if (c.firstName.Equals(firstName) && c.lastName.Equals(lastName))
                {
                    contactList.Remove(c);

                    return;
                }
            }
        }
        public bool CheckName(string firstName, string lastName)
        {
            foreach (Contact c in contactList.FindAll(e=> e.firstName.Equals(firstName) && e.lastName.Equals(lastName)))
            {
                return true;                
            }
            return false;
        }
        public List<Contact> GetPersonByCityOrState(string cityOrState)
        {
            List<Contact> contact = new List<Contact>();
            foreach (Contact c in contactList.FindAll(e=> e.city.Equals(cityOrState) || e.state.Equals(cityOrState)))
            {               
                    contact.Add(c);
            }
            return contact;
        }
        public void SortByName()
        {
            contactList.Sort((contact1, contact2) => contact1.firstName.CompareTo(contact2.firstName));
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void SortByCity()
        {
            contactList.Sort((contact1, contact2) => contact1.city.CompareTo(contact2.city));
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void SortByState()
        {
            contactList.Sort((contact1, contact2) => contact1.state.CompareTo(contact2.state));
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void SortByZipCode()
        {
            contactList.Sort((contact1, contact2) => contact1.zipCode.CompareTo(contact2.zipCode));
            foreach (Contact c in contactList)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public void WriteToFile()
        {
            if (FileExitsts())
            {
                int count = 0;
                using (StreamWriter sr = File.AppendText(path))
                {

                    foreach (Contact c in contactList)
                    {
                        sr.WriteLine(++count + " " + c.ToString() + "\n");

                    }
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("File Does Not Exist");
            }

        }
        public void ClearFile()
        {
            File.WriteAllText(path, string.Empty);
        }
        public bool FileExitsts()
        {
            if (File.Exists(path))
                return true;
            return false;
        }
    }
}

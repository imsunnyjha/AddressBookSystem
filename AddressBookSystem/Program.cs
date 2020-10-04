using System;
using System.Collections.Generic;

namespace AddressBookSystem
{
    class Program
    {
        public static void AddressBook(Contact cont )
        {
            bool flag = true;
            int choice;
            Contact contact = new Contact();
            //Menu to display for the user
            while (flag)
            {
                try
                {
                    Console.WriteLine("\n1. Display All Contacts\n2. Add New Contact\n3. Edit Contact\n4. Delete Contact\n5. Exit");
                    choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        contact.DisplayContact();
                    }
                    else if (choice == 2)
                    {
                        contact.AddNewContact();
                    }
                    else if (choice == 3)
                    {
                        contact.EditContact();
                    }
                    else if (choice == 4)
                    {
                        contact.DeleteContact();
                    }
                    else if (choice == 5)
                    {
                        flag = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message + "\n" + e.StackTrace);
                }
            }
        }
            static void Main(string[] args)
            {
                Console.WriteLine("Welcome To Address Book System!");
                SwitchAddressBook switchaddressbook = new SwitchAddressBook();
                // Create a list of contacts.
                List<Contact> contacts = new List<Contact>();
                
                bool flag = true;
                int choice;

                while (flag)
                {
                    try
                    {
                        Console.WriteLine("\n1. Create New Address Book \n2. Use Another Address Book\n3. Exit");
                        choice = int.Parse(Console.ReadLine());
                        if (choice == 1)
                        {
                            Contact addressBook = new Contact();
                            Console.Write("\nEnter New Address Book's Name: ");
                            string addressBookName = Console.ReadLine();
                            switchaddressbook.AddNewAddressBook(addressBookName, addressBook);
                            Console.WriteLine("Successfully created " + addressBookName + "\tUsing Address Book " + addressBookName + "...");
                            AddressBook(addressBook);
                        }
                        else if (choice == 2)
                        {
                            Console.Write("\nEnter Address Book's Name: ");
                            string addressBookName = Console.ReadLine();
                            Contact addressBook = switchaddressbook.GetAddressBook(addressBookName);
                            if (addressBook != null)
                            {
                                Console.WriteLine("Using Address Book " + addressBookName + "___");
                                AddressBook(addressBook);
                            }
                            else
                                Console.WriteLine("There is no Book with name " + addressBookName);
                        }
                        else if (choice == 3)
                        {
                            flag = false;
                        }
                        else
                        {                       
                            Console.WriteLine("Invalid Input");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Invalid data entered. Error: " + e.Message + "\n" + e.StackTrace);
                    }
                }

            }
    }
} 

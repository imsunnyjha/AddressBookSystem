using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class SwitchAddressBook
    {

        Dictionary<string, AddressBook> addressBooksCollection = new Dictionary<string, AddressBook>();
        public Dictionary<string, List<Contact>> ContactByCity;
        public Dictionary<string, List<Contact>> ContactByState;
        List<string> cities;
        List<string> states;
        public SwitchAddressBook()
        {
            addressBooksCollection = new Dictionary<string, AddressBook>();
            ContactByCity = new Dictionary<string, List<Contact>>();
            ContactByState = new Dictionary<string, List<Contact>>();
            cities = new List<string>();
            states = new List<string>();

        }
        public void AddAddressBook(string name)
        {
            AddressBook addressBook = new AddressBook();
            if (addressBooksCollection.ContainsKey(name) == false)
            {
                addressBooksCollection.Add(name, addressBook);
                Console.WriteLine("Address Book Added Successfully");
            }
            else
            {
                Console.WriteLine("Address Book Already Exist");
            }

        }
        public AddressBook GetAddressBook(string name)
        {
            if (addressBooksCollection.ContainsKey(name))
            {
                return addressBooksCollection[name];
            }
            return null;
        }
        public void GetDistinctCityAndStateList()
        {
            foreach (var addressBook in addressBooksCollection)
            {
                foreach (var contact in addressBook.Value.contactList)
                {
                    if (cities.Contains(contact.city) == false)
                    {
                        cities.Add(contact.city);
                    }
                    if (states.Contains(contact.state) == false)
                    {
                        states.Add(contact.state);
                    }

                }
            }
        }
        public void SetContactByCityDictionary()
        {
            GetDistinctCityAndStateList();

            foreach (string city in cities)
            {
                List<Contact> contact = new List<Contact>();
                foreach (var addressBook in addressBooksCollection)
                {
                    contact.AddRange(addressBook.Value.GetPersonByCityOrState(city));
                }
                if (ContactByCity.ContainsKey(city))
                {
                    ContactByCity[city] = contact;
                }
                else
                {
                    ContactByCity.Add(city, contact);
                }
            }

        }
        public void SetContactByStateDictionary()
        {
            GetDistinctCityAndStateList();

            foreach (string state in states)
            {
                List<Contact> contacts = new List<Contact>();
                foreach (var addressBook in addressBooksCollection)
                {
                    contacts.AddRange(addressBook.Value.GetPersonByCityOrState(state));
                }
                if (ContactByState.ContainsKey(state))
                {
                    ContactByState[state] = contacts;
                }
                else
                {
                    ContactByState.Add(state, contacts);
                }
            }

        }
        public void ViewPersonsByCity(string city)
        {
            if (ContactByCity.ContainsKey(city))
            {
                foreach (Contact contact in ContactByCity[city])
                {
                    contact.ToString();
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
        public void ViewPersonsByState(string state)
        {
            if (ContactByState.ContainsKey(state))
            {
                foreach (Contact contact in ContactByState[state])
                {
                    contact.ToString();
                }
            }
            else
            {
                Console.WriteLine("No Contact found");
            }
        }
    }
}

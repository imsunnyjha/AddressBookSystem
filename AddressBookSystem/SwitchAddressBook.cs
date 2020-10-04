using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    class SwitchAddressBook
    {
        Dictionary<string, Contact> switchaddressbook = new Dictionary<string, Contact>();

        public void AddNewAddressBook(string addressBookName, Contact addressBook)
        {
            switchaddressbook.Add(addressBookName, addressBook);
        }

        public Contact GetAddressBook(string name)
        {
            foreach (var item in switchaddressbook)
            {
                if (item.Key == name)
                    return item.Value;
            }
            return null;
        }
    }
}

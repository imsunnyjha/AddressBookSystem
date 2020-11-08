using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookSystem
{
    public class ContactDatabase
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string phone { get; set; }
        public string email { get; set; }

        public string B_ID { get; set; }
        public string B_Name { get; set; }

        public string B_Type { get; set; }

    }
}

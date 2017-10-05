using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightJeffreyContactList
{
    //class to hold contact info
     class Contact
    {
        private string first;
        private string last;
        private long phone;
        private string email;

        //constructor
        public Contact(string f, string l,long p,string e)
        {
            first = f;
            last = l;
            phone = p;
            email = e;
        }
        public string First
        {
            get
            {
                return first;
            }
            set
            {
                first = value;
            }
        }
        public string Last
        {
            get
            {
                return last;
            }
            set
            {
                last = value;
            }
        }
        public long Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

    }
}

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

    }
}

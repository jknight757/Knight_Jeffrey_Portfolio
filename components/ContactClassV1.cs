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
        string first;
        string last;
        long phone;
        string email;

        //constructor
        public Contact(string f, string l,long p,string e)
        {
            first = f;
            last = l;
            phone = p;
            email = e;
        }
        public override string ToString()
        {
            return first + " " + last;
        }

    }
}

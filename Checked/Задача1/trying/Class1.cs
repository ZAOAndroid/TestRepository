using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
    {
        public class Card
        {
            private List<Contact> _contacts = new List<Contact>();

            public string Name { get; set; }

            public long SynCode { get; set; }

            public int Id { get; set; }

            public void AddContact(Contact contact)
            {
                _contacts.Add(contact);
            }
        }
    }


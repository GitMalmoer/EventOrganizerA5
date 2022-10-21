using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerA5
{
    public class Participant
    {
        private string _firstName;
        private string _lastName;
        private Address _address;

        public Participant()
        {
            _address = new Address();
        }
        public Participant(Address address):this(string.Empty,string.Empty, address)
        {

        }
        public Participant(string firstName, string lastName, Address address)
        {
            _firstName = firstName;
            _lastName = lastName;

            if (address != null)
                _address = address;
            else
                _address = new Address();
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            set { _lastName = value; }
            get { return _lastName; }
        }
        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public override string ToString()
        {
            string strOut = string.Format("{0} {1} {2,80}", _firstName, _lastName, _address);
            return strOut;
        }

    }
}

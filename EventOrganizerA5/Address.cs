using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerA5
{
    public class Address
    {
        private string _street;
        private string _city;
        private string _zipCode;
        private Countries _country;


        public Address():this(string.Empty,string.Empty, string.Empty, Countries.Sverige)
        {

        }
        public Address(string street, string city, string zipCode, Countries country)
        {
            _street = street;
            _city = city;
            _zipCode = zipCode;
            _country = country;
        }

        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }
        public Countries Country
        {
            get { return _country; }
            set
            {
                _country = value;
            }
        }

        public string CountryToString()
        {
            string countryStr = _country.ToString();
            string countryStrChanged;

            if (countryStr.Contains("_"))
            {
                 countryStrChanged = countryStr.Replace("_", " ");
                 return countryStrChanged;
            }
            else
            {
                return countryStr;
            }
            
        }

        public bool Validate()
        {
            bool cityOk = !string.IsNullOrEmpty(_city);
            return cityOk;
        }

        public override string ToString()
        {
            string strOut = string.Format("{0} {1} {2} {3}", _street, _city ,ZipCode, CountryToString());
            return strOut;
        }
    }
}

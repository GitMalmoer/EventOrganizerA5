using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerA5
{
    public class EventManager
    {
        private ParticipantManager _participantManager;
        private double _costPerPerson = 0.0;
        private double _feePerPerson = 0.0;
        private string _title;

        public EventManager()
        {
            _participantManager =  new ParticipantManager();
        }

        public ParticipantManager ParticipantManager // this getter is needed to accesss methods of ParticipantManager
        {
            get { return _participantManager; }

        }


        public double CostPerPerson
        {
            get { return _costPerPerson; }
            set 
            { 
                if(_costPerPerson >= 0.0)
                _costPerPerson = value; 
            }
        }

        public double FeePerPerson
        {
            get { return _feePerPerson; }
            set 
            { 
                if(_feePerPerson >= 0.0)
                _feePerPerson = value; 
            }
        }

        public string Title
        {
            get { return _title; }
            set 
            { 
                if(string.IsNullOrEmpty(_title)) // if its empty then sets value
                _title = value; 
            }
        }

        public double CalculateTotalCost()
        {
            double cost = _participantManager.Count * _costPerPerson;
            return cost;
        }

        public double CalculateTotalFee()
        {
            double fee = _participantManager.Count * _feePerPerson;
            return fee;
        }

    }
}

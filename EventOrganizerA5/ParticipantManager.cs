using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EventOrganizerA5
{
    public class ParticipantManager
    {
        List<Participant> participants;


        public ParticipantManager()
        {
            participants = new List<Participant>();
        }


        public void AddParticipant(Participant participant)
        {
            if(participant != null)
            participants.Add(participant);
        }

        public Participant GetParticipantAtIndex(int index)
        {

            if (CheckIndex(index))
                return participants[index];
            else
                return null;
        }

        public void RemoveParticipantAtIndex(int index)
        {
            if(CheckIndex(index))
            {
            participants.RemoveAt(index);
            }
            else
                MessageBox.Show( "Wrong selection");

        }

        public void ChangeParticipantAtIndex(Participant participant ,int index) 
        {
            if (CheckIndex(index))
            {
                participants[index] = participant;
            }
            else
            {
                MessageBox.Show("Wrong selected item");
            }
        }

        public int Count
        {
            get { return participants.Count; }
        }
        private bool CheckIndex(int index)
        {
            if (index < 0 || index > Count || index == -1)
                return false;
            else
                return true;
        }


    }
}

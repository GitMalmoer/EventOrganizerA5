using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizerA5
{
    public class ParticipantManager
    {
        List<Participant> participants;
        private int selectedIndex = -1;


        public ParticipantManager()
        {
            participants = new List<Participant>();
        }

        public int SelectedIndex
            { get { return selectedIndex; } set { selectedIndex = value; } }

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
        }

        public void ChangeParticipantAtIndex(Participant participant ,int index) 
        {
           // if (CheckIndex(index))
           // {
                participants[index] = participant;
            //}
        }

        public int Count()
        {
            int count = participants.Count;
            return count;
       }
        private bool CheckIndex(int index)
        {
            if (index == null || index < 0 || index > Count())
                return false;
            else
                return true;
        }

        
    }
}

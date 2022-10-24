using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventOrganizerA5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private ParticipantManager participantManager = new ParticipantManager();
        //private int _selectedIndex = 3;
        private EventManager eventManager;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            cmbCountries.ItemsSource = Enum.GetValues(typeof(Countries));
            cmbCountries.SelectedIndex = (int)Countries.Sverige;
            this.Title = "Event Manager by Marcin Junka";
            grpAddParticipant.IsEnabled = false;
        }
        private void btnCreateEvent_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtTitle.Text))
            {
                lstResults.Items.Clear();
                eventManager = new EventManager();
                eventManager.Title = txtTitle.Text;

                bool costOk = double.TryParse(txtCost.Text, out double cost);
                bool feeOk = double.TryParse(txtFee.Text, out double fee);

                eventManager.CostPerPerson = cost;
                eventManager.FeePerPerson = fee;


                this.Title = eventManager.Title + " by Marcin Junka";
                grpAddParticipant.IsEnabled = true;
                UpdateList();
            }
            else
                MessageBox.Show("Title can't be empty.");
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Participant participant = new Participant();
            ReadInput(ref participant);
            UpdateList();
        }

        private bool ReadInput(ref Participant participant)
        {
            bool participantDataOk = ReadParticipantData(ref participant);

            if(participantDataOk)
            {
                eventManager.ParticipantManager.AddParticipant(participant);
            }
            else
            {
                string errorMessage = "First name, Last name and city are required";
                MessageBox.Show(errorMessage);
            }

            return participantDataOk;
        }


        private bool ReadParticipantData(ref Participant participant)
        {
            participant.FirstName = txtFirstName.Text;
            participant.LastName = txtLastName.Text;

            participant.Address = ReadAddress();

            bool adressOk = participant.Address.Validate();

            return adressOk;
        }

        private Address ReadAddress()
        {
            Address address = new Address();
            address.Street = txtStreet.Text;
            address.City = txtCity.Text;
            address.ZipCode = txtZipCode.Text;
            address.Country = (Countries)cmbCountries.SelectedItem;

            return address;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = IsListBoxSelected();

            if (selectedIndex >= 0)
            {
                Participant participant = eventManager.ParticipantManager.GetParticipantAtIndex(selectedIndex);
                ReadParticipantData(ref participant);

                eventManager.ParticipantManager.ChangeParticipantAtIndex(participant, selectedIndex);

                UpdateList();
            }
            else
            {
                MessageBox.Show("You need to select something first!");
            }


        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = lstResults.SelectedIndex;
            eventManager.ParticipantManager.RemoveParticipantAtIndex(index);
            UpdateList();
        }


        public void UpdateList()
        {
            lstResults.Items.Clear();
            for (int i = 0; i < eventManager.ParticipantManager.Count; i++)
            {
                if (eventManager.ParticipantManager.GetParticipantAtIndex(i) != null)
                    lstResults.Items.Add(eventManager.ParticipantManager.GetParticipantAtIndex(i).ToString());
            }

            txtNumberOfParticipants.Text = eventManager.ParticipantManager.Count.ToString();
            txtTotalCost.Text = eventManager.CalculateTotalCost().ToString();
            txtTotalFees.Text = eventManager.CalculateTotalFee().ToString();
            txtSurplus.Text = ((eventManager.CalculateTotalCost() - eventManager.CalculateTotalFee()).ToString());


        }
        public int IsListBoxSelected()
        {
            if (lstResults.SelectedIndex >= 0)
            {
                return lstResults.SelectedIndex;
            }
            else
            {
                return -1;
            }
        }

        private void lstResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = IsListBoxSelected();
            

            if (selectedIndex >= 0)
            {
                Participant participant = eventManager.ParticipantManager.GetParticipantAtIndex(selectedIndex);
                txtFirstName.Text = participant.FirstName;
                txtLastName.Text = participant.LastName;
                txtCity.Text = participant.Address.City;
                txtStreet.Text = participant.Address.Street;
                txtZipCode.Text = participant.Address.ZipCode;
                cmbCountries.SelectedIndex = (int)participant.Address.Country;
            }
            

        }


    }
}
//Participant participant2 = new Participant();
//participant2.FirstName = txtFirstName.Text;
//participant2.LastName = txtLastName.Text;

//Address address = new Address();
//address.Street = txtStreet.Text;
//address.City = txtCity.Text;
//address.ZipCode = txtZipCode.Text;
//address.Country = (Countries)cmbCountries.SelectedItem;

//participant2.Address = address;


////participantManager.SelectedIndex = index;

//int index = lstResults.SelectedIndex;
//if (index < 0 || index > participantManager.Count()) 
//    return;

//            participantManager.ChangeParticipantAtIndex(participant2 , index);

//UpdateList();
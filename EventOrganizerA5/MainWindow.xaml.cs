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
        private ParticipantManager participantManager = new ParticipantManager();
        private int _selectedIndex = 3;
        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            cmbCountries.ItemsSource = Enum.GetValues(typeof(Countries));
            cmbCountries.SelectedIndex = (int)Countries.Sverige;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lstResults.Items.Clear();
            Participant participant = new Participant();
            participant.FirstName = txtFirstName.Text;
            participant.LastName = txtLastName.Text;

            Address address = new Address();
            address.Street = txtStreet.Text;
            address.City = txtCity.Text;
            address.ZipCode = txtZipCode.Text;
            address.Country = (Countries)cmbCountries.SelectedItem;

            participant.Address = address;

            participantManager.AddParticipant(participant);

            UpdateList();
            


            
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            //lstResults.Items.Clear();

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

            
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            lstResults.Items.Clear();
            int index = lstResults.SelectedIndex;
            participantManager.RemoveParticipantAtIndex(index);
            UpdateList();
        }

        private void lstResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstResults.SelectedIndex;
            _selectedIndex = index;
            lblCity.Content = IsListBoxSelected().ToString();
        }

        public void UpdateList()
        {
            for (int i = 0; i < participantManager.Count(); i++)
            {
                if (participantManager.GetParticipantAtIndex(i) != null)
                    lstResults.Items.Add(participantManager.GetParticipantAtIndex(i).ToString());
            }
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
                MessageBox.Show("Select an item");
            }
        }

        //public void EmptyTextBoxes(GroupBox groupBox)
        //{
        //    foreach(Control ctrl in groupBox.)
        //}

    }
}

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
using System.Windows.Shapes;
using TBQuestGameRH.DataLayer;
using TBQuestGameRH.Models;

namespace TBQuestGameRH.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupWindow.xaml
    /// </summary>
    public partial class PlayerSetupWindow : Window
    {
        Player _player;

        public PlayerSetupWindow(Player player)
        {
            _player = player;

            InitializeComponent();

            SetupWindow();
        }

        private void SetupWindow()
        {
            //
            // generate lists for each enum to use in the combo boxes
            //

            string Name = Player.Name;
            List<string> Status = Enum.GetNames(typeof(Player.Status)).ToList();
            List<string> Level = Enum.GetNames(typeof(Player.Level)).ToList();
            JobTitleComboBox.ItemsSource = ;
            RaceComboBox.ItemsSource = races;

            //
            // hide error message box initially
            //
            ErrorMessageTextBlock.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// event handler for the OK button
        /// </summary>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if (IsValidInput(out errorMessage))
            {
                //
                // get values from combo boxes
                //
                Enum.TryParse(JobTitleComboBox.Text.ToString(), out Player.Status jobTitle);
                Enum.TryParse(RaceComboBox.SelectionBoxItem.ToString(), out Player.RaceType race);

                //
                // set player properties
                //
                _player.CurrentStatus = 0;
                _player.Race = race;

                Visibility = Visibility.Hidden;
            }
            else
            {
                //
                // display error messages
                //
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }
        }

        /// <summary>
        /// validate user input and generate appropriate error messages
        /// </summary>
        /// <param name="errorMessage">user feedback</param>
        /// <returns>is user input valid</returns>
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (NameTextBox.Text == "")
            {
                errorMessage += "Player Name is required.\n";
            }
            else
            {
                _player.Name = NameTextBox.Text;
            }
            if (!int.TryParse(AgeTextBox.Text, out int age))
            {
                errorMessage += "Player Age is required and must be an integer.\n";
            }
            else
            {
                _player.Age = age;
            }

            return errorMessage == "" ? true : false;
        }
    }
}

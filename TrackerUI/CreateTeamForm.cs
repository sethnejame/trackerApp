using TrackerLibrary.Data;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        private List<PersonModel> availableTeamMembers = new();
        private List<PersonModel> selectedTeamMembers = new(); 

        public CreateTeamForm()
        {
            InitializeComponent();

            LoadPeople();

            ConfigureLists();
        }

        private void LoadPeople()
        {
            availableTeamMembers = GlobalConfig.Connection.GetAllPeople();
        }

        private void ConfigureLists()
        {
            selectTeamMemberDropDown.DataSource = null;

            selectTeamMemberDropDown.DataSource = availableTeamMembers;
            selectTeamMemberDropDown.DisplayMember = nameof(PersonModel.FullName);

            teamMembersListBox.DataSource = null;

            teamMembersListBox.DataSource = selectedTeamMembers;
            teamMembersListBox.DisplayMember = nameof(PersonModel.FullName);
        }

        private void createMemberButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var person = new PersonModel()
                {
                    FirstName = firstNameValue.Text,
                    LastName = lastNameValue.Text,
                    EmailAddress = emailValue.Text,
                    Mobile = mobileValue.Text
                };

                GlobalConfig.Connection.CreatePerson(person);

                firstNameValue.Text = "";
                lastNameValue.Text = "";
                emailValue.Text = "";
                mobileValue.Text = "";
            }
            else
            {
                MessageBox.Show("Invalid form data, please complete all fields with valid data.");
            }
        }

        private bool ValidateForm()
        {
            var output = true;

            if (string.IsNullOrWhiteSpace(firstNameValue.Text)) output = false;
            if (string.IsNullOrWhiteSpace(lastNameValue.Text)) output = false;
            if (string.IsNullOrWhiteSpace(emailValue.Text)) output = false;
            if (string.IsNullOrWhiteSpace(mobileValue.Text)) output = false;

            return output;
        }

        private void addMemberButton_Click(object sender, EventArgs e)
        {
            var person = (PersonModel) selectTeamMemberDropDown.SelectedItem;

            selectedTeamMembers.Add(person);
            availableTeamMembers.Remove(person);

            ConfigureLists();
        }

        private void deleteSelectedMemberButton_Click(object sender, EventArgs e)
        {
            var person = (PersonModel) teamMembersListBox.SelectedItem;

            selectedTeamMembers.Remove(person);
            availableTeamMembers.Add(person);

            ConfigureLists();
        }
    }
}

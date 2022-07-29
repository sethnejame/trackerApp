using TrackerLibrary.Data;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreateTeamForm : Form
    {
        public CreateTeamForm()
        {
            InitializeComponent();
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
    }
}

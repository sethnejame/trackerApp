using TrackerLibrary;
using TrackerLibrary.Data;

namespace TrackerUI;

public partial class CreatePrizeForm : Form
{
    public CreatePrizeForm()
    {
        InitializeComponent();
    }

    private void createPrizeButton_Click(object sender, EventArgs e)
        {
        if (ValidateForm())
        {
            var model = new PrizeModel(
                placeNumberValue.Text, 
                placeNameValue.Text, 
                prizeAmountValue.Text, 
                prizePercentageValue.Text);

            foreach (var db in GlobalConfig.Connections)
                db.CreatePrize(model);
        }
    }

    private bool ValidateForm()
    {
        var output = true;

        // Validate place number
        var placeNumberValid = int.TryParse(placeNumberValue.Text, out int placeNumResult);
        if (!placeNumberValid) output = false;
        if (placeNumberValid && placeNumResult < 1) output = false;

        // Validate place name
        if (string.IsNullOrWhiteSpace(placeNameValue.Text)) output = false;

        // Validate prize amount OR percentage
        var prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out decimal prizeAmtResult);
        var prizePercentageValid = int.TryParse(prizePercentageValue.Text, out int prizePercentageResult);

        if (!prizeAmountValid && !prizePercentageValid) output = false;

        if (prizeAmountValid && prizePercentageValid) output = false;

        if (prizeAmtResult <= 0 && prizePercentageResult <= 0) output = false;

        if (prizePercentageResult > 100) output = false;

        return output;
    }
}

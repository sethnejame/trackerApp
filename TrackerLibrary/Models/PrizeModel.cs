namespace TrackerLibrary.Models;

public class PrizeModel
{
    public PrizeModel()
    {

    }

    public PrizeModel(string placeNumber, string placeName, string prizeAmount, string prizePercentage)
    {
        PlaceName = placeName;

        var placeNumberValid = int.TryParse(placeNumber, out int placeNumberResult);
        PlaceNumber = placeNumberValid ? placeNumberResult : 0;

        var prizeAmountValid = int.TryParse(prizeAmount, out int prizeAmountResult);
        PrizeAmount = prizeAmountValid ? prizeAmountResult : 0;

        var prizePercentageValid = double.TryParse(prizePercentage, out double prizePercentageResult);
        PrizePercentage = prizePercentageValid ? prizePercentageResult : 0;
    }

    public int Id { get; set; }
    public int PlaceNumber { get; set; }
    public string PlaceName { get; set; } = string.Empty;
    public decimal PrizeAmount { get; set; }
    public double PrizePercentage { get; set; }
}

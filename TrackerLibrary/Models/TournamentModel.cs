namespace TrackerLibrary.Models;

public class TournamentModel
{
    public string TournamentName { get; set; }
    public decimal EntryFee { get; set; }
    public List<TeamModel> EnteredTeams { get; set; } = new();
    public List<PrizeModel> Prizes { get; set; } = new();
    public List<List<MatchupModel>> Rounds { get; set; } = new();
}

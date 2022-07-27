namespace TrackerLibrary.Models;

public class TeamModel
{
    public List<PersonModel> TeamMembers { get; set; } = new();
    public string TeamName { get; set; }

}

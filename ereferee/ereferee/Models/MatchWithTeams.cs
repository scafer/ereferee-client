namespace ereferee.Models
{
    public class MatchWithTeams
    {
        public Match match { get; set; }
        public Team homeTeam { get; set; }
        public Team visitorTeam { get; set; }
    }
}
namespace ereferee.Models
{
    public class Match
    {
        public int matchId { get; set; }
        public string timeStart { get; set; }
        public string timeEnd { get; set; }
        public int home_Score { get; set; }
        public string home_Color { get; set; }
        public int visitor_Score { get; set; }
        public string visitor_Color { get; set; }
        public int status { get; set; }
        public string dt_Creation { get; set; }
        public int matchOwnerId { get; set; }
        public int homeTeamId { get; set; }
        public int visitorId { get; set; }
    }
}

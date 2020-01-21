namespace ereferee.Models
{
    public class Event
    {
        public int matchID { get; set; }
        public int userID { get; set; }
        public int memberID { get; set; }
        public int eventType { get; set; }
        public string dateTime { get; set; }
        public string event_Description { get; set; }
        public string reg { get; set; }
    }
}

using System;

namespace ereferee.Models
{
    public class TeamMember
    {
        public int teamId { get; set; }
        public int memberID { get; set; }
        public int status { get; set; }
        public int role { get; set; }
        public int number { get; set; }
        public DateTime dayStart { get; set; }
        public string dayEnd { get; set; }
        public string name { get; set; }
    }
}

﻿using System.Collections.Generic;

namespace ereferee.Models
{
    public class MatchWithTeamsAndMembers
    {
        public Match match { get; set; }
        public Team homeTeam { get; set; }
        public Team visitorTeam { get; set; }
        public List<TeamMember> homeMembers { get; set; }
        public List<TeamMember> visitorMembers { get; set; }
    }
}

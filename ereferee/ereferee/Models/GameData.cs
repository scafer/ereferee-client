﻿using System.Collections.Generic;
using Newtonsoft.Json;

#nullable enable
namespace ereferee.Models
{
    public class GameData
    {
        [JsonProperty("game")]
        public Game? Game { get; set; }

        [JsonProperty("homeTeam")]
        public Team? HomeTeam { get; set; }

        [JsonProperty("visitorTeam")]
        public Team? VisitorTeam { get; set; }

        [JsonProperty("homeAthletes")]
        public List<Athlete>? HomeAthletes { get; set; }

        [JsonProperty("visitorAthletes")]
        public List<Athlete>? VisitorAthletes { get; set; }

        [JsonProperty("events")]
        public List<Event>? Events { get; set; }
    }
}
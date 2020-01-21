using ereferee.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ereferee.Helpers
{
    public static class Global
    {
        public static MatchWithTeamsAndMembersAndEvents match;

        public static int eventType;
        public static int matchID;
        public static int teamId;
        public static int memberId;
        public static string description;
        public static string matchTime;

        public static int homeScore;
        public static int visitorScore;
        public static int idScore;
        public static string matchPart;

        public static Color GetColor(string colorName)
        {
            return NameToColor[colorName];
        }

        public static Color GetColor(object sender)
        {
            var picker = (Picker)sender;

            if (picker.SelectedIndex == -1)
            {
                return Color.Default;
            }
            else
            {
                var colorName = picker.Items[picker.SelectedIndex];
                return NameToColor[colorName];
            }
        }

        public static readonly Dictionary<string, Color> NameToColor = new Dictionary<string, Color>
        {
            { "Aqua", Color.Aqua }, { "Black", Color.Black },
            { "Blue", Color.Blue },
            { "Gray", Color.Gray }, { "Green", Color.Green },
            { "Lime", Color.Lime }, { "Maroon", Color.Maroon },
            { "Navy", Color.Navy }, { "Olive", Color.Olive },
            { "Purple", Color.Purple }, { "Red", Color.Red },
            { "Silver", Color.Silver }, { "Teal", Color.Teal },
            { "White", Color.White }, { "Yellow", Color.Yellow }
        };

        public static int GetMemberRole(string roleName)
        {
            return RoleToName[roleName];
        }

        public static readonly Dictionary<string, int> RoleToName = new Dictionary<string, int>
        {
            {"Player", 1 }, {"Player-Captain", 2}
        };
    }
}

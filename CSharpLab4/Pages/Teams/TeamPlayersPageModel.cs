using CSharpLab4.Data;
using CSharpLab4.Models;
using CSharpLab4.Models.UserViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLab4.Pages.Teams
{
    public class TeamPlayersPageModel: PageModel
    {
        public List<AssignedPlayerData> AssignedPlayerDataList { get; set; }
        public void PopulateAssignedPlayerData(UserContext context, Team team)
        {
            var allPlayers = context.Players;
            var teamPlayers = new HashSet<int>
                (team.Players.Select(p => p.ID));
            AssignedPlayerDataList = new List<AssignedPlayerData>();
            foreach (var player in allPlayers)
            {
                AssignedPlayerDataList.Add(new AssignedPlayerData
                {
                    PlayerID = player.ID,
                    Name = player.FullName,
                    Assigned = teamPlayers.Contains(player.ID)
                });
            }
        }
    }
}

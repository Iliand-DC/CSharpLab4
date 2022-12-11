using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSharpLab4.Data;
using CSharpLab4.Models;
using CSharpLab4.Models.UserViewModels;

namespace CSharpLab4.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly CSharpLab4.Data.UserContext _context;

        public IndexModel(CSharpLab4.Data.UserContext context)
        {
            _context = context;
        }

        public IList<Team> Team { get;set; } = default!;
        public TeamIndexData TeamData { get; set; }
        public int PlayerID { get; set; }
        public int TeamID { get; set; }

        public async Task OnGetAsync(int? teamID, int? playerID)
        {
            TeamData = new TeamIndexData();
            TeamData.Teams = await _context.Teams
                .Include(coaches => coaches.Coach)
                .Include(players => players.Players)
                .OrderBy(teams => teams.Name)
                .ToListAsync();
            if(teamID!=null)
            {
                TeamID=teamID.Value;
                Team team = TeamData.Teams
                    .Where(i => i.ID == teamID.Value).Single();
                TeamData.Players = team.Players;
            }
            if(playerID!=null)
            {
                PlayerID=playerID.Value;
                Player player = TeamData.Players
                    .Where(i=>i.ID == playerID.Value).Single();
                TeamData.Teams = player.Teams;
            }
        }
    }
}

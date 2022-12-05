﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSharpLab4.Models.UserViewModels;
using CSharpLab4.Data;
using CSharpLab4.Models;

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
        public int TeamID { get; set; }
        public int PlayerID { get; set; }
        public TeamIndexData TeamData { get; set; }

        public async Task OnGetAsync(int? playerID, int? teamID)
        {
            TeamData = new TeamIndexData();
            TeamData.Teams = await _context.Teams
                .Include(i => i.Players)
                .OrderBy(i => i.Name)
                .ToListAsync();
            if(teamID!=null)
            {
                TeamID = teamID.Value;
                Team team = TeamData.Teams
                    .Where(i => i.TeamID == teamID.Value).Single();
                TeamData.Players = team.Players;
            }
            if(playerID!=null)
            {
                PlayerID = playerID.Value;
                Player player = TeamData.Players
                    .Where(i => i.ID== playerID.Value).Single();
                TeamData.Teams = player.Teams;
            }
        }
    }
}

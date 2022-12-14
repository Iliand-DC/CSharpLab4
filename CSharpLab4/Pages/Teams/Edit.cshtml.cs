using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSharpLab4.Data;
using CSharpLab4.Models;
using Microsoft.Identity.Client;

namespace CSharpLab4.Pages.Teams
{
    public class EditModel : TeamPlayersPageModel
    {
        private readonly CSharpLab4.Data.UserContext _context;

        public EditModel(CSharpLab4.Data.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Team Team { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team =  await _context.Teams
                .Include(c=>c.Coach)
                .Include(p=>p.Players)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Team == null)
            {
                return NotFound();
            }
            //PopulateCoachesDropDownList(_context, Team.CoachID);
            PopulateAssignedPlayerData(_context, Team);
            //ViewData["CoachID"] = new SelectList(_context.Coachs, "CoachID", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedPlayers)
        {
            if(id==null)
            {
                return NotFound();
            }

            var teamToUpdate = await _context.Teams
                .Include(c=>c.Coach)
                .Include(p=>p.Players)
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if(teamToUpdate == null)
            {
                return NotFound();
            }
            if(await TryUpdateModelAsync<Team>(
                teamToUpdate,
                "Team",
                p=>p.Name, p=>p.Coach, p=>p.CoachID))
            {
                UpdateTeamPlayers(selectedPlayers, teamToUpdate);
                //_context.Attach(Team).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateTeamPlayers(selectedPlayers,teamToUpdate);
            //_context.Attach(Team).State = EntityState.Modified;
            //PopulateCoachesDropDownList(_context, teamToUpdate.CoachID);
            PopulateAssignedPlayerData(_context, teamToUpdate);
            return Page();
        }
        public void UpdateTeamPlayers(string[] selectedPlayers, Team teamToUpdate)
        {
            if(selectedPlayers==null)
            {
                teamToUpdate.Players = new List<Player>();
                return;
            }
            var selectedPlayersHS = new HashSet<string>(selectedPlayers);
            var teamPlayers = new HashSet<int>
                (teamToUpdate.Players.Select(p => p.ID));
            foreach(var player in _context.Players) 
            {
                if(selectedPlayersHS.Contains(player.ID.ToString()))
                {
                    if(!teamPlayers.Contains(player.ID))
                    {
                        teamToUpdate.Players.Add(player);
                    }
                }
                else
                {
                    if(teamPlayers.Contains(player.ID))
                    {
                        var playerToRemove = teamToUpdate.Players.Single(
                            p => p.ID == player.ID);
                        teamToUpdate.Players.Remove(playerToRemove);
                    }
                }
            }
        }

        private bool TeamExists(int id)
        {
          return _context.Teams.Any(e => e.ID == id);
        }
    }
}

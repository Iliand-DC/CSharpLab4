using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CSharpLab4.Data;
using CSharpLab4.Models;
using Microsoft.EntityFrameworkCore;

namespace CSharpLab4.Pages.Teams
{
    public class CreateModel : TeamPlayersPageModel
    {
        private readonly CSharpLab4.Data.UserContext _context;
        private readonly ILogger<TeamPlayersPageModel> _logger;

        public CreateModel(CSharpLab4.Data.UserContext context, ILogger<TeamPlayersPageModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            ViewData["CoachID"] = new SelectList(_context.Coachs, "CoachID", "FirstName");
            var team = new Team();
            team.Players = new List<Player>();
            PopulateAssignedPlayerData(_context,team);
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedPlayers) 
        {
            var newTeam = new Team();
            
            if(selectedPlayers.Length > 0)
            {
                newTeam.Players = new List<Player>();
                _context.Players.Load();
            }
            foreach(var player in selectedPlayers)
            {
                var foundPlayer = await _context.Players.FindAsync(int.Parse(player));
                if(foundPlayer != null)
                {
                    newTeam.Players.Add(foundPlayer);
                }
                else
                {
                    _logger.LogWarning("Player {player} not found", player);
                }
            }
            try
            {
                if (await TryUpdateModelAsync<Team>(
                    newTeam,
                    "Team",
                    p => p.Coach, p => p.CoachID, p => p.Name)) ;
                {
                    _context.Teams.Add(newTeam);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                return RedirectToPage("./Index");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            PopulateAssignedPlayerData(_context,newTeam);
            return Page();
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //_context.Teams.Add(Team);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }
    }
}

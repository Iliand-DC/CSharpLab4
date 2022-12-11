using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSharpLab4.Data;
using CSharpLab4.Models;

namespace CSharpLab4.Pages.Teams
{
    public class DeleteModel : PageModel
    {
        private readonly CSharpLab4.Data.UserContext _context;

        public DeleteModel(CSharpLab4.Data.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }

            var team = await _context.Teams.FirstOrDefaultAsync(m => m.ID == id);

            if (team == null)
            {
                return NotFound();
            }
            else 
            {
                Team = team;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Teams == null)
            {
                return NotFound();
            }
            var team = await _context.Teams
                .Include(p => p.Players)
                .SingleAsync(p => p.ID == id);

            if (team == null)
            {
                return RedirectToPage("./Index");
            }
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}

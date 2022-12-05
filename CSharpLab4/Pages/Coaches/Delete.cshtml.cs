using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSharpLab4.Data;
using CSharpLab4.Models;

namespace CSharpLab4.Pages.Coaches
{
    public class DeleteModel : PageModel
    {
        private readonly CSharpLab4.Data.UserContext _context;

        public DeleteModel(CSharpLab4.Data.UserContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Coach Coach { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coachs == null)
            {
                return NotFound();
            }

            var coach = await _context.Coachs.FirstOrDefaultAsync(m => m.CoachID == id);

            if (coach == null)
            {
                return NotFound();
            }
            else 
            {
                Coach = coach;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Coachs == null)
            {
                return NotFound();
            }
            var coach = await _context.Coachs.FindAsync(id);

            if (coach != null)
            {
                Coach = coach;
                _context.Coachs.Remove(Coach);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

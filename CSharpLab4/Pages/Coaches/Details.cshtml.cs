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
    public class DetailsModel : PageModel
    {
        private readonly CSharpLab4.Data.UserContext _context;

        public DetailsModel(CSharpLab4.Data.UserContext context)
        {
            _context = context;
        }

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CSharpLab4.Data;
using CSharpLab4.Models;

namespace CSharpLab4.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly CSharpLab4.Data.UserContext _context;

        public IndexModel(CSharpLab4.Data.UserContext context)
        {
            _context = context;
        }

        public IList<Player> Player { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Players != null)
            {
                Player = await _context.Players.ToListAsync();
            }
        }
    }
}

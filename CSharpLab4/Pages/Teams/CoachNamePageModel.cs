using CSharpLab4.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CSharpLab4.Pages.Teams
{
    public class CoachNamePageModel : PageModel
    {
        public SelectList CoachNameSL { get; set; }
        public void PopulateCoachesDropDown(UserContext _context, object selectedCoach = null)
        {
            var coachQuery = from d in _context.Coachs
                             orderby d.LastName
                             select d;
            CoachNameSL = new SelectList(coachQuery.AsNoTracking(),"CoachID", "LastName", selectedCoach);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpLab4.Models.UserViewModels
{
    public class PlayerIndexData
    {
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}

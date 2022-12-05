using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CSharpLab4.Models
{
    public class Player
    {
        public int ID { get; set; }
        [Required]
        [Display(Name= "FirstName")]
        [StringLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        [Display(Name = "LastName")]
        [StringLength(50)]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
        public string Position { get; set; }
        public int Age { get; set; }
        public int TeamID { get; set; }
        public Team Team { get; set; }
        public ICollection<Team> Teams { get; set; }
        public Player()
        {
            Teams = new List<Team>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpLab4.Models
{
    public class Coach
    {
        public int CoachID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50,ErrorMessage = "First name cannot be longer than 50 symbols.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }
        public ICollection<Team> Teams { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RobotWars.Models
{
    public class RobotWars
    {
        [StringLength(5, ErrorMessage = "There is an issue with the Initial Position entry", MinimumLength = 5)]
        [Display(Name = "Initial Position")]
        [Required]
        public string InitialPosition { get; set; }

        [Display(Name = "Movement Instructions")]
        [Required, StringLength(100)]
        public string MovementInstructions { get; set; }
        public string FinalPosition{ get; set; }
        public int PenaltyCount { get; set; }

    }
}

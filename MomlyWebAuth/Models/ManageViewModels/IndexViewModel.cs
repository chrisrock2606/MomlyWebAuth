using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MomlyWebAuth.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Brugernavn")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Vægt")]
        public double Weight { get; set; }
        [Display(Name = "Højde")]
        public int Height { get; set; }
        [Display(Name = "Termin")]
        public DateTime DueDate { get; set; }

        public string StatusMessage { get; set; }
    }
}

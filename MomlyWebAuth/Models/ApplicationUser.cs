using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MomlyWebAuth.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int AccountId { get; set; }
        public string Token { get; set; }
        public string PhoneNr { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public DateTime DueDate { get; set; }
    }
}

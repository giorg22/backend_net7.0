using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string? EmailConfirmationCode { get; set; }
        public void ConfirmEmail()
        {
            EmailConfirmed = true;
        }
        public void UpdateEmailConfirmationCode(string emailConfirmationCode)
        {
            EmailConfirmationCode = emailConfirmationCode;
        }
    }
}

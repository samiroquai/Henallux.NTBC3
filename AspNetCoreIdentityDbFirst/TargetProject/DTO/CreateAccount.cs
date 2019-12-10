using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TargetProject.DTO
{
    public class CreateAccount
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string EMail { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Compare("Password")]
        public string PasswordConfirmation { get; set; }
    }
}

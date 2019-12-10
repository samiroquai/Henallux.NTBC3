using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetProject.DTO
{
    public class Account
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public string[] Roles { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DDDDemo.DTO
{
    public class JwtToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
}

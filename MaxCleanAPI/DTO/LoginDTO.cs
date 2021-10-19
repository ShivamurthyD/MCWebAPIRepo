using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxCleanAPI.DTO
{
    public class LoginRequest
    {
        public Int64 Mobile { get; set; }
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public long Mobile { get; set; }
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxCleanAPI.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Int64 Mobile { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Mobilverfied { get; set; }
        public bool Emailverified { get; set; }
        public string Status { get; set; }
        public ROLE Role { get; set; }
        public DateTime createddate { get; set; }
        public DateTime updateddate { get; set; }
    }   

}

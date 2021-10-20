using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxCleanAPI.DTO
{
    public class UserRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string Mobil { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Mobilverfied { get; set; }
        public bool Emailverified { get; set; }
        public string Status { get; set; }
        public DateTime createddate { get; set; }
        public DateTime updateddate { get; set; }
    }

    public class UserResponse
    {
        public static List<UserRequest> register { get; set; }
        public static List<UserRequest>  Add(UserRequest registerRequest)
        {
            register = new List<UserRequest>();
            register.Add(registerRequest);
            return register;
        }
        public static bool EmaiAndMobileVerification(string email,string mobile)
        {
           UserRequest registerRequest= register.SingleOrDefault(x => x.Email == email && x.Mobil == mobile);
            if(registerRequest!=null)
            {
                registerRequest.Emailverified = true;
                registerRequest.Mobilverfied = true;
                registerRequest.Status = "Mobil and Email verified";
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxCleanAPI.DTO
{
    public class RegisterRequest
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Int64 Mobil { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Mobilverfied { get; set; }
        public bool Emailverified { get; set; }
        public string Status { get; set; }
        public DateTime createddate { get; set; }
        public DateTime updateddate { get; set; }
    }

    public class RegisterResponse
    {
        public static List<RegisterRequest> register { get; set; }
        public static List<RegisterRequest>  Add(RegisterRequest registerRequest)
        {
            register = new List<RegisterRequest>();
            register.Add(registerRequest);
            return register;
        }
        public static bool EmaiAndMobileVerification(string email,Int64 mobile)
        {
           RegisterRequest registerRequest= register.SingleOrDefault(x => x.Email == email && x.Mobil == mobile);
            if(registerRequest!=null)
            {
                registerRequest.Emailverified = true;
                registerRequest.Mobilverfied = true;
                registerRequest.Status = "Mobil and Email erified";
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

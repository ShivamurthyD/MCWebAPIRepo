using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxCleanAPI.DTO
{
    public class RegisterRequest
    {

       public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string fullname { get; set; }
        public Int64 mobilenum { get; set; }
        public string email { get; set; }
        public DateTime Datecreated { get; set; }
        public DateTime dateupdated { get; set; }
        public bool emailverified { get; set; } 
        public string status { get; set; }
        public bool Mobileverified { get; set; } 

        
        
    }
    public class RegisterResponse
    {
        public static List<RegisterRequest> registerRequests { get; set; }
        public static List<RegisterRequest> AddInfo(RegisterRequest registerRequest)
        {
            registerRequests = new List<RegisterRequest>();
            registerRequests.Add(registerRequest);
            return registerRequests;
        }
        public static bool Emailverified(string email, Int64 mobile)
        {
            RegisterRequest registerRequest = registerRequests.SingleOrDefault(x => x.email == email && x.mobilenum==mobile);
            if(registerRequest!=null)
            {
                registerRequest.Mobileverified = true;
                registerRequest.emailverified = true;
                registerRequest.status = "Activated";
                return true;
            }
            else
            {
                return false;
            }
        }

    }




}

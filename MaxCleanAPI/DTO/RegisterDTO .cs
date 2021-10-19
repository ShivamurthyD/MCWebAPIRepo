using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaxCleanAPI.DTOO
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
        public static registerRequests AddInfo(RegisterRequest registerRequest)
        {
            List<RegisterRequest> registerRequest1 = new List<RegisterRequest>();
            registerRequest1.Add(registerRequest);
        }
        public static bool Emailverified(string email, string mobile)
        {
            RegisterRequest registerRequest = registerRequests.SingleOrDefault(x => x.email == email && x.mobilenum==mobile);
            if(registerRequest!=null)
            {
                registerRequest.Mobileverified = true;
                registerRequest.email = true;
                registerRequest.status = "Activated";
            }
        }

    }




}

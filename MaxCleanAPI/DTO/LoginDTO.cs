using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaxCleanAPI.DTO
{
    public class LoginRequest
    {
        [MinLength(10), MaxLength(10)]
        [Required(ErrorMessage = "Mobile is required.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only Numbers allowed.")]
        public string Mobile { get; set; }

        [MinLength(4), MaxLength(10)]
        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string Password { get; set; }
    }

    public class LoginResponse
    {
        public string Mobile { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}

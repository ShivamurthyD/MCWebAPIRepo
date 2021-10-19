using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaxCleanAPI.DTO;
namespace MaxCleanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpGet]
        public IActionResult CustRegister()
        {
            if (RegisterResponse.register == null)
            {
                return NotFound(StatusCodes.Status404NotFound);
            }
            else
            {
                return Ok(RegisterResponse.register);
            }
        }
        [HttpPost]
        public IActionResult Addcustomer([FromBody]RegisterRequest model)
        {
            model.createddate = DateTime.Now;
            model.updateddate = DateTime.Now;
            RegisterResponse.Add(model);
            return Created("Added successfully", model);
        }
        [Route("verification")]
        [HttpGet]
        
        public IActionResult EmailMobileVerification([FromBody]RegisterRequest model)
        {
            RegisterResponse.EmaiAndMobileVerification(model.Email, model.Mobil);
            return Ok(RegisterResponse.register);
        }
    }
}

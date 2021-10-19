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
            if (RegisterResponse.registerRequests == null)
            {
                return NotFound(StatusCodes.Status404NotFound);
            }
            else
            {
                return Ok(RegisterResponse.registerRequests);
            }
        }
        [HttpPost]
        public IActionResult Addcustomer([FromBody] RegisterRequest model)
        {
            model.Datecreated = DateTime.Now;
            model.dateupdated = DateTime.Now;
            RegisterResponse.AddInfo(model);
            return Created("Added successfully", model);
        }
        [Route("verification")]
        [HttpGet]

        public IActionResult EmailMobileVerification([FromBody] RegisterRequest model)
        {
            RegisterResponse.Emailverified(model.email, model.mobilenum);
            return Ok(RegisterResponse.registerRequests);
        }
    }
}
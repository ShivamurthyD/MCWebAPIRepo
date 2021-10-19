using MaxCleanAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaxCleanAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet("Login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            LoginResponse obj = new LoginResponse();
            obj.Mobile = loginRequest.Mobile;
            
            return Ok(obj);
        }

        [HttpGet("SignUp")]

        public IActionResult SignUp(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            registerRequest.createddate = DateTime.Now;
            registerRequest.updateddate = DateTime.Now;
            RegisterResponse.Add(registerRequest);
            return Created("Added successfully", RegisterResponse.register);
        }

        [HttpGet("Verification")]
        public IActionResult EmailMobileVerification(RegisterRequest model)
        {
            RegisterResponse.EmaiAndMobileVerification(model.Email, model.Mobil);
            return Ok(RegisterResponse.register);
        }

        #region OLD Code No Use       
        //// GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion
    }
}

using MaxCleanAPI.DTO;
using MaxCleanAPI.Helpers;
using MaxCleanAPI.Service;
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

        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
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

        [HttpPost]

        public IActionResult SignUp(UserRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest(StatusCodes.Status400BadRequest);
            }
            registerRequest.createddate = DateTime.Now;
            registerRequest.updateddate = DateTime.Now;
            UserResponse.Add(registerRequest);
            userService.CreateUser(registerRequest);

            return Created("Added successfully", UserResponse.register);
        }

        [HttpGet("Verification")]
        public IActionResult EmailMobileVerification(string email,string mobile)
        {
            userService.EmailMobilVerification(email, mobile);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteUser(string mobile)
        {
            userService.DeleteUser(mobile);
            return Ok();
        }
        [HttpGet("GetUserByid")]
        public IActionResult GetUserByid(string mobile)
        {
           var items= userService.GetUser(mobile);
            return Created("", items);
            
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

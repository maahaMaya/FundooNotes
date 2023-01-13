using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FundooNoteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBl iUserBl;
        public UserController(IUserBl iUserBl)
        {
            this.iUserBl = iUserBl;
        }

        [HttpPost]

        [Route("UserRegistration")]
        public IActionResult Register(UserRegistration userRegistration)
        {
            try
            {
                var result = iUserBl.RegisterUser(userRegistration);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Registration Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Registration Unsuccessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        [HttpPost]

        [Route("UserLogin")]
        public IActionResult Login(UserLogin userLogin)
        {
            try
            {
                var result = iUserBl.Login(userLogin);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Login Successfull", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "Login Unsuccessfull" });
                }

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                var result = iUserBl.ForgotPassword(email);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Mail Sent Successsfully", data = result });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "Mail Sent Unsuccessfully" });
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Authorize]
        [HttpPut]

        [Route("ResetPassword")]
        public IActionResult PasswordReset(string new_password, string confirm_password)
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email).Value.ToString();
                var result = iUserBl.ResetPassword(email, new_password, confirm_password);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Password Reset Successfull" });
                }
                else
                {
                    return this.NotFound(new { success = false, message = "Password Reset Failed" });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

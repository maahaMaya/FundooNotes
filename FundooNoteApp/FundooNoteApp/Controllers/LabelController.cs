using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace FundooNoteApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        ILabelBl iLabelBl;
        public LabelController(ILabelBl iLabelBl)
        {
              this.iLabelBl = iLabelBl;
        }

        [HttpPost]
        [Route("CreateNewLabel")]
        public IActionResult CreateNewLabel(NewLabel newLabel)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iLabelBl.CreateNewLabel(newLabel, UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Label is created Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Label is not created" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("DelteLabel")]
        public IActionResult DeleteLabel(DeleteLabel deleteLabel)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iLabelBl.DeleteLabel(deleteLabel, UserId);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Label is deleted Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Label is not deleted" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("Retrieve")]
        public IActionResult RetrieveLabel()
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iLabelBl.RetrieveLabel(UserId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Retrieving label successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "Retrieving unsuccessful" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("UpdateLabel")]
        public IActionResult UpdateLabel(UpdateLabel updateLabel)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iLabelBl.UpdateLabel(updateLabel, UserId);
                if (result == true)
                {
                    return Ok(new { success = true, message = "update is successful", data = result });
                }
                else
                {
                    return BadRequest(new { success = false, message = "update is unsuccessful" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

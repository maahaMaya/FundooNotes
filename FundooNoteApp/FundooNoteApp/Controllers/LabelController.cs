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
    }
}

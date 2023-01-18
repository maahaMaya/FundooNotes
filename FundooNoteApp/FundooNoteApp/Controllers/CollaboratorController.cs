using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace FundooNoteApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorController : ControllerBase
    {
        ICollaboratorBl iCollaboratorBl;
        public CollaboratorController(ICollaboratorBl iCollaboratorBl)
        {
            this.iCollaboratorBl = iCollaboratorBl;
        }

        [HttpPost]
        [Route("AddNewCollaborator")]
        public IActionResult AddCollaborator(AddCollaborator addCollaborator)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iCollaboratorBl.AddCollaborator(addCollaborator, UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Collaborator is Successfull", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Collaborator is Unsuccessfull" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("RetrieveAllCollab")]
        public IActionResult RetrieveAllCollab([FromQuery] PinTrashArchieveCollab NoteTableId)
        {
            try
            {
                var UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iCollaboratorBl.RetrieveAllCollaborate(NoteTableId, UserId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Retrieving all notes successful", data = result });
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
    }
}

using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FundooNoteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        INoteBl iNoteBl;
        public NoteController(INoteBl iNoteBl)
        {
            this.iNoteBl = iNoteBl;
        }

        [Authorize]
        [HttpPost]
        [Route("CreateNewNote")]
        public IActionResult CreateNewNote(NewNote newNote)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iNoteBl.CreateNewNote(newNote, UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "Note is created Successfully", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Note is created Unsuccessfully" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [Authorize]
        [HttpGet]
        [Route("Retrieve")]
        public IActionResult retrieveNotes([FromQuery] RetriveNote retriveNote)
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBl.RetrieveNotes(retriveNote, userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Retrieving notes successful", data = result });
                }
                else
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Retrieving unsuccessful"
                    });
                }
            }
            catch (System.Exception) { throw; }
        }

        [Authorize]
        [HttpGet]
        [Route("RetrieveAll")]
        public IActionResult RetrieveAllNotes()
        {
            try
            {
                var userId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);

                var result = iNoteBl.RetrieveAllNotes(userId);
                if (result != null)
                {
                    return Ok(new { success = true, message = "Retrieving notes successful", data = result });
                }
                else
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Retrieving unsuccessful"
                    });
                }
            }
            catch (System.Exception) { throw; }
        }

        [HttpPut]
        [Route("MoveToTrash")]
        public IActionResult MoveToTrash(TrashNote trashNote)
        {
            try
            {
                long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
                var result = iNoteBl.MoveToTrash(trashNote, UserId);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Move to trash", data = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Not move to trash" });
                }
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

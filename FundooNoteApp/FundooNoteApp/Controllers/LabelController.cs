using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using RepositoryLayer.Context;
using Newtonsoft.Json;
using RepositoryLayer.Entity;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FundooNoteApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        ILabelBl iLabelBl;
        private readonly IMemoryCache memoryCache;
        private readonly FundooContext fundooContext;
        private readonly IDistributedCache distributedCache;
        public LabelController(ILabelBl iLabelBl, IMemoryCache memoryCache, FundooContext fundooContext, IDistributedCache distributedCache)
        {
            this.iLabelBl = iLabelBl;
            this.memoryCache = memoryCache;
            this.fundooContext = fundooContext;
            this.distributedCache = distributedCache;
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

        [HttpGet]
        [Route("redis")]
        public async Task<IActionResult> GetAllLabelUsingRedisCache()
        {
            long UserId = Convert.ToInt32(User.Claims.FirstOrDefault(e => e.Type == "UserId").Value);
            var cacheKey = "labelList";
            string serializedLabelList;
            var labelList = new List<LabelEntity>();
            var redislabelList = await distributedCache.GetAsync(cacheKey);
            if (redislabelList != null)
            {
                serializedLabelList = Encoding.UTF8.GetString(redislabelList);
                labelList = JsonConvert.DeserializeObject<List<LabelEntity>>(serializedLabelList);
            }
            else
            {
                labelList = fundooContext.LabelDetails.ToList();
                serializedLabelList = JsonConvert.SerializeObject(labelList);
                redislabelList = Encoding.UTF8.GetBytes(serializedLabelList);
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(2));
                await distributedCache.SetAsync(cacheKey, redislabelList, options);
            }
            return Ok(labelList);
        }
    }
}

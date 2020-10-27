using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDS.Core.AplicationService;
using SDS.Core.Entity;
using SDS.Infrastructure.data;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class sdsconController : ControllerBase
    {
        private readonly IAvatarService _avatarService;

        public sdsconController(IAvatarService avatarService)
        {

            _avatarService = avatarService;
        }


        // GET: api/sdscon
        //[Authorize(Roles = "Administrator")]
        [HttpGet]
        public IEnumerable<Avatar> Get()
        {
          
            return _avatarService.GetAvatars(); 
            
        }


        // [HttpGet("{id}", Name = "Get")]
        //[Authorize]
        [HttpGet("{id}")]
        public ActionResult<Avatar> Get(int id)
        {
            return _avatarService.FindAvatarById(id); 
        }

        // POST: api/sdscon
        //[ProduceResponseType](typeof

        //[Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(Avatar), 201)]
        [ProducesResponseType(typeof(Avatar), 400)]
        public ActionResult<Avatar> Post([FromBody] Avatar avatar)
        {
           return Ok(_avatarService.Create(avatar));
        }

        // PUT: api/sdscon/5
       // [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Avatar> Put(int id, [FromBody] Avatar avatar)
        {
            return _avatarService.UpdateAvatar(avatar);
        }
        /// <summary>
        /// Deletes a specific item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        //[Authorize]
        [HttpDelete("{id}")]
        public ActionResult<Avatar> Delete(int id)
        {
           return  _avatarService.DeleteAvatar(id);
        }
    }
        
}



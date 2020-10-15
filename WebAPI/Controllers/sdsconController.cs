using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDS.Core.AplicationService;
using SDS.Core.Entity;
using SDS.Infrastructure.data;

namespace WebAPI.Controllers
{
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
        [HttpGet]
        public IEnumerable<Avatar> Get()
        {
          
            return _avatarService.GetAvatars(); // <-- Get this working ERROR:Service/Repos
            
        }

     
       // [HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public ActionResult<Avatar> Get(int id)
        {
            return _avatarService.FindAvatarById(id); 
        }

        // POST: api/sdscon
        //[ProduceResponseType](typeof


        [HttpPost]
        public ActionResult<Avatar> Post([FromBody] Avatar avatar)
        {
           return _avatarService.Create(avatar);
        }

        // PUT: api/sdscon/5
        [HttpPut("{id}")]
        public ActionResult<Avatar> Put(int id, [FromBody] Avatar avatar)
        {
            return _avatarService.UpdateAvatar(avatar);
        }
        //nnfnf
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Avatar> Delete(int id)
        {
           return  _avatarService.DeleteAvatar(id);
        }
    }
        
}



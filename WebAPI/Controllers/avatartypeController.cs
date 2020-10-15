using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SDS.Core.AplicationService;
using SDS.Core.Entity;
using SDS.Infrastructure.data;

namespace WebAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class avatartypeController : ControllerBase
    {
        private readonly IAvatarTypeService _avatarTypeService;

        public avatartypeController(IAvatarTypeService avatarTypeService)
        {

            _avatarTypeService = avatarTypeService;
        }

        // GET: api/avatartype
        [HttpGet]
        public IEnumerable<AvatarType> Get()
        {
            return _avatarTypeService.ReadAllAvatars();
        }

        // GET: api/avatartype/5
        [HttpGet("{id}")]
        public ActionResult<AvatarType> Get(int id)
        {
            return _avatarTypeService.FindAvatarById(id);
        }

        // POST: api/avatartype
        [HttpPost]
        public ActionResult<AvatarType> Post([FromBody] AvatarType avatarType)
        {
            return _avatarTypeService.Create(avatarType);
        }

        // PUT: api/avatartype/5
        [HttpPut("{id}")]
        public ActionResult<AvatarType> Put(int id, [FromBody] AvatarType avatarType)
        {
           return _avatarTypeService.UpdateAvatar(avatarType);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<AvatarType> Delete(int id)
        {
           return _avatarTypeService.DeleteAvatar(id);
        }
    }
}

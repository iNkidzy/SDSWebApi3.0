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
    public class ownerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public ownerController(IOwnerService ownerService)
        {

            _ownerService = ownerService;
        }


        // GET: api/owner
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _ownerService.GetOwners();
        }

        // GET: api/owner/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            return _ownerService.FindOwnerById(id);
        }

        // POST: api/owner
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
           return  _ownerService.Create(owner);
        }

        // PUT: api/owner/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
           return _ownerService.UpdateOwner(owner);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            return _ownerService.DeleteOwner(id);
        }
    }
}

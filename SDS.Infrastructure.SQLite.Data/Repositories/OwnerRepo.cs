using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.SQLite.Data.Repositories
{
    public class OwnerRepo : IOwnerRepository
    {

        private readonly SdsLiteContext _litectx;

        public OwnerRepo(SdsLiteContext litectx)
        {
            _litectx = litectx;

        }


        public Owner Create(Owner owner)
        {
            if (owner.Address != null)
            {
                _litectx.Attach(owner.Address).State = EntityState.Unchanged;
            }
            var customerEntry = _litectx.Add(owner);
            _litectx.SaveChanges();
            return customerEntry.Entity;
        }

        public Owner Delete(int id)
        {
            Owner o = GetOwners().Find(x => x.Id == id);
            GetOwners().Remove(o);
            if (o != null)
            {

                return o;
            }
            return null;
        }

        public Owner GetOwnerById(int Id)
        {
            return _litectx.Owners
               .AsNoTracking()
               .Include(c => c.Address)
               .FirstOrDefault(c => c.Id == Id);
        }
       public IEnumerable<Owner> ReadAllOwners()
        {
            throw new System.NotImplementedException();
        }

        public Owner Update(Owner ownerUpdate)
        {
            throw new System.NotImplementedException();

        }

        public List<Owner> GetOwners()
        {

            throw new System.NotImplementedException();
        }
    }
   
}

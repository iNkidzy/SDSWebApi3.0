using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SDS.Core.DomainService;
using SDS.Core.Entity;
using SDS.Infrastructure.SQL.Data;

namespace SDS.Infrastructure.SQLite.Data.Repositories
{
    public class OwnerRepo : IOwnerRepository
    {

        private readonly SQLDBContext _context;

        public OwnerRepo(SQLDBContext context)
        {
            _context = context;

        }


        public Owner Create(Owner owner)
        {
            if (owner.Address != null)
            {
                _context.Attach(owner.Address).State = EntityState.Unchanged;
            }
            var customerEntry = _context.Add(owner);
            _context.SaveChanges();
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
            return _context.Owners
               .AsNoTracking()

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

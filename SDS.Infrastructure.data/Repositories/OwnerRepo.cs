using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data.Repositories
{
    public class OwnerRepo : IOwnerRepository
    {

         readonly SDScontext _ctx;

        private static List<Owner> _ownerLst = new List<Owner>();
        //static int Ownerid = 1;

        public OwnerRepo(SDScontext ctx)
        {
            _ctx = ctx;
        }

        public Owner Create(Owner owner)
        {

            Owner ow = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return ow;

            //owner.Id = DBinitializer.GetNextId();
            //var list = DBinitializer.GetOwners();
            //list.Add(owner);
            //return owner;
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
            //var ownerLst = DBinitializer.GetOwners();
            //var owner = ownerLst.Find(x => x.Id == Id);

            //return owner;

            return _ctx.Owners
                .AsNoTracking()
                .FirstOrDefault(o => o.Id == Id);

        }



        Owner IOwnerRepository.ReadByIdIncludingAvatars(int id)
        {
            return _ctx.Owners.Include(o => o.AvatarsOwned).FirstOrDefault(o => o.Id == id);
        }

       public IEnumerable<Owner> ReadAllOwners()
        {
            // return DBinitializer.ownerLst;
            return _ctx.Owners;
        }

        public Owner Update(Owner ownerUpdate)
        {
            var avatarFromDB = this.GetOwnerById(ownerUpdate.Id);
            if (avatarFromDB != null)
            {
                avatarFromDB.FirstName = ownerUpdate.FirstName;
                avatarFromDB.LastName = ownerUpdate.LastName;
                avatarFromDB.Address = ownerUpdate.Address;
                avatarFromDB.PhoneNumber = ownerUpdate.PhoneNumber;
                avatarFromDB.Email = ownerUpdate.Email;


                return avatarFromDB;
            }

            return null;

        }

        public List<Owner> GetOwners()
        {
            return _ctx.Owners.Include(o =>o.AvatarsOwned).ToList();
            
            //return _ownerLst;
        }
    }
   
}

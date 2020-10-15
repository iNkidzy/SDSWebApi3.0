using System;
using System.Collections.Generic;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data.Repositories
{
    public class OwnerRepo : IOwnerRepository
    {
        
        //private static List<Owner> _ownerLst = new List<Owner>();
        //static int id = 1;

        public Owner Create(Owner owner)
        {
            //owner.OwnerId = id++;
            //_ownerLst.Add(owner);
            //return owner;

            owner.Id = DBinitializer.GetNextId();
            var list = DBinitializer.GetOwners();
            list.Add(owner);
            return owner;
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
            var ownerLst = DBinitializer.GetOwners();
            var owner = ownerLst.Find(x => x.Id == Id);

            return owner;
        }
       public IEnumerable<Owner> ReadAllOwners()
        {
            return DBinitializer.ownerLst;
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

            var ownerLst = DBinitializer.GetOwners();
            return ownerLst;
        }
    }
   
}

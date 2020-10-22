using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Core.AplicationService.Services
{
    public class OwnerService:IOwnerService
    {
        private readonly IOwnerRepository _ownerRepo;
       

        public static IEnumerable<Owner> ownerLst;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
            
        }

        public Owner Create(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepo.Delete(id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.GetOwnerById(id);
        }

        public Owner ReadByIdIncludingAvatars(int id)
        {
            var owner = _ownerRepo.ReadByIdIncludingAvatars(id);
            return owner;
        }

        public List<Owner> GetOwners()
        {
            return _ownerRepo.ReadAllOwners().ToList();
        }

        public Owner NewOwner(string firstname, string lastname, string adress,string phoneNumber, string email)
        {
            var owner = new Owner()
            {
                FirstName = firstname,
                LastName = lastname,
                Address = adress,
                PhoneNumber = phoneNumber,
                Email = email,
         

            };
            return owner;
        }

        public List<Owner> ReadAllOwners()
        {
            return _ownerRepo.ReadAllOwners().ToList();
        }

        public Owner Update(Owner owner)
        {
            if (owner.FirstName.Length < 1)
            {
                throw new InvalidDataException("Name must be atleast 1 charecter");
            }
            return _ownerRepo.Update(owner);
        }

        public Owner UpdateOwner(Owner ownerUpdate)
        {
            var DBowner = FindOwnerById(ownerUpdate.Id);
            if (DBowner != null)
            {

                DBowner.FirstName = ownerUpdate.FirstName;
                DBowner.LastName = ownerUpdate.LastName;
                DBowner.Address = ownerUpdate.Address;
                DBowner.PhoneNumber = ownerUpdate.PhoneNumber;
                DBowner.Email = ownerUpdate.Email;


            }

            return DBowner;
        }
    }
}

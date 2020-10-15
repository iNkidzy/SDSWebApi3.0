using System;
using System.Collections.Generic;
using SDS.Core.Entity;

namespace SDS.Core.DomainService
{
    public interface IOwnerRepository
    {


        Owner Create(Owner owner);

        //ReadCustomer

        Owner GetOwnerById(int Id);
        IEnumerable<Owner> ReadAllOwners(); //Owners

        //Update
        Owner Update(Owner ownerUpdate);///owner/avatar

        //Delete
        Owner Delete(int Id);
    }
}



using System;
using System.Collections.Generic;
using SDS.Core.Entity;

namespace SDS.Core.AplicationService
{
    public interface IOwnerService
    {
        Owner NewOwner(string firstname,
            string lastname, string adress, string phoneNumber, string email);
          


        Owner Create(Owner owner);

        Owner FindOwnerById(int id);
        List<Owner> ReadAllOwners();

        List<Owner> GetOwners(); //Delete


        Owner UpdateOwner(Owner ownerUpdate);


        Owner DeleteOwner(int id);

    }
}

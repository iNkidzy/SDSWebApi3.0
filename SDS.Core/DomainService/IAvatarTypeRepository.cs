using System;
using System.Collections.Generic;
using SDS.Core.Entity;

namespace SDS.Core.DomainService
{
    public interface IAvatarTypeRepository
    {


        AvatarType Create(AvatarType avatarType);

        //ReadCustomer

        AvatarType GetAvatarById(int Id);
        IEnumerable<AvatarType> ReadAllAvatars();

        //Update
        AvatarType Update(AvatarType avatarUpdate);

        //Delete
        AvatarType Delete(int Id);
    }
}

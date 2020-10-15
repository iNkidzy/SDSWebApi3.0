using System;
using System.Collections.Generic;
using SDS.Core.Entity;

namespace SDS.Core.DomainService
{
    public interface IAvatarRepository
    {

        //Create

        Avatar Create(Avatar avatar);

        //ReadCustomer

        Avatar GetAvatarById(int Id); 
        IEnumerable<Avatar> ReadAllAvatars();

        //Update
        Avatar Update(Avatar avatarUpdate);

        //Delete
        Avatar Delete(int Id);


        
        
        
    }
}




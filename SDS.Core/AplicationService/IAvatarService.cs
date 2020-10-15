using System;
using System.Collections.Generic;
using SDS.Core.Entity;

namespace SDS.Core.AplicationService
{
    public interface IAvatarService
    {
        Avatar CreateAvatar(string name,
            string type, DateTime birthdate,
            DateTime soldDate, string color,
            string previousOwner, double price);


        Avatar Create(Avatar avatar);

        Avatar FindAvatarById(int id);
        List<Avatar> ReadAllAvatars(); 

        List<Avatar> GetAvatars(); //Delete

        public List<Avatar> AvatarsByPrice();

        public List<Avatar> CheapestAvatars();


        Avatar UpdateAvatar(Avatar avatarUpdate);


        Avatar DeleteAvatar(int id);

        

       

    }
}

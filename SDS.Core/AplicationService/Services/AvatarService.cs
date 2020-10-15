using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Core.AplicationService.Services
{
    public class AvatarService : IAvatarService
    {
        private readonly IAvatarRepository _avatarRepo;

        public static IEnumerable<Avatar> avatarList; 

        public AvatarService(IAvatarRepository avatarRepo)
        {
            _avatarRepo = avatarRepo;
        }

        public Avatar Create(Avatar avatar)
        {
            if (avatar.Name.Length < 1)
            {
                throw new InvalidDataException("Name must be atleast 1 charecter");
            }
            return _avatarRepo.Create(avatar);
        }

        public Avatar CreateAvatar(string name, string type, DateTime birthdate, DateTime soldDate, string color, string owner, double price)
        {
            var avatar = new Avatar()
            {
                Name = name,
                Type = type,
                Birthdate = birthdate,
                SoldDate = soldDate,
                Color = color,
                Owner = owner,
                Price = price

            };
            return avatar;
        }

        public Avatar FindAvatarById(int id)
        {
            return _avatarRepo.GetAvatarById(id);
        }

        public List<Avatar> GetAvatars()
        {
            return _avatarRepo.ReadAllAvatars().ToList();
        }

       

        public Avatar DeleteAvatar(int id)
        {
           return _avatarRepo.Delete(id);
        }

        public Avatar Update(Avatar avatar)
        {
            if(avatar.Name.Length<1)
            {
                throw new InvalidDataException("Name must be atleast 1 charecter");
            }
            return _avatarRepo.Update(avatar);
  
        }

        public Avatar UpdateAvatar(Avatar avatarUpdate)
        {
            var avatarFromDB = FindAvatarById(avatarUpdate.Id);
            if (avatarFromDB != null)
            {
                avatarFromDB.Name = avatarUpdate.Name;
                avatarFromDB.Type = avatarUpdate.Type;
                avatarFromDB.Birthdate = avatarUpdate.Birthdate;
                avatarFromDB.SoldDate = avatarUpdate.SoldDate;
                avatarFromDB.Color = avatarUpdate.Color;
                avatarFromDB.Owner = avatarUpdate.Owner;
                avatarFromDB.Price = avatarUpdate.Price;


            }
            return avatarFromDB;
        }

        static void ListAvatars()
        {
            foreach(var avatar in avatarList)
            {
                Console.WriteLine($"Id: {avatar.Id}\n Type: {avatar.Type}\n Birthdate: { avatar.Birthdate}\n Sold date: {avatar.SoldDate}\n Color: {avatar.Color}\n Previous Owner: {avatar.Owner}\n Price: {avatar.Price}\n");
            }
        }

        public List<Avatar> ReadAllAvatars()
        {
            return _avatarRepo.ReadAllAvatars().ToList();
        }

        public List<Avatar> AvatarsByPrice() 
        {
            List<Avatar> avatars = ReadAllAvatars();
            List<Avatar> avatartoSort = new List<Avatar>();

            foreach (Avatar av in avatars)
            {
                avatartoSort.Add(av);
            }
            avatartoSort.Sort((avatar1, avatar2)=> avatar1.Price.CompareTo(avatar2.Price));

            return avatartoSort;
        }

        public List<Avatar> CheapestAvatars()
        {
            List<Avatar> avatars = AvatarsByPrice();
            List<Avatar> cheapesAv = new List<Avatar>();

            if (avatars.Count >= 5)
            {

                for (int i = 0; i < 5; i++)
                
                    cheapesAv.Add(avatars[i]);
                    return cheapesAv;
                

            }
            return avatars;
        }
    }
}

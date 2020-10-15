using System;
using System.Collections.Generic;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data
{
    public static class DBinitializer
    {
        public static List<Avatar> avatarLst = new List<Avatar>();
        public static List<AvatarType> avatarTypeLst = new List<AvatarType>();
        public static List<Owner> ownerLst = new List<Owner>();
        
        public static int Id = 1;
        public static int AvatarTypeId = 1;
        public static int OwnerId = 1;
        

        public static void InitData()
        {


            Random r = new Random();
            avatarLst.Add(new Avatar
            {

                Name = "Ban",
                Type = "Greed",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Red",
                Owner = "Nana",
                Price = 2000,
                Id = Id++

            });
            avatarLst.Add(new Avatar
            {

                Name = "Kiki",
                Type = "Sloth",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Green",
                Owner = "Koko",
                Price = 5,
                Id = Id++
            });

            avatarLst.Add(new Avatar
            {

                Name = "Chili",
                Type = "Wrath",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Red",
                Owner = "Meliodas",
                Price = 3,
                Id = Id++
            });
            avatarLst.Add(new Avatar
            {

                Name = "Kirito",
                Type = "Sloth",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Green",
                Owner = "Koko",
                Price = 4,
                Id = Id++

            });
            avatarLst.Add(new Avatar
            {

                Name = "Jerry",
                Type = "Greed",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Red",
                Owner = "Nana",
                Price = 2,
                Id = Id++

            });
            avatarLst.Add(new Avatar
            {

                Name = "Marry",
                Type = "Sloth",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Green",
                Owner = "Koko",
                Price = 1,
                Id = Id++

            });



            avatarTypeLst.Add(new AvatarType
            {
                AvatarTypeName = "Cat",
                Id = AvatarTypeId++

            });

            avatarTypeLst.Add(new AvatarType
            {
                AvatarTypeName = "Dog",
                Id = AvatarTypeId++

            });
            avatarTypeLst.Add(new AvatarType
            {
                AvatarTypeName = "Lion",
                Id = AvatarTypeId++

            });
            avatarTypeLst.Add(new AvatarType
            {
                AvatarTypeName = "Zebra",
                Id = AvatarTypeId++

            });

            ownerLst.Add(new Owner
            {
                FirstName = "Honey",
                LastName = "Bunny",
                Address = "Havnegade",
                PhoneNumber = "42213184",
                Email = "Bunny@gmail.com",
                Id = OwnerId++

            });

            ownerLst.Add(new Owner 
            {
                FirstName = "Ronnie",
                LastName = "Anderson",
                Address = "Kirkegade",
                PhoneNumber = "6748282",
                Email = "RonnieA@gmail.com",
                Id = OwnerId++

            });


            //foreach (Avatar avatar in avartarLists)
            //{
            //    int bdInt = r.Next(1, 100);
            //    avatar.Birthday = DateTime.Now.AddYears(-1 * bdInt);
            //    avatar.Birthday = avatar.Birthday.AddDays(r.Next(0, 365));
            //    avatar.Birthday = avatar.Birthday.AddSeconds(r.Next(0, 60 * 60 * 24));
            //    avatar.SoldDate = DateTime.Now.AddYears(-1 * r.Next(1, bdInt));
            //    avatar.SoldDate = avatar.SoldDate.AddDays(r.Next(0, 365));
            //    avatar.SoldDate = avatar.SoldDate.AddSeconds(r.Next(0, 60 * 60 * 24));
            //}



        }

        public static List<Avatar> GetAvatars()
        {
            return avatarLst;
        }

        public static List<AvatarType>GetAvatarTypes()
        {
            return avatarTypeLst;
        }
        public static List<Owner> GetOwners()
        {
            return ownerLst;
        }

        public static int GetNextId()
        {
           
            return Id++;
           
        }

        public static int GetNextIdType()
        {
            return AvatarTypeId++;

        }

        public static int GetNextIdOwner()
        {
            return OwnerId++;

        }
    }
}

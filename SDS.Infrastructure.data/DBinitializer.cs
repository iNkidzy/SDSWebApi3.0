using System;
using System.Collections.Generic;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data
{
    public class DBinitializer
    {
        private IAvatarRepository _aRepo;
        private IAvatarTypeRepository _aTypeRepo;
        private IOwnerRepository _owRepo;

        public DBinitializer(IAvatarRepository aRepo,IAvatarTypeRepository aTypeRepo, IOwnerRepository owRepo)
        {
            _aRepo = aRepo;
            _aTypeRepo = aTypeRepo;
            _owRepo = owRepo;
        }

        public void InitData(SDScontext ctx)
        {

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            Random r = new Random();
            _aRepo.Create(new Avatar
            {

                Name = "Ban",
                Type = "Greed",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Red",
                PreviousOwner = "Nana",
                Price = 2000,
                

            });
            _aRepo.Create(new Avatar
            {

                Name = "Kiki",
                Type = "Sloth",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Green",
                PreviousOwner = "Koko",
                Price = 5,
                
            });

            _aRepo.Create(new Avatar
            {

                Name = "Chili",
                Type = "Wrath",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Red",
                PreviousOwner = "Meliodas",
                Price = 3,
                
            });
            _aRepo.Create(new Avatar
            {

                Name = "Kirito",
                Type = "Sloth",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Green",
                PreviousOwner = "Koko",
                Price = 4,
                

            });
            _aRepo.Create(new Avatar
            {

                Name = "Jerry",
                Type = "Greed",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Red",
                PreviousOwner = "Nana",
                Price = 2,
               

            });
            _aRepo.Create(new Avatar
            {

                Name = "Marry",
                Type = "Sloth",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Green",
                PreviousOwner = "Koko",
                Price = 1,
              

            });



            var avatarType1= ctx.AvatarTypes.Add(new AvatarType //.avatarTypeLst
            {
                AvatarTypeName = "Cat",
                

            }).Entity;

            _aTypeRepo.Create(new AvatarType
            {
                AvatarTypeName = "Dog",
                

            });
            _aTypeRepo.Create(new AvatarType
            {
                AvatarTypeName = "Lion",
                

            });
            _aTypeRepo.Create(new AvatarType
            {
                AvatarTypeName = "Zebra",
                

            });

            _owRepo.Create(new Owner
            {
                FirstName = "Honey",
                LastName = "Bunny",
                Address = "Havnegade",
                PhoneNumber = "42213184",
                Email = "Bunny@gmail.com",
                

            });

            _owRepo.Create(new Owner 
            {
                FirstName = "Ronnie",
                LastName = "Anderson",
                Address = "Kirkegade",
                PhoneNumber = "6748282",
                Email = "RonnieA@gmail.com",
                

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


            ctx.SaveChanges();

        }

       
    }
}

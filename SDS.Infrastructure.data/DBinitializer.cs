using System;
using System.Collections.Generic;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data
{
    public class DBinitializer:IDBinitializer
    {
        //private IAvatarRepository _aRepo;
        //private IAvatarTypeRepository _aTypeRepo;
        //private IOwnerRepository _owRepo;

        public DBinitializer()
        {
            //_aRepo = repo;
            //_aTypeRepo = atrepo;
            //_owRepo = owrepo;
        }

        public void InitData(SDScontext ctx)
        {

            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();


            Owner owner1 = ctx.Owners.Add(new Owner
            {
                FirstName = "Honey",
                LastName = "Bunny",
                Address = "Havnegade",
                PhoneNumber = "42213184",
                Email = "Bunny@gmail.com",
               



            }).Entity;

            Owner owner2 = ctx.Owners.Add(new Owner
            {
                FirstName = "Ronnie",
                LastName = "Anderson",
                Address = "Kirkegade",
                PhoneNumber = "6748282",
                Email = "RonnieA@gmail.com",
                


            }).Entity;

            Random r = new Random();
            Avatar avatar1 = ctx.Avatars.Add(new Avatar
            {

                Name = "Ban",
                Type = "Greed",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Red",
                PreviousOwner = "Nana",
                Price = 2000,
                Owner = owner1


            }).Entity;
            Avatar avatar2 = ctx.Avatars.Add(new Avatar
            {

                Name = "Kiki",
                Type = "Sloth",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Green",
                PreviousOwner = "Koko",
                Price = 5,
                Owner =owner2
                

            }).Entity;

            Avatar avatar3 = ctx.Avatars.Add(new Avatar
            {

                Name = "Chili",
                Type = "Wrath",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Red",
                PreviousOwner = "Meliodas",
                Price = 3,
                Owner = owner1

            }).Entity;
            Avatar avatar4 = ctx.Avatars.Add(new Avatar
            {

                Name = "Kirito",
                Type = "Sloth",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Green",
                PreviousOwner = "Koko",
                Price = 4,
                Owner = owner2


            }).Entity;
            Avatar avatar5 = ctx.Avatars.Add(new Avatar
            {

                Name = "Jerry",
                Type = "Greed",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Red",
                PreviousOwner = "Nana",
                Price = 2,
                Owner = owner1


            }).Entity;
            Avatar avatar6 = ctx.Avatars.Add(new Avatar
            {

                Name = "Marry",
                Type = "Greed",
                Birthdate = DateTime.Now.AddYears(-15),
                SoldDate = DateTime.Now.AddYears(-5),
                Color = "Green",
                PreviousOwner = "Koko",
                Price = 1,
                Owner = owner2


            }).Entity;


            AvatarType avatarTypet1 = ctx.AvatarTypes.Add(new AvatarType //.avatarTypeLst
            {
                AvatarTypeName = "Cat",


            }).Entity;

            AvatarType avatarType2 = ctx.AvatarTypes.Add(new AvatarType
            {
                AvatarTypeName = "Dog",


            }).Entity;

            AvatarType avatarType3 = ctx.AvatarTypes.Add(new AvatarType
            {
                AvatarTypeName = "Lion",


            }).Entity;
            AvatarType avatarType4 = ctx.AvatarTypes.Add(new AvatarType
            {
                AvatarTypeName = "Zebra",


            }).Entity;




            ctx.SaveChanges();

        }

       
    }
}

using System;
using System.Collections.Generic;
using SDS.Core.AplicationService;
using SDS.Core.DomainService;
using SDS.Core.Entity;
using SDS.Infrastructure.data.Repositories;

namespace SDSUI
{
    public class NewPrinter:IPrinter
    {
       
        private  IAvatarService _aService;


        public NewPrinter(IAvatarService aService)
        {
            
            _aService = aService;


       

            Console.WriteLine("Welcome Seven Deadly Sins maniac! :)");
            Console.WriteLine("Welcome to SDS!\n Choose one of the following options to begin your adventure!");

        }


        public void StartUI()
            {
                string[] menuItems =
                {
                "Create your avatar",
                "Show avatars",
                "Update avatar",
                "Delete avatar",
                "ShowbyPrice",
                "CheapesAvatars",
                "Exit SDS character setup"

            };



                var selection = ShowMenu(menuItems);

            while (selection != 7)
            {
                switch (selection)
                {
                    case 1:
                        CreateAvatar();
                        break;
                    case 2:
                        ShowAllAvatarsList(); 
                        break;
                    case 3: 
                        UpdateAvatar();
                        break;
                    case 4:
                        DeleteAvatar();
                        break;
                    case 5:
                        ShowbyPrice();
                        break;
                    case 6:
                        CheapesAvatars();
                        break;
                    default:
                        break;

                }
                Console.WriteLine("Done!Go back to menu?");
                Console.ReadLine();
                Console.Clear();

                selection = ShowMenu(menuItems);

            }

            Console.WriteLine("See yaa");
            Console.ReadLine();


        }

         int ShowMenu(string[] menuItems) { 
       
            

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{(i + 1)}:{menuItems[i]}");

            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > menuItems.Length)
            {
                Console.WriteLine("You've commited an unforgivable Sin! Only numbers from  1-7 allowed");

            }
            Console.Clear();
            return selection;
        }


         void ListAvatars(List<Avatar> avatars) 
        { 
            foreach (var avatar in avatars)
            {
                Console.WriteLine($"Id: {avatar.Id}\n Name: {avatar.Name}\n Type: {avatar.Type}\n Birth Date: {avatar.Birthdate}\n Sold Date: {avatar.SoldDate}\n Color: {avatar.Color}\n Owner: {avatar.Owner}\n Price: {avatar.Price}\n");
            }

            Console.WriteLine("\n");

        }


        void ShowAllAvatarsList()
        {
            Console.WriteLine("\nList of all Avatars");
            var avatars = _aService.ReadAllAvatars();
            ListAvatars(avatars);
        }


        int PrintGetAvatarById()
        {
            Console.WriteLine("Insert Avatar id:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Only numbers allowed");
            }
            return id;
        }

        

        public void ShowbyPrice()
        {
            Console.WriteLine("Shown avatars by price");
            var avatars = _aService.AvatarsByPrice();
            ListAvatars(avatars);


        }
        public void CheapesAvatars()
        {
            Console.WriteLine("Here are the 5 cheapest avatars");
            var avatars = _aService.CheapestAvatars();
            ListAvatars(avatars);
        }

        void DeleteAvatar()
        {
            var idForDelete = PrintGetAvatarById();
            _aService.DeleteAvatar(idForDelete);
   
        }

        void UpdateAvatar()
        {
            var idForUpdate = PrintGetAvatarById();
            var avatarToUpdate = _aService.FindAvatarById(idForUpdate);
            Console.WriteLine("Name: ");
            avatarToUpdate.Name = Console.ReadLine();
            Console.WriteLine("Type: ");
            avatarToUpdate.Type = Console.ReadLine();
            Console.WriteLine("Birthday: ");
            avatarToUpdate.Birthdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("SoldDate: ");
            avatarToUpdate.SoldDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Owner: ");
            avatarToUpdate.Owner = Console.ReadLine();
            Console.WriteLine("Price: ");
            avatarToUpdate.Price = double.Parse(Console.ReadLine());

            _aService.UpdateAvatar(avatarToUpdate);
             
            
        }


        void CreateAvatar()
        {

           
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();

            Console.WriteLine("Type: ");
            var type = Console.ReadLine();

            Console.WriteLine("Birthdate: ");
            DateTime birthdate;

            while (!DateTime.TryParse(Console.ReadLine(), out birthdate))
            {
                Console.WriteLine("Wrong!Try again");
            }

            Console.WriteLine("SoldDate: ");
            DateTime soldDate;
            while (!DateTime.TryParse(Console.ReadLine(), out soldDate))
            {
                Console.WriteLine("Wrong again,try again");
            }

            Console.WriteLine("Color: ");
            var color = Console.ReadLine();

            Console.WriteLine("Owner: ");
            var owner = Console.ReadLine();

            Console.WriteLine("Price: ");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Wrong yet again,Try again");
            }

            var avatar = _aService.CreateAvatar( name,
             type, birthdate,
             soldDate,  color,
             owner, price);

            _aService.Create(avatar);
        }

        
    }
}

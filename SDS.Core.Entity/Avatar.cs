using System;
namespace SDS.Core.Entity
{
    public class Avatar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Birthdate {get; set;}
        public DateTime SoldDate {get; set;}
        public string Color {get; set;}
        public string Owner {get; set;}
        public double Price { get; set; }
          
        }
    }


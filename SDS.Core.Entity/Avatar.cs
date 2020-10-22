using System;
using System.ComponentModel.DataAnnotations;

namespace SDS.Core.Entity
{
    public class Avatar
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Birthdate {get; set;}
        public DateTime SoldDate {get; set;}
        public string Color {get; set;}
        public string PreviousOwner {get; set;}
        public double Price { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }


    }
    }


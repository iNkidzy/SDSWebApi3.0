﻿using System;
namespace SDS.Core.Entity
{
    public class Owner
    {

        public int Id { get; set; }

        //public string Username { get; set; }
        //public byte[] PasswordHash { get; set; }
        //public byte[] PasswordSalt { get; set; }
        //public bool IsAdmin { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
       

    }
}

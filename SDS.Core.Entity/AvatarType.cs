using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDS.Core.Entity
{
    public class AvatarType
    {

        [Required]
        public int Id { get; set; }
        public string AvatarTypeName { get; set; }
        public Avatar Avatar { get; set; }
        //public List<Avatar> AvatarTypeList { get; set; }
       
       


    }
}

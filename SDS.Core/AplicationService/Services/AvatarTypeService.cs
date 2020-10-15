using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Core.AplicationService.Services
{
    public class AvatarTypeService : IAvatarTypeService
    {

        private readonly IAvatarTypeRepository _avatarTypeRepo;


        // public static IEnumerable<AvatarType> avatarTypeList;

        public AvatarTypeService(IAvatarTypeRepository avatarTypeRepo)
        {
            _avatarTypeRepo = avatarTypeRepo;

        }

        public AvatarType Create(AvatarType avatarType)
        {
            if (avatarType.AvatarTypeName.Length < 1)
            {
                throw new InvalidDataException("Name must be atleast 1 charecter");
            }
            return _avatarTypeRepo.Create(avatarType);
        }

        public AvatarType CreateAvatar(string AvatarTypeName)
        {
            var avatarType = new AvatarType()
            {
                AvatarTypeName = AvatarTypeName

            };
            return avatarType;
        }

        public AvatarType DeleteAvatar(int id)
        {
            return _avatarTypeRepo.Delete(id);
        }

        public AvatarType FindAvatarById(int id)
        {
            return _avatarTypeRepo.GetAvatarById(id);
        }

        public List<AvatarType> GetTypeAvatars()
        {
            return _avatarTypeRepo.ReadAllAvatars().ToList();
        }

        public List<AvatarType> ReadAllAvatars()
        {
            return _avatarTypeRepo.ReadAllAvatars().ToList();
        }


        public AvatarType Update(AvatarType avatarType)
        {
            if (avatarType.AvatarTypeName.Length < 1)
            {
                throw new InvalidDataException("Name must be atleast 1 charecter");
            }
            return _avatarTypeRepo.Update(avatarType);
        }

        public AvatarType UpdateAvatar(AvatarType avatarUpdate) ///FIX
        {
            var DBtype = FindAvatarById(avatarUpdate.Id);
            if (DBtype != null)
            {

                DBtype.AvatarTypeName = avatarUpdate.AvatarTypeName;


            }
 
            return DBtype;

        }  
    }
}

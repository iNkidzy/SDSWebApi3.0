using System;
using System.Collections.Generic;
using SDS.Core.Entity;

namespace SDS.Core.AplicationService
{
    public interface IAvatarTypeService
    {
        AvatarType CreateAvatar(string AvatarTypeName);




        AvatarType Create(AvatarType avatarType);

        AvatarType FindAvatarById(int Id);
        List<AvatarType> ReadAllAvatars();

        List<AvatarType> GetTypeAvatars(); 

        AvatarType UpdateAvatar(AvatarType avatarUpdate);


        AvatarType DeleteAvatar(int id);

    }
}

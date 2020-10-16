using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.SQLite.Data.Repositories
{
    public class AvatarTypeRepo : IAvatarTypeRepository
    {

        private readonly SdsLiteContext _litectx;


        public AvatarTypeRepo(SdsLiteContext litectx)
        {

            _litectx = litectx;
        }




        public AvatarType Create(AvatarType avatarType)
        {
            if (avatarType.AvatarTypeName != null)
            {
                _litectx.Attach(avatarType.AvatarTypeName).State = EntityState.Unchanged;
            }
            var avatarTypeEntry = _litectx.Add(avatarType);
            _litectx.SaveChanges();
            return avatarTypeEntry.Entity;
        }

        public AvatarType Delete(int id)
        {
            

            AvatarType at = GetAvatarTypes().Find(x => x.Id == id);
            GetAvatarTypes().Remove(at);
            if (at != null)
            {

                return at;
            }
            return null;
        }

        private List<AvatarType> GetAvatarTypes()
        {

            throw new System.NotImplementedException();
        }

        public AvatarType GetAvatarById(int Id)
        {
            return _litectx.AvatarTypes
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<AvatarType> ReadAllAvatars()
        {
            return _litectx.AvatarTypes.ToList();
        }

        public AvatarType Update(AvatarType avatarUpdate)
        {

            throw new System.NotImplementedException();
        }
    }     
    
}

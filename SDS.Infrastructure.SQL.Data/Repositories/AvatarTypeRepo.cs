using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SDS.Core.DomainService;
using SDS.Core.Entity;
using SDS.Infrastructure.SQL.Data;

namespace SDS.Infrastructure.SQLite.Data.Repositories
{
    public class AvatarTypeRepo : IAvatarTypeRepository
    {

        private readonly SQLDBContext _context;

        public AvatarTypeRepo(SQLDBContext context)
        {
            _context = context;

        }



        public AvatarType Create(AvatarType avatarType)
        {
            if (avatarType.AvatarTypeName != null)
            {
                _context.Attach(avatarType.AvatarTypeName).State = EntityState.Unchanged;
            }
            var avatarTypeEntry = _context.Add(avatarType);
            _context.SaveChanges();
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
            return _context.AvatarTypes
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == Id);
        }

        public IEnumerable<AvatarType> ReadAllAvatars()
        {
            return _context.AvatarTypes.ToList();
        }

        public AvatarType Update(AvatarType avatarUpdate)
        {

            throw new System.NotImplementedException();
        }
    }     
    
}

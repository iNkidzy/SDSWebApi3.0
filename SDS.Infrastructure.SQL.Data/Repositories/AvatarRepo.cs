using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SDS.Core.DomainService;
using SDS.Core.Entity;
using SDS.Infrastructure.SQL.Data;
using SDS.Infrastructure.SQLite.Data;

namespace SDS.Infrastructure.data.Repositories
{
    public class AvatarRepo:IAvatarRepository
    {
        private readonly SQLDBContext _context;

        public AvatarRepo(SQLDBContext context)
        {
            _context = context;

        }


        public Avatar Create(Avatar avatar)
        {



            var cityEntry = _context.Add(avatar);
            _context.SaveChanges();
            return cityEntry.Entity;
        }

        public IEnumerable<Avatar> ReadAllAvatars()
        {
            return _context.Avatars.ToList();
        }

        public Avatar GetAvatarById(int Id)
        {
            return _context.Avatars
                .AsNoTracking()
                
                .FirstOrDefault(c => c.Id == Id);
        }


        public Avatar Update(Avatar avatarUpdate)
        {
            var updatedEntity = _context.Avatars.Update(avatarUpdate);
            _context.SaveChanges();
            return updatedEntity.Entity;

        }

        public Avatar Delete(int id)
        {

            var avatarDelete = GetAvatarById(id);
            _context.Avatars.Remove(GetAvatarById(id));
            _context.SaveChanges();
            return avatarDelete;
        }

        public List<Avatar> GetAvatars()
        {
            return _context.Avatars.ToList();

        }



    }
}

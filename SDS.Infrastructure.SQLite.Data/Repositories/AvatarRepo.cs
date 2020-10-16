using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SDS.Core.DomainService;
using SDS.Core.Entity;
using SDS.Infrastructure.SQLite.Data;

namespace SDS.Infrastructure.data.Repositories
{
    public class AvatarRepo:IAvatarRepository
    {
        private readonly SdsLiteContext _litectx;


        public AvatarRepo(SdsLiteContext litectx)
        {

            _litectx = litectx;
        }


        public Avatar Create(Avatar avatar)
        {
            var cityEntry = _litectx.Add(avatar);
            _litectx.SaveChanges();
            return cityEntry.Entity;
        }

        public IEnumerable<Avatar> ReadAllAvatars()
        {
            return _litectx.Avatars.ToList();
        }

        public Avatar GetAvatarById(int Id)
        {
            return _litectx.Avatars
                .AsNoTracking()
                .FirstOrDefault(c => c.Price == Id);
        }


        public Avatar Update(Avatar avatarUpdate)
        {
            throw new System.NotImplementedException();

        }

        public Avatar Delete(int id)
        {

            throw new System.NotImplementedException();
        }

        public List<Avatar> GetAvatars()
        {
            return _litectx.Avatars.ToList();

        }



    }
}

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data.Repositories
{
    public class AvatarRepo:IAvatarRepository
    {

        readonly SDScontext _ctx;

        private static List<Avatar> _avatarLst = new List<Avatar>();
        //public static int AvatarId = 1;

        public AvatarRepo(SDScontext ctx)
        {
            _ctx = ctx;
        }

        public Avatar Create(Avatar avatar)
        {
            //avatar.Id = AvatarId++;

            //_avatarLst.Add(avatar);
            //return avatar;
            //if (avatar.Name != null)
            //{
            //    _ctx.Attach(avatar.Name).State = EntityState.Unchanged;
            //}

            Avatar a = _ctx.Avatars.Add(avatar).Entity;
            _ctx.SaveChanges();
            return a;

        }

        public IEnumerable<Avatar> ReadAllAvatars()
        {
             return _avatarLst;
           // return _ctx.Avatars.ToList();
           
           
        }

        public Avatar GetAvatarById(int Id)
        {

            //var avatar = _avatarLst.Find(x => x.Id == Id);

            //return avatar;
            return _ctx.Avatars
                .AsNoTracking()
                .FirstOrDefault(a => a.Id == Id);
        }


        public Avatar Update(Avatar avatarUpdate)
        {
            var avatarFromDB = GetAvatarById(avatarUpdate.Id);
            if (avatarFromDB != null)
            {
                avatarFromDB.Name = avatarUpdate.Name;
                avatarFromDB.Type = avatarUpdate.Type;
                avatarFromDB.Birthdate = avatarUpdate.Birthdate;
                avatarFromDB.SoldDate = avatarUpdate.SoldDate;
                avatarFromDB.Color = avatarUpdate.Color;
                avatarFromDB.PreviousOwner = avatarUpdate.PreviousOwner;
                avatarFromDB.Price = avatarUpdate.Price;


                return avatarFromDB;
            }

            return null;
            
        }

        public Avatar Delete(int id)
        {

            Avatar a = GetAvatars().Find(x => x.Id == id);
            GetAvatars().Remove(a);
            if (a != null)
            {
                
                return a;
            }
            return null;
        }

        public List<Avatar> GetAvatars()
        {

            return _ctx.Avatars.Include(o=>o.Owner).ToList();
            //return _avatarLst.ToList();
        }



    }
}

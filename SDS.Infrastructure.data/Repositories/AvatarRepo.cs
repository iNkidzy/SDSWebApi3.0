using System.Collections.Generic;
using System.IO;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data.Repositories
{
    public class AvatarRepo:IAvatarRepository
    {

       //Those DO NOTHING apperantly...
       // private static List<Avatar> _avatarLst = new List<Avatar>();
       // public static int id = 1;


        public Avatar Create(Avatar avatar)
        {
            avatar.Id = DBinitializer.GetNextId();
            var list = DBinitializer.GetAvatars();
            list.Add(avatar);
            return avatar;
        }

        public IEnumerable<Avatar> ReadAllAvatars()
        {
            // return _avatarLst;
            var avatarLst = DBinitializer.GetAvatars();
            return avatarLst;
        }

        public Avatar GetAvatarById(int Id)
        {
            var avatarLst = DBinitializer.GetAvatars();
            var avatar = avatarLst.Find(x => x.Id == Id);
            
            return avatar;
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
                avatarFromDB.Owner = avatarUpdate.Owner;
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

            var avatarLst = DBinitializer.GetAvatars();
            return avatarLst;
        }



    }
}

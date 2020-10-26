using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SDS.Core.DomainService;
using SDS.Core.Entity;

namespace SDS.Infrastructure.data.Repositories
{
    public class AvatarTypeRepo : IAvatarTypeRepository
    {

        readonly SDScontext _ctx;
        
         private static List<AvatarType> _avatarTypeLst = new List<AvatarType>();
        // public static int AvatarTypeid = 1;


        public AvatarTypeRepo(SDScontext ctx)
        {
            _ctx = ctx;
        }



        public AvatarType Create(AvatarType avatarType)
        {
            //avatarType.Id = AvatarTypeid++;

            //_avatarTypeLst.Add(avatarType);
            //return avatarType;

            AvatarType at = _ctx.AvatarTypes.Add(avatarType).Entity;
            _ctx.SaveChanges();
            return at;
        }

        public AvatarType Delete(int id)
        {
            //var avatarFound = this.GetAvatarById(id);
            //if (avatarFound != null)
            //{

            //    _avatarTypeLst.Remove(avatarFound);
            //    return avatarFound;
            //}
            //return null;

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


             return _avatarTypeLst;
            //return _ctx.AvatarTypes.ToList();
        }

        public AvatarType GetAvatarById(int Id)
        {
            
            //var avatarType = _avatarTypeLst.Find(x => x.Id == Id);

            //return avatarType;

            return _ctx.AvatarTypes
                .AsNoTracking()
                .FirstOrDefault(at => at.Id == Id);
        }

        public IEnumerable<AvatarType> ReadAllAvatars()
        {

            //return _ctx.AvatarTypes.ToList();
            return _avatarTypeLst;
        }

        public AvatarType Update(AvatarType avatarUpdate)
        {
            var avatarFromDB = GetAvatarById(avatarUpdate.Id);
            if (avatarFromDB != null)
            {
                avatarFromDB.AvatarTypeName = avatarUpdate.AvatarTypeName;


                return avatarFromDB;
            }

            return null;

        }
    }     
    
}

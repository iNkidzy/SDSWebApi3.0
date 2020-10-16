using System;
using WebAPI.data;

namespace WebAPI.Data
{
    public interface IDBInitializer
    {
        void Initialize(sdsDBcontext context);
    }
}

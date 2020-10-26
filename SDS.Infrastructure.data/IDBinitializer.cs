using System;
namespace SDS.Infrastructure.data
{
    public interface IDBinitializer
    {
        public void InitData(SDScontext ctx);
    }
}

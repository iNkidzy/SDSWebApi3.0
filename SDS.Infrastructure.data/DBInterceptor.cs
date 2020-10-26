using System;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace SDS.Infrastructure.data
{
    public class DBInterceptor :DbCommandInterceptor
    {
        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            return result;
        }
    }
}

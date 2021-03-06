﻿using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using SqlFu.Providers;

namespace SqlFu
{
    public interface IDbFactory
    {
        IDbProvider Provider { get; }
        DbConnection Create(DbConnection db=null);
        Task<DbConnection> CreateAsync(CancellationToken cancel, DbConnection db = null);
    }
}
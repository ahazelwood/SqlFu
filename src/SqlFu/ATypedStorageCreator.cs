using CavemanTools.Model.Persistence;
using SqlFu.Builders;
using SqlFu.Builders.CreateTable;
using SqlFu.Configuration.Internals;

namespace SqlFu
{
    public abstract class ATypedStorageCreator<T> : ICreateStorage
    {
        protected readonly IDbFactory _db;

        protected ATypedStorageCreator(IDbFactory db)
        {
            _db = db;
        }

        protected abstract void Configure(IConfigureTable<T> cfg);

        public void Create()
        {
            _db.Do(db =>
            {
                db.CreateTableFrom<T>(table =>
                {
                    table.IfTableExists(Just.Ignore);
                    Configure(table);
                });
            });
        }
    }
}
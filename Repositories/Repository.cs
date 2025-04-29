using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        public Repository(SqlConnection connection) => Database.Connection = connection;
        public IEnumerable<T> Get() => Database.Connection.GetAll<T>();

        public T Get(int Id) => Database.Connection.Get<T>(Id);

        public void Create(T model) => Database.Connection.Insert<T>(model);

        public void Update(T model) => Database.Connection.Update<T>(model);

        public void Delete(T model) => Database.Connection.Delete<T>(model);

        public void Delete(int Id)
        {
            var model = Database.Connection.Get<T>(Id);
            Database.Connection.Delete<T>(model);
        }
    }
}
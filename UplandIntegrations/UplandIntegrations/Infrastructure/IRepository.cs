using System.Collections.Generic;

namespace UplandIntegrations.Infrastructure
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(string id);

        IEnumerable<TEntity> Find(Dictionary<string, string> parameters);

        IEnumerable<TEntity> GetAll();
    }
}
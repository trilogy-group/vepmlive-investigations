using System.Collections.Generic;

namespace PortfolioEngineCore.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        int Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        int? FindIdBy(string key, object value);
        IEnumerable<T> FindAll();
        T FindById(int id);
    }
}
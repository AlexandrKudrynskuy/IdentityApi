using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public interface IRepository<T> where T : class
    {
        void CreateAsync(T entity);
        void UpdateAsync(int id,T entity);
        void DeleteAsync(int id);
       Task<IEnumerable<T>> GetFromConditionAsync(Expression<Func <T,bool>> condition);

        void Create(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        IEnumerable<T> GetFromCondition(Expression<Func<T, bool>> condition);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBaseInterfaceDao<T>
    {
        Task<T> Create(T input);
        void Delete(Int64 input);
        void Delete(T input);
        void Update(T input);
        Task<IList<T>> GetAll(Expression<Func<T, bool>>? filter = null, string orderBy = "", string? includeProperties = "");
        Task<IList<T>> GetAll(int pageNumber, int pageSize, Expression<Func<T, bool>>? filter = null, string orderBy = "", string? includeProperties = "");
        Task<int> GetAllCount(Expression<Func<T, bool>>? filter = null);
        Task<T> GetByKey(Int64 input, string? includeProperties = "");
    }
}

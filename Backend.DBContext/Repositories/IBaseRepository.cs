using Backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereClause, bool includeDeactivated = false);

        List<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> whereClause);

        TEntity GetById(object id, bool includeDeactive = true);
        List<TEntity> GetById(IEnumerable<int> id);
        List<TEntity> GetById(IEnumerable<int> id, bool includeDeactive = true);

        bool Exists(int id);
        TEntity GetBy(Expression<Func<TEntity, bool>> whereClause);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereClause);

        int Insert(TEntity entity);
        int Insert(IEnumerable<TEntity> entities);

        int Delete(int id);
        int Delete(IEnumerable<int> ids);
        int Delete(TEntity entity);
        int Delete(IEnumerable<TEntity> entities);
        int Delete();
        int DeleteAll();

        int Update(TEntity entity);
        int Update(IEnumerable<TEntity> entities);

        int InsertOrReplaceAll(IEnumerable<TEntity> entities);

        IList<TEntity> GetAllIncludes(Expression<Func<TEntity, bool>> whereClause, params Expression<Func<TEntity, object>>[] includes);
        IList<TEntity> GetAllWithOrderByDescending(Expression<Func<TEntity, object>> sortColumn, Expression<Func<TEntity, bool>> whereClause = null);
    }
}

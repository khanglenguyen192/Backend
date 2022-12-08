using Backend.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DBContext
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public readonly IDbContextFactory ContextFactory;

        public BaseRepository(IDbContextFactory contextFactory)
        {
            ContextFactory = contextFactory;
        }

        public virtual IList<TEntity> GetAll(Expression<Func<TEntity, bool>> whereClause, bool includeDeactivated = false)
        {
            var query = GetAll(whereClause);

            if (includeDeactivated) return query;

            return query.Where(p => p.IsDeactivate == false).ToList();
        }

        public virtual IList<TEntity> GetAllIncludes(Expression<Func<TEntity, bool>> whereClause, params Expression<Func<TEntity, object>>[] includes)
        {

            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        if (item != null) query = query.Include(item);
                    }
                }

                return query.ToList();
            }
        }

        public virtual IList<TEntity> GetAllWithOrderByDescending(Expression<Func<TEntity, object>> sortColumn, Expression<Func<TEntity, bool>> whereClause = null)
        {

            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                if (sortColumn != null)
                {
                    query = query.OrderByDescending(sortColumn);
                }

                return query.ToList();
            }
        }

        public virtual TEntity LastOrDefault(Expression<Func<TEntity, bool>> whereClause = null)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                return query.LastOrDefault();
            }
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereClause, bool includeDeactivated = false)
        {
            var query = FirstOrDefault(whereClause);

            if (includeDeactivated) return query;

            if (query != null && query.IsDeactivate) return null;
            else return query;
        }

        public virtual TEntity GetById(object id, bool includeDeactive = true)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var obj = context.Set<TEntity>().Where(p => p.Id == (int)id);

                if (!includeDeactive)
                    obj = obj.Where(p => p.IsDeactivate == false);

                return obj.FirstOrDefault();
            }
        }

        public virtual List<TEntity> GetAll()
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = context.Set<TEntity>();

                return query.ToList();
            }
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> whereClause)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                return query.ToList();
            }
        }

        public virtual bool Exists(int id)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                return context.Set<TEntity>().Any(p => p.Id == id);
            }
        }

        public virtual List<TEntity> GetById(IEnumerable<int> id, bool includeDeactive = true)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from ent in context.Set<TEntity>()
                            where id.Contains(ent.Id)
                            select ent;
                if (!includeDeactive)
                    query = query.Where(p => p.IsDeactivate == false);

                return query.ToList();
            }
        }
        public virtual List<TEntity> GetById(IEnumerable<int> id)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from ent in context.Set<TEntity>()
                            where id.Contains(ent.Id)
                            select ent;

                return query.ToList();
            }
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> whereClause)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                return query.FirstOrDefault();
            }
        }

        public virtual TEntity GetBy(Expression<Func<TEntity, bool>> whereClause)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = from b in context.Set<TEntity>()
                            select b;

                if (whereClause != null)
                {
                    query = query.Where(whereClause);
                }

                return query.FirstOrDefault();
            }
        }

        public virtual int Insert(TEntity entity)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                entity.Created = DateTime.UtcNow;
                entity.Modified = DateTime.UtcNow;
                context.Set<TEntity>().Add(entity);
                return context.SaveChanges();
            }
        }

        public virtual int Insert(IEnumerable<TEntity> entities)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                foreach (var entity in entities)
                {
                    entity.Created = DateTime.UtcNow;
                    entity.Modified = DateTime.UtcNow;
                    context.Set<TEntity>().Add(entity);
                }

                return context.SaveChanges();
            }
        }

        public virtual int Delete(int id)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                try
                {
                    var entity = context.Set<TEntity>().Find(id);

                    if (entity == null)
                        throw new ArgumentNullException("entity");

                    context.Set<TEntity>().Remove(entity);

                    return context.SaveChanges();

                }
                catch (Exception dbEx)
                {
                    var msg = dbEx.ToString();
                    throw new Exception(msg, dbEx);
                }
            }
        }

        public virtual int Delete(IEnumerable<int> ids)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                foreach (var id in ids)
                {
                    try
                    {
                        var entity = context.Set<TEntity>().Find(id);

                        if (entity == null)
                            throw new ArgumentNullException("entity");

                        context.Set<TEntity>().Remove(entity);
                    }
                    catch (Exception dbEx)
                    {
                        var msg = dbEx.ToString();
                        throw new Exception(msg, dbEx);
                    }
                }

                return context.SaveChanges();
            }
        }

        public virtual int Delete(TEntity entity)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                try
                {
                    if (entity == null)
                        throw new ArgumentNullException("entity");

                    context.Set<TEntity>().Remove(entity);

                    return context.SaveChanges();

                }
                catch (Exception dbEx)
                {
                    var msg = dbEx.ToString();
                    throw new Exception(msg, dbEx);
                }
            }
        }
        public virtual int Delete(IEnumerable<TEntity> entities)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                foreach (var entity in entities)
                {
                    try
                    {
                        if (entity == null)
                            throw new ArgumentNullException("entity");

                        context.Set<TEntity>().Remove(entity);

                    }
                    catch (Exception dbEx)
                    {
                        var msg = dbEx.ToString();
                        throw new Exception(msg, dbEx);
                    }
                }

                return context.SaveChanges();
            }
        }

        public virtual int Delete()
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var query = context.Set<TEntity>();

                foreach (var entity in query)
                {
                    try
                    {
                        if (entity == null)
                            throw new ArgumentNullException("entity");

                        context.Set<TEntity>().Remove(entity);
                    }
                    catch (Exception dbEx)
                    {
                        var msg = dbEx.ToString();
                        throw new Exception(msg, dbEx);
                    }
                }

                return context.SaveChanges();
            }
        }

        public virtual int DeleteAll()
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                try
                {
                    var sqlCommand = string.Format("DELETE FROM {0}", typeof(TEntity).Name);
                    return context.Database.ExecuteSqlRaw(sqlCommand);
                }
                catch (Exception dbEx)
                {
                    var msg = dbEx.ToString();
                    throw new Exception(msg, dbEx);
                }
            }
        }

        public virtual int Update(TEntity entity)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                entity.Modified = DateTime.UtcNow;
                context.Set<TEntity>().Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                return context.SaveChanges();
            }
        }

        public virtual int Update(IEnumerable<TEntity> entities)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                foreach (var entity in entities)
                {
                    entity.Modified = DateTime.UtcNow;
                    context.Set<TEntity>().Attach(entity);
                    context.Entry(entity).State = EntityState.Modified;
                }
                return context.SaveChanges();
            }
        }

        public virtual int InsertOrReplaceAll(IEnumerable<TEntity> entities)
        {
            using (var context = ContextFactory.CreateDbContext())
            {
                var existIds = context.Set<TEntity>().Select(p => p.Id).ToList();

                foreach (var item in entities)
                {
                    if (!existIds.Contains(item.Id))
                    {
                        item.Created = DateTime.UtcNow;
                        item.Modified = DateTime.UtcNow;
                        context.Set<TEntity>().Add(item);
                    }
                    else
                    {
                        item.Modified = DateTime.UtcNow;
                        context.Set<TEntity>().Attach(item);
                        context.Entry(item).State = EntityState.Modified;
                    }
                }

                return context.SaveChanges();
            }
        }
    }
}

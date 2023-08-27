using FA.JustBlog.Core;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Repository.Infrastructures
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
          where TEntity : class
    {
        protected readonly JustBlogContext dataContext;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(JustBlogContext context)
        {
            dataContext = context;
            dbSet = context.Set<TEntity>();
        }
        public bool Create(TEntity entity)
        {
            try
            {
                //dbSet.Add(entity);
                //dataContext.SaveChanges();
                dataContext.Entry<TEntity>(entity).State = EntityState.Added;
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;

        }
        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
            // Context.Entry<TEntity>(entity).State = EntityState.Deleted;
        }

        public void Delete(params object[] primaryKey)
        {
            dbSet.Remove(dbSet.Find(primaryKey)!);
        }

        public TEntity Find(params object[] primaryKey)
        {
            return dbSet.Find(primaryKey)!;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking();
        }
        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
            // Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}

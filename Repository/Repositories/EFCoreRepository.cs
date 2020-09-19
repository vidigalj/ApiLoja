using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Repository.Context;

namespace Repository.Repositories
{
    public abstract class EFCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {

        private readonly TContext context;

        public EFCoreRepository(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }

        public Task<List<TEntity>> GetByFilter(
                                                Expression<Func<TEntity, bool>> filter,
                                                Func<TEntity, object> orderingFunction = null,
                                                bool orderingAsc = true,
                                                int skip = 0,
                                                int pageLength = -1)
        {
            using (var context = new AppDbContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>()
                        .Where(filter)
                        .AsQueryable();

                if (Includes.Any())
                    foreach (string include in Includes)
                    {
                        query = query.Include(include);
                    }

                if (orderingAsc)
                    query = query.OrderBy(orderingFunction ?? (p => "")).AsQueryable();
                else
                    query = query.OrderByDescending(orderingFunction ?? (p => "")).AsQueryable();

                query = query.Skip(skip);

                if (pageLength > -1)
                    query = query.Take(pageLength);

                return query.AsNoTracking().ToListAsync();
            }
        }
        public List<string> Includes { get; set; }

    }
}

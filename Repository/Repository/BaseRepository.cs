using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Domain;

namespace Repository.BaseRepository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly DigiDataBase _context;
        private DbSet<TEntity> _dbSet;

        public BaseRepository(DigiDataBase context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual List<TEntity> GetList(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includeProperty)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
                query = query.Where(filter);

            //Apply eager loading
            foreach (var navigationProperty in includeProperty)
                query = query.Include<TEntity, object>(navigationProperty);


            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includeProperty)
        {
            IQueryable<TEntity> query = _dbSet;

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in includeProperty)
                query = query.Include<TEntity, object>(navigationProperty);

            return _dbSet.Where(filter).FirstOrDefault();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> dbQuery = _context.Set<TEntity>();
            var query = dbQuery.Where(where);
            return query;
        }

        public virtual bool Any(Expression<Func<TEntity, bool>> where)
        {
            IQueryable<TEntity> dbQuery = _context.Set<TEntity>();
            var query = dbQuery.Where(where).Any<TEntity>();
            return query;
        }

        public virtual int Count(Expression<Func<TEntity, bool>> where = null)
        {
            int query = 0;
            if (where != null)
                query = _dbSet.Where(where).ToList<TEntity>().Count;
            else
                query = _dbSet.ToList<TEntity>().Count;
            return query;
        }


        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _dbSet.Attach(entity);

            _dbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                Delete(item);
            }
        }

        public virtual void Update(TEntity entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
                _context.Set<TEntity>().AddOrUpdate(entity);
        }
    }
}
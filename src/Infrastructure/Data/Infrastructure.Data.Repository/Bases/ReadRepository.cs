using Domain.Interfaces.Repositories.Bases;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Bases
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        public virtual IQueryable<T> AsQuerable()
        {
            return _contexto.Set<T>()
                .AsQueryable();
        }

        public virtual IQueryable<T> Where(ISpecification<T> specification)
        {
            var query = _contexto.Set<T>()
                .Where(specification.Predicate);

            return query;
        }

        public Task<bool> All(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            var result = _contexto.Set<T>()
                .AllAsync(specification.Predicate, cancellationToken);

            return result;
        }

        public Task<bool> Any(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            var result = _contexto.Set<T>()
                .AnyAsync(specification.Predicate, cancellationToken);

            return result;
        }

        public virtual Task<int> Count(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            var result = _contexto.Set<T>()
                .CountAsync(specification.Predicate, cancellationToken);

            return result;
        }

        public virtual Task<List<T>> Search(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            var result = specification.Prepare(_contexto.Set<T>().AsQueryable())
                .ToListAsync(cancellationToken);

            return result;
        }

        public virtual Task<List<T>> Search(ISpecification<T> specification, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var query = specification.Prepare(_contexto.Set<T>().AsQueryable())
                .Skip(pageNumber)
                .Take(pageSize);

            var entities = query.ToListAsync(cancellationToken);
            return entities;
        }

        public virtual Task<T> Find(CancellationToken cancellationToken, params object[] keys)
        {
            var entity = _contexto.Set<T>()
                .FindAsync(keys, cancellationToken);

            return entity;
        }

        public virtual Task<T> FirstOrDefault(ISpecification<T> specification, CancellationToken cancellationToken)
        {
            var result = _contexto.Set<T>()
                .FirstOrDefaultAsync(specification.Predicate, cancellationToken);
            return result;
        }
    }
}
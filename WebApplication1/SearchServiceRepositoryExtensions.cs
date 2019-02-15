using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Vision.Data;
using Vision.Data.EntityFramework;
using Vision.Data.EntityFramework.Mappings;
using WebApplication1.Models;

namespace WebApplication1
{
    public static class SearchServiceRepositoryExtensions
    {
        #region Map & Repository
        public static IServiceCollection AddDbBaseAccess<TEntity>(this IServiceCollection services, params Expression<Func<TEntity, object>>[] keys)
            where TEntity : class
            => AddDbBaseAccess(services, ServiceLifetime.Singleton, ServiceLifetime.Scoped, keys);

        /// <summary>
        /// Add the default Mapping and Repository
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbBaseAccess<TEntity>(this IServiceCollection services, ServiceLifetime mappingServiceLifeTime = ServiceLifetime.Singleton, ServiceLifetime repositoryServiceLifeTime = ServiceLifetime.Scoped, params Expression<Func<TEntity, object>>[] keys)
            where TEntity : class
            => services.AddMapping<TEntity>(serviceLifeTime: mappingServiceLifeTime, mappingConfig: keys.Any() ? a => a.HasKey(keys) : (Action<EntityTypeBuilder<TEntity>>)null)
                       .AddRepositoryBase<SearchServiceDbContext, TEntity>(repositoryServiceLifeTime);

        public static IServiceCollection AddDbAccess<TEntity>(this IServiceCollection services, params Expression<Func<TEntity, object>>[] keys)
            where TEntity : EntityBase
            => AddDbAccess(services, ServiceLifetime.Singleton, ServiceLifetime.Scoped, keys);

        /// <summary>
        /// Add the default Mapping and Repository
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDbAccess<TEntity>(this IServiceCollection services, ServiceLifetime mappingServiceLifeTime = ServiceLifetime.Singleton, ServiceLifetime repositoryServiceLifeTime = ServiceLifetime.Scoped, params Expression<Func<TEntity, object>>[] keys)
            where TEntity : EntityBase
            => services.AddMapping<TEntity>(serviceLifeTime: mappingServiceLifeTime, mappingConfig: keys.Any() ? a => a.HasKey(keys) : (Action<EntityTypeBuilder<TEntity>>)null)
                       .AddRepository<SearchServiceDbContext, TEntity>(repositoryServiceLifeTime);
        /// <summary>
        /// Add mapping and repository for xref table
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="services"></param>
        /// <param name="mappingServiceLifeTime"></param>
        /// <param name="repositoryServiceLifeTime"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static IServiceCollection AddXrefDbAccess<TEntity>(this IServiceCollection services, ServiceLifetime mappingServiceLifeTime = ServiceLifetime.Singleton, ServiceLifetime repositoryServiceLifeTime = ServiceLifetime.Scoped, params Expression<Func<TEntity, object>>[] keys)
            where TEntity : EntityBase
            => services.AddMapping<TEntity>(TableNameStrategyType.XrefTable, ColumnNameStrategyType.Regular, a => a.HasKey(keys), mappingServiceLifeTime)
                       .AddRepository<SearchServiceDbContext, TEntity>(repositoryServiceLifeTime);
        /// <summary>
        /// Add mapping and repository for xref table
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="services"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static IServiceCollection AddXrefDbAccess<TEntity>(this IServiceCollection services, params Expression<Func<TEntity, object>>[] keys)
            where TEntity : EntityBase
            => services.AddXrefDbAccess(ServiceLifetime.Singleton, ServiceLifetime.Scoped, keys);
        #endregion
    }
    }

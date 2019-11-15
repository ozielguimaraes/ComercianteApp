using Infrastructure.CrossCutting.Environment;
using Infrastructure.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace Infrastructure.CrossCutting.IoC
{
    public static class InjectorContainer
    {
        public static void Register(IServiceCollection services, AppSettings appSetttings, string connectionString)
        {
            services.AddScoped((x) => appSetttings);

            // services.AddScoped<IMediatorHandler, InMemoryBus>();
            // services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            // services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            ConfigureDbOptions(services, connectionString);

            // InjectContext<EventStoreContext>(services, connectionString);
        }

        private static void ConfigureDbOptions(IServiceCollection services, string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                AddConnection(services, connectionString);
                AddTransaction(services);
                AddDbOptions(services);
            }
        }

        private static void AddConnection(IServiceCollection services, string connectionString)
        {
            services.AddScoped((serviceProvider) =>
            {
                var dbConnection = new SqlConnection(connectionString);
                dbConnection.Open();
                return dbConnection;
            });
        }

        private static void AddTransaction(IServiceCollection services)
        {
            services.AddScoped<DbTransaction>((serviceProvider) =>
            {
                var dbConnection = serviceProvider.GetService<SqlConnection>();
                return dbConnection.BeginTransaction(IsolationLevel.ReadCommitted);
            });
        }

        private static void AddDbOptions(IServiceCollection services)
        {
            services.AddScoped((serviceProvider) =>
            {
                var dbConnection = serviceProvider.GetService<SqlConnection>();

                var dbContext = new DbContextOptionsBuilder()
                    .UseSqlServer(dbConnection, x =>
                    {
                        x.MigrationsHistoryTable("Migrations");
                        x.MigrationsAssembly("Infrastructure.Data.Migrations");
                    })
                    .UseLazyLoadingProxies()
                    .EnableSensitiveDataLogging();

                AddContextLog(dbContext);
                return dbContext.Options;
            });
        }

        public static void InjectContext(IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                UseInMemoryDatabase(services);
                return;
            }

            UseSqlDatabase(services);
        }

        private static void UseInMemoryDatabase(IServiceCollection services)
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .AddEntityFrameworkProxies()
                .BuildServiceProvider();

            services.AddDbContext<ComercianteContext>(options => options
                .UseInternalServiceProvider(serviceProvider)
                .UseInMemoryDatabase("ComercianteDb")
                .UseLazyLoadingProxies()
                .EnableSensitiveDataLogging());
        }

        private static void UseSqlDatabase(IServiceCollection services)
        {
            services.AddScoped((serviceProvider) =>
            {
                var transaction = serviceProvider.GetService<DbTransaction>();
                var options = serviceProvider.GetService<DbContextOptions>();

                var context = (ComercianteContext)Activator.CreateInstance(typeof(ComercianteContext), options);
                context.Database.UseTransaction(transaction);
                return context;
            });
        }

        private static ILoggerFactory GetLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging(builder =>
                builder
                    .AddConsole()
                    .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information)
            );

            return serviceCollection
                .BuildServiceProvider()
                .GetService<ILoggerFactory>();
        }

        [Conditional("DEBUG")]
        private static void AddContextLog(DbContextOptionsBuilder dbContext)
        {
            dbContext.UseLoggerFactory(GetLoggerFactory());
        }
    }
}
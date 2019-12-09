using System.Reflection;
using Autofac;
using MedicinePlanner.Infrastructure.Mongo;
using MedicinePlanner.Infrastructure.Repositories;
using MongoDB.Driver;

namespace MedicinePlanner.Infrastructure.IoC.Modules
{
    public class MongoModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) => {
                var settings = c.Resolve<MongoSettings>();
                return new MongoClient(settings.ConnectionString);
            }).SingleInstance();

            builder.Register((c, p) => {
                var client = c.Resolve<MongoClient>();
                var settings = c.Resolve<MongoSettings>();
                var database = client.GetDatabase(settings.Database);

                return database;
            }).As<IMongoDatabase>();

            var assembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;


            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IMongoRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
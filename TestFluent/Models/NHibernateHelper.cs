using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace TestFluent.Models
{
    public class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(PostgreSQLConfiguration.Standard
                        .ConnectionString(c =>
                            c.Host("localhost")
                            .Port(5432)
                            .Database("TestDB")
                            .Username("postgres")
                            .Password("postgres"))
                )
               .Mappings(m =>
                          m.FluentMappings
                              .AddFromAssemblyOf<Employee>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg)
                                                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
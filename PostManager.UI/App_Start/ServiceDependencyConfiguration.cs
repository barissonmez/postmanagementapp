using PostManager.BLL.Services;
using PostManager.CL.Data;
using PostManager.DAL.DataSource;
using PostManager.DAL.Repositories;
using PostManager.IL.TypicodeApi;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using PostManager.CL.Manager;

namespace UI.App_Start
{
    public class ServiceDependencyConfiguration
    {
        public static void RegisterServices()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register(typeof(IService<>), typeof(PostService), Lifestyle.Scoped);
            container.Register(typeof(IRepository<>), typeof(PostRepository), Lifestyle.Scoped);
            container.Register(typeof(IDataSource<>), typeof(PostDataSource), Lifestyle.Singleton);
            container.Register(typeof(ICachedDataProvider<>), typeof(CachedPostDataProvider), Lifestyle.Singleton);
            container.Register(typeof(ICacheManager), typeof(CacheManager), Lifestyle.Singleton);
            container.Register(typeof(ITypicodeApiProvider), typeof(TypicodeApiProvider), Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}

using Autofac.Core;
using EnginCan.Caching;
using EnginCan.Caching.Microsoft;
using EnginCan.Core.Elastic.Abstract;
using EnginCan.Core.Elastic.Concrete;
using EnginCan.Core.Elastic.Models;
using EnginCan.Core.Elastic;
using EnginCan.Core.Middleware;
using EnginCan.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnginCan.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {

            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.AddTransient(typeof(IElasticSearchService<>), typeof(ElasticSearchService<>));
            serviceCollection.AddSingleton<ElasticClientProvider>();
        }
    }
}

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using System;
using System.Collections.Generic;
using TestTaskWebApplication.DAL.Entities;
using TestTaskWebApplication.Infrastructure.Config;
using TestTaskWebApplication.Models;

namespace TestTaskWebApplication.Infrastructure
{
    public sealed class DependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly StandardKernel Kernel;

        public TDependency Resolve<TDependency>()
        {
            return Kernel.Get<TDependency>();
        }

        public object GetService(Type serviceType)
        {
            return serviceType != null ? Kernel.TryGet(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Kernel.GetAll(serviceType);
        }

        public void Dispose() { }

        public DependencyResolver()
        {
            Kernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            Kernel.Bind<IdentityDbContext<User>>()
                .ToConstructor(c => new ApplicationDbContext());
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject;
using System;
using System.Collections.Generic;
using TestTaskWebApplication.DAL.Entities;
using TestTaskWebApplication.Infrastructure.Config;
using TestTaskWebApplication.Models;
using TestTaskWebApplication.Services;

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
            Settings settings = Settings.GetSettings();

            Kernel.Bind<IdentityDbContext<User>>()
                .ToConstructor(c => new ApplicationDbContext());

            Kernel.Bind<IMailService>()
               .ToConstructor(x => new EmailService(settings.Email))
               .InTransientScope();

            Kernel.Bind<EmailElement>().ToConstant(settings.Email);
        }
    }
}
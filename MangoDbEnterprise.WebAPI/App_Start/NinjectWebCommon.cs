using System;
using System.Web;
using MangoDbEnterprise.Repositories;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;

namespace MangoDbEnterprise.WebAPI.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();
        private static IKernel _kernel;

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            if (_kernel == null)
            {
                _kernel = new StandardKernel();
                try
                {
                    _kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                    _kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                    RegisterServices(_kernel);
                }
                catch
                {
                    _kernel.Dispose();
                    throw;
                }
            }
            return _kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IReferenceService>().To<ReferenceService>();
            kernel.Bind<ITodoService>().To<TodoService>();
        }
    }
}
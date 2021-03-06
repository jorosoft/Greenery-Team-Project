[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AirportSystem.WebClient.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AirportSystem.WebClient.App_Start.NinjectWebCommon), "Stop")]

namespace AirportSystem.WebClient.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Controllers;
    using Contracts.Data;
    using Data;
    using System.Data.Entity;
    using Contracts.Models;
    using AirportSystem.Models;
    using Contracts.MainDll;
    using Converters;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAirportSystemMsSqlData>().To<AirportSystemMsSqlData>();
            kernel.Bind<IAirportSystemPSqlData>().To<AirportSystemPSqlData>();
            kernel.Bind<IAirportSystemSqliteData>().To<AirportSystemSqliteData>();

            kernel.Bind<DbContext>().To<AirportSystemMsSqlDbContext>();

            kernel.Bind<IScheduleUpdater>().To<ScheduleUpdater>();
            //kernel.Bind<IDeserializer>().To<XmlDeserializer>().Named("XML");
            //kernel.Bind<IDeserializer>().To<JsonDeserializer>().Named("JSON");
            //kernel.Bind<IDeserializer>().To<ExcelDeserializer>().Named("EXCEL");

        }
    }
}

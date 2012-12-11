using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using CPS.WebUI.Controllers;
using log4net;
using log4net.Config;

namespace CPS.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            // ---IOC of autofac ---
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (MvcApplication).Assembly).PropertiesAutowired();

            // load assemblies not referenenced
            RegisterAssemblyModulesInWebConfig(builder, "externalAssemblies");

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            // --- End IOC of autofac---

            // --- Set Log Directory ---
            string logDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CPS\\log";
            if (!Directory.Exists(logDirectoryPath))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(logDirectoryPath);
            }

            Environment.SetEnvironmentVariable("APPLOGS", logDirectoryPath);
            XmlConfigurator.Configure();
            // --- End Set Log Directory ---

            // --- log System Info ---
            if (log.IsDebugEnabled)
            {
                log.Debug("Is64BitOperatingSystem: " + System.Environment.Is64BitOperatingSystem);
                log.Debug("Is64BitProcess: " + System.Environment.Is64BitProcess);
                log.Debug(System.Environment.MachineName);
                log.Debug(System.Environment.OSVersion);
                log.Debug(System.Environment.UserDomainName);
                log.Debug(System.Environment.UserName);
            }
            // --- End log System Info ---
        }

        private void RegisterAssemblyModulesInWebConfig(ContainerBuilder builder, string webConfigName)
        {
            string assemblyPathsStr = WebConfigurationManager.AppSettings[webConfigName];

            //if (Logger.IsDebugEnabled)
            //{
            //    Logger.DebugFormat("External Assembly Paths = {0}", assemblyPathsStr);
            //}

            if (assemblyPathsStr == null)
            {
                return;
            }

            var serverRootPath = Server.MapPath("/");
            var assemblyResolver = new AssemblyResolver();

            var paths = assemblyPathsStr.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var path in paths)
            {
                string fullPath = "";
                if (Path.IsPathRooted(path))
                {
                    fullPath = path;

                    // add the folder path for searching other assemblies
                    var assemblyFolderPath = Path.GetDirectoryName(fullPath);
                    assemblyResolver.AddFolderPath(assemblyFolderPath);
                }
                else
                {
                    fullPath = Path.GetFullPath(Path.Combine(serverRootPath, "bin", path));
                }

                bool isFileFound = File.Exists(fullPath);

                if (isFileFound)
                {
                    try
                    {
                        var asm = Assembly.LoadFile(path);
                        builder.RegisterAssemblyModules(asm);

                        //if (Logger.IsInfoEnabled)
                        //{
                        //    Logger.InfoFormat("Assembly loaded : {0}", fullPath);
                        //}
                    }
                    catch (Exception ex)
                    {
                        //if (Logger.IsErrorEnabled)
                        //{
                        //    Logger.Error("kernel.Load(...)", ex);
                        //}
                    }
                }
                else
                {
                    //if (Logger.IsWarnEnabled)
                    //{
                    //    Logger.WarnFormat("Assembly file not found : {0}", fullPath);
                    //}
                }
            }
        }
    }

    public class AssemblyResolver : IDisposable
    {
        HashSet<string> mAssemblyFolderCollection = new HashSet<string>();

        public AssemblyResolver()
        {
            AppDomain.CurrentDomain.AssemblyResolve += ResolveEventHandler;
        }

        public void AddFolderPath(string assemblyFolderPath)
        {
            if (!mAssemblyFolderCollection.Contains(assemblyFolderPath))
            {
                mAssemblyFolderCollection.Add(assemblyFolderPath);
            }
        }

        public void Dispose()
        {
            AppDomain.CurrentDomain.AssemblyResolve -= ResolveEventHandler;
        }

        Assembly ResolveEventHandler(object sender, ResolveEventArgs args)
        {
            foreach (var folderPath in mAssemblyFolderCollection)
            {
                string assemblyPath = Path.Combine(folderPath, new AssemblyName(args.Name).Name + ".dll");
                if (File.Exists(assemblyPath) == false)
                {
                    continue;
                }
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                return assembly;
            }
            return null;
        }
    }
}
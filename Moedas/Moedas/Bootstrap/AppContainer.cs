using Autofac;
using Moedas.Repository;
using Moedas.Services.Coins;
using Moedas.Services.Navigation;
using Moedas.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Moedas.Bootstrap
{
    public static class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<CoinsViewModel>();
           

            //services - data
            builder.RegisterType<CoinsService>().As<ICoinsService>();


            //services - general
            builder.RegisterType<NavigationService>().As<INavigationService>(); 

            //General

            builder.RegisterType<GenericRepository>().As<IGenericRepository>();
           

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        //Resolve : casos em que eh necessario instancia, e nao ha injecao de dependencia no construtor(casos VM)
        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}

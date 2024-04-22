using System;
using Eurotorg_trainee.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace Eurotorg_trainee.Service
{
    public class Container
    {
        private readonly ServiceProvider serviceProvider;

        public Container()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();

            services.AddSingleton<RateViewModel>();
        }

        public object GetService(Type type)
        {
            if (type is null) throw new ArgumentNullException(nameof(type));
            return serviceProvider.GetService(type); //
        }

        public T GetService<T>()
        {
            return serviceProvider.GetService<T>(); //
        }
    }
}

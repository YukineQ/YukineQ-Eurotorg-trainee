using System;
using Eurotorg_trainee.Commands;
using Eurotorg_trainee.Intefaces;
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
            services.AddSingleton<DatePickerModelView>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<DynamicGraphViewModel>();
            services.AddSingleton<OpenFileInfoViewModel>();

            services.AddSingleton<IMessageBoxService, MessageBoxService>();
            services.AddSingleton<IDialogService , DialogService>();
            services.AddSingleton<IExRatesAPI, ExRatesAPI>();

            services.AddSingleton<ICommandBinding, GetRatesForDateCommand>();
            services.AddSingleton<ICommandBinding, ReadFromJsonCommand>();
            services.AddSingleton<ICommandBinding, SelectRowForGraphCommand>();
            services.AddSingleton<ICommandBinding, SaveToJsonCommand>();

            services.AddSingleton<SourceService>();
        }

        public object GetService(Type type)
        {
            if (type is null) throw new ArgumentNullException(nameof(type));
            return serviceProvider.GetService(type) ?? throw new NotSupportedException(type.Name);
        }

        public T GetService<T>() => serviceProvider.GetService<T>();
    }
}

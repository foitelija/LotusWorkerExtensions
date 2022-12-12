using LotusWorkerExtensions.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LotusWorkerExtensions
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;


        public App()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddDbContext<IncomingMessageContext>(options =>
            {
                options.UseSqlServer("Server=localhost;Database=lotus;trusted_connection=true;Integrated Security=SSPI;MultipleActiveResultSets=True;TrustServerCertificate=True");
            });
            services.AddSingleton<MainWindow>();
            _serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}

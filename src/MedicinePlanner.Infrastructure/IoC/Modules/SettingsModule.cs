using System.Reflection;
using Autofac;
using MedicinePlanner.Infrastructure.Commands;
using MedicinePlanner.Infrastructure.Extensions;
using MedicinePlanner.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace MedicinePlanner.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                    .SingleInstance();
        }
    }
}
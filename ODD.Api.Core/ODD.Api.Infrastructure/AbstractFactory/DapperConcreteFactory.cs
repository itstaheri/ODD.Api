using ODD.Api.Application.AbstractFactory;
using ODD.Api.Application.Contract.Enums;
using ODD.Api.Application.Interfaces;
using ODD.Api.Infrastructure.Utility.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Infrastructure.AbstractFactory
{
    public class DapperConcreteFactory : IDapperAbstractFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DapperConcreteFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IApplicationDapperContext CreateInstance(ServiceType type)
        {
            return type switch
            {
                ServiceType.SSMS => _serviceProvider.GetRequiredService<DapperSSMSDBHelper>()
            };
        }
    }
}

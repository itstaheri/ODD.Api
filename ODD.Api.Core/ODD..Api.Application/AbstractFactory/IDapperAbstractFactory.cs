using ODD.Api.Application.Contract.Enums;
using ODD.Api.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODD.Api.Application.AbstractFactory
{
    public interface IDapperAbstractFactory
    {
        public IApplicationDapperContext CreateInstance(ServiceType type);

    }
}

using LoggerService.Model;
using LoggerService.Services;
using Microsoft.Extensions.Configuration;
using Nest;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.Implement
{
    public class ElasticSearchService : ILoggerService
    {
        private readonly IConfiguration _configuration;

        ElasticClient client = new ElasticClient();
        string defualtIndex = string.Empty;
        string connection = string.Empty;
        public ElasticSearchService(IConfiguration configuration)
        {
        
            _configuration = configuration;
            connection = _configuration.GetSection("LoggerService").GetSection("ElasticSearch").GetSection("Connection").Value;
            defualtIndex = _configuration.GetSection("LoggerService").GetSection("ElasticSearch").GetSection("DefaultIndex").Value;
            var setting = new ConnectionSettings(new Uri(connection)).DefaultIndex(defualtIndex); 
            client = new ElasticClient(setting);
             
        }
        public  void Log(Model.LogServiceLevel logLevel,string message)
        { 

            client.IndexDocument(new LogModel {LogLevel = logLevel.ToString(), Message = message,DateTime = DateTime.Now.ToString()});
        }
    }
}

using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Functions.Worker.Configuration;
using System.Net.Mail;
using System.Net;
using System;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api;
using Microsoft.Extensions.Logging;
using System.Net.Http;

namespace ApiIsolated
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder().ConfigureFunctionsWorkerDefaults().Build();


            host.Run();
        }

    }
}
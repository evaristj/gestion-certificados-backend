using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ApiGTT.Models;

namespace ApiGTT.Services
{
    internal class ServiceCron : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;

        public ServiceCron(ILogger<ServiceCron> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Arrancando el servicio");
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(15));
            return Task.CompletedTask;

           // throw new NotImplementedException();
        }

        public void DoWork(object state)
        {
            
            var optionsBuild = new DbContextOptionsBuilder<AppDbContext>();

            optionsBuild.UseNpgsql("Host=192.168.99.100; Port=5432; Username=postgres; Password=example; Database=ApiGTT;");


            using (var context = new AppDbContext(optionsBuild.Options))
            {
                DateTime maxDateTime = DateTime.Now.AddMonths(1);
                DateTime nowDate = DateTime.Now;
                context.Certificates.Load();
                foreach (var cert in context.Certificates.Local)
                {
                    var caducados = cert.caducidad;
                    if (caducados < maxDateTime && !(caducados < nowDate))
                    {
                        Console.WriteLine("más de 1 mes para caducar");
                        cert.proxCaducidad = true;
                        context.SaveChanges();
                        Console.WriteLine(cert.proxCaducidad);
                    } else if(caducados < nowDate)
                    {
                        Console.WriteLine("Caducados.");
                        cert.caducado = true;
                        cert.proxCaducidad = false;
                        context.SaveChanges();
                    }else if (caducados > maxDateTime)
                    {
                        cert.caducado = false;
                        context.SaveChanges();
                    }

                }

            }
            

            _logger.LogInformation("Ejecutando tarea.");


            // throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {

            _logger.LogInformation("Parando el servicio");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;

           // throw new NotImplementedException();
        }

        public void Dispose()
        {
            _timer?.Dispose();

            // throw new NotImplementedException();
        }

    }

}

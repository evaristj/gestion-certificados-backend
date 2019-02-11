﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;

           // throw new NotImplementedException();
        }

        public void DoWork(object state)
        {
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

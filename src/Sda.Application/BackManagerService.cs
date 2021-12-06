using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sda.Application
{
    public class BackManagerService : BackgroundService
    {
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Task.CompletedTask.Wait();

            //int i = 1;
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    Console.WriteLine("后端任务"+i++);

            //    await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
            //}
        }


        
    }
}

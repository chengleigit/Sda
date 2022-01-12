using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sda.Application
{
    public class BackManagerService : BackgroundService
    {
        public readonly IConfiguration _configuration;
        private Socket clientSocket = null;
        private bool connected = false;
        string ip;
        int port = 5004;
        public BackManagerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Executed SdaMeasDataWorker..!");

                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }

            //Console.WriteLine("Executed SdaMeasDataWorker..!");
            //if (connected)
            //{
            //    Console.ReadKey();

            //    await BeginSdaMeasDataAsync();
            //}
            //connected = true;
        }





        public async Task BeginSdaMeasDataAsync() 
        {
            this.ip = _configuration["SdaConnection:IP"].ToString();
            this.port = Convert.ToInt32(_configuration["SdaConnection:Port"]);

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.ReceiveTimeout = 5000;
                clientSocket.Connect(ip, port);
                connected = true;
                Console.WriteLine("Socket连接成功！");
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
            }
        }



    }
}

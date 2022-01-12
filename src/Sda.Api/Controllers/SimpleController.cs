using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Sda.Api.Controllers
{
    /// <summary>
    /// 简单示例
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SimpleController : ControllerBase
    {
        private readonly ILogger<SimpleController> _logger;

        private readonly ISchedulerFactory _schedulerFactory;
        private IScheduler _scheduler;

        public SimpleController(ILogger<SimpleController> logger, ISchedulerFactory schedulerFactory)
        {
            _logger=logger;
            _schedulerFactory= schedulerFactory; 
        }
        
        [HttpGet("test")]
        public Task Test()
        {
            _logger.LogTrace("Trace(跟踪)Log");
            _logger.LogDebug("Debug(调试)Log");
            _logger.LogInformation("信息(Information)Log");
            _logger.LogWarning("警告(Warning)Log");
            _logger.LogError("错误(Error)Log");
            _logger.LogCritical("严重(Critical)Log");

            return Task.FromResult("OK");
        }

        [HttpGet("quartz")]
        public async Task<string> TestQuartz() 
        {
            //通过调度工厂获得调度器
            _scheduler = await _schedulerFactory.GetScheduler();
           
            //开启调度器
            await _scheduler.Start();

            //创建一个触发器
            var trigger = TriggerBuilder.Create()
                            //.WithSimpleSchedule(x => x.WithIntervalInSeconds(2).RepeatForever())//每两秒执行一次
                            .Build();

            //创建任务
            var jobDetail = JobBuilder.Create<MyJob>()
                            .WithIdentity("job", "group")
                            .UsingJobData("key1", 321)
                            .Build();

            //将触发器和任务器绑定到调度器中
            await _scheduler.ScheduleJob(jobDetail, trigger);

            return "OK!";
        }

    }

    /// <summary>
    /// 创建IJob的实现类，并实现Excute方法
    /// </summary>
    public class MyJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            var triggerData = context.Trigger.JobDataMap;//获取Trigger中的参数

            return Task.Run(() =>
            {

                System.Console.WriteLine($"{ DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}==={triggerData.GetInt("key1")}");
                //using (StreamWriter sw = new StreamWriter(@"nlog-all-2021-12-06.log", true, Encoding.UTF8))
                //{
                //    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
                //}
            });
        }
    }
}

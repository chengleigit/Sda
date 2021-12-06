using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public SimpleController(ILogger<SimpleController> logger)
        {
            _logger=logger;
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

        [HttpGet]
        public Task<string> GetHangfire() 
        {
            return Task.FromResult("OK");
        }

    }
}

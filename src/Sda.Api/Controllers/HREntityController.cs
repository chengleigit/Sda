using Microsoft.AspNetCore.Mvc;
using Sda.Application.HREntitys;
using Sda.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sda.Api.Controllers
{
    /// <summary>
    /// 实体
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class HREntityController : ControllerBase
    {
        private readonly IHREntityService _hREntityService;
        public HREntityController(IHREntityService hREntityService)
        {
            _hREntityService = hREntityService;
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<HREntity>> GetAll()
        {
            return await _hREntityService.GetAllAsyns();
        }

    }
}

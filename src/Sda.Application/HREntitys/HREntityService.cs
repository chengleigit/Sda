using Microsoft.EntityFrameworkCore;
using Sda.Core.Models;
using Sda.Core.Repositories;
using Sda.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.Application.HREntitys
{
    public class HREntityService : IHREntityService
    {
        private readonly IRepository<HREntity, Guid> _hrEntityRepository;

        public HREntityService(IRepository<HREntity, Guid> hrEntityRepository)
        {
            _hrEntityRepository = hrEntityRepository;
        }

        public async Task<List<HREntity>> GetAllAsyns()
        {
            return await _hrEntityRepository.GetAllListAsync();
        }
    }
}

using Sda.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.Application.HREntitys
{
    public interface IHREntityService
    {
        Task<List<HREntity>> GetAllAsyns();
    }
}

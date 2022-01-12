using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sda.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.EntityFrameworkCore.Seed
{
    public static class DataInitializer
    {
        public static IApplicationBuilder UseDataInitializer(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var dbcontext = scope.ServiceProvider.GetService<AppDbContext>();

                if (dbcontext.HREntitys.Any())
                {
                    return builder;//数据已经初始化了
                }

                #region HREntity
                var hrEntitys = new[]
                {
                    new HREntity()
                    {
                       Id=Guid.NewGuid(),
                       BattleId=Guid.NewGuid(),
                       CurTime=1,
                       IsOver=false
                    },
                     new HREntity()
                    {
                       Id=Guid.NewGuid(),
                       BattleId=Guid.NewGuid(),
                       CurTime=2,
                       IsOver=false
                    },
                      new HREntity()
                    {
                       Id=Guid.NewGuid(),
                       BattleId=Guid.NewGuid(),
                       CurTime=3,
                       IsOver=false
                    }
                };

                foreach (var item in hrEntitys)
                    dbcontext.HREntitys.Add(item);
                dbcontext.SaveChanges();

                #endregion

            }

            return builder;
        }
    }
}

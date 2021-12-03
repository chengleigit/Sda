using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.Core.Models
{
    public class HREntity
    {
        public Guid Id { get; set; }
        public Guid ConcurrencyStamp { get; set; }
        /// <summary>
        /// 比赛Id
        /// </summary>
        public Guid BattleId { get; set; }
        /// <summary>
        /// 是否结束
        /// </summary>
        public bool IsOver { get; set; }
        /// <summary>
        /// 步长
        /// </summary>
        public int CurTime { get; set; }




    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.Application.Dtos
{
    public class PagedSortedAndFilterInput
    {
        public PagedSortedAndFilterInput()
        {
            CurrentPage = 1;
            MaxResultCount = 10;
        }

        /// <summary>
        /// 每页分页条数
        /// </summary>
        [Range(0, 1000)]
        public int MaxResultCount { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        [Range(0, 1000)]
        public int CurrentPage { get; set; }
        /// <summary>
        /// 排序字段ID
        /// </summary>
        public string Sorting { get; set; }

        /// <summary>
        /// 查询名称
        /// </summary>
        public string FilterText { get; set; }
    }
}

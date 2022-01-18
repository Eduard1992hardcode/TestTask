using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Models
{
    public abstract class PeriodEntity
    {
        /// <summary>
        /// период начисления или оплаты в формате YYYYMM
        /// </summary>
        public DateTime Period { get; set; }
    }
}

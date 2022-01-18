using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Dto
{
    public class BalanceDto
    {
        public int Account_id { get; set; }
        public int Period { get; set; }
        public double In_balance { get; set; }
        public double Calculation { get; set; }
    }
}

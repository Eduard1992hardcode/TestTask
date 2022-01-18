using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Dto
{
    public class PaymentDto
    {
        public int Account_id { get; set; }
        public string Date { get; set; }
        public double Sum { get; set; }
        public string Payment_guid { get; set; }
    }
}

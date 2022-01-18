using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.Dto
{
    public class TurnoverStatementDto
    {
        /// <summary>
        /// Наименование периода
        /// </summary>
        public string PeriodName { get; set; }
        /// <summary>
        /// Входящее сальдо на начало периода
        /// </summary>
        public double IncomingBalance { get; set; }
        /// <summary>
        /// Начислено за период
        /// </summary>
        public double Accrued { get; set; }
        /// <summary>
        /// Оплачено за период
        /// </summary>
        public double Prepaid { get; set; }
        /// <summary>
        /// Исходящий баланс на конец периода
        /// </summary>
        public double OutgoingBalance { get; set; }
    }
}

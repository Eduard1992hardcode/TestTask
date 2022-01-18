using System;

namespace TestTask.Models
{
    public class BalanceModel : PeriodEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// идентификатор ЛС
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// Начальное сальдо на указанный период.
        /// Указанное значение может быть не корректным, при построении баланса рекомендуемся его рассчитывать
        /// </summary>
        public double InBalance { get; set; }
        /// <summary>
        /// начислено за период
        /// </summary>
        public double Calculation { get; set; }
    }
}
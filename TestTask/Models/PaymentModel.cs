using System;

namespace TestTask.Models
{
    public class PaymentModel: PeriodEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// идентификатор ЛС
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// сумма платежа
        /// </summary>
        public double Sum { get; set; }
        /// <summary>
        /// уникальный идентификатор платежа.
        /// </summary>
        public string PaymentGuid { get; set; }
    }
}

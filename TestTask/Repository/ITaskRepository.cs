using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Dto;
using TestTask.Models;

namespace TestTask.Repository
{
    public interface ITaskRepository
    {
        public void AddBalance(BalanceModel balance);
        public void AddPayment(PaymentModel payment);
        public IQueryable<BalanceModel> GetBalances();
        public IQueryable<PaymentModel> GetPayments();
    }
}

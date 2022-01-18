using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Data;
using TestTask.Dto;
using TestTask.Models;

namespace TestTask.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _dataContext;
        public TaskRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void AddBalance(BalanceModel balance)
        {
            _dataContext.Balances.Add(balance);
            _dataContext.SaveChanges();
        }
        public void AddPayment(PaymentModel payment)
        {
            _dataContext.Payments.Add(payment);
            _dataContext.SaveChanges();
        }
        public IQueryable<BalanceModel> GetBalances()
        {
            return _dataContext.Balances;
        }
        public IQueryable<PaymentModel> GetPayments()
        {
            return _dataContext.Payments;
        }


    }
}

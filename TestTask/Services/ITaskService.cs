using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Dto;

namespace TestTask.Services
{
    public interface ITaskService
    {
        public string CreateBalances(List<BalanceDto> balances);
        public string CreatePayments(List<PaymentDto> payments);
        public List<TurnoverStatementDto> CalculateTurnoverStatement(int accountId, DateTime date, string groupType);
        public Task<string> LoadAccount(string accountName);
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TestTask.Dto;
using TestTask.Models;
using TestTask.Repository;

namespace TestTask.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;
         public TaskService(ITaskRepository taskRepository,
            IMapper mapper,
            IHttpClientFactory clientFactory)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _clientFactory = clientFactory;

        }
        public string CreateBalances(List<BalanceDto> dtos)
        {
            foreach (var b in dtos)
            {
                var balance = _mapper.Map<BalanceModel>(b);
                _taskRepository.AddBalance(balance);
            }
            return "add balance";
        }
        public string CreatePayments(List<PaymentDto> dtos)
        {
            foreach (var b in dtos)
            {
                var payment = _mapper.Map<PaymentModel>(b);
                _taskRepository.AddPayment(payment);
            }
            return "add payment";
        }
         public List<TurnoverStatementDto> CalculateTurnoverStatement(int accountId, DateTime date, string groupType)
        {
            var orderFunction = GetGroupingExpression(groupType);

            var result = new List<TurnoverStatementDto>();
            var balences = _taskRepository.GetBalances()
                .Where(o => o.AccountId == accountId && o.Period <= date.Date)
                .ToList()
                .GroupBy(balance => orderFunction.Invoke(balance));

            var payments = _taskRepository.GetPayments()
                .Where(o => o.AccountId == accountId && o.Period <= date.Date)
                .ToList()
                .GroupBy(payment => orderFunction.Invoke(payment));

            var currenrtBalance = 0.0; 
            foreach(var balance in balences)
            {
                var payment = payments.FirstOrDefault(payment => payment.Key == balance.Key);
                var dto = new TurnoverStatementDto();
                dto.Accrued = balance.Sum(s => s.Calculation);
                dto.IncomingBalance = currenrtBalance;
                if (payment == null)
                {
                    dto.Prepaid = 0.0;
                }
                else 
                {
                    dto.Prepaid = payment.Sum(p => p.Sum);
                }
                dto.OutgoingBalance = dto.IncomingBalance - dto.Prepaid + dto.Accrued;
                currenrtBalance = dto.OutgoingBalance;
                result.Add(dto);
            }
            return result;

        }
        public async Task<string> LoadAccount(string accountName)
        {
            var httpClient = _clientFactory.CreateClient("GitHub");
            var result =  await httpClient.GetStringAsync($"users/{accountName}");
            return result;
        }
        private static Func<PeriodEntity, string> GetGroupingExpression(string periodType)
        {
            if (periodType == "month")
                return entity => entity.Period.Year + "/" + entity.Period.Month;
            if (periodType == "quarter")
                return entity => entity.Period.Year + "/" + (entity.Period.Month + 2) / 3;
            else
                return entity => entity.Period.Year.ToString();
        }
    }
}

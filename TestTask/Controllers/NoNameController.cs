using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Data;
using TestTask.Dto;
using TestTask.Services;

namespace TestTask.Controllers
{
    [Route("api/noNameController")]
    public class NoNameController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public NoNameController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        // POST: NoNameController/CreateBalances
        [HttpPost("createBalances")]
        public ActionResult CreateBalances([FromBody]List<BalanceDto> dtos)
        {
            var result = _taskService.CreateBalances(dtos);
            return Ok(result);
        }
        // POST: NoNameController/CreatePayment
        [HttpPost("createPayment")]
        public ActionResult CreatePayment([FromBody] List<PaymentDto> dtos)
        {
            var result = _taskService.CreatePayments(dtos);
            return Ok(result);
        }
        [HttpGet("getBalances")]
        public ActionResult GetBalance([FromBody]int accountId, DateTime date, string typePeriod)
        {
            var result = _taskService.CalculateTurnoverStatement(accountId, date, typePeriod);
            return Ok(result);
        }
        [HttpGet("getInfoGitHubAccount")]
        public async Task<ActionResult> GetAccountInfo(string accontName)
        {
            var result = await _taskService.LoadAccount(accontName);
            return Ok(result);
        }
    }
}

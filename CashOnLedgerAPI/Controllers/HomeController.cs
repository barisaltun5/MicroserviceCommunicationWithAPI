using CashOnLedgerAPI.Attributes;
using CashOnLedgerAPI.Models.RequestModels;
using CashOnLedgerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashOnLedgerAPI.Controllers
{
    [Route("api")]
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;
        public HomeController(HomeService homeService)
        {
            _homeService = homeService;
        }
        [ApiKeyCheck]
        [HttpPost("orderstatus")]
        public IActionResult CheckStatus([FromBody] OrderRequestModel model)
        {
            var response = _homeService.CheckStatus(model);
            return Ok(response);
        }
    }
}

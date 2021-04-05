using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TechOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        private readonly ILogger<BankController> _logger;

        public BankController(ILogger<BankController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ConvertToString")]
        public string ConvertToString(string value)
        {
            ulong dollars;
            ulong cents;

            if (!value.Contains('.')){
                // Just dollars
                var parsed = ulong.TryParse(value, out dollars);

                if (parsed){
                    return $"{BankHelper.NumberToString(dollars)} dollar{(dollars != 1 ? "s" : "")}";
                }
                
                Response.StatusCode = 400;
                throw new ArgumentException();
            } 

            // Dollars and cents.
            var split = value.Split(".");

            var parsedDollars = ulong.TryParse(split[0], out dollars);
            var parsedCents = ulong.TryParse(split[1].PadRight(2, '0'), out cents);

            if (parsedDollars && parsedCents) {
                return $"{BankHelper.NumberToString(dollars)} dollar{(dollars != 1 ? "s" : "")}" + 
                    $" and {BankHelper.NumberToString(cents)} cent{(cents != 1 ? "s" : "")}";
            }

            Response.StatusCode = 400;
            throw new ArgumentException();
        }
    }
}

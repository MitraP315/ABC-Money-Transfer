using ABCExchange.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABCExchange.Controllers
{
    [Route("api/")]
    [ApiExplorerSettings(GroupName = "access-control")]
    public class TransanctionApiController:BaseApiController
        
    {
        private readonly IForexService _forexervice;
        public TransanctionApiController(IForexService forexervice)
        {
            _forexervice = forexervice;
        }
        [HttpPost("view/exchangeRates")]
        public async Task<ResponseModel> GetExchangeRates()
        {
            try
            {
                var data = await _forexervice.GetExchangeRatesAsync();
                if (data == null || !data.Any())
                {
                    return new ResponseModel(404, "No valid exchange rates found.");
                }

                return new ResponseModel(200, "", data.ToArray());
            }
            catch (Exception ex)
            {
                return new ResponseModel(400, $"Error: {ex.Message}");
            }
        }


    }
}

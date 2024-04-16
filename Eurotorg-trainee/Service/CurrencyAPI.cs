using Eurotorg_trainee.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiRequest = Core.Helpers.ApiCall;

namespace Eurotorg_trainee.Service
{
    public class CurrencyAPI
    {
        private readonly ApiRequest apiRequest = new ApiRequest();

        public async ValueTask<IEnumerable<Currency>> GetCurrencyList()
        {
            var currencies = await apiRequest
                .GetAsync<IEnumerable<Currency>>("https://api.nbrb.by/exrates/currencies")
                .ConfigureAwait(false);
            return currencies;
        }
    }
}

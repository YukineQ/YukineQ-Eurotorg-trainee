using Eurotorg_trainee.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using ApiRequest = Eurotorg_trainee.Helpers.ApiCall;

namespace Eurotorg_trainee.Service
{
    public class ExRatesAPI
    {
        private readonly ApiRequest apiRequest = new ApiRequest();

        public async ValueTask<IEnumerable<Rate>> GetRatesList()
        {
            var rates = await apiRequest
                .GetAsync<IEnumerable<Rate>>("https://api.nbrb.by/exrates/rates", ExRatesOptions.Default())
                .ConfigureAwait(false);
            return rates;
        }
    }
}

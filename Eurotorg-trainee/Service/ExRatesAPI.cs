using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Eurotorg_trainee.Intefaces;
using Eurotorg_trainee.Models;
using ApiRequest = Eurotorg_trainee.Helpers.ApiCall;

namespace Eurotorg_trainee.Service
{
    public class ExRatesAPI : IExRatesAPI
    {
        private readonly ApiRequest apiRequest = new ApiRequest();

        public async ValueTask<IEnumerable<Rate>> GetRatesList(DateTime date)
        {
            var options = new (string, string)[]
            {
                ExRatesOptions.Periodicity(Periodicity_.EVERYDAY),
                ExRatesOptions.OnDate(date)
            };

            var rates = await apiRequest
                .GetAsync<IEnumerable<Rate>>("https://api.nbrb.by/exrates/rates", options)
                .ConfigureAwait(false);
            return rates;
        }

        public async ValueTask<IEnumerable<Dynamics>> GetDynamics(int id, DateTime startDate)
        {
            var url = $"https://api.nbrb.by/exrates/rates/dynamics/{id}";
            var options = ExRatesOptions.DynamicsOptions(startDate);
            var dynamics = await apiRequest
                .GetAsync<IEnumerable<Dynamics>>(url, options)
                .ConfigureAwait(false);
            return dynamics;
        }
    }
}

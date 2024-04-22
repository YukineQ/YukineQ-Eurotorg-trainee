using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Eurotorg_trainee.Models;

namespace Eurotorg_trainee.Intefaces
{
    public interface IExRatesAPI
    {
        ValueTask<IEnumerable<Rate>> GetRatesList(DateTime date);

        ValueTask<IEnumerable<Dynamics>> GetDynamics(int id, DateTime startDate);
    }
}

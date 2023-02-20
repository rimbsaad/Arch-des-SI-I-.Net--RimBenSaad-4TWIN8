using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applicationcore.Interfaces
{
    internal interface IServiceFlight
    {
        IEnumerable<IGrouping<String, Flight>> DestinationGroupedFlights()

    }
}

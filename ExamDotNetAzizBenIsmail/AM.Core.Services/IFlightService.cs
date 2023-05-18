using AM.Core.Interfaces;
using ExamDotNetAzizBenIsmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public interface IFlightService: IService<Flight>
    {
        IList<Flight> GetFlightDates(string destination);
        IList<Flight> SortFlights();

        Flight GetDetails(int id);


    }
}

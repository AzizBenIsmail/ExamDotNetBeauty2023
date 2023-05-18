using AM.Core.Interfaces;
using ExamDotNetAzizBenIsmail;

namespace AM.Core.Services
{
    public class FlightService : Service<Flight>,IFlightService
    {
        public IList<Flight> Flights { get; set; } //prop

        public FlightService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Flights = GetAll();
        }


        public IList<Flight> GetFlightDates(string destination) // linqIntegre
        {
            ////return (from f in Flights 
            ////       where f.Destination == destination
            ////       select f.FlightDate).ToList();
            //return Flights.Where(f => f.Destination.ToString() == destination) //Methoded'extention
            //    .Select(f => f.FlightDate).ToList();
            return Flights;

        }

        public IList<Flight> SortFlights()
        {
            return (from f in Flights
                    orderby f.EstimatedDuration descending
                    select f).ToList();
        }
        public Flight GetDetails(int id)
        {
            return Flights.FirstOrDefault(f => f.FlightId == id);
        }

    }
}
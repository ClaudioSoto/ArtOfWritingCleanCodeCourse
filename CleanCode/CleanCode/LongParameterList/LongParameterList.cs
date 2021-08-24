
using System;
using System.Collections.Generic;

namespace CleanCode.LongParameterList
{
    public class DateRange
    {
        public DateRange(DateTime dateFrom, DateTime dateTo)
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
        }

        public DateTime DateFrom { get; private set; }
        public DateTime DateTo { get; private set; }
    }


    public class LongParameterList
    {
        public IEnumerable<Reservation> GetReservations(DateRange dateRange,
           User user, int locationId,
           LocationType locationType, int? customerId = null)
        {
            if (dateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (dateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetUpcomingReservations(DateRange DateRange,
            User user, int locationId,
            LocationType locationType)
        {
            if (DateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        private static Tuple<DateTime, DateTime> GetReservationDateRange(DateRange DateRange, ReservationDefinition sd)
        {
            if (DateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }

        public void CreateReservation(DateRange DateRange, int locationId)
        {
            if (DateRange.DateFrom >= DateTime.Now)
                throw new ArgumentNullException("dateFrom");
            if (DateRange.DateTo <= DateTime.Now)
                throw new ArgumentNullException("dateTo");

            throw new NotImplementedException();
        }
    }

    internal class ReservationDefinition
    {
    }

    public class LocationType
    {
    }

    public class User
    {
        public object Id { get; set; }
    }

    public class Reservation
    {
    }
}

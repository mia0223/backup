using System;
using System.Linq;
using System.Collections.Generic;

using TEK.SeatPlan.BusinessLogic.Contract;
using TEK.SeatPlan.BusinessLogic.Mappers;

namespace TEK.SeatPlan.BusinessLogic
{
    public class SeatChangeLogComponent : DataComponentBase, ISeatChangeLogComponent
    {
        private readonly IDataService<Entity.SeatChangeLog> seatChangeLogDataService;

        public SeatChangeLogComponent(IDataService<Entity.SeatChangeLog> seatChangeLogDataService) : base()
        {
            this.seatChangeLogDataService = seatChangeLogDataService;
        }

        public Dto.SeatChangeLogPresenter[] GetSeatChangeLog()
        {
            var dayBeforeDate = PreviousWorkDay(DateTime.Today);

            var dayBeforeLog = this.GetSeatChangeLogByDate(dayBeforeDate);
            var todayLog = this.GetSeatChangeLogByDate(DateTime.Today);

            return new[]
            {
                new Dto.SeatChangeLogPresenter { ActionDate = dayBeforeDate, SeatChangeLog = FilterSeatChangeLogByBorders(dayBeforeLog) },
                new Dto.SeatChangeLogPresenter { ActionDate = DateTime.Today, SeatChangeLog = FilterSeatChangeLogByBorders(todayLog) },
            };
        }

        private IEnumerable<Dto.SeatChangeLog> GetSeatChangeLogByDate(DateTime actionDate)
        {
            var seatChangeLog = this.seatChangeLogDataService.
                Find(x => x.ActionDate.Date == actionDate,
                x => x.OrderBy(y => y.Employee.LastName).ThenBy(y => y.ActionDate),
                x => x.Employee, x => x.SourceSeat, x => x.TargetSeat, x => x.Employee.Project)?.ToDto();

            return seatChangeLog;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "SeatChangeLog")]
        private static IEnumerable<Dto.SeatChangeLog> FilterSeatChangeLogByBorders(IEnumerable<Dto.SeatChangeLog> logToFilter)
        {
            var filteredSeatChangeLog = new List<Dto.SeatChangeLog>();

            if (logToFilter != null && logToFilter.Any())
            {
                var seatChangeLog = logToFilter.FirstOrDefault();
                if (seatChangeLog != null && seatChangeLog.Employee != null)
                {
                    var currentEmployeeId = seatChangeLog.Employee.Id;

                    filteredSeatChangeLog.Add(logToFilter.First());

                    foreach (var logItem in logToFilter)
                    {
                        if (logItem.Employee.Id != currentEmployeeId)
                        {
                            filteredSeatChangeLog.Add(logItem);
                            currentEmployeeId = logItem.Employee.Id;
                        }
                        else
                        {
                            filteredSeatChangeLog.Last().TargetSeat = logItem.TargetSeat;
                        }
                    }
                }
            }

            return filteredSeatChangeLog.Where(x => x.SourceSeat.Number != x.TargetSeat.Number);
        }

        private static DateTime PreviousWorkDay(DateTime date)
        {
            do { date = date.AddDays(-1); }
            while (IsWeekend(date));

            return date;
        }

        private static bool IsWeekend(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
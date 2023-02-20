using System;

namespace AutoGTP2Tests
{
    public class DashportData
    {
        public DashportData(string dateFrom, string dateTo)
        {
            StartDateFrom = dateFrom;
            StartDateTo = dateTo;

            EndDateFrom = dateFrom;
            EndDateTo = dateTo;
        }

        public string StartDateFrom { get; set; }
        public string StartDateTo { get; set; }
        public string EndDateFrom { get; set; }
        public string EndDateTo { get; set; }
    }
}

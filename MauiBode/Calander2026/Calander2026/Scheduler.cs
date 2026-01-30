using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calander2026
{
    public partial class fScheduler : Form
    {
        DateRange monthRange = new DateRange(null, null);
        List<DateRange> weekRangeList = new List<DateRange>();

        public fScheduler()
        {
            InitializeComponent();
            PublicHolidayGenerator();
            Fill_CmbMonth();
            Fill_CmbYear();
            populateWeek();

            // Keep dropdowns in sync when the user clicks the calendar.
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            monthCalendar1.DateSelected += monthCalendar1_DateChanged;
        }

        public class DateRange
        {
            public DateTime? StartDate;
            public DateTime? EndDate;

            public DateRange(DateTime? startDate, DateTime? endDate)
            {
                StartDate = startDate;
                EndDate = endDate;
            }
        }

        public void populateWeek()
        {

            int selectedMonth = cmbMonth.SelectedIndex;
            int selectedYear = (int)cmbYear.SelectedItem;

            //Need to use value selected in the calendar
            //monthCalendar1.TodayDate.Year
            //DateTime wokringDate = new DateTime(1, 2, 3);

            //DateTime mydate = new DateTime(year, month, day);
            int startOfMonth = 1;
            int daysInMonth = DateTime.DaysInMonth(selectedYear, selectedMonth);
            DateRange aWeek = new DateRange(null, null);
            int weekIndex = 0;
            weekRangeList.Add(aWeek);

            if (txtbStartDate.Text != "")
            {
                DateTime startfMonth = DateTime.Parse(txtbStartDate.Text);
                if (startfMonth.Day > 1)
                {
                    startOfMonth = startfMonth.Day;
                }
            }
            DateTime mydate = new DateTime(selectedYear, selectedMonth, startOfMonth);

            if (txtbEndDate.Text != "")
            {
                DateTime endOfMonth = DateTime.Parse(txtbEndDate.Text);
                if (endOfMonth.Day < daysInMonth)
                {
                    daysInMonth = endOfMonth.Day;
                }
            }

            for (int dayIndex = startOfMonth; dayIndex <= daysInMonth; dayIndex++)
            {
                if ((mydate.DayOfWeek == DayOfWeek.Monday
                    || mydate.DayOfWeek == DayOfWeek.Tuesday
                    || mydate.DayOfWeek == DayOfWeek.Wednesday
                    || mydate.DayOfWeek == DayOfWeek.Thursday
                    || mydate.DayOfWeek == DayOfWeek.Friday)
                    )
                {
                    // Start of the month case
                    if (weekRangeList[weekIndex].StartDate == null && weekIndex == 0)
                    {
                        monthRange.StartDate = mydate;
                        weekRangeList[weekIndex].StartDate = mydate;
                    }

                    // Middel of the Month
                    if (mydate.DayOfWeek == DayOfWeek.Monday && weekIndex > 0)
                    {
                        weekRangeList[weekIndex].StartDate = mydate;
                    }
                }

                //middel of the month
                if (weekRangeList[weekIndex].StartDate != null
                   && weekRangeList[weekIndex].EndDate == null
                     && mydate.DayOfWeek == DayOfWeek.Friday)
                {
                    // If this Friday is within the last 2 days of the configured month,
                    // treat it as the end of the month and do not create a trailing blank week.
                    if (daysInMonth - dayIndex <= 2)
                    {
                        monthRange.EndDate = mydate;
                        weekRangeList[weekIndex].EndDate = mydate;
                    }
                    else
                    {
                        weekRangeList[weekIndex].EndDate = mydate;
                        //Reset aWeek to null
                        aWeek = new DateRange(null, null);
                        // add new blank week
                        weekRangeList.Add(aWeek);
                        weekIndex++;
                    }
                }


                //*******************************************


                //End of the month case
                if (weekRangeList[weekIndex].StartDate != null
                    && weekRangeList[weekIndex].EndDate == null
                    && daysInMonth - dayIndex <= 2
                    && mydate.DayOfWeek == DayOfWeek.Friday
                    //mydate.AddDays(1).DayOfWeek == DayOfWeek.Saturday
                    )
                {
                    monthRange.EndDate = mydate;
                    weekRangeList[weekIndex].EndDate = mydate;
                }

                // FINAL day
                if (weekRangeList[weekIndex].StartDate != null
                    && weekRangeList[weekIndex].EndDate == null
                    && dayIndex == daysInMonth)
                {
                    monthRange.EndDate = mydate;
                    weekRangeList[weekIndex].EndDate = mydate;

                    rtbOutput.AppendText(mydate.ToShortDateString() + Environment.NewLine);
                    continue;
                }


                if (mydate.DayOfWeek == DayOfWeek.Saturday || mydate.DayOfWeek == DayOfWeek.Sunday)
                {
                    rtbOutput.AppendText(mydate.DayOfWeek.ToString() + Environment.NewLine);
                    // increment to next day
                    mydate = mydate.AddDays(1);

                    // DO NOT SET ANY VALUE
                    continue;
                }

                rtbOutput.AppendText(mydate.ToShortDateString() + Environment.NewLine);

                // increment to next day
                mydate = mydate.AddDays(1);
            }

            cmbWeek.Items.Clear();
            cmbWeek.Items.Add("Select a week...");
            for (int i = 0; i <= weekIndex; i++)
            {
                cmbWeek.Items.Add(i + 1);
                rtbOutput.AppendText(Environment.NewLine);
                rtbOutput.AppendText(Environment.NewLine);
                rtbOutput.AppendText((i + 1) + " : " + weekRangeList[i].StartDate.ToString());
                rtbOutput.AppendText(Environment.NewLine);
                rtbOutput.AppendText((i + 1) + " : " + weekRangeList[i].EndDate.ToString());
            }


            txtbStartDate.Text = monthRange.StartDate.ToString();
            txtbEndDate.Text = monthRange.EndDate.ToString();
            /*
            //Calculate number of weeks if only used DateTime.Now
            DateTime today = DateTime.Now;
            //extract the month
            int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
            DateTime firstOfMonth = new DateTime(today.Year, today.Month, 1);
            //days of week starts by default as Sunday = 0
            int firstDayOfMonth = (int)firstOfMonth.DayOfWeek;
            int weeksInMonth = ((int)(firstDayOfMonth + daysInMonth) / 7);
            Console.WriteLine("5 weeks in month");
            */
        }

        private void Fill_CmbYear()
        {
            try
            {
                //clear all data from combobox
                cmbYear.Items.Clear();
                //add default item
                cmbYear.Items.Add("Select");

                var varYear = DateTime.Now.Year;
                var startYear = varYear - 5;
                var endYear = varYear + 5;
                //fill array from System.Globalization.DateTimeFormatInfo.InvariantInfo
                for (int i = startYear; i <= endYear; i++)
                {
                    cmbYear.Items.Add(i);
                }
                //set selected item for display on startup
                cmbYear.SelectedItem = varYear;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public class PublicHoliday
        {

            public string Name;
            public DateTime Date;

            public PublicHoliday(string name, DateTime date)
            {
                Name = name;
                Date = date;
            }
        }

        private void Fill_CmbMonth()
        {
            try
            {
                //clear all data from combobox
                cmbMonth.Items.Clear();
                //add default item
                cmbMonth.Items.Add("Select");
                //fill array from System.Globalization.DateTimeFormatInfo.InvariantInfo
                var Months = System.Globalization.DateTimeFormatInfo.InvariantInfo.MonthNames;
                //loop array for add items
                foreach (string sm in Months)
                {
                    if (sm != "")
                        cmbMonth.Items.Add(sm);
                }
                //set selected item for display on startup
                cmbMonth.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void PublicHolidayGenerator()
        {
            // Determine year to generate holidays for:
            // if cmbYear has an integer selected use it; otherwise fall back to current year.
            int yearToGenerate = DateTime.Now.Year;
            try
            {
                if (cmbYear.SelectedItem is int selectedYear)
                    yearToGenerate = selectedYear;
            }
            catch
            {
                yearToGenerate = DateTime.Now.Year;
            }

            // Build holidays for that year (sample South Africa list for 1..12 dates + Easter)
            List<PublicHoliday> publicHolidays = new List<PublicHoliday>();
            publicHolidays.Add(new PublicHoliday("New Year's Day", new DateTime(yearToGenerate, 1, 1)));
            publicHolidays.Add(new PublicHoliday("Human Rights Day", new DateTime(yearToGenerate, 3, 21)));
            // Good Friday and Family Day (Easter Monday) can be added if desired (example below)
            DateTime easterSunday = CalculateEasterSunday(yearToGenerate);
            publicHolidays.Add(new PublicHoliday("Good Friday", easterSunday.AddDays(-2)));
            publicHolidays.Add(new PublicHoliday("Family Day", easterSunday.AddDays(1)));
            publicHolidays.Add(new PublicHoliday("Freedom Day", new DateTime(yearToGenerate, 4, 27)));
            publicHolidays.Add(new PublicHoliday("International Workers' Day", new DateTime(yearToGenerate, 5, 1)));
            publicHolidays.Add(new PublicHoliday("Youth Day", new DateTime(yearToGenerate, 6, 16)));
            publicHolidays.Add(new PublicHoliday("National Women's Day", new DateTime(yearToGenerate, 8, 9)));
            publicHolidays.Add(new PublicHoliday("Heritage Day", new DateTime(yearToGenerate, 9, 24)));
            publicHolidays.Add(new PublicHoliday("DayOfReconciliation", new DateTime(yearToGenerate, 12, 16)));
            publicHolidays.Add(new PublicHoliday("ChristmasDay", new DateTime(yearToGenerate, 12, 25)));
            publicHolidays.Add(new PublicHoliday("BoxingDay", new DateTime(yearToGenerate, 12, 26)));

            // Collect observed dates applying SA law:
            // - If holiday falls on Sunday, the following Monday becomes a public holiday.
            // - If holiday falls on Saturday, nothing changes.
            var observedDates = new HashSet<DateTime>();
            foreach (var holiday in publicHolidays)
            {
                if (holiday.Date.DayOfWeek == DayOfWeek.Saturday)
                {
                    // Nothing to do per SA law (do not add)
                    continue;
                }

                if (holiday.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    // Observed Monday becomes a public holiday (next day)
                    var observed = holiday.Date.AddDays(1).Date;
                    observedDates.Add(observed);
                }
                else
                {
                    // Normal case: add the holiday date
                    observedDates.Add(holiday.Date.Date);
                }
            }

            // Update the MonthCalendar bolded dates with deduplicated observed dates
            monthCalendar1.RemoveAllBoldedDates();
            foreach (var d in observedDates)
            {
                monthCalendar1.AddBoldedDate(d);
            }
            monthCalendar1.UpdateBoldedDates();
        }

        /// <summary>
        /// Meeus/Jones/Butcher algorithm for Gregorian Easter Sunday
        /// (kept local for this sample; consider extracting to a utility class)
        /// </summary>
        private static DateTime CalculateEasterSunday(int year)
        {
            int a = year % 19;
            int b = year / 100;
            int c = year % 100;
            int d = b / 4;
            int e = b % 4;
            int f = (b + 8) / 25;
            int g = (b - f + 1) / 3;
            int h = (19 * a + b - d - g + 15) % 30;
            int i = c / 4;
            int k = c % 4;
            int l = (32 + 2 * e + 2 * i - h - k) % 7;
            int m = (a + 11 * h + 22 * l) / 451;
            int month = (h + l - 7 * m + 114) / 31; // 3=March, 4=April
            int day = ((h + l - 7 * m + 114) % 31) + 1;
            return new DateTime(year, month, day);
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFeedback.Text = cmbMonth.SelectedIndex.ToString();
            var selectedMonth = cmbMonth.SelectedIndex;
            int selectedYear = (int)cmbYear.SelectedItem;
            //MONTH
            if (selectedMonth == -1)
            {
                monthCalendar1.SelectionStart = new DateTime(selectedYear, DateTime.Now.Month, 1);//"1 " + cmbMonth.SelectedItem.ToString();
                monthCalendar1.SelectionEnd = new DateTime(selectedYear, DateTime.Now.Month, 1);
            }
            //YEAR
            if (selectedYear == -1)
            {
                monthCalendar1.SelectionStart = new DateTime(DateTime.Now.Year, selectedMonth, 1);//"1 " + cmbMonth.SelectedItem.ToString();
                monthCalendar1.SelectionEnd = new DateTime(DateTime.Now.Year, selectedMonth, 1);
            }
            //BOTH
            if (selectedMonth == -1 && selectedYear == -1)
            {
                monthCalendar1.SelectionStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);//"1 " + cmbMonth.SelectedItem.ToString();
                monthCalendar1.SelectionEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            else
            {
                monthCalendar1.SelectionStart = new DateTime(selectedYear, selectedMonth, 1);//"1 " + cmbMonth.SelectedItem.ToString();
                monthCalendar1.SelectionEnd = new DateTime(selectedYear, selectedMonth, 1);
            }

            // regenerate bolded holiday dates for the selected year
            try
            {
                PublicHolidayGenerator();
            }
            catch
            {
                // keep UI responsive; consider logging
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFeedback.Text = cmbMonth.SelectedIndex.ToString();
            var selectedMonth = cmbMonth.SelectedIndex;
            int selectedYear = DateTime.Now.Year;
            if (cmbYear.SelectedItem != null)
                selectedYear = (int)cmbYear.SelectedItem;

            //MONTH
            if (selectedMonth == -1)
            {
                monthCalendar1.SelectionStart = new DateTime(selectedYear, DateTime.Now.Month, 1);//"1 " + cmbMonth.SelectedItem.ToString();
                monthCalendar1.SelectionEnd = new DateTime(selectedYear, DateTime.Now.Month, 1);
            }
            //YEAR
            if (selectedYear == -1)
            {
                monthCalendar1.SelectionStart = new DateTime(DateTime.Now.Year, selectedMonth, 1);//"1 " + cmbMonth.SelectedItem.ToString();
                monthCalendar1.SelectionEnd = new DateTime(DateTime.Now.Year, selectedMonth, 1);
            }
            //BOTH
            if (selectedMonth == -1 && selectedYear == -1)
            {
                monthCalendar1.SelectionStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);//"1 " + cmbMonth.SelectedItem.ToString();
                monthCalendar1.SelectionEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            }
            else
            {
                monthCalendar1.SelectionStart = new DateTime(selectedYear, selectedMonth, 1);//"1 " + cmbMonth.SelectedItem.ToString();
                monthCalendar1.SelectionEnd = new DateTime(selectedYear, selectedMonth, 1);
            }
        }

        private void cmbWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = cmbWeek.SelectedIndex; // 0 = "Select a week..."
            if (i <= 0) return;
            int idx = i - 1;
            if (idx < 0 || idx >= weekRangeList.Count) return;
            var dr = weekRangeList[idx];
            if (!dr.StartDate.HasValue || !dr.EndDate.HasValue) return; // or show a message
            monthCalendar1.SelectionStart = dr.StartDate.Value;
            monthCalendar1.SelectionEnd = dr.EndDate.Value;
        }

        private void btnUpdateStartDate_Click(object sender, EventArgs e)
        {
            txtbStartDate.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void btnUpdateEndDate_Click(object sender, EventArgs e)
        {
            txtbEndDate.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void btnRecalculate_Click(object sender, EventArgs e)
        {
            // Rebuild weeks, then select the first week (if present) so the calendar highlights it.
            weekRangeList.Clear();
            rtbOutput.Clear();
            populateWeek();

            // Ensure the UI selects the first real week (index 1 in combo) when available.
            if (cmbWeek.Items.Count > 1)
            {
                cmbWeek.SelectedIndex = 1;
            }
        }

        // New handler: update month/year dropdowns to reflect calendar selection.
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Use SelectionStart as the canonical chosen date.
            var dt = monthCalendar1.SelectionStart;
            int month = dt.Month; // 1..12
            int year = dt.Year;

            // Set month dropdown. cmbMonth items: [0]="Select", [1]=January ... so SelectedIndex == month is correct.
            if (cmbMonth.SelectedIndex != month)
            {
                // set without re-running populateWeek unintentionally (cmbMonth_SelectedIndexChanged will update the calendar but to the same date)
                cmbMonth.SelectedIndex = month;
            }

            // Set year dropdown by selecting the boxed int item if present.
            int yearIndex = cmbYear.Items.IndexOf(year);
            if (yearIndex >= 0 && cmbYear.SelectedIndex != yearIndex)
            {
                cmbYear.SelectedIndex = yearIndex;
            }
        }
    }
}

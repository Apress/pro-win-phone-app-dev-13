using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AutoCompleteBoxCustomFilters.Resources;

namespace AutoCompleteBoxCustomFilters
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            autoCompleteBox1.ItemsSource = new AppointmentDays();
            autoCompleteBox1.ValueMemberPath = "Day";
            autoCompleteBox1.FilterMode = AutoCompleteFilterMode.Custom;
            autoCompleteBox1.ItemFilter = AppointmentFilter;
            autoCompleteBox1.TextFilter = WeekendFilter;
        }

        public bool WeekendFilter(string search, string item)
        {
            bool isWeekend = item.Equals("Saturday") || item.Equals("Sunday");
            return item.StartsWith(search, StringComparison.OrdinalIgnoreCase) && !isWeekend;
        }

        public bool AppointmentFilter(string search, object item)
        {
            Appointment appointment = item as Appointment;
            return appointment.Day.StartsWith(search, StringComparison.OrdinalIgnoreCase);
        }
    }
}
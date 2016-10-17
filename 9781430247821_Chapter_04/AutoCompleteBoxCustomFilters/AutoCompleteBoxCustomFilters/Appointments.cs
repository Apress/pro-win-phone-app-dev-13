using System;
using System.Collections.Generic;

namespace AutoCompleteBoxCustomFilters
{
public class Appointment
{
    public string Day { get; set; }
}

public class AppointmentDays : List<Appointment>
{
    public AppointmentDays()
    {
        foreach (DayOfWeek dayOfWeek in Enum.GetValues(typeof(DayOfWeek)))
        {
            this.Add(new Appointment() { Day = dayOfWeek.ToString() });
        }
    }
}
}

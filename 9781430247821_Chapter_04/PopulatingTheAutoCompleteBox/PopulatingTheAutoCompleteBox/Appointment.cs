using System;
using System.Collections.Generic;

namespace PopulatingTheAutoCompleteBox
{
public class Appointment
{
    public string Day { get; set; }
}

public class AppointmentDays : List<Appointment>
{
    public AppointmentDays()
    {
        this.Add(new Appointment() { Day = DayOfWeek.Monday.ToString() });
        this.Add(new Appointment() { Day = DayOfWeek.Tuesday.ToString() });
        this.Add(new Appointment() { Day = DayOfWeek.Wednesday.ToString() });
        this.Add(new Appointment() { Day = DayOfWeek.Friday.ToString() });
    }
}
}

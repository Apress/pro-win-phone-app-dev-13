using System;
using Microsoft.Devices.Sensors;

namespace ShakeGestures.Classes
{
public class ShakeReading : ISensorReading
{
    public DateTimeOffset Timestamp { get; internal set; }
}
}

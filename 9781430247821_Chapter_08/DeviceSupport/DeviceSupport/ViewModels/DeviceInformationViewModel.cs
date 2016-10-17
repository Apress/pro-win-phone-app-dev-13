using System.Collections.Generic;
using Microsoft.Devices;
using Microsoft.Phone.Info;

namespace DeviceSupport.ViewModels
{
    public class DeviceInformationViewModel : Dictionary<string, object>
    {
        public DeviceInformationViewModel()
        {
            var id = (byte[])DeviceExtendedProperties.GetValue("DeviceUniqueId");
            var deviceId = System.Convert.ToBase64String(id);

            Add("Device Type", Microsoft.Devices.Environment.DeviceType.ToString().ToLower());
            Add("Name", DeviceStatus.DeviceName);
            Add("Manufacturer", DeviceStatus.DeviceManufacturer);
            Add("Unique ID", deviceId);
            Add("Memory Used", DeviceStatus.ApplicationCurrentMemoryUsage);
            Add("Firmware Ver", DeviceStatus.DeviceFirmwareVersion);
            Add("Hardware Ver", DeviceStatus.DeviceHardwareVersion);
            Add("Power Source", DeviceStatus.PowerSource.ToString());
           
        }
    }
}

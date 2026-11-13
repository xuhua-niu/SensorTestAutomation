using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorTest.Core.Models
{
    public record AlarmResult(
    
        string SensorID,
        double Temperature,
        double Threshold,
        bool IsAlarm

    );
}

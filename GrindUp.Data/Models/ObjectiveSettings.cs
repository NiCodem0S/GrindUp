using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using GrindUp.Shared.Enums;

namespace GrindUp.Data.Models
{
    [Table("ObjectiveSettings")]
    public class ObjectiveSettings
    {
        public int ObjectiveSettingsId { get; set; }
        public int ObjectiveId { get; set; }
        public int MeasurementTypeId { get; set; }
        public int FrequencyTypeId { get; set; }
        public int TargetAmount { get; set; }
        public string? CustomPeriod { get; set; } = string.Empty;
        public int DurationValue { get; set; }
        public DurationUnit DurationUnit { get; set; }
        public Objective Objective { get; set; } = new Objective();
    }
}

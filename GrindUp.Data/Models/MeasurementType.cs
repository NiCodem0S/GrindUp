using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindUp.Data.Models
{
    [Table("MeasurementTypes)")]
    public class MeasurementType
    {
        public int MeasurementTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? UnitName { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
    }
}

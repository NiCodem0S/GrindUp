using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindUp.Data.Models
{
    [Table("ProgressLogs")]
    public class ProgressLog
    {
        public int ProgressLogId { get; set; }
        public int ObjectiveId { get; set; }
        public DateTime LogDate { get; set; }
        public int Amount { get; set; }
        public string? Note { get; set; }
    }
}

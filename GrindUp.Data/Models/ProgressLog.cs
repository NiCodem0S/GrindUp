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
        public int UserId { get; set; }
        public DateTime LoggedAt { get; set; }
        public long Amount { get; set; }
        public string? Note { get; set; }
        public Objective Objective { get; set; } = new Objective();
        public AppUser User { get; set; } = new AppUser();
    }
}

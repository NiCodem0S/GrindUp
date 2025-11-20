using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrindUp.Data.Models
{
    [Table("Objectives")]
    public class Objective
    {
        public int ObjectiveId { get; set; }
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(512)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsArchived { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        bool IsPublic { get; set; }
        public ObjectiveSettings Settings { get; set; } = new ObjectiveSettings();
        public ICollection<ProgressLog> ProgressLogs { get; set; } = new List<ProgressLog>();
        public AppUser Owner { get; set; } = new AppUser();
    }
}

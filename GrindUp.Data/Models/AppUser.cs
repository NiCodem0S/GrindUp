using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GrindUp.Data.Models
{
    [Table("AppUsers")]
    public class AppUser
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Objective> Objectives { get; set; } = new List<Objective>();
        public ICollection<ProgressLog> ProgressLogs { get; set; } = new List<ProgressLog>();
    }
}

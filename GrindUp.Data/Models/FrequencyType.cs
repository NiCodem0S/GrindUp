using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindUp.Data.Models
{
    [Table("FrequencyTypes")]
    public class FrequencyType
    {
        public int FrequencyTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}

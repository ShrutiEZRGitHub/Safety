using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class SR
    {
        public string InId { get; set; } = string.Empty;
        public string ReportedBy { get; set; } = string.Empty;
        public string SafetyType { get; set; } = string.Empty;
        public string Deptmt { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Department
    {
        public string DeptName { get; set; } = string.Empty;
        public string GeoLocation { get; set; } = string.Empty;
        public string HODName { get; set; } = string.Empty;
        public string EmailTUser { get; set; } = string.Empty;
        public string EmailCCUser { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
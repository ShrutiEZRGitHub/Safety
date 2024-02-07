using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class SRList
    {
        List<SR> srlist = new List<SR>()
        {
            new SR(){InId="5235" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="350" , Status="Open"},
            new SR(){InId="5213" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="350" , Status="Close"},
            new SR(){InId="5214" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Dry Cargo" , Date=Convert.ToDateTime("22-Apr-2022") , Description="111" , Status="In Progress"},
            new SR(){InId="5214" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="Offline Exception" , Status="Closed"}

        };
        public async Task<List<SR>> SafetyReportTable()
        {
            return await Task.FromResult(srlist);
        }
    }
}
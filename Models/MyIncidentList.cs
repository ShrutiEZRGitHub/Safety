using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class MyIncidentList
    {
        List<MyIncident> incidents = new List<MyIncident>()
        {
            new MyIncident(){InId="5235" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="350" , Status="Open"},
            new MyIncident(){InId="5213" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="350" , Status="Close"},
            new MyIncident(){InId="5214" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Dry Cargo" , Date=Convert.ToDateTime("22-Apr-2022") , Description="111" , Status="In Progress"},
            new MyIncident(){InId="5214" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="Offline Exception" , Status="Closed"},
            new MyIncident(){InId="5235" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="350" , Status="Open"},
            new MyIncident(){InId="5213" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="350" , Status="Close"},
            new MyIncident(){InId="5214" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Dry Cargo" , Date=Convert.ToDateTime("22-Apr-2022") , Description="111" , Status="In Progress"},
            new MyIncident(){InId="5214" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="Offline Exception" , Status="Closed"},
            new MyIncident(){InId="5235" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="350" , Status="Open"},
            new MyIncident(){InId="5213" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="350" , Status="Close"},
            new MyIncident(){InId="5214" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Dry Cargo" , Date=Convert.ToDateTime("22-Apr-2022") , Description="111" , Status="In Progress"},
            new MyIncident(){InId="5214" , ReportedBy="5_LEVEL", SafetyType="5_LEVEL" , Deptmt="Others" , Date=Convert.ToDateTime("22-Apr-2022") , Description="Offline Exception" , Status="Closed"}
        };
        public async Task<List<MyIncident>> MyIncidentTable()
        {
            return await Task.FromResult(incidents);
        }
    }
}
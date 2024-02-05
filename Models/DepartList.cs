using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class DepartList
    {
        List<Department> depart = new List<Department>()
        {
            new Department(){DeptName="AICTPL", GeoLocation="False",HODName="----",EmailTUser="----",EmailCCUser="----",Status="Active"},
            new Department(){DeptName="Engineering Services", GeoLocation="True",HODName="----",EmailTUser="----",EmailCCUser="----",Status="InActive"},
            new Department(){DeptName="Exim Yard", GeoLocation="False",HODName="----",EmailTUser="----",EmailCCUser="----",Status="Active"},
            new Department(){DeptName="Finance and Accounts", GeoLocation="True",HODName="----",EmailTUser="----",EmailCCUser="----",Status="Active"},
            new Department(){DeptName="Liquid Terminal", GeoLocation="False",HODName="----",EmailTUser="----",EmailCCUser="----",Status="InActive"},
            new Department(){DeptName="Human Resource", GeoLocation="True",HODName="----",EmailTUser="----",EmailCCUser="----",Status="Active"},
            new Department(){DeptName="Logistic (All)", GeoLocation="False",HODName="----",EmailTUser="----",EmailCCUser="----",Status="Active"},
            new Department(){DeptName="OHS", GeoLocation="True",HODName="",EmailTUser="----",EmailCCUser="----",Status="InActive"},
            new Department(){DeptName="MLTPL-LPG", GeoLocation="False",HODName="----",EmailTUser="",EmailCCUser="",Status="Active"},
            new Department(){DeptName="Railway Services", GeoLocation="True",HODName="----",EmailTUser="----",EmailCCUser="----",Status="Active"},
        };
        public async Task<List<Department>> DepartTable()
        {
            return await Task.FromResult(depart);
        }
    }
}
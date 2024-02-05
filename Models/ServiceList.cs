using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class ServiceList
    {
        List<ServiceP> service = new List<ServiceP>()
        {
            new ServiceP(){ServiceProvider="Service PRO 1",Status="Active"},
            new ServiceP(){ServiceProvider="Test SO 02",Status="Inactive"},
            new ServiceP(){ServiceProvider="Active SP02",Status="Inactive"},
            new ServiceP(){ServiceProvider="MANUAL S ERVICES",Status="Active"},
            new ServiceP(){ServiceProvider="TRANS SERVICES",Status="Active"},
            new ServiceP(){ServiceProvider="Suraj Informatics",Status="Active"},
            new ServiceP(){ServiceProvider="Services Provider",Status="Active"},
            new ServiceP(){ServiceProvider="Services Provider",Status="Active"}

        };
        public async Task<List<ServiceP>> ServiceTable()
        {
            return await Task.FromResult(service);
        }
    }
}
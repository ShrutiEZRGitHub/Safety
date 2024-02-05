using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class FirmList
    {
        List<Firm> firm = new List<Firm>()
        {
            new Firm(){FirmName="Active Cargo Movers",Status="Active"},
            new Firm(){FirmName="Access Computech",Status="Inactive"},
            new Firm(){FirmName="Accurate  PMS",Status="Inactive"},
            new Firm(){FirmName="Aditya Marine",Status="Active"},
            new Firm(){FirmName="Anjani Udyog",Status="Active"},
            new Firm(){FirmName="Apex Techno",Status="Active"},
            new Firm(){FirmName="Anjani Udyog PVT L",Status="Active"},
            new Firm(){FirmName="Apex Techno",Status="Active"}
        };

        public async Task<List<Firm>> FirmTable()
        {
            return await Task.FromResult(firm);
        }
    }
}
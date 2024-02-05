using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class WalkTypeList
    {
        List<WalkType> walktype = new List<WalkType>()
        {
            new WalkType(){Walk_Type="General Round",Status="Active"},
            new WalkType(){Walk_Type="Night Round",Status="Inactive"},
            new WalkType(){Walk_Type="Safety Interaction",Status="Inactive"},
            new WalkType(){Walk_Type="SRFA",Status="Active"},
            new WalkType(){Walk_Type="Inspection",Status="Active"},
            new WalkType(){Walk_Type="Walk 12",Status="Active"},
            new WalkType(){Walk_Type="New QA walk Type",Status="Active"},
            new WalkType(){Walk_Type="Walk 12",Status="Active"},
            
        };
        public async Task<List<WalkType>> WalkTypeTable()
        {
            return await Task.FromResult(walktype);
        }
    }
}
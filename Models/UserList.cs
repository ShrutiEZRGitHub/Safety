using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class UserList
    {
        List<User> users = new List<User>()
        {
            new User(){UserLevel="Level 1", FullName="Sameer",Depart="North",HOD="Yes",CNumber="+91 9145275485",Status="Active"},
            new User(){UserLevel="Level 5", FullName="Jay",Depart="Department-1",HOD="No",CNumber="+91 9145275485",Status="InActive"},
            new User(){UserLevel="Level 2", FullName="Viraj",Depart="OSY-10",HOD="Yes",CNumber="+91 9145275485",Status="Active"},
            new User(){UserLevel="Level 4", FullName="Rahul",Depart="South",HOD="No",CNumber="+91 9145275485",Status="InActive"},
            new User(){UserLevel="Level 3", FullName="Amit",Depart="West",HOD="Yes",CNumber="+91 9145275485",Status="Active"}
        };
        public async Task<List<User>> UserTable()
        {
            return await Task.FromResult(users);
        }
    }
}
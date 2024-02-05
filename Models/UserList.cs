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
            new User(){UserLevel="Level 1", FullName="Sameer",Depart="OSY-10",HOD="Yes",CNumber="+91 9145275485",Status="Active"},
            new User(){UserLevel="Level 1", FullName="Jay",Depart="Department-1",HOD="No",CNumber="+91 9145275485",Status="InActive"},
            new User(){UserLevel="Level 2", FullName="Viraj",Depart="OSY-10",HOD="Yes",CNumber="+91 9145275485",Status="Active"},
            new User(){UserLevel="Level 1", FullName="Rahul",Depart="Department-3",HOD="No",CNumber="+91 9145275485",Status="InActive"},
            new User(){UserLevel="Level 3", FullName="Amit",Depart="Department-2",HOD="Yes",CNumber="+91 9145275485",Status="Active"}
        };
        public async Task<List<User>> UserTable()
        {
            return await Task.FromResult(users);
        }
    }
}
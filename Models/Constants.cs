using System.ComponentModel;

namespace Models;

public enum APIList
{
    [Description("")] Root,
    [Description("auth")] Authentication,
    [Description("users")] Users,
    [Description("sysparams")] SysParams
}

public class APIRoutes
{
    public const string GetOTP = "/getotp";
    public const string VerifyOTP = "/verifyotp";
}

public class SignalRHubs
{
    public const string GenHubs = "/hubs/genhubs";
}

public class GenHubCallBack
{
    public const string SyncTasks = "SyncTasks";
}

public class GenHubGroups
{
    public const string HubCallBack = "HubCallBack";
}


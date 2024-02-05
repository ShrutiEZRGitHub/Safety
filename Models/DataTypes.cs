namespace Models;

public class AuthToken
{
    public string apiKey { get; set; }
    public string authToken { get; set; }
    public DateTime expTime { get; set; }
}

[DapperJson(true)]
public class Roles
{
    public record Role(string role);

    public IEnumerable<Role> roles { get; set; }
}

[DapperJson(true)]
public record BackgroundTask
{
    public bool running { get; set; }
}

[DapperJson(true)]
public class SysValueTypes
{
    public class SysValueType : EntityBase<SysValueType>
    {
        public string code { get; set; }
        public string desc { get; set; }
    }

    public IEnumerable<SysValueType> value { get; set; }
}

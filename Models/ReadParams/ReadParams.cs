namespace Models;

public class UsersReadParams : ReadParams
{
    public string? mobno { get; set; } = null;
    public string? uname { get; set; } = null;
    public string? email { get; set; } = null;
    public string? urole { get; set; } = null;
    public string? dept { get; set; } = null;
    public string? apikey { get; set; } = null;
    public bool? isapplogin { get; set; } = null; 
}

public class SysParamsReadParams : ReadParams
{
    public string systype { get; set; }
}

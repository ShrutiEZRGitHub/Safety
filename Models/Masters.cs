
namespace Models;

public class SysParams<T> : EntityBase<SysParams<T>>
{
    public string systype { get; set; }
    public T sysvalue { get; set; }
}

public class Users : EntityBase<Users>
{
    [Required(ErrorMessage = "Please enter valid Mobile No"),
    MinLength(10, ErrorMessage = "Please enter valid Mobile No"),
    MaxLength(10, ErrorMessage = "Please enter valid Mobile No")]
    public string mobno { get; set; }
    public string uname { get; set; }
    public string email { get; set; }
    public Roles urole { get; set; }
    public string apikey { get; set; }
    public bool isapplogin { get; set; }
    public string? dept { get; set; }
}

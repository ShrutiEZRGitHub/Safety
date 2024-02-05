namespace API.Queries;

public partial class APIQueries
{
    public static readonly Query Users = new()
    {
        APIBaseUri = APIList.Users.Description(),

        CreateQuery = @"INSERT INTO master.users(mobno, uname, email, urole, apikey, dept, createdby, lastmodifiedby) 
						VALUES (@mobno, @uname, @email, @urole::JSONB, RPAD(md5(random()::text), 58, floor(random()*100000000)::TEXT) || md5(now()::text||random()::text), @dept, @createdby, @lastmodifiedby)
						RETURNING uin;",
        ReadQuery = @"SELECT * FROM master.fetchusers(@offset, @limit, @uin, @isactive, @mobno, @uname, @email, @urole, @dept, @apikey, @isapplogin);",
        UpdateQuery = @"UPDATE  master.users 
                        SET     mobno = @mobno, uname = @uname, urole = @urole::JSONB, dept = @dept, 
						        isapplogin = @isapplogin, modifieddate = NOW(), modifiedby = @modifiedby, lastmodifiedby = @lastmodifiedby
						WHERE   email = @email;",
        DeleteQuery = @"UPDATE	master.users 
						SET		isactive = false, modifieddate = NOW(), modifiedby = @modifiedby, lastmodifiedby = @lastmodifiedby 
						WHERE	uin = @uin;" 
    };

    public static readonly Query SysParams = new()
    {
        APIBaseUri = APIList.SysParams.Description(),

        ReadQuery = @"SELECT * FROM master.sysparams sp WHERE systype = @systype",
        UpdateQuery = @"UPDATE master.sysparams SET sysvalue = @sysvalue::JSONB WHERE systype = @systype"
    };
}

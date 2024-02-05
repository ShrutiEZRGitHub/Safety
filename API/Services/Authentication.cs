using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace API.Services;

public class Authentication : IModule
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        string moduleURI = APIList.Authentication.Description();

        endpoints.MapGet($"{moduleURI}" + "/{param}", AuthenticateWithToken).AllowAnonymous();
        endpoints.MapGet($"{moduleURI}{APIRoutes.GetOTP}" + "/{param}", GetOTP).RequireRole(AppSettings.GetValue("EmpezarAPIs:AuthRole"));
        endpoints.MapGet($"{moduleURI}{APIRoutes.VerifyOTP}" + "/{param}/{otp}/{m2fas}", VerifyOTP).RequireRole(AppSettings.GetValue("EmpezarAPIs:AuthRole"));
    }

    public async Task<IResult> AuthenticateWithToken(string param, CancellationToken token, GoDB goDB)
    {
        var user = (await goDB.GetList<Users>(APIQueries.Users.ReadQuery, token, new UsersReadParams()
        {
            apikey = param
        })).SingleOrDefault();

        return (user != default) ? Results.Text(await AuthorizeAccessToken(user)) : Results.Unauthorized();
    }

    public async Task<string> GetOTP(string param, CancellationToken token, GoDB goDB, IMemoryCache cache, Email email, SMS sms)
    {
        UsersReadParams usersReadParams = new() { isapplogin = true };
        if ((new EmailAddressAttribute()).IsValid(param))
            usersReadParams.email = param;
        else
            usersReadParams.mobno = param;

        var verifyUser = (await goDB.GetList<Users>(APIQueries.Users.ReadQuery, token, usersReadParams)).SingleOrDefault();

        string m2faDetails = string.Empty;
        if (verifyUser != default)
        {
            if (param.StartsWith("000") || param.EndsWith("@empezar.test"))
            {
                m2faDetails = "m2faDemo";
            }
            else
            {
                if ((new EmailAddressAttribute()).IsValid(param))
                {
                    string cacheKey = Guid.NewGuid().ToString();
                    int emailOtp = Random.Shared.Next(111111, 999999);
                    await email.Send(AppSettings.GetValue("EmpezarAPIs:EmailJS:Adani_OTP_Login"), new { app_name = AppSettings.GetValue("EmpezarAPIs:AppName"), to_name = verifyUser.uname, to_email = param, login_otp = emailOtp }, token);
                    cache.Set(cacheKey, emailOtp, TimeSpan.FromMinutes(10));
                    m2faDetails = cacheKey;
                }
                else
                {
                    m2faDetails = await sms.SendOTP(verifyUser.mobno, token);
                }
            }
        }
        return m2faDetails;
    }

    public async Task<IResult> VerifyOTP(string param, int otp, string m2fas, CancellationToken token, GoDB goDB, IMemoryCache cache, SMS sms)
    {
        bool isVerified = false;

        UsersReadParams usersReadParams = new() { isapplogin = true };
        if ((new EmailAddressAttribute()).IsValid(param))
            usersReadParams.email = param;
        else
            usersReadParams.mobno = param;

        if (m2fas != "m2faDemo")
        {
            if ((new EmailAddressAttribute()).IsValid(param))
            {
                if (cache.TryGetValue(m2fas, out int emailOtp))
                    isVerified = (otp == emailOtp);
            }
            else
            {
                isVerified = await sms.VerifyOTP(m2fas, otp.ToString(), token);
            }
        }
        else
        {
            isVerified = true;
        }
        var user = (await goDB.GetList<Users>(APIQueries.Users.ReadQuery, token, usersReadParams))
                              .FirstOrDefault(_ => isVerified);

        if (user != default)
        {
            return Results.Json(new AuthToken
            {
                apiKey = user.apikey,
                authToken = await AuthorizeAccessToken(user),
                expTime = DateTime.Now.AddMinutes(Convert.ToInt32(AppSettings.GetValue("EmpezarAPIs:Jwt:Expiry")) - 5)
            });
        }
        else
        {
            return Results.Json(new AuthToken
            {
                apiKey = string.Empty,
                authToken = string.Empty,
                expTime = DateTime.Now
            });
        }
    }

    public Task<string> AuthorizeAccessToken(Users user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.uin.ToString()),
            new Claim(ClaimTypes.Name, user.uname),
            new Claim(ClaimTypes.MobilePhone, user.mobno??string.Empty),
            new Claim(ClaimTypes.Email, user.email??string.Empty),
            new Claim("Department", user.dept??string.Empty),
        };
        foreach (var r in user.urole.roles) claims.Add(new Claim(ClaimTypes.Role, r.role));

        return Task.FromResult(claims.GetToken());
    }
}

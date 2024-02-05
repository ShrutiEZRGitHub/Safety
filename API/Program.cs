var builder = WebApplication.CreateBuilder(args);
builder.AddEmpezarAPIs();

//Register Services Here
{
    //Masters
    builder.Services.AddScoped<IModule>(s => new Service<Users, UsersReadParams>(APIQueries.Users));
    builder.Services.AddScoped<IModule>(s => new Service<SysParams<object>, SysParamsReadParams>(APIQueries.SysParams));

}

var app = builder.Build();
app.UseEmpezarAPIs();

app.Run();

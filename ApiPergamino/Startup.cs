using Amazon.Lambda.Annotations;
using ApiPergamino.Data.ApiPergamino.Data;
using ApiPergamino.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiPergamino;

[LambdaStartup]
public class Startup
{

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<RepositoryEmpleados>();
        string connectionString = @"server=awsmysqlsejo.cvgm0yoms3v8.us-east-1.rds.amazonaws.com;port=3306;user id=adminsql;password=Admin123;database=television";
        services.AddDbContext<EmpleadosContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    }
}

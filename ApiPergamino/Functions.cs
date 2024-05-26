using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using ApiPergamino.Repositories;
using ApiPergamino.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ApiPergamino;

public class Functions
{

    private RepositoryEmpleados repo;

    public Functions(RepositoryEmpleados repo)
    {
        this.repo = repo;
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/")]
    public async Task<IHttpResult> Get(ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Get' Request");
        List<Empleado> empleados = await this.repo.GetPersonajesAsync();
        return HttpResults.Ok(empleados);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Get, "/find/{id}")]
    public async Task<IHttpResult> Find(int id, ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Find' Request");
        Empleado empleado = await this.repo.FindPersonajeAsync(id);
        return HttpResults.Ok(empleado);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Post, "/post")]
    public async Task<IHttpResult> Post([FromBody] Empleado empleado, ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Post' Request");
        Empleado empleadoNew = await this.repo.CreatePersonajeAsync(empleado.Apellido, empleado.Apellido, empleado.Oficio);
        return HttpResults.Ok(empleadoNew);
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Put, "/put")]
    public async Task<IHttpResult> Put([FromBody] Empleado empleado, ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Put' Request");
        await this.repo.UpdatePersonajeAsync(empleado.IdEmpleado, empleado.Apellido, empleado.Salario);
        return HttpResults.Ok("Todo Ok Jose Luis");
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Put, "/put/{id}")]
    public async Task<IHttpResult> Update(int id, [FromBody] Empleado empleado, ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Put' Request");
        await this.repo.UpdatePersonajeAsync(id, empleado.Apellido, empleado.Salario);
        return HttpResults.Ok("Todo Ok Jose Luis");
    }

    [LambdaFunction]
    [RestApi(LambdaHttpMethod.Delete, "/delete/{id}")]
    public async Task<IHttpResult> Delete(int id, ILambdaContext context)
    {
        context.Logger.LogInformation("Handling the 'Delete' Request");
        await this.repo.DeletePersonajeAsync(id);
        return HttpResults.Ok("Eliminado!!!!");
    }

}

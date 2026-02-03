using System.Text.Json;

namespace Inventory.Api.Middleware;

public class GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
{

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        object response;

        switch (exception)
        {
            case FluentValidation.ValidationException fluentEx:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                response = new
                {
                    title = "Error de validacion",
                    status = StatusCodes.Status400BadRequest,
                    errors = fluentEx.Errors.Select(err => new {err.PropertyName, err.ErrorMessage})
                };
                break;
            
            case KeyNotFoundException argEx:
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                response = new
                {
                    title = "Recurso no encontrado",
                    status = StatusCodes.Status404NotFound,
                    errors = new[] {argEx.Message}
                };
                break;
            default:
                logger.LogError(exception,"Ocurrio un error no controlado: {Message}", exception.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                response = new
                {
                    title = "Error interno del servidor", 
                    status = StatusCodes.Status500InternalServerError,
                    errors = new[]{"Ocurrio un error inesperado. por favor, contacte a soporte."}
                };
                break;
                
            
        }

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));


    }
    
    
}
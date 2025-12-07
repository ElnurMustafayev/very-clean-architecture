namespace BookingApp.Hotels.WebApi.Shared.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (FluentValidation.ValidationException exception)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            if(exception.Errors.Any() == false)
                return;

            var response = exception.Errors.Select(error =>
            {
                return new
                {
                    property = error.PropertyName,
                    message = error.ErrorMessage,
                };
            });

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
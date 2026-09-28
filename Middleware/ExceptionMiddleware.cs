public class ExceptionMiddleware
{
    public readonly RequestDelegate next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task HandlingError(HttpContext context)
    {
        try
        {
            next(context);
        }
        catch
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new{
                message = "Something went wrong!"
            });
        }
    }
}
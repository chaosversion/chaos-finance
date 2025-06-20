using ChaosFinance.Application.DTOs.Responses;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ChaosFinance.CrossCutting.Middlewares;

public class GlobalExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (InvalidOperationException ex)
        {
            await WriteErrorResponse(context, 400, ex.Message, ex.StackTrace);
        }
        catch (ArgumentException ex)
        {
            await WriteErrorResponse(context, 404, ex.Message, ex.StackTrace);
        }
        catch (UnauthorizedAccessException ex)
        {
            await WriteErrorResponse(context, 403, ex.Message, ex.StackTrace);
        }
        catch (Exception ex)
        {
            await WriteErrorResponse(context, 500, "An error occurred while processing your request.", ex.StackTrace);
        }
    }

    private async Task WriteErrorResponse(HttpContext context, int statusCode, string message, string? details)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        var result = new ErrorResponse
        {
            StatusCode = statusCode,
            Message = message,
            Details = details
        };
        await context.Response.WriteAsync(JsonSerializer.Serialize(result));
    }
}
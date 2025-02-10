using System;
using System.Linq;
using System.Threading.Tasks;
using LionBitcoin.BiddingGame.Application.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace LionBitcoin.BiddingGame;

public class MetadataFillerMiddleware
{
    private readonly RequestDelegate _next;

    public MetadataFillerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // TODO: now I am just mocking metadata but this part should be implemented correctly. 
        RequestMetadata requestMetadata = context.RequestServices.GetRequiredService<RequestMetadata>();
        if (context.Request.Headers.TryGetValue("customer_id", out StringValues headerValues))
        {
            string customerId = headerValues.Single()!;
            requestMetadata.CustomerId = Guid.Parse(customerId);
        }

        await _next(context);
    }
}
using DataClass;
using DataClass.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Utility.Extensions;

namespace webapi.Filters
{
    public class CustomAuthorizationMiddlewareResultHandler : IAuthorizationMiddlewareResultHandler
{
    private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();

    public async Task HandleAsync(
        RequestDelegate next,
        HttpContext context,
        AuthorizationPolicy policy,
        PolicyAuthorizationResult authorizeResult)
    {
        // If the authorization was forbidden and the resource had a specific requirement,
        // provide a custom 404 response.
        if (authorizeResult.Forbidden
            && authorizeResult.AuthorizationFailure!.FailedRequirements
                .OfType<Show404Requirement>().Any())
        {
            // Return a 404 to make it appear as if the resource doesn't exist.
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            return;
        }

        if(!authorizeResult.Succeeded){
            await context.Response.WriteAsJsonAsync(new ResponseBase(
                ChatroomStatusCode.JWTInvalid,
                 ChatroomStatusCode.JWTInvalid.GetDisplayName()));
            return;
        }

        // Fall back to the default implementation.
        await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
    }
}

public class Show404Requirement : IAuthorizationRequirement { }
}
using Microsoft.AspNetCore.Authorization;

namespace dry.Server;

public class UserAdminHandler : AuthorizationHandler<UserAdminRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAdminRequirement requirement)
    {
        var userClaim = context.User.FindFirst(c => c.Type == "roles" && c.Value == "user");
        var adminClaim = context.User.FindFirst(c => c.Type == "roles" && c.Value == "admin");

        if (userClaim is null && adminClaim is null)
        {
            return Task.CompletedTask;
        }

        context.Succeed(requirement);
        
        return Task.CompletedTask;
    }
}

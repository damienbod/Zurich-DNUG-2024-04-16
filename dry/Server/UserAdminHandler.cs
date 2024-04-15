using Microsoft.AspNetCore.Authorization;

namespace dry.Server;

public class UserAdminHandler : AuthorizationHandler<UserAdminRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserAdminRequirement requirement)
    {
        var userClaim = context.User.HasClaim(c => c.Type == "roles" && c.Value == "user");
        var adminClaim = context.User.HasClaim(c => c.Type == "roles" && c.Value == "admin");

        if (userClaim && adminClaim)
        {
            return Task.CompletedTask;
        }

        context.Succeed(requirement);
        
        return Task.CompletedTask;
    }
}

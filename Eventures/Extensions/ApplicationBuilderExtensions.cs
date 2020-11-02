namespace Eventures.Extensions
{
    using Eventures.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    public static class SeedRoleExtension
    {
        public static IApplicationBuilder SeedRoles(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<EventuresDbContext>())
                {
                    context.Database.EnsureCreated();

                    if (!context.Roles.Any())
                    {
                        context.Roles.Add(new IdentityRole
                        {
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });

                        context.Roles.Add(new IdentityRole
                        {
                            Name = "User",
                            NormalizedName = "USER"
                        });
                    }
                    context.SaveChanges();
                }

                return app;
            }
        }
    }
}

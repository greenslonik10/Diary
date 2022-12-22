using System;
using Diary.Entity;
using Diary.Entity.Models;
using Diary.Services.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Diary.WebAPI.AppConfiguration;

public static class RepositoryInitializer
{
    public const string MASTER_ADMIN_EMAIL = "nik@mail.ru";
    public const string MASTER_ADMIN_PASSWORD = "pass";

    private static async Task CreateGlobalAdmin(IAuthService authService)
    {
        await authService.RegisterUser(new Services.Models.RegisterStudentModel()
        {
            Login = MASTER_ADMIN_EMAIL,
            Password = MASTER_ADMIN_PASSWORD,
            Role = Entity.Models.Role.Admin

        });
    }

    public static async Task InitializeRepository(IServiceProvider provider)
    {
        using (var scope = provider.GetService<IServiceScopeFactory>().CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<Context>();            
            context.Database.Migrate();
            
            var userManager = (UserManager<Student>)scope.ServiceProvider.GetRequiredService(typeof(UserManager<Student>));
            var user = await userManager.FindByEmailAsync(MASTER_ADMIN_EMAIL);
            if (user == null)
            {
                var authService = (IAuthService)scope.ServiceProvider.GetRequiredService(typeof(IAuthService));
                await CreateGlobalAdmin(authService);
            }
        }
    }
}
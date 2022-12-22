using Diary.Entities.Models;
using Diary.Repository;
using Diary.Services.Abstract;
using NUnit.Framework;

namespace Diary.Test;

[TestFixture]
public partial class UserTests : UnitTest
{
    private  IAuthService authService;
    private  IStudentService userService;
    private  IRepository<Student> userRepository;
    
    public async override Task OneTimeSetUp()
    {
        await base.OneTimeSetUp();
        authService = services.Get<IAuthService>();
        userService = services.Get<IUserService>();
        userRepository = services.Get<IRepository<Student>>();
    }

    protected async override Task ClearDb()
    {
        var userRepository = services.Get<IRepository<Student>>();
        var users = userRepository.GetAll().ToList();
        foreach(var user in users)
        {
            userRepository.Delete(user);
        }
    }

}
using Diary.Services.Models;
using Diary.Shared.Exceptions;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Diary.Test;

[TestFixture]
public partial class StudentTests
{
    [Test]
    public async Task DeleteUser_Success()
    {
        var model = new RegisterStudentModel(){
            FirstName = "Test 1",
            LastName = "Test 2",
            Patronimyc = "Test 3",
            Password = "Test 4",
            Login = "test@test",
            Role = Entities.Models.Role.Admin            
        };

        var resultModel = await authService.RegisterStudent(model);
        userService.DeleteStudent(resultModel.Id);
        
        Assert.Throws<LogicException>(()=>
            {
                var checkUser = userService.GetUser(resultModel.Id);
            }
        );
    }

    [Test]
    public async Task DeleteUser_NotExisting()
    {
        var randomGuid = Guid.NewGuid();
        Assert.Throws<LogicException>(()=>
            userService.DeleteUser(randomGuid)
        );
    }
}
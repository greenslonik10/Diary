using Diary.Entities.Models;
using Diary.Services.Models;
using Diary.Shared.Exceptions;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Diary.Test;

[TestFixture]
public partial class SubjectTests
{
    [Test]
    public async Task GetSubject_Success()
    {
        var model = new TrainModel(){
            Name = "MAths",
        };

        var subjectId = new Guid("E40B66BC-84CE-407D-A3B4-033A340D1E68");
        var subject = subjectService.GetSubject(subjectId);

        Assert.AreEqual(model.Name, subject.Name);
    }

    [Test]
    public async Task GetSubject_NotExisting()
    {
        var subjectId = new Guid("E40B66BC-84CE-407D-A3B4-033A340D1E68");

        Assert.Throws<Exception>( ()=>
        {
            trainService.GetSubject(subjectId);
        });   
    }
}
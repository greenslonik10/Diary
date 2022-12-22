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
    public async Task CreateSubject_Success()
    {
        var model = new SubjectModel(){
            Name = "name"
        };

        var addSubject = subjectService.addSubject(model);

        var Subject = schoolService.GetSubject(addSubject.Id);

        Assert.AreEqual(model.Name, subject.Name);
    }

    [Test]
    public async Task CreateSubject_NotExisting()
    {
        var model = new SubjectModel(){
            Name = "name"
        };
        var addSubject = subjectService.addSubject(model);

        Assert.Throws<Exception>( ()=>
        {
            trainService.addSubject(model);
        });   
    }
}
using Diary.Entities.Models;
using Diary.Repository;
using Diary.Services.Abstract;
using NUnit.Framework;

namespace Diary.Test;

[TestFixture]
public partial class SubjectTests : UnitTest
{
    private  ISubjectService subjectService;
    private  IRepository<Entities.Models.Subject> subjectRepository;
    
    public async override Task OneTimeSetUp()
    {
        await base.OneTimeSetUp();
        subjectService = services.Get<ISubjectService>();
        subjectRepository = services.Get<IRepository<Entities.Models.Subject>>();
    }

    protected async override Task ClearDb()
    {
        var subjectRepository = services.Get<IRepository<Entities.Models.Subject>>();
        var subjects = subjectRepository.GetAll().ToList();
        foreach(var subject in subjects)
        {
            subjectRepository.Delete(subject);
        }
    }
}

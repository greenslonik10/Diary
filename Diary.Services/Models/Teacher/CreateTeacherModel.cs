
namespace Diary.Services.Models;
public class CreateTeacherModel {

   
    public string Login { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }
    public virtual Guid SchoolID { get; set; }
    
}
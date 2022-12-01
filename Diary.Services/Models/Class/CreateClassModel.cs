namespace Diary.Services.Models;
public class CreateClassModel {

    public string Name { get; set; }
    public virtual Guid SchoolID { get; set; }
    
}
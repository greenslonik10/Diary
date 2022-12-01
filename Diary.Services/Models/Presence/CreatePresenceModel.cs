
namespace Diary.Services.Models;
public class CreatePresenceModel {

   
    public bool Value { get; set; }
    public virtual Guid StudentID { get; set; }
    public virtual Guid ScheduleID { get; set; }

}
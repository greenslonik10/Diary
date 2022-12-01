
namespace Diary.Services.Models;
public class CreateMarkModel {

    
    public int Score { get; set; }
    public virtual Guid StudentID { get; set; }
    public virtual Guid ScheduleID { get; set; }
    
}
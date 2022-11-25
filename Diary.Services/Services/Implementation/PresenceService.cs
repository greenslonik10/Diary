using AutoMapper;
using Diary.Entity.Models;
using Diary.Repository;
using Diary.Services.Abstract;
using Diary.Services.Models;

namespace Diary.Services.Implementation;

public class PresenceService : IPresenceService
{
    private readonly IRepository<Presence> presenceRepository;
    private readonly IMapper mapper;
    public PresenceService(IRepository<Presence> presenceRepository, IMapper mapper)
    {
        this.presenceRepository = presenceRepository;
        this.mapper = mapper;
    }

    public void DeletePresence(Guid id)
    {
        var presenceToDelete = presenceRepository.GetById(id);
        if (presenceToDelete == null)
        {
            throw new Exception("Presence not found");
        }

        presenceRepository.Delete(presenceToDelete);
    }

    public PresenceModel GetPresence(Guid id)
    {
        var presence = presenceRepository.GetById(id);
        return mapper.Map<PresenceModel>(presence);
    }

    public PageModel<PresencePreviewModel> GetPresences(int limit = 20, int offset = 0)
    {
        var presences = presenceRepository.GetAll();
        int totalCount = presences.Count();
        var chunk = presences.OrderBy(x => x.Value).Skip(offset).Take(limit);

        return new PageModel<PresencePreviewModel>()
        {
            Items = mapper.Map<IEnumerable<PresencePreviewModel>>(presences),
            TotalCount = totalCount
        };
    }

    public PresenceModel UpdatePresence(Guid id, UpdatePresenceModel presence)
    {
        var existingPresence = presenceRepository.GetById(id);
        if (existingPresence == null)
        {
            throw new Exception("Presence not found");
        }

        existingPresence.Value = presence.Value;

        existingPresence = presenceRepository.Save(existingPresence);
        return mapper.Map<PresenceModel>(existingPresence);
    }
}
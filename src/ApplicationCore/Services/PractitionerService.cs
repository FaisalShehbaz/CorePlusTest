using ApplicationCore.Aggregates;
using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Services;

public class PractitionerService : IPractitionerService
{
    private readonly IDataFileService<Practitioner> _PractitionerFileService;
    public PractitionerService(IDataFileService<Practitioner> practitionerFileService)
    {
        _PractitionerFileService = practitionerFileService;
    }


    public async Task<IReadOnlyCollection<PractitionerDto>> GetPractitioners()
    {
        var data = await _PractitionerFileService.ReadFile(AppConstants.FilePath.Practitioners);
        return data.Select(prac => new PractitionerDto(prac.id, prac.name)).ToList();
    }

    public async Task<IReadOnlyCollection<PractitionerDto>> GetSupervisorPractitioners()
    {
        var data = await _PractitionerFileService.ReadFile(AppConstants.FilePath.Practitioners);
        return data.Where(practitioner => (int)practitioner.level >= 2).Select(prac => new PractitionerDto(prac.id, prac.name)).ToList();
    }
}
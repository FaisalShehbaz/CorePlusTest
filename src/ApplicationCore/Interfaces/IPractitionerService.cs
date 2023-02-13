using ApplicationCore.Aggregates;

namespace ApplicationCore.Interfaces;

public interface IPractitionerService
{
    Task<IReadOnlyCollection<PractitionerDto>> GetPractitioners();
    Task<IReadOnlyCollection<PractitionerDto>> GetSupervisorPractitioners();
}
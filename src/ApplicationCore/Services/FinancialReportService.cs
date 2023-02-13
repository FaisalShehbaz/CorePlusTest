using ApplicationCore.Aggregates;
using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System.Collections.Concurrent;
using System.Linq;

namespace ApplicationCore.Services;

public class FinancialReportService : IFinancialReportService
{
    private readonly IDataFileService<Practitioner> _PractitionerFileService;
    private readonly IDataFileService<Appointment> _AppointmentFileService;
    public FinancialReportService(
        IDataFileService<Practitioner> practitionerFileService,
        IDataFileService<Appointment> appointmentFileService)
    {
        _PractitionerFileService = practitionerFileService;
        _AppointmentFileService = appointmentFileService;
    }

    public async Task<IReadOnlyCollection<PractitionerFinancialSummaryReportDto>> GetPractitionerFinancialSummaryReport(int? practitionerId, DateOnly? startDate, DateOnly? endDate)
    {
        var practitionerData = await _PractitionerFileService.ReadFile(AppConstants.FilePath.Practitioners);
        var appointmentData = await _AppointmentFileService.ReadFile(AppConstants.FilePath.Appointments);

        if (!startDate.HasValue)
        {
            startDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-3));
        }

        if (!endDate.HasValue)
        {
            endDate = DateOnly.FromDateTime(DateTime.Now);
        }

        var appointmentFilter = appointmentData
            .Where(
            x => (practitionerId != null && x.practitioner_id == practitionerId.Value)
            && DateOnly.Parse(x.date) >= startDate && DateOnly.Parse(x.date) <= endDate)
            .Join(
                practitionerData,
                o => o.practitioner_id,
                i => i.id,
                (app, prac) =>
                new PractitionerFinancialSummaryReportDto(
                    prac.name,
                    DateOnly.Parse(app.date).ToString("MMMM"),
                    DateOnly.Parse(app.date).Month,
                    app.revenue,
                    app.cost)
                )
            .GroupBy(g => new { g.month, g.practitionerName })
            .Select(
                s => new PractitionerFinancialSummaryReportDto(
                    s.Key.practitionerName,
                    s.First().monthName,
                    s.Key.month,
                    s.Sum(r => r.revenue),
                    s.Sum(r => r.cost)));

        return appointmentFilter.ToList();
    }


    public async Task<IReadOnlyCollection<PractitionerFinancialDetailReportDto>> GetPractitionerFinancialDetailReport(int? practitionerId, int month, DateOnly? startDate, DateOnly? endDate)
    {
        var practitionerData = await _PractitionerFileService.ReadFile(AppConstants.FilePath.Practitioners);
        var appointmentData = await _AppointmentFileService.ReadFile(AppConstants.FilePath.Appointments);

        var practitionerName = practitionerData.FirstOrDefault(x => x.id == practitionerId)?.name ?? "";

        if (!startDate.HasValue)
        {
            startDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-3));
        }

        if (!endDate.HasValue)
        {
            endDate = DateOnly.FromDateTime(DateTime.Now);
        }

        var appointmentFilter = appointmentData
           .Where(
           x => (practitionerId != null && x.practitioner_id == practitionerId.Value)
           && DateOnly.Parse(x.date) >= startDate && DateOnly.Parse(x.date) <= endDate)
           .Select(
                s => new PractitionerFinancialDetailReportDto(
                    s.practitioner_id,
                    s.date,
                    practitionerName,
                    s.client_name,
                    s.appointment_type,
                    s.duration,
                    s.revenue,
                    s.cost));


        return appointmentFilter.ToList();

    }
}

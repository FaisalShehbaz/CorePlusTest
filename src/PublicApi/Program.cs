using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Services;
using PublicApi.Endpoints.Practitioner;
using PublicApi.Endpoints.Report;
using static ApplicationCore.Constants.AppConstants;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(typeof(IDataFileService<>), typeof(DataFileService<>));
builder.Services.AddSingleton<IPractitionerService, PractitionerService>();
builder.Services.AddSingleton<IFinancialReportService, FinancialReportService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyHeader()
                  .AllowAnyOrigin()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors();
var practitionerEndpoints = app.MapGroup("/api");
practitionerEndpoints.MapPractitionerEndpoints();
practitionerEndpoints.MapFinancialReportsEndpoints();

app.Run();

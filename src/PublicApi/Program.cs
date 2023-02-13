using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Services;
using PublicApi.Endpoints.Practitioner;
using PublicApi.Endpoints.Report;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton(typeof(IDataFileService<>), typeof(DataFileService<>));
builder.Services.AddSingleton<IPractitionerService, PractitionerService>();
builder.Services.AddSingleton<IFinancialReportService, FinancialReportService>();

var app = builder.Build();

var practitionerEndpoints = app.MapGroup("/api");
practitionerEndpoints.MapPractitionerEndpoints();
practitionerEndpoints.MapFinancialReportsEndpoints();

app.Run();

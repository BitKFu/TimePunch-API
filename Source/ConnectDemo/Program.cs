using TimePunch.Core.Services.ProjectService.Dto;
using TimePunch.Wcf.Api;
using TpProjectService;

Console.WriteLine("Hello, TimePunch!");

// Connect to the TimePunch Server
var timePunchInstance = new TimePunchInstance(new Uri("https://demo.timepunch-hub.com/TimePunch")); // !!!Server-URL must be replaced!!!

// Create an authentication object
var adminAuthentication = TimePunchInstance.CreateAuthentication("{user}", "{pwd}");                // !!!User name and password must be replaced!!!

// Create the project service
var projectService = timePunchInstance.CreateProjectService();

// Execute Project search
var spr = new SearchProjectsRequest(adminAuthentication, new ProjectSearchDto());
var response = projectService.SearchProjects(spr);

// Output projects
if (response.fault != null)
{
    Console.WriteLine("Error: " + response.fault.Message);
    return;
}

response.SearchProjectsResult.ForEach(p => Console.WriteLine($"--> {p.ProjectName}"));
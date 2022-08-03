# Access via the TimePunch Web API package

Since version 4.8 TimePunch offers a TimePunch Web API Nuget package for easy accessing the TimePunch web services.

It can be installed with the name: **TpWebWcf**

[NuGet Gallery | TpWebWcf](https://www.nuget.org/packages/TpWebWcf)

And is compatible with all .net frameworks due to the netStandard2.0 compliance.

## Connecting to a TimePunch Application Server
To connect to a TimePunch Application Server a new TimePunchInstance object needs to be created.

        // Connect to the TimePunch Server
        var timePunchInstance = new TimePunchInstance(new Uri("https://demo.timepunch-hub.com/TimePunch"));

## Authenticate the user
To ensure that the user is allowed to access the TimePunch instance, an authentication object needs to be created.
        
        // Create an authentication object
        var adminAuthentication = TimePunchInstance.CreateAuthentication("{user}", "{pwd}");

**Hint:** The identity parameter (third parameter) can be used to access a different TimePunch User profile, with the rights of the principal, which is the logon user (first parameter).

## Create a service connection
Next step is to create a service connection. This could be the project service as in the example, or any other service that TimePunch offers.

        // Create the project service
        var projectService = timePunchInstance.CreateProjectService();

## Execute a service call
Finally, we can execute the service call and validate the response.

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

## Furhter Documentation
For enhanced documentation read the following manual:

- [TimePunch API Dokumentation (deutsch)](http://tpwebsite.s3-eu-central-1.amazonaws.com/doc/TimePunch-API-4.8-de.pdf)
- [TimePunch API Documentation (english)](http://tpwebsite.s3-eu-central-1.amazonaws.com/doc/TimePunch-API-4.8-en.pdf)

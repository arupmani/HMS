# HMS
HMS is a sample project developed with Angular "~13.0.0" , Asp.Netcore WebAPI, EntityFramework, Asp.Net Core MVC and SQL server as Database.

Project Stucture:

1. Hotel Owner Use Cases :

    Project Name: HMSWeb : Technologies used : Angular 13, Asp.Net Core Web API, SQL Sever, JWT Bearer Token authentication is implmented.
  
    By default login provided for the user name "Admin" new user can be added via 1 time script.
  
    Admin can create room, view room list and booked status
  
  
  2. Customer User Case : 
  
    Project Name : HMSClient Technologies used: Asp.Net Core MVC, Google Authentication along with the Asp.Net core Identity and SQL Server.
    
    Customer have google authentication and can be register to the site this is handled by Asp.Net Identity tables.
    
    Customer can book room for the available date period and can view his/her bookings.
    
    Google API Client Id and Client Secret is store in User Secret.
    
    
   Executable Procedure:
    
    1 Table script and post deployment scripts are provided in the repository path executed the table script followed by PostDeploymentScript.
    
    2. Change the connection string given in appsettings.json (variable name : "HMSConnection" ) in HMSClient and HMSWeb projects
          "HMSConnection": "<LOCAL-SQLSERVER-CONNECTION-STRING>"
    3. Both project are executable in IISExpress hence the appropriate project need to be open in IDE and to be executed.
    
    

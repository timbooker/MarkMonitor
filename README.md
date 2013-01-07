MarkMonitor
===========


How To Use: 
-----------

*Prereqs :*
* VS 2010
* C# 4.0
* SQL Server 2008 R2
* NuGet

*Packages Used (should auto-generate from build in VS):*
* Simple.Data (ORM)
* structuremap (IoC)
* ASP.NET MVC 3 (Web Client)
* HtmlAgilityPack (HTML Parsing)
* NUnit (Testing)
* RhinoMocks (Unit Testing)

__Running the application__

* Run SQL in SQL.sql.
* Configurate Web.Config / App.Configs to use the correct connection string for your application (Default connection string may work fine)
* To test the app is working, run the tests + try to run the console application.
* Put a few fully qualified urls into the console window, and let it run for a while. 
* To view the resultant data, and add more - just set the web app to be the starting application and press f5.
* Put any urls into the text box, and press the "submit" button. 

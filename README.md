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
1. Run SQL in SQL.sql.
2. Configurate Web.Config / App.Configs to use the correct connection string for your application (Default connection string may work fine)
3. To test the app is working, run the tests + try to run the console application.
4. Put a few fully qualified urls into the console window, and let it run for a while. 
5. To view the resultant data, and add more - just set the web app to be the starting application and press f5.
6. Put any urls into the text box, and press the "submit" button. 
7. If you re-load the page, you will be able to see the items being added to the tree structure as the data is being gathered in the backgroud.

===========
Code Review
===========
__*Provide a review of your code, including notes about any problems or weaknesses present in the solution,*__
__*and describe what you would improve in future iterations (max 1 page):*__

By Project :
------------
* MarkMonitor.LinkCrawler.Data - Contains Domain structure and Database Repository layer.
* MarkMonitor.LinkCrawler.Data.Tests - Tests for the above
* MarkMonitor.LinkCrawler.Framework - Contains framework level helpers for relevant parts of the crawler.
* MarkMonitor.LinkCrawler.Framework.Test - Tests for above
* MarkMonitor.LinkCrawler.Service - Invokation of crawl from a url service
* MarkMonitor.LinkCrawler.Web - Contains Web UI 

As a whole, I am pleased with the solution for options for extension to be a stronger framework / web crawling application.

To Improve : 
------------
* Exception handling around the service layer, with some form of logging. This would be easily achieved out of the box with WCF service hosting and log4net (or any similar logging tool.)

* I would improve the quality of actual stored data by rather than ending the node (url path in this case when I hit a node I have found this session already, I would link the url back to the original id of that entry. This would reduce huge amounts of data replication - as well as allow for tree following to be linked back to real tree paths.





===========
Process Notes
===========
__*Explain how you approached the development task, and describe the process of solving it (max 1 page):*__

Immediate thoughts on getting the application going were :
* Create a simplistic idea of the data model, and how I would be able link found nodes back to the parent nodes.
* Usage of TPL for easy threadpool management.
* Use Simple.Data as my micro ORM of choice - as it is very easy to set up (dynamic implicit casting to model), and lightweight.
* IoC - StructureMap to be used - again due to simple set up
* Use Html.AgilityPack package to parse HTML pages downloaded
* Create simple recursive algorithm not using any threading to download, parse and save links from a web page structure.

Having implemented a simple version of this, build it up to a more formal multiple tier style project to allow for movement 
away from the Console app easily.
From here, I started splitting parts out into the logical chucks, and getting a rough version working using resharper / testing
to build out all the required interfaces.

With a now working application I started working on performance as I wasn't impressed and felt a smoother / better experience
could be created from both the service side, and the client (web) side.

On the client side, I changed the page loading from being one huge recursive request to being just requests by parentIds already
rendered asynchronously. 

I re-implemented the basic web crawling algorithm to use asynchronous call backs - allowing for continuation of threads while
the heavyweight work of page downloading was being done in the background.


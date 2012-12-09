MarkMonitor
===========
How To Use: 

Prereqs : 
VS 2010
C# 4.0
SQL Server 2008 R2
NuGet

Code Review
Provide a review of your code, including notes about any problems or weaknesses present in the solution,
and describe what you would improve in future iterations (max 1 page):

By Project : 
MarkMonitor.LinkCrawler.Data - Contains Domain structure and Database Repository layer.
MarkMonitor.LinkCrawler.Data.Tests - Tests for the above
MarkMonitor.LinkCrawler.Framework - Contains framework level helpers for relevant parts of the crawler.
MarkMonitor.LinkCrawler.Framework.Test - Tests for above
MarkMonitor.LinkCrawler.Service - Invokation of crawl from a url service
MarkMonitor.LinkCrawler.Web - Contains Web UI 

As a whole, I am pleased with the solution for options for extension to be a stronger framework / web crawling application.

I feel that things I would improve would be 

Exception handling around the service layer, with some form of logging. This would be 
easily achieved out of the box with WCF service hosting and log4net (or any similar logging tool.)

I would improve the quality of actual stored data by rather than ending the node (url path in this case when I hit a node I
have found this session already, I would link the url back to the original id of that entry. This would reduce huge amounts
of data replication - as well as allow for tree following to be linked back to real tree paths.

Process Notes
Explain how you approached the development task, and describe the process of solving it (max 1 page):

Immediate thoughts on getting the application going were a simplistic idea of the data model, and how I would 
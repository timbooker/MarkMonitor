using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using MarkMonitor.LinkCrawler.Data;
using MarkMonitor.LinkCrawler.Framework;
using StructureMap;

namespace MarkMonitor.LinkCrawler
{
	public class Program
	{
		private const int MaxDepth = 4;

		private static PageScraper _scraper;
		private static Container _container;

		static void Main(string[] args)
		{
			SetupApplication();
			const string value = "https://www.google.co.uk/search?q=test&rlz=1C1CHFX_enGB505GB505&oq=test&aqs=chrome.0.57j61j60l4.170&sugexp=chrome,mod=11&sourceid=chrome&ie=UTF-8";

			ServicePointManager.DefaultConnectionLimit = 1000;

			var sw = new Stopwatch();
			sw.Start();
			var newParentId = _container.GetInstance<StoredLinkRepository>().Save(new StoredLink()
			{
				Value = value,
				ParentId = 0,
			});

			Console.WriteLine(newParentId + " has been added - Value = " + value);
			DoWorkFor(value, newParentId, 1);

			sw.Stop();
			Console.Write(sw.Elapsed);

			Console.Read();
		}

		static void DoWorkFor(string url, int parentId, int currentDepth)
		{
			if (currentDepth < MaxDepth)
			{
				var items = _scraper.GetLinksFor(url);

				Console.BackgroundColor = ConsoleColor.White;
				Console.ForegroundColor = ConsoleColor.Black;
				Console.WriteLine("Threads : " + Process.GetCurrentProcess().Threads.Count);
				Console.WriteLine("Threads : " + Process.GetCurrentProcess().Threads.Count);
				Console.WriteLine("Threads : " + Process.GetCurrentProcess().Threads.Count);
				Console.ResetColor();

				Parallel.ForEach(items, s =>
					                        {
						                        var newParentId = _container.GetInstance<StoredLinkRepository>().Save(new StoredLink()
							                                                                                              {
								                                                                                              Value = s,
								                                                                                              ParentId =
									                                                                                              parentId,
							                                                                                              });
						                        Console.WriteLine(newParentId + " has been added - Value = " + s);

						                        if (!RecordedThisSessionEntries.Contains(s))
						                        {
							                        RecordedThisSessionEntries.Add(s);
							                        DoWorkFor(s, newParentId, currentDepth + 1);
						                        }
					                        });
			}
		}

		private static List<string> RecordedThisSessionEntries { get; set; }

		private static void SetupApplication()
		{
			_container = new Container(x =>
				                     {
					                     x.For<IPageScraper>().Use<PageScraper>();
					                     x.For<IPageDataProvider>().Use<PageDataProvider>();
					                     x.For<IStoredLinkRepository>().Use<StoredLinkRepository>();
					                     x.For<ILinkHelper>().Use<LinkHelper>();
				                     });

			_scraper = _container.GetInstance<PageScraper>();
			RecordedThisSessionEntries = new List<string>();
		}
	}
}

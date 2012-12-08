using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarkMonitor.LinkCrawler.Data;
using MarkMonitor.LinkCrawler.Framework;
using StructureMap;

namespace MarkMonitor.LinkCrawler
{
	public class Program
	{
		static void Main(string[] args)
		{
			RecordedThisSessionEntries = new List<string>();
			DoWorkFor("http://google.com", 0);
			Console.Read();
		}

		static void DoWorkFor(string url, int parentId)
		{
			var container = SetupApplication();

			var scraper = container.GetInstance<PageScraper>();

			var items = scraper.GetLinksFor(url);
			foreach (var s in items)
			{
				var newParentId = container.GetInstance<StoredLinkRepository>().Save(new StoredLink()
				{
					Value = s,
					ParentId = parentId,
				});

				if (!RecordedThisSessionEntries.Contains(s))
				{
					RecordedThisSessionEntries.Add(s);
					DoWorkFor(s, newParentId);
				}
			}
		}

		private static List<string> RecordedThisSessionEntries { get; set; }

		private static Container SetupApplication()
		{
			return new Container(x =>
				                     {
					                     x.For<IPageScraper>().Use<PageScraper>();
					                     x.For<IPageDataProvider>().Use<PageDataProvider>();
					                     x.For<IStoredLinkRepository>().Use<StoredLinkRepository>();
				                     });
		}
	}
}

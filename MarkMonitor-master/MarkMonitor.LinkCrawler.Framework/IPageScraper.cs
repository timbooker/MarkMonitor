using System.Collections.Generic;

namespace MarkMonitor.LinkCrawler.Framework
{
	public interface IPageScraper
	{
		IEnumerable<string> GetLinksFor(string url);
	}
}
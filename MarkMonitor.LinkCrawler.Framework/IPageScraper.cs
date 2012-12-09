using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarkMonitor.LinkCrawler.Framework
{
	public interface IPageScraper
	{
		Task<IEnumerable<string>> GetLinksFor(string url);
	}
}
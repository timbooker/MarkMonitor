using System.Net;

namespace MarkMonitor.LinkCrawler.Framework
{
	public class PageDataProvider : IPageDataProvider
	{
		public string GetPageFor(string url)
		{
			return new WebClient().DownloadString(url);
		}
	}
}
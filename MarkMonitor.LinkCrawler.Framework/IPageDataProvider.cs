namespace MarkMonitor.LinkCrawler.Framework
{
	public interface IPageDataProvider
	{
		string GetPageFor(string url);
	}
}
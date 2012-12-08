namespace MarkMonitor.LinkCrawler.Framework
{
	public interface ILinkHelper
	{
		string ParseLink(string hrefValue, string url);
	}
}
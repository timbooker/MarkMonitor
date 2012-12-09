using System.Threading.Tasks;

namespace MarkMonitor.LinkCrawler.Framework
{
	public interface IPageDataProvider
	{
		Task<string> GetPageFor(string url);
	}
}
using System.Linq;
using System.Text;

namespace MarkMonitor.LinkCrawler.Service
{
    public interface ICrawlerService
    {
        bool Crawl(string seedUrlValue);
    }
}

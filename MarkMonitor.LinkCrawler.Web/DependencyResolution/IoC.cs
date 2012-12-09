using MarkMonitor.LinkCrawler.Data;
using MarkMonitor.LinkCrawler.Framework;
using MarkMonitor.LinkCrawler.Service;
using StructureMap;
namespace MarkMonitor.LinkCrawler.Web {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>
                                    {
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });
                            x.For<ICrawlerService>().Use<CrawlerService>();
                            x.For<IStoredLinkRepository>().Use<StoredLinkRepository>();
                            x.For<IPageScraper>().Use<PageScraper>(); 
                            x.For<ILinkHelper>().Use<LinkHelper>();
                            x.For<IPageDataProvider>().Use<PageDataProvider>();
                        });
            return ObjectFactory.Container;
        }
    }
}
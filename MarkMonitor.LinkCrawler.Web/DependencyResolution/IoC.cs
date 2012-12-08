using MarkMonitor.LinkCrawler.Data;
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
	                        x.For<IStoredLinkRepository>().Use<StoredLinkRepository>();
                        });
            return ObjectFactory.Container;
        }
    }
}
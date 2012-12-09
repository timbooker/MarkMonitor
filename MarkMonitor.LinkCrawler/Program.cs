using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using MarkMonitor.LinkCrawler.Data;
using MarkMonitor.LinkCrawler.Framework;
using MarkMonitor.LinkCrawler.Service;
using StructureMap;

namespace MarkMonitor.LinkCrawler
{
    public class Program
    {
        private static Container _container;

        static void Main(string[] args)
        {
            SetupApplication();

            while (true)
            {
                Console.WriteLine("Enter Seed Url :");
                var seedUrlValue = Console.ReadLine();
                if (seedUrlValue == "exit")
                {
                    break;
                }


                if (Uri.IsWellFormedUriString(seedUrlValue, UriKind.Absolute))
                {
                    _container.GetInstance<ICrawlerService>().Crawl(seedUrlValue);
                }
                else
                {
                    Console.WriteLine("Invalid Seed Url");
                }
            }
        }

        private static void SetupApplication()
        {
            ServicePointManager.DefaultConnectionLimit = 1000;
            _container = new Container(x =>
                                     {
                                         x.For<IPageScraper>().Use<PageScraper>();
                                         x.For<IPageDataProvider>().Use<PageDataProvider>();
                                         x.For<IStoredLinkRepository>().Use<StoredLinkRepository>();
                                         x.For<ILinkHelper>().Use<LinkHelper>();
                                         x.For<ICrawlerService>().Use<CrawlerService>();
                                     });
        }

    }


}

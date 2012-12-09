using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MarkMonitor.LinkCrawler.Data;
using MarkMonitor.LinkCrawler.Framework;

namespace MarkMonitor.LinkCrawler.Service
{
    public class CrawlerService : ICrawlerService
    {
        private readonly IPageScraper _pageScraper;
        private readonly IStoredLinkRepository _storedLinkRepository;
        private readonly int _maxDepth;

        public CrawlerService(IPageScraper pageScraper, IStoredLinkRepository storedLinkRepository)
        {
            _maxDepth = 3;
            _pageScraper = pageScraper;
            _storedLinkRepository = storedLinkRepository;

            RecordedThisSessionEntries = new List<string>();
        }

        public bool Crawl(string seedUrlValue)
        {
            var success = true;
            try
            {
                var parentId = _storedLinkRepository.Save(new StoredLink()
                {
                    Value = seedUrlValue,
                    ParentId = 0,
                });

                DoWorkFor(seedUrlValue, parentId, 0);   
            }
            catch(Exception ex)
            {
                success = false;
            }

            return success;
        }

        private void DoWorkFor(string url, int parentId, int currentDepth)
        {
            if (currentDepth >= _maxDepth) return;

            _pageScraper.GetLinksFor(url).ContinueWith(x => Continuation(x, parentId, currentDepth));
           //WriteThreadTrace();
        }

        private void Continuation(Task<IEnumerable<string>> items, int parentId, int currentDepth)
        {
            Parallel.ForEach(items.Result, s =>
                                               {
                                                   var newParentId = _storedLinkRepository.Save(new StoredLink()
                                                                                                    {
                                                                                                        Value = s,
                                                                                                        ParentId = parentId,
                                                                                                    });
                                                   // Console.WriteLine(newParentId + " has been added - Value = " + s);

                                                   if (!RecordedThisSessionEntries.Contains(s))
                                                   {
                                                       RecordedThisSessionEntries.Add(s);
                                                       DoWorkFor(s, newParentId, currentDepth + 1);
                                                   }
                                               });
        }

        private static void WriteThreadTrace()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Threads : " + Process.GetCurrentProcess().Threads.Count);
            Console.WriteLine("Threads : " + Process.GetCurrentProcess().Threads.Count);
            Console.WriteLine("Threads : " + Process.GetCurrentProcess().Threads.Count);
            Console.ResetColor();
        }

        private List<string> RecordedThisSessionEntries { get; set; }
    }
}
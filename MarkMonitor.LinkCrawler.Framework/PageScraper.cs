using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace MarkMonitor.LinkCrawler.Framework
{
	public class PageScraper : IPageScraper
	{
		private readonly IPageDataProvider _dataProvider;

		public PageScraper(IPageDataProvider dataProvider)
		{
			_dataProvider = dataProvider;
		}

		public IEnumerable<string> GetLinksFor(string url)
		{
			var htmlDocument = new HtmlDocument();
		    var result = _dataProvider.GetPageFor(url);

            if(!string.IsNullOrWhiteSpace(result))
            {
                htmlDocument.LoadHtml(result);

                return htmlDocument.DocumentNode.SelectNodes("//a[@href]")
                                                .Select(x => x.GetAttributeValue("href", string.Empty));
            }

            return new List<string>();
		}
	}
}

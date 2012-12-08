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
		private readonly ILinkHelper _linkhelper;

		public PageScraper(IPageDataProvider dataProvider, ILinkHelper linkhelper)
		{
			_dataProvider = dataProvider;
			_linkhelper = linkhelper;
		}

		public IEnumerable<string> GetLinksFor(string url)
		{
			var htmlDocument = new HtmlDocument();
			var result = _dataProvider.GetPageFor(url);

			if (!string.IsNullOrWhiteSpace(result))
			{
				htmlDocument.LoadHtml(result);

				var items = htmlDocument.DocumentNode.SelectNodes("//a[@href]");
				if (items != null)
					return items.Select(x => _linkhelper.ParseLink(x.GetAttributeValue("href", string.Empty), url))
								.Where(x => !string.IsNullOrWhiteSpace(x));
			}

			return new List<string>();
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace MarkMonitor.LinkCrawler.Framework
{
	public interface IPageScraper
	{
		IEnumerable<string> GetLinksFor(string url);
	}

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
			htmlDocument.LoadHtml(_dataProvider.GetPageFor(url));

			return htmlDocument.DocumentNode.SelectNodes("//a[@href]")
											.Select(x => x.GetAttributeValue("href", string.Empty));
		}
	}

	public interface IPageDataProvider
	{
		string GetPageFor(string url);
	}

	public class PageDataProvider : IPageDataProvider
	{
		public string GetPageFor(string url)
		{
			return new WebClient().DownloadString(url);
		}
	}
}

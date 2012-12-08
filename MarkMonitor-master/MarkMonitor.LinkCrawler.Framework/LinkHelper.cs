using System;
using System.Web;

namespace MarkMonitor.LinkCrawler.Framework
{
	public class LinkHelper : ILinkHelper
	{
		public string ParseLink(string hrefValue, string url)
		{
			if (hrefValue.StartsWith("#"))
				return string.Empty;

			if (hrefValue.StartsWith("javascript"))
				return string.Empty;

			var parsedUrl = new Uri(new Uri(url), hrefValue);
			return parsedUrl.AbsoluteUri;
		}
	}
}
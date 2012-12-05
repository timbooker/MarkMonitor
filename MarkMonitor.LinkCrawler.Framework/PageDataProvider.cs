using System;
using System.Net;

namespace MarkMonitor.LinkCrawler.Framework
{
	public class PageDataProvider : IPageDataProvider
	{
		public string GetPageFor(string url)
		{
            try
            {
                return new WebClient().DownloadString(url);
            }
            catch(Exception)
            {
                
            }
		    return string.Empty;
		}
	}
}
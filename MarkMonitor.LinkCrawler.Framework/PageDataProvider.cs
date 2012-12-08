using System;
using System.IO;
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
            catch(Exception ex)
            {
				if (!File.Exists("C:\\errorsWithMM.txt"))
				{
					File.Create("C:\\errorsWithMM.txt");
				}
				try
				{
					using (var sw = File.AppendText("C:\\errorsWithMM.txt"))
					{
						sw.WriteLine(ex.Message);
					}	
				}
				catch(Exception)
				{
					
				}
            }
		    return string.Empty;
		}
	}
}
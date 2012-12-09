using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MarkMonitor.LinkCrawler.Framework
{
    public class PageDataProvider : IPageDataProvider
    {
        public Task<string> GetPageFor(string url)
        {
            return HttpGetAsync(new Uri(url)).ContinueWith(t =>
                                                                       {
                                                                           var result = t.Result as HttpWebResponse;
                                                                           return GetContentString(result);
                                                                       }
            );
        }

        public static string GetContentString(WebResponse response)
        {
            if (response != null)
            {
                using (var stream = response.GetResponseStream())
                {
                    try
                    {
                        if (stream != null)
                            using (var reader = new StreamReader(stream))
                            {
                                return reader.ReadToEnd();
                            }   
                    }
                    catch (Exception ex)
                    {
                         
                    }
                }
            }

            return string.Empty;
        }

        protected Task<WebResponse> HttpGetAsync(Uri uri)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = "GET";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Timeout = (int)1500;

                return Task.Factory.StartNew(() =>
                {
                    try
                    {
                        return request.GetResponse();
                    }
                    catch (Exception ex)
                    {
                        return null;
                    }
                });   
            }
            catch (Exception ex)
            {
            }

            return new Task<WebResponse>(() => null);
        }

    }
}
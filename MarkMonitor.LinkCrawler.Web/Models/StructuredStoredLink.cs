using System.Collections.Generic;
using MarkMonitor.LinkCrawler.Data;

namespace MarkMonitor.LinkCrawler.Web.Models
{
	public class StructuredStoredLink
	{
		public StructuredStoredLink(StoredLink storedLink)
		{
			Id = storedLink.Id;
			ParentId = storedLink.ParentId;
			Value = storedLink.Value;
		}

		public int ParentId { get; set; }
		public int Id { get; set; }
		public string Value { get; set; }
		public List<StructuredStoredLink> Children { get; set; }

		public bool HasChildren()
		{
			return Children != null && Children.Count > 0;
		}
	}
}
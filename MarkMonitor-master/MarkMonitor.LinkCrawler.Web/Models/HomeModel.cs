using System.Collections.Generic;
using System.Linq;
using MarkMonitor.LinkCrawler.Data;

namespace MarkMonitor.LinkCrawler.Web.Models
{
	public class HomeModel
	{
		private readonly IStoredLinkRepository _storedLinkRepository;

		public HomeModel(IStoredLinkRepository storedLinkRepository)
		{
			_storedLinkRepository = storedLinkRepository;
		}

		public IEnumerable<StoredLink> GetLinksForParentIdOf(int parentId)
		{
			return _storedLinkRepository.GetLinksForParentId(parentId);
		}

		/// <summary>
		/// Gets all links in the db into a structured set.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<StructuredStoredLink> GetLinks()
		{
			var parentItems = GetLinksForParentIdOf(0).Select(x => new StructuredStoredLink(x)).ToList();
			foreach (var item in parentItems)
			{
				BuildLinks(item);
			}

			return parentItems;
		}

		/// <summary>
		/// Recursive method used if eager loading
		/// </summary>
		/// <param name="link"></param>
		private void BuildLinks(StructuredStoredLink link)
		{
			link.Children =new List<StructuredStoredLink>();
			link.Children.AddRange(GetLinksForParentIdOf(link.Id).Select(x => new StructuredStoredLink(x)));
			foreach(var item in link.Children)
			{
				BuildLinks(item);
			}
		}

	}
}
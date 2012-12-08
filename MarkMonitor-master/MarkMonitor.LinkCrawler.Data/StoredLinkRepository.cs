using System.Collections.Generic;
using Simple.Data;

namespace MarkMonitor.LinkCrawler.Data
{
	public class StoredLinkRepository :IStoredLinkRepository
	{
		public int Save(StoredLink link)
		{
			return Database.Default.StoredLink.Insert(link).Id;
		}

		public void Update(StoredLink link)
		{
			Database.Default.StoredLink.Update(link);
		}

		public void Delete(int id)
		{
			Database.Default.StoredLink.Delete(id);
		}

		public StoredLink Get(int id)
		{
			return Database.Default.StoredLink.Get(id);
		}

		public IEnumerable<StoredLink> GetAll()
		{
			return Database.Default.StoredLink.FindAll(Database.Default.StoredLink.Id > 0);
		}

		public IEnumerable<StoredLink> GetLinksForParentId(int id)
		{
			return Database.Default.StoredLink.FindAllByParentId(id);
		}
	}
}
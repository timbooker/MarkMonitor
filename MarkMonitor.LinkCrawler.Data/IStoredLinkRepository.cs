using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarkMonitor.LinkCrawler.Data
{
	public interface IStoredLinkRepository
	{
		int Save(StoredLink link);
		void Update(StoredLink link);
		void Delete(int id);
		StoredLink Get(int id);
		IEnumerable<StoredLink> GetAll();
		IEnumerable<StoredLink> GetLinksForParentId(int id);
	}
}

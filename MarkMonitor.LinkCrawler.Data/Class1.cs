using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Data;

namespace MarkMonitor.LinkCrawler.Data
{
	public class StoredLink
	{
		public int Id { get; set; }
		public int ParentId { get; set; }
		public string Value { get; set; }
	}

	public interface IStoredLinkRepository
	{
		int Save(StoredLink link);
		void Update(StoredLink link);
		void Delete(int id);
		StoredLink Get(int id);
	}

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
	}
}

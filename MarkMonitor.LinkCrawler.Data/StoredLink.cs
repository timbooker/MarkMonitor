namespace MarkMonitor.LinkCrawler.Data
{
	public class StoredLink
	{
		public int Id { get; set; }
		public int ParentId { get; set; }
		public string Value { get; set; }
	}
}
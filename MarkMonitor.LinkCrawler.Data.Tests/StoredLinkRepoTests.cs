using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MarkMonitor.LinkCrawler.Data.Tests
{
	[TestFixture]
	public class StoredLinkRepoTests
	{
		[Test]
		public void can_store_a_valid_found_link()
		{
			// arrange
			var repository = new StoredLinkRepository();
			var linkToStore = new StoredLink()
				                  {
					                  Value = "http://google.com",
				                  };

			// act
			var result = repository.Save(linkToStore);


			// assert
			Assert.That(repository.Get(result), Is.Not.Null);
		}
	}
}

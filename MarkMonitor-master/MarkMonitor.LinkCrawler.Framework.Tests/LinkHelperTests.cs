using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MarkMonitor.LinkCrawler.Framework.Tests
{
	[TestFixture]
	class LinkHelperTests
	{
		private const string BaseUrl = "https://news.google.co.uk/news/story?q=test&rlz=1C1CHFX_enGB505GB505&sugexp=chrome,mod%3D11&um=1&ie=UTF-8&ncl=di5VlmJOfHq5jPMQ7gnHkmdgMet_M&hl=en&sa=X&ei=P_bBUPKmBMa3hQfpy4DwDg&ved=0CEcQqgIwCg";
		private const string BaseUrlHost = "https://news.google.co.uk";
		private const string RelativeLink = "/news/section?pz=1&cf=all&ned=uk&hl=en&q=Contact+lens&topicsid=FRONTPAGE&ict=tnv0";
		private const string JavascriptLink = "javascript:void(0)";
		private const string HashTagLink = "#";

		private const string BaseLinkFromWhichElipsisLinksOccur = "http://www.google.com/intl/en/policies/terms/?ei=TPbBUOOzDqeMwAPl0QE";
		private const string RelativeLinkWithElipsis = "../../policies/";

		[Test]
		public void expect_well_formed_link_with_baseurl_and_relative_link()
		{
			// arrange 
			var linkHelper = new LinkHelper();

			// act 
			var result = linkHelper.ParseLink(RelativeLink, BaseUrl);

			// assert
			Assert.That(result, Is.EqualTo(BaseUrlHost + RelativeLink));
		}

		[Test]
		public void expect_rejected_link_with_baseurl_and_javascript_link()
		{
			// arrange
			var linkhelper = new LinkHelper();

			// act 
			var result = linkhelper.ParseLink(JavascriptLink, BaseUrl);

			// assert
			Assert.That(result, Is.Empty);
		}

		[Test]
		public void expect_rejected_link_with_baseurl_and_hashtag_link()
		{
			// arrange
			var linkhelper = new LinkHelper();

			// act
			var result = linkhelper.ParseLink(HashTagLink, BaseUrl);

			// assert
			Assert.That(result, Is.Empty);
		}

		[Test]
		public void expect_well_formed_link_with_elipsisrelativeurl_and_appropriate_baseurl()
		{
			// arrange 
			var linkhelper = new LinkHelper();

			// act 
			var result = linkhelper.ParseLink(RelativeLinkWithElipsis, BaseLinkFromWhichElipsisLinksOccur);

			// assert
			Assert.That(result, Is.EqualTo("http://www.google.com/intl/en/policies/"));
		}
	}

}

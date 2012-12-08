using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkMonitor.LinkCrawler.Data;
using MarkMonitor.LinkCrawler.Web.Models;

namespace MarkMonitor.LinkCrawler.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IStoredLinkRepository _storedLinkRepository;

		public HomeController(IStoredLinkRepository storedLinkRepository)
		{
			_storedLinkRepository = storedLinkRepository;
		}

		public ActionResult Index()
		{
			return View();
		}

		public JsonResult GetChildrenFor(int parentId)
		{
			return new JsonResult()
					   {
						   Data = new HomeModel(_storedLinkRepository).GetLinksForParentIdOf(parentId)
																	  .Select(x =>
																		          {
																			          var hasChildren = _storedLinkRepository.GetLinksForParentId(x.Id).Any();
																			          return new {title = x.Value, key = x.Id, isLazy = hasChildren, isFolder = hasChildren};
																		          }),
						   JsonRequestBehavior = JsonRequestBehavior.AllowGet,
					   }
				;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarkMonitor.LinkCrawler.Data;
using MarkMonitor.LinkCrawler.Service;
using MarkMonitor.LinkCrawler.Web.Models;

namespace MarkMonitor.LinkCrawler.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IStoredLinkRepository _storedLinkRepository;
	    private readonly ICrawlerService _crawlerService;

	    public HomeController(IStoredLinkRepository storedLinkRepository, ICrawlerService crawlerService)
		{
		    _storedLinkRepository = storedLinkRepository;
		    _crawlerService = crawlerService;
		}

	    public ActionResult Index()
		{
			return View();
		}

        [HttpPost]
        public ActionResult Index(HomeModel inputUrlModel)
        {
            if (!string.IsNullOrWhiteSpace(inputUrlModel.Url))
            {
                inputUrlModel.IsSuccess = _crawlerService.Crawl(inputUrlModel.Url);

            }

            return View(inputUrlModel);
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

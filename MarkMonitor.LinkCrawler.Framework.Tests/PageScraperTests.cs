using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Rhino.Mocks;

namespace MarkMonitor.LinkCrawler.Framework.Tests
{
	[TestFixture]
	public class PageScraperTests
	{
		#region Test Data

		public const string SimpleTestData = @"

<html>
<body>
   <a href=""test"" />
   <a href=""test1"" />
</body>
</html>
";


		public const string TestData = @"
 
<!DOCTYPE html>
<html>
  <head prefix=""og: http://ogp.me/ns# fb: http://ogp.me/ns/fb# githubog: http://ogp.me/ns/fb/githubog#"">
    <meta charset='utf-8'>
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
        <title>timbooker/MarkMonitor</title>
    <link rel=""search"" type=""application/opensearchdescription+xml"" href=""/opensearch.xml"" title=""GitHub"" />
    <link rel=""fluid-icon"" href=""https://github.com/fluidicon.png"" title=""GitHub"" />
    <link rel=""apple-touch-icon-precomposed"" sizes=""57x57"" href=""apple-touch-icon-114.png"" />
    <link rel=""apple-touch-icon-precomposed"" sizes=""114x114"" href=""apple-touch-icon-114.png"" />
    <link rel=""apple-touch-icon-precomposed"" sizes=""72x72"" href=""apple-touch-icon-144.png"" />
    <link rel=""apple-touch-icon-precomposed"" sizes=""144x144"" href=""apple-touch-icon-144.png"" />
    <meta name=""msapplication-TileImage"" content=""/windows-tile.png"">
    <meta name=""msapplication-TileColor"" content=""#ffffff"">

    
    
    <link rel=""icon"" type=""image/x-icon"" href=""/favicon.ico"" />

    <meta content=""authenticity_token"" name=""csrf-param"" />
<meta content=""fkkD97l9FQ237t2WY1p2/aRUJHU3xtyY+6EjtrZn4nU="" name=""csrf-token"" />

    <link href=""https://a248.e.akamai.net/assets.github.com/assets/github-bd7a9aac1964f57509ff6d9dbddc6e086343bca4.css"" media=""screen"" rel=""stylesheet"" type=""text/css"" />
    <link href=""https://a248.e.akamai.net/assets.github.com/assets/github2-60a2241e211894e3a93457bd79cd7783b3f823c4.css"" media=""screen"" rel=""stylesheet"" type=""text/css"" />
    


    <script src=""https://a248.e.akamai.net/assets.github.com/assets/frameworks-eee761b9d5e06efb064aaaf528c44ef8e1601e71.js"" type=""text/javascript""></script>
    <script src=""https://a248.e.akamai.net/assets.github.com/assets/github-53606884f5c83019eec6d611078189f49512e5e2.js"" type=""text/javascript""></script>
    

      <link rel='permalink' href='/timbooker/MarkMonitor/tree/035aeef34c2f1b16158a751551802002666636fa'>
    <meta property=""og:title"" content=""MarkMonitor""/>
    <meta property=""og:type"" content=""githubog:gitrepository""/>
    <meta property=""og:url"" content=""https://github.com/timbooker/MarkMonitor""/>
    <meta property=""og:image"" content=""https://secure.gravatar.com/avatar/d060f8c89f1a745caf2befa069d3326a?s=420&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png""/>
    <meta property=""og:site_name"" content=""GitHub""/>
    <meta property=""og:description"" content=""MarkMonitor. Contribute to MarkMonitor development by creating an account on GitHub.""/>

    <meta name=""description"" content=""MarkMonitor. Contribute to MarkMonitor development by creating an account on GitHub."" />

  <link href=""https://github.com/timbooker/MarkMonitor/commits/master.atom"" rel=""alternate"" title=""Recent Commits to MarkMonitor:master"" type=""application/atom+xml"" />

  </head>


  <body class=""logged_in  windows vis-public env-production "">
    <div id=""wrapper"">

      

      

      


        <div class=""header header-logged-in true"">
          <div class=""container clearfix"">

            <a class=""header-logo-blacktocat"" href=""https://github.com/"">
  <span class=""mega-icon mega-icon-blacktocat""></span>
</a>

            <div class=""divider-vertical""></div>

              <a href=""/notifications"" class=""notification-indicator tooltipped downwards"" title=""You have no unread notifications"">
    <span class=""mail-status all-read""></span>
  </a>
  <div class=""divider-vertical""></div>


              
  <div class=""topsearch command-bar-activated"">
    <form accept-charset=""UTF-8"" action=""/search"" class=""command_bar_form"" id=""top_search_form"" method=""get"">
  <a href=""/search/advanced"" class=""advanced-search tooltipped downwards command-bar-search"" id=""advanced_search"" title=""Advanced search""><span class=""mini-icon mini-icon-advanced-search ""></span></a>

  <input type=""text"" name=""q"" id=""command-bar"" placeholder=""Search or type a command"" tabindex=""1"" data-username=""timbooker"" autocapitalize=""off"">

  <span class=""mini-icon help tooltipped downwards"" title=""Show command bar help"">
    <span class=""mini-icon mini-icon-help""></span>
  </span>

  <input type=""hidden"" name=""ref"" value=""commandbar"">

  <div class=""divider-vertical""></div>
</form>



    <ul class=""top-nav"">
        <li class=""explore""><a href=""https://github.com/explore"">Explore</a></li>
        <li><a href=""https://gist.github.com"">Gist</a></li>
        <li><a href=""/blog"">Blog</a></li>
      <li><a href=""http://help.github.com"">Help</a></li>
    </ul>
  </div>


            

  
    <ul id=""user-links"">
      <li>
        <a href=""https://github.com/timbooker"" class=""name"">
          <img height=""20"" src=""https://secure.gravatar.com/avatar/d060f8c89f1a745caf2befa069d3326a?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png"" width=""20"" /> timbooker
        </a>
      </li>
      <li>
        <a href=""/new"" id=""new_repo"" class=""tooltipped downwards"" title=""Create a new repo"">
          <span class=""mini-icon mini-icon-create""></span>
        </a>
      </li>
      <li>
        <a href=""/settings/profile"" id=""account_settings""
          class=""tooltipped downwards""
          title=""Account settings (You have no verified emails)"">
          <span class=""mini-icon mini-icon-account-settings""></span>
            <span class=""setting_warning"">!</span>
        </a>
      </li>
      <li>
          <a href=""/logout"" data-method=""post"" id=""logout"" class=""tooltipped downwards"" title=""Sign out"">
            <span class=""mini-icon mini-icon-logout""></span>
          </a>
      </li>
    </ul>



            
          </div>
        </div>


      <div class=""global-notice warn""><div class=""global-notice-inner""><h2>You don't have any verified emails.  We recommend <a href=""https://github.com/settings/emails"">verifying</a> at least one email.</h2><p>Email verification will help our support team help you in case you have any email issues or lose your password.</p></div></div>

      


            <div class=""site hfeed"" itemscope itemtype=""http://schema.org/WebPage"">
      <div class=""hentry"">
        
        <div class=""pagehead repohead instapaper_ignore readability-menu"">
          <div class=""container"">
            <div class=""title-actions-bar"">
              


                  <ul class=""pagehead-actions"">
          <li class=""nspr"">
            <a href=""/timbooker/MarkMonitor/pull/new/master"" class=""minibutton btn-pull-request"" icon_class=""mini-icon-pull-request""><span class=""mini-icon mini-icon-pull-request""></span>Pull Request</a>
          </li>

          <li class=""subscription"">
              <form accept-charset=""UTF-8"" action=""/notifications/subscribe"" data-autosubmit=""true"" data-remote=""true"" method=""post""><div style=""margin:0;padding:0;display:inline""><input name=""authenticity_token"" type=""hidden"" value=""fkkD97l9FQ237t2WY1p2/aRUJHU3xtyY+6EjtrZn4nU="" /></div>  <input id=""repository_id"" name=""repository_id"" type=""hidden"" value=""7018359"" />
  <div class=""context-menu-container js-menu-container js-context-menu"">
    <span class=""minibutton switcher bigger js-menu-target"">
      <span class=""js-context-button"">
          <span class=""mini-icon mini-icon-unwatch""></span>Unwatch
      </span>
    </span>

    <div class=""context-pane js-menu-content"">
      <a href=""javascript:;"" class=""close js-menu-close""><span class=""mini-icon mini-icon-remove-close""></span></a>
      <div class=""context-title"">Notification status</div>

      <div class=""context-body pane-selector"">
        <ul class=""js-navigation-container"">
          <li class=""selector-item js-navigation-item js-navigation-target "">
            <span class=""mini-icon mini-icon-confirm""></span>
            <label>
              <input id=""do_included"" name=""do"" type=""radio"" value=""included"" />
              <h4>Not watching</h4>
              <p>You will only receive notifications when you participate or are mentioned.</p>
            </label>
            <span class=""context-button-text js-context-button-text"">
              <span class=""mini-icon mini-icon-watching""></span>
              Watch
            </span>
          </li>
          <li class=""selector-item js-navigation-item js-navigation-target selected"">
            <span class=""mini-icon mini-icon-confirm""></span>
            <label>
              <input checked=""checked"" id=""do_subscribed"" name=""do"" type=""radio"" value=""subscribed"" />
              <h4>Watching</h4>
              <p>You will receive all notifications for this repository.</p>
            </label>
            <span class=""context-button-text js-context-button-text"">
              <span class=""mini-icon mini-icon-unwatch""></span>
              Unwatch
            </span>
          </li>
          <li class=""selector-item js-navigation-item js-navigation-target "">
            <span class=""mini-icon mini-icon-confirm""></span>
            <label>
              <input id=""do_ignore"" name=""do"" type=""radio"" value=""ignore"" />
              <h4>Ignored</h4>
              <p>You will not receive notifications for this repository.</p>
            </label>
            <span class=""context-button-text js-context-button-text"">
              <span class=""mini-icon mini-icon-mute""></span>
              Stop ignoring
            </span>
          </li>
        </ul>
      </div>
    </div>
  </div>
</form>
          </li>

          <li class=""js-toggler-container js-social-container starring-container "">
            <a href=""/timbooker/MarkMonitor/unstar"" class=""minibutton js-toggler-target starred"" data-remote=""true"" data-method=""post"" rel=""nofollow"">
              <span class=""mini-icon mini-icon-star""></span>Unstar
            </a><a href=""/timbooker/MarkMonitor/star"" class=""minibutton js-toggler-target unstarred"" data-remote=""true"" data-method=""post"" rel=""nofollow"">
              <span class=""mini-icon mini-icon-star""></span>Star
            </a><a class=""social-count js-social-count"" href=""/timbooker/MarkMonitor/stargazers"">0</a>
          </li>

              <li><a href=""/timbooker/MarkMonitor/fork"" class=""minibutton js-toggler-target fork-button lighter"" rel=""nofollow"" data-method=""post""><span class=""mini-icon mini-icon-fork""></span>Fork</a><a href=""/timbooker/MarkMonitor/network"" class=""social-count"">0</a>
              </li>


    </ul>

              <h1 itemscope itemtype=""http://data-vocabulary.org/Breadcrumb"" class=""entry-title public"">
                <span class=""repo-label""><span>public</span></span>
                <span class=""mega-icon mega-icon-public-repo""></span>
                <span class=""author vcard"">
                  <a href=""/timbooker"" class=""url fn"" itemprop=""url"" rel=""author"">
                  <span itemprop=""title"">timbooker</span>
                  </a></span> /
                <strong><a href=""/timbooker/MarkMonitor"" class=""js-current-repository"">MarkMonitor</a></strong>
              </h1>
            </div>

            

  <ul class=""tabs"">
    <li><a href=""/timbooker/MarkMonitor"" class=""selected"" highlight=""repo_sourcerepo_downloadsrepo_commitsrepo_tagsrepo_branches"">Code</a></li>
    <li><a href=""/timbooker/MarkMonitor/network"" highlight=""repo_network"">Network</a></li>
    <li><a href=""/timbooker/MarkMonitor/pulls"" highlight=""repo_pulls"">Pull Requests <span class='counter'>0</span></a></li>

      <li><a href=""/timbooker/MarkMonitor/issues"" highlight=""repo_issues"">Issues <span class='counter'>0</span></a></li>

      <li><a href=""/timbooker/MarkMonitor/wiki"" highlight=""repo_wiki"">Wiki</a></li>


    <li><a href=""/timbooker/MarkMonitor/graphs"" highlight=""repo_graphsrepo_contributors"">Graphs</a></li>

      <li>
        <a href=""/timbooker/MarkMonitor/admin"">Admin</a>
      </li>

  </ul>
  
  <div id=""repo_details"" class=""metabox clearfix
        not-editable"">
      <div id=""repo_details_loader"" class=""metabox-loader"" style=""display:none"">Sending Request&hellip;</div>

        <div class=""repo-desc-homepage"">
          

<div id=""repository_description"" class=""repository-description"">
    <p>MarkMonitor
      <span id=""read_more"" style=""display:none"">&mdash; <a href=""#readme"">Read more</a></span>
    </p>
</div>


<div class=""repository-homepage"" id=""repository_homepage"">
  <p></p>
</div>

  <a href=""#"" class=""minibutton edit-button js-edit-details"">Edit</a>

        </div>

      <div class=""edit-repo-desc-homepage"" style=""display:none"">
        <form accept-charset=""UTF-8"" action=""/timbooker/MarkMonitor/admin/update_meta"" id=""js-update-repo-meta-form"" method=""post""><div style=""margin:0;padding:0;display:inline""><input name=""_method"" type=""hidden"" value=""put"" /><input name=""authenticity_token"" type=""hidden"" value=""fkkD97l9FQ237t2WY1p2/aRUJHU3xtyY+6EjtrZn4nU="" /></div>
          <p class=""error"" style=""display:none"">Sorry, but there was a problem saving your changes.</p>
          <div>
            <input type=""text"" id=""repository-description-field"" class=""description-field"" name=""repo_description"" value=""MarkMonitor"" placeholder=""Add a description to this repository"" />

            <input type=""text"" id=""repository-homepage-field"" class=""homepage-field"" name=""repo_homepage"" value="""" placeholder=""Add a website to this repository"" />
          </div>

          <button type=""submit"" class=""classy save-button"">Save Changes</button>
          <p class=""cancel""><a href=""#"" class=""danger"">Cancel</a></p>
</form>      </div>

      
<div class=""url-box"">
  <ul class=""native-clones"">
      <li><a href=""github-windows://openRepo/https://github.com/timbooker/MarkMonitor"" class=""minibutton "" icon_class=""mini-icon-windows""><span class=""mini-icon mini-icon-windows""></span>Clone in Windows</a></li>
      <li><a href=""/timbooker/MarkMonitor/archive/master.zip"" class=""minibutton "" icon_class=""mini-icon-download"" rel=""nofollow"" title=""Download this repository as a zip file""><span class=""mini-icon mini-icon-download""></span>ZIP</a>
  </ul>

  <ul class=""clone-urls"">
    <li class=""http_clone_url selected""><a href=""https://github.com/timbooker/MarkMonitor.git"" class=""js-git-protocol-selector"" data-permission=""Read+Write"" data-url=""/users/set_protocol?protocol_selector=http&amp;protocol_type=push"">HTTP</a></li>
<li class=""private_clone_url""><a href=""git@github.com:timbooker/MarkMonitor.git"" class=""js-git-protocol-selector"" data-permission=""Read+Write"" data-url=""/users/set_protocol?protocol_selector=ssh&amp;protocol_type=push"">SSH</a></li>
<li class=""public_clone_url""><a href=""git://github.com/timbooker/MarkMonitor.git"" class=""js-git-protocol-selector"" data-permission=""Read-Only"">Git Read-Only</a></li>
  </ul>
  <input type=""text"" spellcheck=""false"" class=""url-field"" value=""https://github.com/timbooker/MarkMonitor.git"">
  <span class=""js-clippy mini-icon mini-icon-clippy url-box-clippy"" data-clipboard-text=""https://github.com/timbooker/MarkMonitor.git"" data-copied-hint=""copied!"" data-copy-hint=""copy to clipboard""></span>
  <p class=""url-description""><span class=""bold js-clone-url-permission"">Read+Write</span> access</p>
</div>

        </div>

<div class=""tabnav"">

  <span class=""tabnav-right"">
    <ul class=""tabnav-tabs"">
      <li><a href=""/timbooker/MarkMonitor/tags"" class=""tabnav-tab"" highlight=""repo_tags"">Tags <span class=""counter blank"">0</span></a></li>
      <li><a href=""/timbooker/MarkMonitor/downloads"" class=""tabnav-tab"" highlight=""repo_downloads"">Downloads <span class=""counter blank"">0</span></a></li>
    </ul>
    
  </span>

  <div class=""tabnav-widget scope"">


    <div class=""context-menu-container js-menu-container js-context-menu"">
      <a href=""#""
         class=""minibutton bigger switcher js-menu-target js-commitish-button btn-branch repo-tree""
         data-hotkey=""w""
         data-ref=""master"">
         <span><em class=""mini-icon mini-icon-branch""></em><i>branch:</i> master</span>
      </a>

      <div class=""context-pane commitish-context js-menu-content"">
        <a href=""javascript:;"" class=""close js-menu-close""><span class=""mini-icon mini-icon-remove-close""></span></a>
        <div class=""context-title"">Switch branches/tags</div>
        <div class=""context-body pane-selector commitish-selector js-navigation-container"">
          <div class=""filterbar"">
            <input type=""text"" id=""context-commitish-filter-field"" class=""js-navigation-enable js-filterable-field"" placeholder=""Filter branches/tags"">
            <ul class=""tabs"">
              <li><a href=""#"" data-filter=""branches"" class=""selected"">Branches</a></li>
                <li><a href=""#"" data-filter=""tags"">Tags</a></li>
            </ul>
          </div>

          <div class=""js-filter-tab js-filter-branches"">
            <div data-filterable-for=""context-commitish-filter-field"" data-filterable-type=substring>
                <div class=""commitish-item branch-commitish selector-item js-navigation-item js-navigation-target selected"">
                  <span class=""mini-icon mini-icon-confirm""></span>
                  <h4>
                      <a href=""/timbooker/MarkMonitor/tree/master"" class=""js-navigation-open"" data-name=""master"" rel=""nofollow"">master</a>
                  </h4>
                </div>
            </div>
            <div class=""no-results"">Nothing to show</div>
          </div>

            <div class=""js-filter-tab js-filter-tags filter-tab-empty"" style=""display:none"">
              <div data-filterable-for=""context-commitish-filter-field"" data-filterable-type=substring>
              </div>
              <div class=""no-results"">Nothing to show</div>
            </div>
        </div>
      </div><!-- /.commitish-context-context -->
    </div>
  </div> <!-- /.scope -->

  <ul class=""tabnav-tabs"">
    <li><a href=""/timbooker/MarkMonitor"" class=""selected tabnav-tab"" highlight=""repo_source"">Files</a></li>
    <li><a href=""/timbooker/MarkMonitor/commits/master"" class=""tabnav-tab"" highlight=""repo_commits"">Commits</a></li>
    <li><a href=""/timbooker/MarkMonitor/branches"" class=""tabnav-tab"" highlight=""repo_branches"" rel=""nofollow"">Branches <span class=""counter "">1</span></a></li>
  </ul>

</div>

  
  
  


            
          </div>
        </div><!-- /.repohead -->

        <div id=""js-repo-pjax-container"" class=""container context-loader-container"" data-pjax-container>
          


    

<!-- tree commit key: views10/v8/tree:v21:d7e257d83a31c32e7caabd079e65629f -->

  <div id=""slider"">


        <p class=""history-link js-history-link-replace"" data-path=""/"">
<a href=""/timbooker/MarkMonitor/commits/master"">              <span class=""mini-icon mini-icon-history tooltipped"" title=""Browse commits for this branch""></span>
              1 commit
</a>        </p>


      <div class=""breadcrumb"" data-path=""/"">
        <span class='bold'><span itemscope="""" itemtype=""http://data-vocabulary.org/Breadcrumb""><a href=""/timbooker/MarkMonitor"" class=""js-slide-to"" data-direction=""back"" itemscope=""url""><span itemprop=""title"">MarkMonitor</span></a></span></span> / 
      </div>

      <a href=""/timbooker/MarkMonitor/find/master"" class=""js-slide-to"" data-hotkey=""t"" style=""display:none"">Show File Finder</a>

        

  <div class=""frames"">
    <div class=""frame frame-center"" data-path=""/"" data-permalink-url=""/timbooker/MarkMonitor/tree/035aeef34c2f1b16158a751551802002666636fa"" data-title=""timbooker/MarkMonitor · GitHub"" data-type=""tree"">

      <div class=""bubble tree-browser-wrapper"">

      <table class=""tree-browser css-truncate"" cellpadding=""0"" cellspacing=""0"">
        <thead>
            
  <div class=""commit commit-tease js-details-container"">
    <p class=""commit-title "">
        <a href=""/timbooker/MarkMonitor/commit/035aeef34c2f1b16158a751551802002666636fa"" class=""message"">Initial commit</a>
        
    </p>
    <div class=""commit-meta"">
      <a href=""/timbooker/MarkMonitor/commit/035aeef34c2f1b16158a751551802002666636fa"" class=""sha-block"">latest commit <span class=""sha"">035aeef34c</span></a>
      <span class=""js-clippy mini-icon mini-icon-clippy "" data-clipboard-text=""035aeef34c2f1b16158a751551802002666636fa"" data-copied-hint=""copied!"" data-copy-hint=""Copy SHA""></span>

      <div class=""authorship"">
        <img class=""gravatar"" height=""20"" src=""https://secure.gravatar.com/avatar/d060f8c89f1a745caf2befa069d3326a?s=140&amp;d=https://a248.e.akamai.net/assets.github.com%2Fimages%2Fgravatars%2Fgravatar-user-420.png"" width=""20"" />
        <span class=""author-name""><a href=""/timbooker"" rel=""author"">timbooker</a></span>
        authored <time class=""js-relative-date updated"" datetime=""2012-12-05T06:01:15-08:00"" title=""2012-12-05 06:01:15"">December 05, 2012</time>

      </div>
    </div>
  </div>

        </thead>

        

<tbody class=""tree-entries js-deferred-content""
    data-url=""/timbooker/MarkMonitor/tree-commits/master"">


    <tr>
      <td class=""icon""><span class=""mini-icon mini-icon-text-file""></span></td>
      <td class=""content""><a href=""/timbooker/MarkMonitor/blob/master/README.md"" class=""js-slide-to css-truncate-target"" id=""04c6e90faac2675aa89e2176d2eec7d8-d8939f6efc39fb24ccbb93310655885a866043ce"" title=""README.md"">README.md</a></td>
      <td class=""age""></td>

      <td class=""message"">

          <span class=""loading"">
            Loading commit data...
            <img alt=""Octocat-spinner-32-eaf2f5"" height=""16"" src=""https://a248.e.akamai.net/assets.github.com/images/spinners/octocat-spinner-32-EAF2F5.gif?1340659511"" width=""16"" />
          </span>
          <span class=""error"">
            Something went wrong.
            <img alt=""Error"" src=""https://a248.e.akamai.net/assets.github.com/images/modules/ajax/error.png?1340659511"" />
          </span>
      </td>
    </tr>
</tbody>

      </table>
      </div>

        <!-- readme cache key: tree-readme:7018359:d8939f6efc39fb24ccbb93310655885a866043ce -->
        <div id=""readme"" class=""clearfix announce instapaper_body md"" data-path=""/"">
          <span class=""name""><span class=""mini-icon mini-icon-readme""></span> README.md</span><article class=""markdown-body entry-content"" itemprop=""mainContentOfPage""><h1>
<a name=""markmonitor"" class=""anchor"" href=""#markmonitor""><span class=""mini-icon mini-icon-link""></span></a>MarkMonitor</h1>

<p>MarkMonitor</p></article>
        </div>
    </div>
  </div>
  <br style=""clear:both;"">


<br style=""clear:both;"">

<div class=""frame frame-loading large-loading-area"" style=""display:none;"">
  <img alt=""Octocat-spinner-128"" height=""64"" src=""https://a248.e.akamai.net/assets.github.com/images/spinners/octocat-spinner-128.gif?1347543527"" width=""64"" />
</div>


  </div>

        </div>
      </div>
      <div class=""context-overlay""></div>
    </div>

      <div id=""footer-push""></div><!-- hack for sticky footer -->
    </div><!-- end of wrapper - hack for sticky footer -->

      <!-- footer -->
      <div id=""footer"">
  <div class=""container clearfix"">

      <dl class=""footer_nav"">
        <dt>GitHub</dt>
        <dd><a href=""https://github.com/about"">About us</a></dd>
        <dd><a href=""https://github.com/blog"">Blog</a></dd>
        <dd><a href=""https://github.com/contact"">Contact &amp; support</a></dd>
        <dd><a href=""http://enterprise.github.com/"">GitHub Enterprise</a></dd>
        <dd><a href=""http://status.github.com/"">Site status</a></dd>
      </dl>

      <dl class=""footer_nav"">
        <dt>Applications</dt>
        <dd><a href=""http://mac.github.com/"">GitHub for Mac</a></dd>
        <dd><a href=""http://windows.github.com/"">GitHub for Windows</a></dd>
        <dd><a href=""http://eclipse.github.com/"">GitHub for Eclipse</a></dd>
        <dd><a href=""http://mobile.github.com/"">GitHub mobile apps</a></dd>
      </dl>

      <dl class=""footer_nav"">
        <dt>Services</dt>
        <dd><a href=""http://get.gaug.es/"">Gauges: Web analytics</a></dd>
        <dd><a href=""http://speakerdeck.com"">Speaker Deck: Presentations</a></dd>
        <dd><a href=""https://gist.github.com"">Gist: Code snippets</a></dd>
        <dd><a href=""http://jobs.github.com/"">Job board</a></dd>
      </dl>

      <dl class=""footer_nav"">
        <dt>Documentation</dt>
        <dd><a href=""http://help.github.com/"">GitHub Help</a></dd>
        <dd><a href=""http://developer.github.com/"">Developer API</a></dd>
        <dd><a href=""http://github.github.com/github-flavored-markdown/"">GitHub Flavored Markdown</a></dd>
        <dd><a href=""http://pages.github.com/"">GitHub Pages</a></dd>
      </dl>

      <dl class=""footer_nav"">
        <dt>More</dt>
        <dd><a href=""http://training.github.com/"">Training</a></dd>
        <dd><a href=""https://github.com/edu"">Students &amp; teachers</a></dd>
        <dd><a href=""http://shop.github.com"">The Shop</a></dd>
        <dd><a href=""http://octodex.github.com/"">The Octodex</a></dd>
      </dl>

      <hr class=""footer-divider"">


    <p class=""right"">&copy; 2012 <span title=""0.11283s from fe16.rs.github.com"">GitHub</span> Inc. All rights reserved.</p>
    <a class=""left"" href=""https://github.com/"">
      <span class=""mega-icon mega-icon-invertocat""></span>
    </a>
    <ul id=""legal"">
        <li><a href=""https://github.com/site/terms"">Terms of Service</a></li>
        <li><a href=""https://github.com/site/privacy"">Privacy</a></li>
        <li><a href=""https://github.com/security"">Security</a></li>
    </ul>

  </div><!-- /.container -->

</div><!-- /.#footer -->


    

<div id=""keyboard_shortcuts_pane"" class=""instapaper_ignore readability-extra"" style=""display:none"">
  <h2>Keyboard Shortcuts <small><a href=""#"" class=""js-see-all-keyboard-shortcuts"">(see all)</a></small></h2>

  <div class=""columns threecols"">
    <div class=""column first"">
      <h3>Site wide shortcuts</h3>
      <dl class=""keyboard-mappings"">
        <dt>s</dt>
        <dd>Focus command bar</dd>
      </dl>
      <dl class=""keyboard-mappings"">
        <dt>?</dt>
        <dd>Bring up this help dialog</dd>
      </dl>
    </div><!-- /.column.first -->

    <div class=""column middle"" style='display:none'>
      <h3>Commit list</h3>
      <dl class=""keyboard-mappings"">
        <dt>j</dt>
        <dd>Move selection down</dd>
      </dl>
      <dl class=""keyboard-mappings"">
        <dt>k</dt>
        <dd>Move selection up</dd>
      </dl>
      <dl class=""keyboard-mappings"">
        <dt>c <em>or</em> o <em>or</em> enter</dt>
        <dd>Open commit</dd>
      </dl>
      <dl class=""keyboard-mappings"">
        <dt>y</dt>
        <dd>Expand URL to its canonical form</dd>
      </dl>
    </div><!-- /.column.first -->

    <div class=""column last js-hidden-pane"" style='display:none'>
      <h3>Pull request list</h3>
      <dl class=""keyboard-mappings"">
        <dt>j</dt>
        <dd>Move selection down</dd>
      </dl>
      <dl class=""keyboard-mappings"">
        <dt>k</dt>
        <dd>Move selection up</dd>
      </dl>
      <dl class=""keyboard-mappings"">
        <dt>o <em>or</em> enter</dt>
        <dd>Open issue</dd>
      </dl>
      <dl class=""keyboard-mappings"">
        <dt><span class=""platform-mac"">⌘</span><span class=""platform-other"">ctrl</span> <em>+</em> enter</dt>
        <dd>Submit comment</dd>
      </dl>
      <dl class=""keyboard-mappings"">
        <dt><span class=""platform-mac"">⌘</span><span class=""platform-other"">ctrl</span> <em>+</em> shift p</dt>
        <dd>Preview comment</dd>
      </dl>
    </div><!-- /.columns.last -->

  </div><!-- /.columns.equacols -->

  <div class=""js-hidden-pane"" style='display:none'>
    <div class=""rule""></div>

    <h3>Issues</h3>

    <div class=""columns threecols"">
      <div class=""column first"">
        <dl class=""keyboard-mappings"">
          <dt>j</dt>
          <dd>Move selection down</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>k</dt>
          <dd>Move selection up</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>x</dt>
          <dd>Toggle selection</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>o <em>or</em> enter</dt>
          <dd>Open issue</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt><span class=""platform-mac"">⌘</span><span class=""platform-other"">ctrl</span> <em>+</em> enter</dt>
          <dd>Submit comment</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt><span class=""platform-mac"">⌘</span><span class=""platform-other"">ctrl</span> <em>+</em> shift p</dt>
          <dd>Preview comment</dd>
        </dl>
      </div><!-- /.column.first -->
      <div class=""column last"">
        <dl class=""keyboard-mappings"">
          <dt>c</dt>
          <dd>Create issue</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>l</dt>
          <dd>Create label</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>i</dt>
          <dd>Back to inbox</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>u</dt>
          <dd>Back to issues</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>/</dt>
          <dd>Focus issues search</dd>
        </dl>
      </div>
    </div>
  </div>

  <div class=""js-hidden-pane"" style='display:none'>
    <div class=""rule""></div>

    <h3>Issues Dashboard</h3>

    <div class=""columns threecols"">
      <div class=""column first"">
        <dl class=""keyboard-mappings"">
          <dt>j</dt>
          <dd>Move selection down</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>k</dt>
          <dd>Move selection up</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>o <em>or</em> enter</dt>
          <dd>Open issue</dd>
        </dl>
      </div><!-- /.column.first -->
    </div>
  </div>

  <div class=""js-hidden-pane"" style='display:none'>
    <div class=""rule""></div>

    <h3>Network Graph</h3>
    <div class=""columns equacols"">
      <div class=""column first"">
        <dl class=""keyboard-mappings"">
          <dt><span class=""badmono"">←</span> <em>or</em> h</dt>
          <dd>Scroll left</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt><span class=""badmono"">→</span> <em>or</em> l</dt>
          <dd>Scroll right</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt><span class=""badmono"">↑</span> <em>or</em> k</dt>
          <dd>Scroll up</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt><span class=""badmono"">↓</span> <em>or</em> j</dt>
          <dd>Scroll down</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>t</dt>
          <dd>Toggle visibility of head labels</dd>
        </dl>
      </div><!-- /.column.first -->
      <div class=""column last"">
        <dl class=""keyboard-mappings"">
          <dt>shift <span class=""badmono"">←</span> <em>or</em> shift h</dt>
          <dd>Scroll all the way left</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>shift <span class=""badmono"">→</span> <em>or</em> shift l</dt>
          <dd>Scroll all the way right</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>shift <span class=""badmono"">↑</span> <em>or</em> shift k</dt>
          <dd>Scroll all the way up</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>shift <span class=""badmono"">↓</span> <em>or</em> shift j</dt>
          <dd>Scroll all the way down</dd>
        </dl>
      </div><!-- /.column.last -->
    </div>
  </div>

  <div class=""js-hidden-pane"" >
    <div class=""rule""></div>
    <div class=""columns threecols"">
      <div class=""column first js-hidden-pane"" >
        <h3>Source Code Browsing</h3>
        <dl class=""keyboard-mappings"">
          <dt>t</dt>
          <dd>Activates the file finder</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>l</dt>
          <dd>Jump to line</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>w</dt>
          <dd>Switch branch/tag</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>y</dt>
          <dd>Expand URL to its canonical form</dd>
        </dl>
      </div>
    </div>
  </div>

  <div class=""js-hidden-pane"" style='display:none'>
    <div class=""rule""></div>
    <div class=""columns threecols"">
      <div class=""column first"">
        <h3>Browsing Commits</h3>
        <dl class=""keyboard-mappings"">
          <dt><span class=""platform-mac"">⌘</span><span class=""platform-other"">ctrl</span> <em>+</em> enter</dt>
          <dd>Submit comment</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>escape</dt>
          <dd>Close form</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>p</dt>
          <dd>Parent commit</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>o</dt>
          <dd>Other parent commit</dd>
        </dl>
      </div>
    </div>
  </div>

  <div class=""js-hidden-pane"" style='display:none'>
    <div class=""rule""></div>
    <h3>Notifications</h3>

    <div class=""columns threecols"">
      <div class=""column first"">
        <dl class=""keyboard-mappings"">
          <dt>j</dt>
          <dd>Move selection down</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>k</dt>
          <dd>Move selection up</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>o <em>or</em> enter</dt>
          <dd>Open notification</dd>
        </dl>
      </div><!-- /.column.first -->

      <div class=""column second"">
        <dl class=""keyboard-mappings"">
          <dt>e <em>or</em> shift i <em>or</em> y</dt>
          <dd>Mark as read</dd>
        </dl>
        <dl class=""keyboard-mappings"">
          <dt>shift m</dt>
          <dd>Mute thread</dd>
        </dl>
      </div><!-- /.column.first -->
    </div>
  </div>

</div>

    <div id=""markdown-help"" class=""instapaper_ignore readability-extra"">
  <h2>Markdown Cheat Sheet</h2>

  <div class=""cheatsheet-content"">

  <div class=""mod"">
    <div class=""col"">
      <h3>Format Text</h3>
      <p>Headers</p>
      <pre>
# This is an &lt;h1&gt; tag
## This is an &lt;h2&gt; tag
###### This is an &lt;h6&gt; tag</pre>
     <p>Text styles</p>
     <pre>
*This text will be italic*
_This will also be italic_
**This text will be bold**
__This will also be bold__

*You **can** combine them*
</pre>
    </div>
    <div class=""col"">
      <h3>Lists</h3>
      <p>Unordered</p>
      <pre>
* Item 1
* Item 2
  * Item 2a
  * Item 2b</pre>
     <p>Ordered</p>
     <pre>
1. Item 1
2. Item 2
3. Item 3
   * Item 3a
   * Item 3b</pre>
    </div>
    <div class=""col"">
      <h3>Miscellaneous</h3>
      <p>Images</p>
      <pre>
![GitHub Logo](/images/logo.png)
Format: ![Alt Text](url)
</pre>
     <p>Links</p>
     <pre>
http://github.com - automatic!
[GitHub](http://github.com)</pre>
<p>Blockquotes</p>
     <pre>
As Kanye West said:

> We're living the future so
> the present is our past.
</pre>
    </div>
  </div>
  <div class=""rule""></div>

  <h3>Code Examples in Markdown</h3>
  <div class=""col"">
      <p>Syntax highlighting with <a href=""http://github.github.com/github-flavored-markdown/"" title=""GitHub Flavored Markdown"" target=""_blank"">GFM</a></p>
      <pre>
```javascript
function fancyAlert(arg) {
  if(arg) {
    $.facebox({div:'#foo'})
  }
}
```</pre>
    </div>
    <div class=""col"">
      <p>Or, indent your code 4 spaces</p>
      <pre>
Here is a Python code example
without syntax highlighting:

    def foo:
      if not bar:
        return true</pre>
    </div>
    <div class=""col"">
      <p>Inline code for comments</p>
      <pre>
I think you should use an
`&lt;addr&gt;` element here instead.</pre>
    </div>
  </div>

  </div>
</div>


    <div id=""ajax-error-message"" class=""flash flash-error"">
      <span class=""mini-icon mini-icon-exclamation""></span>
      Something went wrong with that request. Please try again.
      <a href=""#"" class=""mini-icon mini-icon-remove-close ajax-error-dismiss""></a>
    </div>

    
    
    <span id='server_response_time' data-time='0.11434' data-host='fe16'></span>
    
  </body>
</html>

";
		#endregion TestData

		[Test]
		public void when_gettingLinksFor_with_simple_data_expect_correct_number_returned()
		{
			// arrage
			var pageDataProvider = MockRepository.GenerateStub<IPageDataProvider>();
			pageDataProvider.Stub(x => x.GetPageFor(string.Empty))
							.Return(SimpleTestData)
							.IgnoreArguments();

			var linkhelper = MockRepository.GenerateStub<ILinkHelper>();
			linkhelper.Stub(x => x.ParseLink(string.Empty, string.Empty))
				.Return(string.Empty)
				.IgnoreArguments();

			// act
			var result = new PageScraper(pageDataProvider, linkhelper).GetLinksFor(string.Empty);

			// act 
			Assert.That(result.Count(), Is.EqualTo(2));
		}

		[Test]
		public void when_gettingLinksFor_with_real_looking_data_expect_correct_number_returned()
		{
			// arrage
			var pageDataProvider = MockRepository.GenerateStub<IPageDataProvider>();
			pageDataProvider.Stub(x => x.GetPageFor(string.Empty))
							.Return(TestData)
							.IgnoreArguments();

			var linkhelper = MockRepository.GenerateStub<ILinkHelper>();
			linkhelper.Stub(x => x.ParseLink(string.Empty, string.Empty))
				.Return(string.Empty)
				.IgnoreArguments();
			// act
			var result = new PageScraper(pageDataProvider, linkhelper).GetLinksFor(string.Empty);

			// act 
			Assert.That(result.Count(), Is.EqualTo(82));
		}
	}
}

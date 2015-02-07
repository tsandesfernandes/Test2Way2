using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Octokit;
using System.Threading.Tasks;

namespace Way2_Test2.Controllers
{
    public class RepositorioController : Controller
    {
        //personal access token = e9bff4045442213ae0d91b0d9e8c200147342515 
        GitHubClient github = new GitHubClient(new ProductHeaderValue("test"), new Uri("https://github.com/")) {
            Credentials = new Credentials("e9bff4045442213ae0d91b0d9e8c200147342515") 
        };

        //
        // GET: /Repositorio/

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> myRespositores()
        {
            //var repositories = await github.Repository.GetAllForCurrent() as IEnumerable<Object>;
            var repositories = await github.Repository.GetAllForCurrent() as IEnumerable<Repository>;
            return View(repositories.ToList());
                
        }

        public async Task<ActionResult> searchRepository(string name)
        {
            var repositories = await github.Search.SearchRepo(new SearchRepositoriesRequest(name));
            return View(repositories.Items.ToList());
        }
        public async Task<ActionResult> favoriteRepositories()
        {

            var repositories = await new StarredClient(new ApiConnection(github.Connection)).GetAllForCurrent();
            return View(repositories.ToList());
        }



    }
}

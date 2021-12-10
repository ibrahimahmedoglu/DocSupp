using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocSupp;
using DocSupp.Web.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Octokit;
using Scriban;
using Volo.Docs.Projects;

namespace DocSupp.Web.Pages.Documents
{


    public class IndexModel : DocSuppPageModel
    {
        public dynamic pathjson;
        public string path1;
        public string NavPath;
        public dynamic Navs;
        public dynamic Params;
        public string NavJson;
        public string Title;
        public string Documentmd;
        public string PassedPath;
        public Guid PassedProjectId;
        public string printPage;
        string GitHubRootUrl;
        string InitialPath;
        string Token;
        public int ListIndex = 0;
        public IReadOnlyList<ProjectDto> Projects { get; set; }

        private readonly IProjectAppService _projectAppService;
        public byte[] NavReader;

        public IndexModel(
            IProjectAppService projectAppService)

        {
            _projectAppService = projectAppService;
        }

            

        public async Task OnGetAsync(string Pageid, int ProjectIndex)
        {
            var listResult = await _projectAppService.GetListAsync();
            Projects = listResult.Items;
            PassedPath = Pageid;
            if (ListIndex != ProjectIndex)
            {
                ListIndex = ProjectIndex;

            }
            else
            {
                ListIndex = ProjectIndex;
            }
            

            Title = Projects[ListIndex].Name;
            if (Projects[ListIndex].DocumentStoreType == "GitHub")
            {
                GitHubRootUrl = Convert.ToString(Projects[ListIndex].ExtraProperties["GitHubRootUrl"]);
                InitialPath = "";
                Token = Convert.ToString(Projects[ListIndex].ExtraProperties["GitHubAccessToken"]);

            }
            else
            {
                GitHubRootUrl = "";
                InitialPath = Convert.ToString(Projects[ListIndex].ExtraProperties["Path"]);
                Token = "";
            }
            string NavReader = await ReadFilesAsync(Projects[ListIndex].DocumentStoreType, Projects[ListIndex].NavigationDocumentName, InitialPath, GitHubRootUrl, Token);
            string paramReader = await ReadFilesAsync(Projects[ListIndex].DocumentStoreType, "docs-params.json", InitialPath, GitHubRootUrl, Token);
            Navs = JsonConvert.DeserializeObject<Nav>(NavReader);
            Params = JsonConvert.DeserializeObject(paramReader);
            string resultb = await ReadFilesAsync(Projects[ListIndex].DocumentStoreType, PassedPath, InitialPath, GitHubRootUrl, Token);
            var template = Template.Parse(resultb);
            printPage = template.Render(new { UI = "MVC", DB = "EF" });






        }

        public async Task<string> ReadFilesAsync(string DocumentStoreType, string PassedPath, string InitialPath, string GitHubRootUrl, string Token)
        {

            string path1;



            if (DocumentStoreType == "GitHub")
            {
                if (PassedPath == null)
                {
                    PassedPath = "Tutorials/Todo/Index.md";
                }
                string[] stringSeparators1 = new string[] { "https://github.com/" };
                string[] stringSeparators2 = new string[] { "/" };

                string[] stringSplit = GitHubRootUrl.Split(stringSeparators1, StringSplitOptions.None);
                string[] getOwnerRepo = stringSplit[1].Split(stringSeparators2, StringSplitOptions.None);
                var client = new GitHubClient(new ProductHeaderValue("DocsReader"));
                var tokenAuth = new Credentials(Token); // NOTE: not real token
                client.Credentials = tokenAuth;
                byte[] PageReader = await client.Repository.Content.GetRawContent(getOwnerRepo[0], getOwnerRepo[1], "/docs/en/" + PassedPath);
                return System.Text.Encoding.UTF8.GetString(PageReader);





            }
            else
            {
                if (PassedPath == null)
                {
                    path1 = InitialPath + "\\en\\Tutorials\\Todo\\Index.md";
                }
                else
                {
                    path1 = InitialPath + "//en//" + PassedPath;
                }
                return System.IO.File.ReadAllText(path1);


            }







        }


    }
}
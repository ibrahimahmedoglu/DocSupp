using DocSupp.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace DocSupp.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class DocSuppPageModel : AbpPageModel
    {
        protected DocSuppPageModel()
        {
            LocalizationResourceType = typeof(DocSuppResource);
        }
    }
}
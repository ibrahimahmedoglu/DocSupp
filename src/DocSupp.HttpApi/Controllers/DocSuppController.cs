using DocSupp.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DocSupp.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class DocSuppController : AbpController
    {
        protected DocSuppController()
        {
            LocalizationResource = typeof(DocSuppResource);
        }
    }
}
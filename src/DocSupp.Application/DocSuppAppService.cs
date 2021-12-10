using System;
using System.Collections.Generic;
using System.Text;
using DocSupp.Localization;
using Volo.Abp.Application.Services;

namespace DocSupp
{
    /* Inherit your application services from this class.
     */
    public abstract class DocSuppAppService : ApplicationService
    {
        protected DocSuppAppService()
        {
            LocalizationResource = typeof(DocSuppResource);
        }
    }
}

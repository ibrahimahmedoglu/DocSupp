using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace DocSupp.Web
{
    [Dependency(ReplaceServices = true)]
    public class DocSuppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "DocSupp";
    }
}

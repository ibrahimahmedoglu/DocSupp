using Volo.Abp.Settings;

namespace DocSupp.Settings
{
    public class DocSuppSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(DocSuppSettings.MySetting1));
        }
    }
}

using DocSupp.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace DocSupp.Permissions
{
    public class DocSuppPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(DocSuppPermissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(DocSuppPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<DocSuppResource>(name);
        }
    }
}

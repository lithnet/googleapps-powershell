using System;
using System.Management.Automation;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.Remove, "GoogleAppsUser")]
    public class RemoveGoogleAppsUser : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public object User { get; set; }

        protected override void ProcessRecord()
        {
            string id = this.User.GetUserIDOrNull();

            if (id == null)
            {
                throw new ArgumentException("Unknown object type. Specify a primary email address or User object");
            }

            UserRequestFactory.Delete(id);
        }
    }
}
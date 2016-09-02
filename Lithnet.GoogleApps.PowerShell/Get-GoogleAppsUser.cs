using System.Management.Automation;
using Lithnet.GoogleApps.ManagedObjects;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "GoogleAppsUser")]
    public class GetGoogleAppsUser : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = false, Position = 1)]
        public string ID { get; set; }

        protected override void ProcessRecord()
        {
            if (this.ID == null)
            {
                foreach (User user in UserRequestFactory.GetUsers(Global.CustomerID))
                {
                    this.WriteObject(user);
                }
            }
            else
            {
                this.WriteObject(UserRequestFactory.Get(this.ID));
            }
        }
    }
}
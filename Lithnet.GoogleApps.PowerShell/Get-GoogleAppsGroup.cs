using System.Management.Automation;
using Lithnet.GoogleApps.ManagedObjects;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "GoogleAppsGroup")]
    public class GetGoogleAppsGroup : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = false, Position = 1)]
        public string ID { get; set; }

        protected override void ProcessRecord()
        {
            if (this.ID == null)
            {
                foreach (GoogleGroup g in GroupRequestFactory.GetGroups(Global.CustomerID, true, true, null, null))
                {
                    this.WriteObject(g);
                }
            }
            else
            {
                GoogleGroup group = new GoogleGroup(GroupRequestFactory.Get(this.ID));
                this.WriteObject(group);
            }
        }
    }
}
using System.Management.Automation;
using Lithnet.GoogleApps.ManagedObjects;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.New, "GoogleAppsUser")]
    public class NewGoogleAppsUser : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1)]
        public string PrimaryMail { get; set; }

        protected override void ProcessRecord()
        {
            User u = new User(true)
            {
                PrimaryEmail = this.PrimaryMail
            };

            this.WriteObject(u);
        }
    }
}
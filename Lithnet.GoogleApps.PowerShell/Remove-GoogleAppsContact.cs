using System.Management.Automation;
using Google.GData.Contacts;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.Remove, "GoogleAppsContact")]
    public class RemoveGoogleAppsContact : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true, ParameterSetName = "DeleteByObject")]
        public ContactEntry Contact { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = false, ParameterSetName = "DeleteByID")]
        public string ID { get; set; }

        protected override void ProcessRecord()
        {
            if (this.ID != null)
            {
                ContactRequestFactory.Delete(this.ID);
            }
            else
            {
                ContactRequestFactory.Delete(this.Contact);
            }
        }
    }
}
using System.Management.Automation;
using Google.GData.Contacts;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "GoogleAppsContact", DefaultParameterSetName = "GetByID")]
    public class GetGoogleAppsContact : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1, ParameterSetName = "GetByID")]
        public string ID { get; set; }

        [Parameter(ValueFromPipeline = false, Mandatory = true, Position = 1, ParameterSetName = "GetByDomain")]
        public string Domain { get; set; }

        protected override void ProcessRecord()
        {
            if (this.ID == null)
            {
                foreach (ContactEntry contact in ContactRequestFactory.GetContacts(this.Domain))
                {
                    this.WriteObject(contact);
                }
            }
            else
            {
                this.WriteObject(ContactRequestFactory.GetContact(this.ID));
            }
        }
    }
}
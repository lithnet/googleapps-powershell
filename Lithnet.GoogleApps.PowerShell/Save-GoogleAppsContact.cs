using System;
using System.Management.Automation;
using Google.GData.Contacts;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsData.Save, "GoogleAppsContact")]
    public class SaveGoogleAppsContact : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1)]
        public ContactEntry Contact { get; set; }

        [Parameter(ValueFromPipeline = false, Mandatory = false, Position = 2)]
        public string Domain { get; set; }

        protected override void ProcessRecord()
        {
            if (this.Contact.SelfUri == null)
            {
                if (this.Domain == null)
                {
                    throw new ArgumentNullException(nameof(this.Domain), "The domain must be specified when saving a new contact");
                }

                this.WriteObject(ContactRequestFactory.Add(this.Contact, this.Domain));
            }
            else
            {
                this.WriteObject(ContactRequestFactory.Update(this.Contact));
            }
        }
    }
}
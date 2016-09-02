using System.Management.Automation;
using Google.GData.Contacts;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.New, "GoogleAppsContact")]
    public class NewGoogleAppsContact : Cmdlet
    {
       
        protected override void ProcessRecord()
        {
            ContactEntry c = new ContactEntry();
            
            this.WriteObject(c);
        }
    }
}
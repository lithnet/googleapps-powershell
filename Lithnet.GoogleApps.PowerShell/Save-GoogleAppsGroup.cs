using System.Management.Automation;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsData.Save, "GoogleAppsGroup")]
    public class SaveGoogleAppsGroup : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1)]
        public GoogleGroup Group { get; set; }

        [Parameter(Mandatory = false, Position = 2)]
        public string ID { get; set; }

        protected override void ProcessRecord()
        {
            string id = this.ID ?? this.Group.Group.Id;

            GroupRequestFactory.Update(id, this.Group.Group);
            GroupSettingsRequestFactory.Update(this.Group.Group.Email, this.Group.Settings);
        }
    }
}
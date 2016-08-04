using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections;
using Lithnet.GoogleApps;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsData.Save, "GoogleAppsUser")]
    public class SaveGoogleAppsUser : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1)]
        public ManagedObjects.User User { get; set; }

        [Parameter(Mandatory = false, Position = 2)]
        public string ID { get; set; }

        protected override void ProcessRecord()
        {
            string id = this.ID ?? this.User.Id;

            this.WriteObject(UserRequestFactory.Update(this.User, id));
        }
    }
}
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
    [Cmdlet(VerbsCommon.Get, "GoogleAppsUser")]
    public class GetGoogleAppsUser : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1)]
        public string ID { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(UserRequestFactory.Get(this.ID));
        }
    }
}
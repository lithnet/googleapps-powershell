
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections;
using Lithnet.GoogleApps;
using Lithnet.GoogleApps.ManagedObjects;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "GoogleAppsDeletedUsers")]
    public class GetGoogleAppsDeletedUsers : Cmdlet
    {
        [Parameter(ValueFromPipeline = false, Mandatory = false, Position = 1)]
        public string CustomerID { get; set; }

        protected override void ProcessRecord()
        {
            string cid = this.CustomerID ?? "my_customer";

            foreach (User u in UserRequestFactory.GetDeletedUsers(cid, null))
            {
                this.WriteObject(u);
            }
        }
    }
}

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
        protected override void ProcessRecord()
        {
            foreach (User u in UserRequestFactory.GetDeletedUsers(Global.CustomerID, null))
            {
                this.WriteObject(u);
            }
        }
    }
}
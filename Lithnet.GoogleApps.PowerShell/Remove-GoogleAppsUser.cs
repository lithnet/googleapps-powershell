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
    [Cmdlet(VerbsCommon.Remove, "GoogleAppsUser")]
    public class RemoveGoogleAppsUser : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1)]
        public object User { get; set; }

        protected override void ProcessRecord()
        {
            string id = this.User.GetUserIDOrNull();

            if (id == null)
            {
                throw new ArgumentException("Unknown object type. Specify a primary email address or User object");
            }

            UserRequestFactory.Delete(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections;
using Lithnet.GoogleApps;
using Lithnet.GoogleApps.ManagedObjects;
using System.Security;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.Set, "GoogleAppsUserPassword")]
    public class SetGoogleAppsUserPassword : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1)]
        public User User { get; set; }

        [Parameter(Mandatory = false, Position = 2)]
        public SecureString NewPassword { get; set; }

        protected override void ProcessRecord()
        {
            string id = this.User.GetUserIDOrNull();

            if (id == null)
            {
                throw new ArgumentException("Unknown object type. Specify a primary email address or User object");
            }

           // UserRequestFactory.SetPassword(id, this.NewPassword);
        }
    }
}
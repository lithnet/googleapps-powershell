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
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1, ParameterSetName = "ByObject")]
        public User User { get; set; }

        [Parameter(ValueFromPipeline = false, Mandatory = true, Position = 1, ParameterSetName = "ByID")]
        public string ID { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public SecureString SecurePassword { get; set; }

        protected override void ProcessRecord()
        {
            string id = this.User?.Id ?? this.User?.PrimaryEmail ?? this.ID;

            if (id == null)
            {
                throw new ArgumentException("Specify a primary email address or User object");
            }

            UserRequestFactory.SetPassword(id, this.SecurePassword);
        }
    }
}
using System;
using System.Management.Automation;
using Lithnet.GoogleApps.ManagedObjects;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsData.Restore, "GoogleAppsUser")]
    public class RestoreGoogleAppsUser : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ByRef")]
        public User User { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "ByKey")]
        public string UserKey { get; set; }

        [Parameter(Mandatory = false, Position = 2)]
        public string OrgUnitPath { get; set; }

        protected override void ProcessRecord()
        {
            string key = null;

            if (this.User != null)
            {
                key = this.User.Id;
            }
            else if (this.UserKey.Contains("@"))
            {
                foreach (User u in UserRequestFactory.GetDeletedUsers(Global.CustomerID, null))
                {
                    if (u.PrimaryEmail.Equals(this.UserKey, StringComparison.CurrentCultureIgnoreCase))
                    {
                        key = u.Id;
                        break;
                    }
                }

                if (key == null)
                {
                    throw new ItemNotFoundException($"The user {this.UserKey} was not found in the deleted items collection");
                }
            }
            else
            {
                key = this.UserKey;
            }

            UserRequestFactory.Undelete(key, this.OrgUnitPath ?? "/");
        }
    }
}
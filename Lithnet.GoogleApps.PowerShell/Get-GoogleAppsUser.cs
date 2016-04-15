using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections;
using Lithnet.GoogleApps;
using System.Collections.Concurrent;
using Lithnet.GoogleApps.ManagedObjects;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.Get, "GoogleAppsUser")]
    public class GetGoogleAppsUser : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = false, Position = 1)]
        public string ID { get; set; }

        protected override void ProcessRecord()
        {
            BlockingCollection<object> users = new BlockingCollection<object>();

            if (this.ID == null)
            {
                Task t = new Task(() =>
                {
                    UserRequestFactory.StartImport("my_customer", users);
                });
                t.Start();

                foreach (User user in users.GetConsumingEnumerable().OfType<User>())
                {
                    this.WriteObject(user);
                }
            }
            else
            {
                this.WriteObject(UserRequestFactory.Get(this.ID));
            }
        }
    }
}
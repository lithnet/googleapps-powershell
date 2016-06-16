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
    [Cmdlet(VerbsCommon.Get, "GoogleAppsDomain")]
    public class GetGoogleAppsDomain : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = false, Position = 1)]
        public string ID { get; set; }

        protected override void ProcessRecord()
        {
            if (this.ID == null)
            {
                var domains = DomainsRequestFactory.GetDomains(Global.CustomerID);

                foreach (Domain d in domains.Domains)
                {
                    this.WriteObject(d);
                }
            }
            else
            {
                this.WriteObject(DomainsRequestFactory.GetDomain(Global.CustomerID, this.ID));
            }
        }
    }
}
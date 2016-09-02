using System.Management.Automation;
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
                DomainList domains = DomainsRequestFactory.List(Global.CustomerID);

                foreach (Domain d in domains.Domains)
                {
                    this.WriteObject(d);
                }
            }
            else
            {
                this.WriteObject(DomainsRequestFactory.Get(Global.CustomerID, this.ID));
            }
        }
    }
}
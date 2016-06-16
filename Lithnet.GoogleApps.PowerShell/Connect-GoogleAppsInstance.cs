using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections;
using Lithnet.GoogleApps;
using System.Security.Cryptography.X509Certificates;
using Google.Apis;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Admin.Directory.directory_v1;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommunications.Connect, "GoogleAppsInstance")]
    public class ConnectGoogleAppsInstance : Cmdlet
    {
        private static string[] RequiredScopes = new string[]
        {
            DirectoryService.Scope.AdminDirectoryUser,
            DirectoryService.Scope.AdminDirectoryDomainReadonly,
        };

        [Parameter(Mandatory = true, Position = 1)]
        public string Mail { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public string ServiceAccountID { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        public string CertificateFile { get; set; }

        [Parameter(Mandatory = true, Position = 4)]
        public string CertificatePassword { get; set; }

        [Parameter(Mandatory = false, Position = 4)]
        public string CustomerID { get; set; }

        protected override void ProcessRecord()
        {
            var creds = GetCredentials(
                  this.ServiceAccountID,
                   this.Mail,
                   GetCertificate(this.CertificateFile, this.CertificatePassword));

            ConnectionPools.InitializePools(creds, 1, 1, 1, 1);

            Global.CustomerID = this.CustomerID ?? "my_customer";
        }

        public static ServiceAccountCredential GetCredentials(string serviceAccountEmailAddress, string userEmailAddress, X509Certificate2 cert)
        {
            return new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccountEmailAddress)
                {
                    Scopes = RequiredScopes,
                    User = userEmailAddress
                }
                .FromCertificate(cert));
        }

        public static X509Certificate2 GetCertificate(string path, string password)
        {
            return new X509Certificate2(path, password, X509KeyStorageFlags.Exportable);
        }
    }
}

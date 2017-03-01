using System.Management.Automation;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Admin.Directory.directory_v1;
using Google.Apis.Groupssettings.v1;
using Lithnet.GoogleApps.ManagedObjects;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommunications.Connect, "GoogleAppsInstance")]
    public class ConnectGoogleAppsInstance : Cmdlet
    {
        private static string[] requiredScopes = {
            DirectoryService.Scope.AdminDirectoryGroup,
            DirectoryService.Scope.AdminDirectoryGroupMember,
            GroupssettingsService.Scope.AppsGroupsSettings,
            DirectoryService.Scope.AdminDirectoryUser,
            DirectoryService.Scope.AdminDirectoryDomainReadonly,
            "http://www.google.com/m8/feeds/contacts/",
        };

        [Parameter(Mandatory = true, Position = 1)]
        public string Mail { get; set; }

        [Parameter(Mandatory = true, Position = 2)]
        public string ServiceAccountID { get; set; }

        [Parameter(Mandatory = true, Position = 3)]
        public string CertificateFile { get; set; }

        [Parameter(Mandatory = true, Position = 4)]
        public string CertificatePassword { get; set; }

        [Parameter(Mandatory = false, Position = 5)]
        public string CustomerID { get; set; }

        protected override void ProcessRecord()
        {
            var creds = GetCredentials(
                  this.ServiceAccountID,
                   this.Mail,
                   GetCertificate(this.CertificateFile, this.CertificatePassword));

            ConnectionPools.InitializePools(creds, 1, 1, 1, 1);
            GroupMembership.GetInternalDomains(this.CustomerID ?? "my_customer");
            Global.CustomerID = this.CustomerID ?? "my_customer";
        }

        public static ServiceAccountCredential GetCredentials(string serviceAccountEmailAddress, string userEmailAddress, X509Certificate2 cert)
        {
            return new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccountEmailAddress)
                {
                    Scopes = ConnectGoogleAppsInstance.requiredScopes,
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

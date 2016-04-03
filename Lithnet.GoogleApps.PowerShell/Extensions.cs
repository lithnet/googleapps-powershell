using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lithnet.GoogleApps.ManagedObjects;
using System.Management.Automation;

namespace Lithnet.GoogleApps.PowerShell
{
    public static class Extensions
    {
        public static string GetUserIDOrNull(this object o)
        {
            string userid = o as string;

            if (userid != null)
            {
                return userid;
            }
            
            PSObject psobj = o as PSObject;
            User u;
            if (psobj != null)
            {
                u = psobj.BaseObject as User;
            }
            else
            {
                u = o as User;
            }

            if (u != null)
            {
                return u.PrimaryEmail;
            }

            return null;
        }
    }
}

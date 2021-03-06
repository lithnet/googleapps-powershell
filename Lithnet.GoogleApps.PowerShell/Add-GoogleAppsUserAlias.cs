﻿using System;
using System.Management.Automation;

namespace Lithnet.GoogleApps.PowerShell
{
    [Cmdlet(VerbsCommon.Add, "GoogleAppsUserAlias")]
    public class AddGoogleAppsUserAlias : Cmdlet
    {
        [Parameter(ValueFromPipeline = true, Mandatory = true, Position = 1)]
        public object User { get; set; }

        [Parameter(ValueFromPipeline = false, Mandatory = true, Position = 2)]
        public string Alias { get; set; }

        protected override void ProcessRecord()
        {
            string id = this.User.GetUserIDOrNull();

            if (id == null)
            {
                throw new ArgumentException("Unknown object type. Specify a primary email address or User object");
            }

            UserRequestFactory.AddAlias(id, this.Alias);
        }
    }
}
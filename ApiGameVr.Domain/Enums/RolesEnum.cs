using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ApiGameVr.Domain.Enums
{
    [DataContract]
    public enum Roles
    {
        [EnumMember(Value = "moderator")]
        Moderator,

        [EnumMember(Value = "administrator")]
        Administrator,

        [EnumMember(Value = "superadministrator")]
        SuperAdministrator,

    }
}

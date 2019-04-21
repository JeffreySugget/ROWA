using System;
using System.Security.Principal;

namespace rowa.repository.Classes
{
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role)
        {
            if (string.Compare(role, RoleConsts.Admin, true) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IIdentity Identity
        {
            get; private set;
        }
    }
}

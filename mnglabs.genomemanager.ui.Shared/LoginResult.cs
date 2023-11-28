using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.Shared
{
    public enum LoginResult
    {
        NoSuchADUser,
        MustChangePassword,
        ErrorOccurred,
        Success,
        Failed,
        None
    }
}

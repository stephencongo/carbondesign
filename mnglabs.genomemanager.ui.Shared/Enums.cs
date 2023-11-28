using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mnglabs.genomemanager.ui.Shared
{
    public enum YesNo
    {
        Yes,
        No
    }

    public enum CacheItemStatus
    {
        Requested = 0,
        InProgress = 1,
        Error = 2,
        Completed = 3
    }
    public enum DatasetRequestOutcome
    {
        DirectFromDatabase = 0,
        FromApplicationCache,
        FromRemoteCache,
        Queued,
        Error,
        None
    }
    public enum DatasetSource
    {
        Database,
        ApplicationCache,
        RemoteCache,
        None
    }
}

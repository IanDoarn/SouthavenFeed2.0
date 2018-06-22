using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SouthavenFeed.FeedTaskManager.SQL
{
    public enum EStatement
    {
        COMPLETED_WORK,
        COMPLETED_WORK_OTHER,
        CURRENT_TRANSFERS,
        ASSIGNED_OUTBOUND_TRANSFERS,
        COMPLETED_OUTBOUND_TRANSFERS,
        CURRENT_MOVEMENTS,
        COMPLETED_MOVEMENTS,
        MOVEMENT_BREAKOUT,
        TRACKED_KITS
    }
}

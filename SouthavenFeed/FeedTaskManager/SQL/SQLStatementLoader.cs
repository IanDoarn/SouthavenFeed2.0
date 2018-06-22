using System.IO;

namespace SouthavenFeed.FeedTaskManager.SQL
{
    public static class SQLStatementLoader
    {
        public static SQLStmt Get(EStatement sqlStmtName)
        {
            switch(sqlStmtName)
            {
                case EStatement.COMPLETED_WORK:
                    return new SQLStmt(_LoadSQLStmt("completed_work.sql"), "completed_work");
                case EStatement.COMPLETED_WORK_OTHER:
                    return new SQLStmt(_LoadSQLStmt("completed_work_other.sql"), "completed_work_other");
                case EStatement.CURRENT_TRANSFERS:
                    return new SQLStmt(_LoadSQLStmt("current_transfers.sql"), "current_transfers");
                case EStatement.ASSIGNED_OUTBOUND_TRANSFERS:
                    return new SQLStmt(_LoadSQLStmt("assigned_outbound_transfers_movements.sql"), "assigned_outbound_transfers");
                case EStatement.COMPLETED_OUTBOUND_TRANSFERS:
                    return new SQLStmt(_LoadSQLStmt("completed_outbound_transfer_movements.sql"), "completed_outbound_transfers");
                case EStatement.CURRENT_MOVEMENTS:
                    return new SQLStmt(_LoadSQLStmt("current_movements.sql"), "current_movements");
                case EStatement.COMPLETED_MOVEMENTS:
                    return new SQLStmt(_LoadSQLStmt("completed_movements.sql"), "completed_movements");
                case EStatement.MOVEMENT_BREAKOUT:
                    return new SQLStmt(_LoadSQLStmt("movement_breakout.sql"), "movement_breakout");
                case EStatement.TRACKED_KITS:
                    return new SQLStmt(_LoadSQLStmt("tracked_kits.sql"), "tracked_kits");
                default:
                    return null;
            }
        }

        private static string _LoadSQLStmt(string filename)
        {
            return EmbeddedResource.GetString(filename);
        }
    }
    
}

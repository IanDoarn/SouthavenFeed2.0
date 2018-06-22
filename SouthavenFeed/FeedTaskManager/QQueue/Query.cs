using System;

namespace SouthavenFeed.FeedTaskManager.QQueue
{
    public abstract class Query : IQuery
    {
        public abstract string FileName { get; }
        public abstract string QueryName { get; }
        public abstract Exception Error { get;  }

        public abstract void FormatResults();
        public abstract bool Get();
        public abstract void WriteJSONFile();
    }
}

namespace SouthavenFeed.FeedTaskManager.QQueue
{
    interface IQuery
    {
        bool Get();

        void FormatResults();

        void WriteJSONFile();
    }
}

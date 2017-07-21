namespace PortfolioEngineCore
{
    public interface IMessageQueue
    {
        void Queue(string basePath);

        void CreateQueue(string name);
    }
}
namespace PortfolioEngineCore
{
    public class PfeJob
    {
        public string Comment { get; internal set; }
        public int Context { get; internal set; }
        public string ContextData { get; internal set; }
        public string Session { get; internal set; }
        public int UserId { get; internal set; }
        public int Queue(IDbRepository dbRepository, IMessageQueue messageQueue, string basePath)
        {
            var rowsAffected = dbRepository.QueuePfeJob(this);
            messageQueue.Queue(basePath);
            return rowsAffected;
        }
    }
}
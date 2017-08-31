namespace PortfolioEngineCore
{
    public interface IDbRepository
    {
        int QueuePfeJob(PfeJob job);
    }
}
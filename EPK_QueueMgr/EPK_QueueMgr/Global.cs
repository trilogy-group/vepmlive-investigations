namespace WE_QueueMgr
{
    public class Global
    {
        private static PPMWorkEngineQueueService _instance;

        public static PPMWorkEngineQueueService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PPMWorkEngineQueueService();
                }
                return _instance;
            }
        }
    }
}
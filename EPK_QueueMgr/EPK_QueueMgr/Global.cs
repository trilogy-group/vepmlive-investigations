namespace WE_QueueMgr
{
    public sealed class Global
    {
        private static PPMWorkEngineQueueService instance;

        static Global()
        {
        }

        private Global()
        {
        }

        public static PPMWorkEngineQueueService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PPMWorkEngineQueueService();
                }
                return instance;
            }
        }
    }
}
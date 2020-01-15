namespace SocialEvents.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private SocialEventsEntities dbContext;

        public SocialEventsEntities Init()
        {
            return dbContext ?? (dbContext = new SocialEventsEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
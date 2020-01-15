using System;

namespace SocialEvents.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        SocialEventsEntities Init();
    }
}
﻿namespace SocialEvents.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
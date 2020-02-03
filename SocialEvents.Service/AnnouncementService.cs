using SocialEvents.Data.Infrastructure;
using SocialEvents.Data.Repositories;
using SocialEvents.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialEvents.Service
{
    // operations you want to expose
    public interface IAnnouncementService : IServiceBase<Announcement>
    {
        void Publish(Guid id);
        IEnumerable<Announcement> GetAllPublished();
    }

    public class AnnouncementService : ServiceBase<Announcement>, IAnnouncementService
    {
        private readonly IAnnouncementRepository announcementRepository;

        public AnnouncementService(IRepository<Announcement> repository, IAnnouncementRepository announcementRepository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            this.announcementRepository = announcementRepository;
        }

        #region IAnnouncementService Members

        public override void Create(Announcement model)
        {
            try
            {
                //using (EdmsServiceRef.WSESRCJGeneralClient client=new EdmsServiceRef.WSESRCJGeneralClient())
                //{
                //    var sevenItems = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };
                //    client.createRecord("", "", "DocType", "Parent", "xml", sevenItems, "File-Name");

                //}

              
                base.Create(model);
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        public override void Update(Announcement model)
        {
            model.Active = true;
            base.Update(model);

        }

        public void Publish(Guid id)
        {
            var entity=this.announcementRepository.GetById(id);
            entity.Published = true;
            this.announcementRepository.Update(entity);

        }

        public IEnumerable<Announcement> GetAllPublished()
        {
            var result = GetAllAtive().Where(e=>e.Published);
            return result;
        }
        #endregion IAnnouncementService Members
    }
}
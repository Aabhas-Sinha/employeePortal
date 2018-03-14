using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;
using Nagarro.EmployeePortal.EntityDataModel.EntityModel;
using Nagarro.EmployeePortal.EntityDataModel;

namespace Nagarro.EmployeePortal.Data
{
    public class NoticeManagerDAC : DACBase, INoticeDAC
    {
        public NoticeManagerDAC()
            : base(DACType.NoticeManagerDAC)
        {

        }

        /// <summary>
        /// Create a new entry in the notice table , if inserted successfully
        ///           a.Yes – return the inserted NoticeDTO
        ///           b.No – return null
        /// </summary>
        /// <param name="noticeDTO"></param>
        /// <returns></returns>
        public INoticeDTO CreateNotice(INoticeDTO noticeDTO)
        {
            INoticeDTO createNoticeRetval = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    noticeDTO.IsActive = true;
                    Notice notice = new Notice();
                    EntityConverter.FillEntityFromDTO(noticeDTO, notice);
                    portal.Notices.Add(notice);
                    if (portal.SaveChanges() > 0)
                    {
                        noticeDTO.NoticeId = notice.NoticeId;
                        createNoticeRetval = noticeDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createNoticeRetval;
        }


        /// <summary>
        /// Set IsActive false for the notice of the given noticeId and 
        /// return true if IsActive was set to false successfully otherwise return false
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public bool DeleteNotice(int noticeId)
        {
            bool isDeleted = false;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var notice = portal.Notices.Where(n => n.NoticeId == noticeId).SingleOrDefault<Notice>();
                    if (notice != null)
                    {
                        notice.IsActive = false;
                        isDeleted = portal.SaveChanges() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return isDeleted;
        }


        /// <summary>
        /// Get all the notices with IsActive set to true.
        /// </summary>
        /// <returns></returns>
        public IList<INoticeDTO> GetActiveNotices()
        {
            IList<INoticeDTO> noticeDTOList = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var noticeList = portal.Notices.Include("Employee").Where(n => n.IsActive).ToList();
                    if (noticeList.Count > 0)
                    {
                        noticeDTOList = new List<INoticeDTO>();
                        INoticeDTO noticeDTO = null;
                        foreach (Notice notice in noticeList)
                        {
                            noticeDTO = (INoticeDTO)DTOFactory.Instance.Create(DTOType.NoticeDTO);
                            noticeDTO.PostedByEmployee = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);
                            EntityConverter.FillDTOFromEntity(notice, noticeDTO);
                            EntityConverter.FillDTOFromEntity(notice.Employee, noticeDTO.PostedByEmployee);
                            noticeDTOList.Add(noticeDTO);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return noticeDTOList;
        }


        /// <summary>
        /// Get all the notices for which today’s date lies between start and expiration date of the notice 
        /// and IsActive is true.
        /// </summary>
        /// <returns></returns>
        public IList<INoticeDTO> GetCurrentNotices()
        {
            IList<INoticeDTO> noticeDTOList = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var noticeList = portal.Notices.Include("Employee").Where(n => n.IsActive && n.StartDate <= DateTime.Now && DateTime.Now <= n.ExpirationDate)
                                                    .ToList();
                    if (noticeList.Count > 0)
                    {
                        noticeDTOList = new List<INoticeDTO>();
                        INoticeDTO noticeDTO = null;
                        foreach (Notice notice in noticeList)
                        {
                            noticeDTO = (INoticeDTO)DTOFactory.Instance.Create(DTOType.NoticeDTO);
                            noticeDTO.PostedByEmployee = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);
                            EntityConverter.FillDTOFromEntity(notice, noticeDTO);
                            EntityConverter.FillDTOFromEntity(notice.Employee, noticeDTO.PostedByEmployee);
                            noticeDTOList.Add(noticeDTO);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return noticeDTOList;
        }


        /// <summary>
        /// Returns a specific notice using the given notice id
        /// </summary>
        /// <param name="noticeId"></param>
        /// <returns></returns>
        public INoticeDTO GetNotice(int noticeId)
        {
            INoticeDTO noticeDTO = null;
            using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
            {
                try
                {
                    var notice = portal.Notices.Include("Employee").Where(n => n.NoticeId == noticeId)
                                               .SingleOrDefault();

                    if (notice != null)
                    {
                        noticeDTO = (INoticeDTO)DTOFactory.Instance.Create(DTOType.NoticeDTO);
                        noticeDTO.PostedByEmployee = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO); 
                        EntityConverter.FillDTOFromEntity(notice, noticeDTO);
                        EntityConverter.FillDTOFromEntity(notice.Employee, noticeDTO.PostedByEmployee);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message);
                }
            }
            return noticeDTO;
        }


        /// <summary>
        /// Update the notice table accordingly, Is Updated successfully
        ///            a.Yes – return the updated NoticeDTO
        ///            b.No – return Null
        /// </summary>
        /// <param name="noticeDTO"></param>
        /// <returns></returns>
        public INoticeDTO UpdateNotice(INoticeDTO noticeDTO)
        {
            INoticeDTO retVal = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var notice = portal.Notices.Where(n => n.NoticeId == noticeDTO.NoticeId).SingleOrDefault<Notice>();
                    if (notice != null)
                    {
                        noticeDTO.IsActive = notice.IsActive;
                        EntityConverter.FillEntityFromDTO(noticeDTO, notice);
                        if(portal.SaveChanges() > 0)
                        {
                            retVal = noticeDTO;
                        }                      
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return retVal;
        }
    }
}

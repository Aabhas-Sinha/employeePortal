using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;


namespace Nagarro.EmployeePortal.BusinessFacades
{
    public class NoticeManagerFacade : FacadeBase, INoticeFacade
    {
        public NoticeManagerFacade() : base(FacadeType.NoticeManagerFacade)
        { }

        public OperationResult<IList<INoticeDTO>> GetCurrentNotices()
        {
            INoticeBDC noticeBDC = (INoticeBDC)BDCFactory.Instance.Create(BDCType.NoticeManagerBDC);
            return noticeBDC.GetCurrentNotices();
        }

        public OperationResult<IList<INoticeDTO>> GetActiveNotices()
        {
            INoticeBDC noticeBDC = (INoticeBDC)BDCFactory.Instance.Create(BDCType.NoticeManagerBDC);
            return noticeBDC.GetActiveNotices();
        }

        public OperationResult<INoticeDTO> CreateNotice(INoticeDTO noticeDTO)
        {
            INoticeBDC noticeBDC = (INoticeBDC)BDCFactory.Instance.Create(BDCType.NoticeManagerBDC);
            return noticeBDC.CreateNotice(noticeDTO);
        }

        public OperationResult<INoticeDTO> UpdateNotice(INoticeDTO noticeDTO)
        {
            INoticeBDC noticeBDC = (INoticeBDC)BDCFactory.Instance.Create(BDCType.NoticeManagerBDC);
            return noticeBDC.UpdateNotice(noticeDTO);
        }

        public OperationResult<bool> DeleteNotice(int noticeId)
        {
            INoticeBDC noticeBDC = (INoticeBDC)BDCFactory.Instance.Create(BDCType.NoticeManagerBDC);
            return noticeBDC.DeleteNotice(noticeId);
        }

        public OperationResult<INoticeDTO> GetNotice(int noticeId)
        {
            INoticeBDC noticeBDC = (INoticeBDC)BDCFactory.Instance.Create(BDCType.NoticeManagerBDC);
            return noticeBDC.GetNotice(noticeId);
        }
    }
}

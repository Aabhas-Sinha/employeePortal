using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface INoticeDAC : IDataAccessComponent
    {
        INoticeDTO CreateNotice(INoticeDTO noticeDTO);
        INoticeDTO UpdateNotice(INoticeDTO noticeDTO);
        bool DeleteNotice(int noticeId);
        IList<INoticeDTO> GetCurrentNotices();
        IList<INoticeDTO> GetActiveNotices();
        INoticeDTO GetNotice(int noticeId);
    }
}

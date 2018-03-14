using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Shared
{
    public interface INoticeFacade : IFacade
    {
        OperationResult<IList<INoticeDTO>> GetCurrentNotices();
        OperationResult<IList<INoticeDTO>> GetActiveNotices();
        OperationResult<INoticeDTO> CreateNotice(INoticeDTO noticeDTO);
        OperationResult<INoticeDTO> UpdateNotice(INoticeDTO noticeDTO);
        OperationResult<bool> DeleteNotice(int noticeId);
        OperationResult<INoticeDTO> GetNotice(int noticeId);
    }
}

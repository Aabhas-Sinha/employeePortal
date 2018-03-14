using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
    public class NoticeManagerBDC : BDCBase, INoticeBDC
    {
        public NoticeManagerBDC() : base(BDCType.NoticeManagerBDC)
        {

        }

        public OperationResult<IList<INoticeDTO>> GetCurrentNotices()
        {
            OperationResult<IList<INoticeDTO>> getAllNoticeReturnValue = null;
            try
            {
                INoticeDAC noticeDAC = (INoticeDAC)DACFactory.Instance.Create(DACType.NoticeManagerDAC);
                IList<INoticeDTO> noticeDTOList = noticeDAC.GetCurrentNotices();
                if (noticeDTOList != null)
                {
                    getAllNoticeReturnValue = OperationResult<IList<INoticeDTO>>.CreateSuccessResult(noticeDTOList);
                }
                else
                {
                    getAllNoticeReturnValue = OperationResult<IList<INoticeDTO>>.CreateFailureResult("Get Current Notices Method Failed");
                }
            }
            catch (DACException dacEx)
            {
                getAllNoticeReturnValue = OperationResult<IList<INoticeDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getAllNoticeReturnValue = OperationResult<IList<INoticeDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getAllNoticeReturnValue;
        }

        public OperationResult<IList<INoticeDTO>> GetActiveNotices()
        {
            OperationResult<IList<INoticeDTO>> getAllNoticeReturnValue = null;
            try
            {
                INoticeDAC noticeDAC = (INoticeDAC)DACFactory.Instance.Create(DACType.NoticeManagerDAC);
                IList<INoticeDTO> noticeDTOList = noticeDAC.GetActiveNotices();
                if (noticeDTOList != null)
                {
                    getAllNoticeReturnValue = OperationResult<IList<INoticeDTO>>.CreateSuccessResult(noticeDTOList);
                }
                else
                {
                    getAllNoticeReturnValue = OperationResult<IList<INoticeDTO>>.CreateFailureResult("Get Active Notices Method Failed");
                }
            }
            catch (DACException dacEx)
            {
                getAllNoticeReturnValue = OperationResult<IList<INoticeDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getAllNoticeReturnValue = OperationResult<IList<INoticeDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getAllNoticeReturnValue;
        }

        public OperationResult<INoticeDTO> CreateNotice(INoticeDTO noticeDTO)
        {
            OperationResult<INoticeDTO> createNoticeReturnValue = null;
            try
            {
                EmployeePortalValidationResult validationResult = Validator<NoticeValidator, INoticeDTO>.Validate(noticeDTO, ValidationConstants.Common + "," + ValidationConstants.CreateNotice);

                if (!validationResult.IsValid)
                {
                    createNoticeReturnValue = OperationResult<INoticeDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    INoticeDAC noticeDAC = (INoticeDAC)DACFactory.Instance.Create(DACType.NoticeManagerDAC);
                    INoticeDTO returnedNoticeDTO = noticeDAC.CreateNotice(noticeDTO);
                    if (returnedNoticeDTO != null)
                    {
                        createNoticeReturnValue = OperationResult<INoticeDTO>.CreateSuccessResult(returnedNoticeDTO, "Notice created successfully");
                    }
                    else
                    {
                        createNoticeReturnValue = OperationResult<INoticeDTO>.CreateFailureResult("Insertion failed!");
                    }
                }                
            }
            catch (DACException dacEx)
            {
                createNoticeReturnValue = OperationResult<INoticeDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                createNoticeReturnValue = OperationResult<INoticeDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return createNoticeReturnValue;
        }

        public OperationResult<INoticeDTO> UpdateNotice(INoticeDTO noticeDTO)
        {
            OperationResult<INoticeDTO> updateNoticeReturnValue = null;
            try
            {
                INoticeDAC noticeDAC = (INoticeDAC)DACFactory.Instance.Create(DACType.NoticeManagerDAC);

                EmployeePortalValidationResult validationResult = Validator<NoticeValidator, INoticeDTO>.Validate(noticeDTO, ValidationConstants.Common);

                if (!validationResult.IsValid)
                {
                    updateNoticeReturnValue = OperationResult<INoticeDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    INoticeDTO returnedNoticeDTO = noticeDAC.UpdateNotice(noticeDTO);
                    if (returnedNoticeDTO != null)
                    {
                        updateNoticeReturnValue = OperationResult<INoticeDTO>.CreateSuccessResult(returnedNoticeDTO, "Notice updated successfully");
                    }
                }
            }
            catch (DACException dacEx)
            {
                updateNoticeReturnValue = OperationResult<INoticeDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                updateNoticeReturnValue = OperationResult<INoticeDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return updateNoticeReturnValue;
        }

        public OperationResult<bool> DeleteNotice(int noticeId)
        {
            OperationResult<bool> deleteNoticeReturnValue = null;
            try
            {
                INoticeDAC noticeDAC = (INoticeDAC)DACFactory.Instance.Create(DACType.NoticeManagerDAC);
                bool isDeleted = noticeDAC.DeleteNotice(noticeId);
                if (isDeleted)
                {
                    deleteNoticeReturnValue = OperationResult<bool>.CreateSuccessResult(isDeleted);
                }
                else
                {
                    deleteNoticeReturnValue = OperationResult<bool>.CreateFailureResult("User Id does not exist");
                }
            }
            catch (DACException dacEx)
            {
                deleteNoticeReturnValue = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                deleteNoticeReturnValue = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return deleteNoticeReturnValue;
        }

        public OperationResult<INoticeDTO> GetNotice(int noticeId)
        {
            OperationResult<INoticeDTO> getNoticeReturnValue = null;
            try
            {
                INoticeDAC noticeDAC = (INoticeDAC)DACFactory.Instance.Create(DACType.NoticeManagerDAC);
                INoticeDTO noticeDTO = noticeDAC.GetNotice(noticeId);
                if (noticeDTO != null)
                {
                    getNoticeReturnValue = OperationResult<INoticeDTO>.CreateSuccessResult(noticeDTO);
                }
                else
                {
                    getNoticeReturnValue = OperationResult<INoticeDTO>.CreateFailureResult("Notice Id does not exist");
                }
            }
            catch (DACException dacEx)
            {
                getNoticeReturnValue = OperationResult<INoticeDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                getNoticeReturnValue = OperationResult<INoticeDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }
            return getNoticeReturnValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;

namespace Nagarro.EmployeePortal.Business
{
    public class IssueManagerBDC : BDCBase, IIssueBDC
    {
        public IssueManagerBDC() : base(BDCType.IssueManagerBDC)
        {

        }

        public OperationResult<IIssueDTO> CreateIssue(IIssueDTO issueDTO)
        {
            OperationResult<IIssueDTO> retVal = null;

            try
            {
                EmployeePortalValidationResult validationResult = Validator<Issuevalidator, IIssueDTO>.Validate(issueDTO, ValidationConstants.UpdateIssue);

                if (!validationResult.IsValid)
                {
                    retVal = OperationResult<IIssueDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    IIssueDAC issueDAC = (IIssueDAC)DACFactory.Instance.Create(DACType.IssueManagerDAC);
                    IIssueDTO resultIssueDTO = issueDAC.CreateIssue(issueDTO);

                    if (resultIssueDTO != null)
                    {
                        retVal = OperationResult<IIssueDTO>.CreateSuccessResult(resultIssueDTO);
                    }
                    else
                    {
                        retVal = OperationResult<IIssueDTO>.CreateFailureResult("Create Failed!");
                    }
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IIssueDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IIssueDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;

        }

        public OperationResult<bool> DeleteIssue(int issueId)
        {
            OperationResult<bool> retVal = null;

            try
            {

                IIssueDAC issueDAC = (IIssueDAC)DACFactory.Instance.Create(DACType.IssueManagerDAC);
                bool resultIssue = issueDAC.DeleteIssue(issueId);

                if (resultIssue != false)
                {
                    retVal = OperationResult<bool>.CreateSuccessResult(resultIssue);
                }
                else
                {
                    retVal = OperationResult<bool>.CreateFailureResult("Delete Failed!");
                }

            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<bool>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<bool>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;

        }

        public OperationResult<IList<IComplexIssueDTO>> GetAllActiveIssues()
        {
            OperationResult<IList<IComplexIssueDTO>> retVal = null;

            try
            {

                IIssueDAC issueDAC = (IIssueDAC)DACFactory.Instance.Create(DACType.IssueManagerDAC);
                IList<IComplexIssueDTO> resultIssueDTO = issueDAC.GetAllActiveIssues();

                if (resultIssueDTO != null)
                {
                    retVal = OperationResult<IList<IComplexIssueDTO>>.CreateSuccessResult(resultIssueDTO);
                }
                else
                {
                    retVal = OperationResult<IList<IComplexIssueDTO>>.CreateFailureResult("Get all active issues Failed!");
                }

            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IList<IComplexIssueDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IList<IComplexIssueDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;

        }

        public OperationResult<IList<IComplexIssueDTO>> GetAllIssuesByEmployeeId(int EmployeeId)
        {
            OperationResult<IList<IComplexIssueDTO>> retVal = null;

            try
            {

                IIssueDAC issueDAC = (IIssueDAC)DACFactory.Instance.Create(DACType.IssueManagerDAC);
                IList<IComplexIssueDTO> resultIssueDTO = issueDAC.GetAllIssuesByEmployeeId(EmployeeId);

                if (resultIssueDTO != null)
                {
                    retVal = OperationResult<IList<IComplexIssueDTO>>.CreateSuccessResult(resultIssueDTO);
                }
                else
                {
                    retVal = OperationResult<IList<IComplexIssueDTO>>.CreateFailureResult("Get all issues Failed!");
                }

            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IList<IComplexIssueDTO>>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IList<IComplexIssueDTO>>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IIssueDTO> GetIssue(int IssueId)
        {
            OperationResult<IIssueDTO> retVal = null;

            try
            {
                IIssueDAC issueDAC = (IIssueDAC)DACFactory.Instance.Create(DACType.IssueManagerDAC);
                IIssueDTO resultIssueDTO = issueDAC.GetIssue(IssueId);

                if (resultIssueDTO != null)
                {
                    retVal = OperationResult<IIssueDTO>.CreateSuccessResult(resultIssueDTO);
                }
                else
                {
                    retVal = OperationResult<IIssueDTO>.CreateFailureResult("Get issue Failed!");
                }

            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IIssueDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IIssueDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IIssueDTO> UpdateIssue(IIssueDTO issueDTO)
        {
            OperationResult<IIssueDTO> retVal = null;

            try
            {
                EmployeePortalValidationResult validationResult = Validator<Issuevalidator, IIssueDTO>.Validate(issueDTO, ValidationConstants.UpdateIssue);

                if (!validationResult.IsValid)
                {
                    retVal = OperationResult<IIssueDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    IIssueDAC issueDAC = (IIssueDAC)DACFactory.Instance.Create(DACType.IssueManagerDAC);
                    IIssueDTO resultIssueDTO = issueDAC.UpdateIssue(issueDTO);

                    if (resultIssueDTO != null)
                    {
                        retVal = OperationResult<IIssueDTO>.CreateSuccessResult(resultIssueDTO);
                    }
                    else
                    {
                        retVal = OperationResult<IIssueDTO>.CreateFailureResult("Update issue Failed!");
                    }
                }
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IIssueDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IIssueDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }

        public OperationResult<IIssueHistoryDTO> UpdateIssueByAdmin(IIssueHistoryDTO issueDTO)
        {
            OperationResult<IIssueHistoryDTO> retVal = null;

            try
            {
                EmployeePortalValidationResult validationResult = Validator<IssueHistoryValidator, IIssueHistoryDTO>.Validate(issueDTO, ValidationConstants.UpdateIssueHistory);

                if (!validationResult.IsValid)
                {
                    retVal = OperationResult<IIssueHistoryDTO>.CreateFailureResult(validationResult);
                }
                else
                {
                    IIssueDAC issueDAC = (IIssueDAC)DACFactory.Instance.Create(DACType.IssueManagerDAC);
                    IIssueHistoryDTO resultIssueDTO = issueDAC.UpdateIssueByAdmin(issueDTO);

                    if (resultIssueDTO != null)
                    {
                        retVal = OperationResult<IIssueHistoryDTO>.CreateSuccessResult(resultIssueDTO);
                    }
                    else
                    {
                        retVal = OperationResult<IIssueHistoryDTO>.CreateFailureResult("Update issue by admin Failed!");
                    }
                }                
            }
            catch (DACException dacEx)
            {
                retVal = OperationResult<IIssueHistoryDTO>.CreateErrorResult(dacEx.Message, dacEx.StackTrace);
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                retVal = OperationResult<IIssueHistoryDTO>.CreateErrorResult(ex.Message, ex.StackTrace);
            }

            return retVal;
        }
    }
}

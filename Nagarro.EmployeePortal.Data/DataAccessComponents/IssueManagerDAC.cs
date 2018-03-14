using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nagarro.EmployeePortal.Shared;
using Nagarro.EmployeePortal.EntityDataModel.EntityModel;
using Nagarro.EmployeePortal.EntityDataModel;
using System.Data.Objects;
using System.Transactions;

namespace Nagarro.EmployeePortal.Data
{
    public class IssueManagerDAC : DACBase, IIssueDAC
    {
        public IssueManagerDAC()
            : base(DACType.IssueManagerDAC)
        {

        }

        /// <summary>
        /// Create a new entry in issue and issue history table
        /// </summary>
        /// <param name="issueDTO"></param>
        /// <returns></returns>
        public IIssueDTO CreateIssue(IIssueDTO issueDTO)
        {
            IIssueDTO createIssueRetVal = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    using (var transScope = new TransactionScope())
                    {
                        issueDTO.IsActive = true;
                        Issue issue = new Issue();
                        EntityConverter.FillEntityFromDTO(issueDTO, issue);
                        portal.Issues.Add(issue);
                        portal.SaveChanges();
                        issueDTO.IssueId = issue.IssueId;

                        IIssueHistoryDTO issueHistoryDTO = (IIssueHistoryDTO)DTOFactory.Instance.Create(DTOType.IssueHistoryDTO);
                        issueHistoryDTO.IssueId = issue.IssueId;
                        issueHistoryDTO.AssignedTo = null;
                        issueHistoryDTO.Comments = null;
                        issueHistoryDTO.ModifiedBy = issue.PostedBy;
                        issueHistoryDTO.ModifiedOn = DateTime.Now;
                        issueHistoryDTO.Status = (int)IssueStatus.Raised;

                        IssueHistory issueHistory = new IssueHistory();
                        EntityConverter.FillEntityFromDTO(issueHistoryDTO, issueHistory);
                        portal.IssueHistories.Add(issueHistory);
                        portal.SaveChanges();
                        transScope.Complete();
                        createIssueRetVal = issueDTO;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return createIssueRetVal;

        }


        /// <summary>
        /// Set IsActive false for the issue of the given IssueId and return true if IsActive was set to false successfully 
        /// otherwise return false
        /// </summary>
        /// <param name="issueId"></param>
        /// <returns></returns>
        public bool DeleteIssue(int issueId)
        {
            bool isDeleted = false;
            using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
            {
                try
                {
                    var issue = portal.Issues.Where(i => i.IssueId == issueId).SingleOrDefault<Issue>();
                    if (issue != null)
                    {
                        issue.IsActive = false;                        
                        isDeleted = portal.SaveChanges() > 0;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionManager.HandleException(ex);
                    throw new DACException(ex.Message);
                }
            }
            return isDeleted;
        }


        /// <summary>
        /// Return all the active issues, get information from the issue table and issue history table 
        /// (get assigned to and status from the latest issue history entry of the corresponding issue)
        /// </summary>
        /// <returns></returns>
        public IList<IComplexIssueDTO> GetAllActiveIssues()
        {
            IList<IComplexIssueDTO> issueDTOList = null;
            IComplexIssueDTO issueDTO = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var issueList = portal.GetAllIssuesByEmployeeId(null).ToList();
                    if(issueList.Count > 0)
                    {
                        issueDTOList = new List<IComplexIssueDTO>();
                        foreach (var issue in issueList)
                        {
                            issueDTO = (IComplexIssueDTO)DTOFactory.Instance.Create(DTOType.ComplexIssueDTO);
                            EntityConverter.FillDTOFromComplexObject(issue, issueDTO);
                            issueDTOList.Add(issueDTO);
                        }
                    }                    
                }
            }

            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return issueDTOList;
        }


        /// <summary>
        /// Return all the issues, get information from the issue table and issue history table 
        /// (get assigned to and status from the latest issue history entry of the corresponding issue), 
        /// which are active and are posted by the given EmployeeId
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public IList<IComplexIssueDTO> GetAllIssuesByEmployeeId(int employeeId)
        {
            IList<IComplexIssueDTO> issueDTOList = null;
            IComplexIssueDTO issueDTO = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var issueList = portal.GetAllIssuesByEmployeeId(employeeId).ToList();
                    if(issueList.Count > 0)
                    {
                        issueDTOList = new List<IComplexIssueDTO>();
                        foreach (var issue in issueList)
                        {
                            issueDTO = (IComplexIssueDTO)DTOFactory.Instance.Create(DTOType.ComplexIssueDTO);
                            EntityConverter.FillDTOFromComplexObject(issue, issueDTO);
                            issueDTOList.Add(issueDTO);
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return issueDTOList;
        }


        /// <summary>
        /// Return IssueDTO corresponding to the passed issue id. 
        /// The IssueDTO should also contain nested inside it list of IIssueHistoryDTOs
        /// </summary>
        /// <param name="issueId"></param>
        /// <returns></returns>
        public IIssueDTO GetIssue(int issueId)
        {
            IIssueDTO issueDTO = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    var issue = portal.Issues.Include("Employee")
                                        .Where(i => i.IssueId == issueId && i.IsActive)
                                        .SingleOrDefault();
                    if (issue != null)
                    {
                        issueDTO = (IIssueDTO)DTOFactory.Instance.Create(DTOType.IssueDTO);
                        EntityConverter.FillDTOFromEntity(issue, issueDTO);

                        issueDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);
                        EntityConverter.FillDTOFromEntity(issue.Employee, issueDTO.EmployeeDTO);

                        var issueHistoryList = portal.GetIssueHistoryByIssueId(issueId).ToList();
                        if(issueHistoryList.Count > 0)
                        {
                            issueDTO.IssueHistories = new List<IComplexIssueHistoryDTO>();
                            IComplexIssueHistoryDTO issueHistoryDTO = null;
                            foreach (var issueHistory in issueHistoryList)
                            {
                                issueHistoryDTO = (IComplexIssueHistoryDTO)DTOFactory.Instance.Create(DTOType.ComplexIssueHistoryDTO);
                                EntityConverter.FillDTOFromComplexObject(issueHistory, issueHistoryDTO);
                                issueDTO.IssueHistories.Add(issueHistoryDTO);
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return issueDTO;
        }


        /// <summary>
        /// Update the issue table (changes only in Issue table , no changes in Issue history table)
        ///             a.Yes – return the updated IssueDTO
        ///             b.No – return Null
        /// </summary>
        /// <param name="issueDTO"></param>
        /// <returns></returns>
        public IIssueDTO UpdateIssue(IIssueDTO issueDTO)
        {
            IIssueDTO updateIssueRetVal = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    Issue issue = portal.Issues.Where(i => i.IssueId == issueDTO.IssueId).SingleOrDefault();
                    if (issue != null)
                    {
                        issueDTO.IsActive = true;
                        EntityConverter.FillEntityFromDTO(issueDTO, issue);
                        if (portal.SaveChanges() > 0)
                        {
                            updateIssueRetVal = issueDTO;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }
            return updateIssueRetVal;
        }


        /// <summary>
        /// This should make an insertion in the IssueHistory table against an entry in the Issue table. 
        /// If successfully done, return the relevant IssueHistoryDTO else return null.
        /// </summary>
        /// <param name="issueHistoryDTO"></param>
        /// <returns></returns>
        public IIssueHistoryDTO UpdateIssueByAdmin(IIssueHistoryDTO issueHistoryDTO)
        {
            IIssueHistoryDTO updateIssueByAdminRetVal = null;
            try
            {
                using (EmployeePortal2017Entities portal = new EmployeePortal2017Entities())
                {
                    IssueHistory issueHistory = new IssueHistory();
                    EntityConverter.FillEntityFromDTO(issueHistoryDTO, issueHistory);
                    portal.IssueHistories.Add(issueHistory);
                    portal.SaveChanges();
                    issueHistoryDTO.IssueHistoryId = issueHistory.IssueHistoryId;
                    updateIssueByAdminRetVal = issueHistoryDTO;
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.HandleException(ex);
                throw new DACException(ex.Message);
            }

            return updateIssueByAdminRetVal;
        }
    }
}

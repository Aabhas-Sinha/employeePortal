using Nagarro.EmployeePortal.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.EmployeePortal.Console
{
    class Program
    {
        #region MenuMethods
        static void EmployeeMenu()
        {
            int choice;

            do
            {
                System.Console.WriteLine("\n...MENU...\n1. CreateEmployee: Transaction\n2. CreateEmployee: SProc\n3. SearchEmployee: Raw Query\n4. SearchEmployee: SProc\n5. UpdateEmployee\n0. Exit\nEnter choice : ");
                int.TryParse(System.Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        CreateEmployeeByTransaction();
                        break;
                    case 2:
                        CreateEmployeeBySProc();
                        break;
                    case 3:
                        SearchEmployeeByRawQuery();
                        break;
                    case 4:
                        SearchEmployeeBySProc();
                        break;
                    case 5:
                        UpdateEmployee();
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Wrong Input. Try Again.");
                        break;
                }
            } while (choice != 0);
        }

        static void UserMenu()
        {
            int choice;

            do
            {
                System.Console.WriteLine("\n...MENU...\n1. UpdateProfile\n2. Login\n0. Exit\nEnter choice : ");
                int.TryParse(System.Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        UpdateProfile();
                        break;
                    case 2:
                        Login();
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Wrong Input. Try Again.");
                        break;
                }
            } while (choice != 0);
        }

        static void NoticeMenu()
        {
            int choice;

            do
            {
                System.Console.WriteLine("\n...MENU...\n1. CreateNotice\n2. DeleteNotice\n3. UpdateNotice\n4. GetCurrentNotice\n5. GetActiveNotice\n0. Exit\nEnter choice : ");
                int.TryParse(System.Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        CreateNotice();
                        break;
                    case 2:
                        DeleteNotice();
                        break;
                    case 3:
                        UpdateNotice();
                        break;
                    case 4:
                        GetCurrentNotices();
                        break;
                    case 5:
                        GetActiveNotices();
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Wrong Input. Try Again.");
                        break;
                }
            } while (choice != 0);
        }

        static void IssueMenu()
        {
            int choice;

            do
            {
                System.Console.WriteLine("\n...MENU...\n1. CreateIssue\n2. DeleteIssue\n3. UpdateIssue\n4. UpdateIssueByadmin\n5. GetAllActiveIssues");
                System.Console.WriteLine("6. GetAllIssuesByEmployeeId\n7. GetIssue\n0. Exit\nEnter choice : ");
                int.TryParse(System.Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        CreateIssue();
                        break;
                    case 2:
                        DeleteIssue();
                        break;
                    case 3:
                        UpdateIssue();
                        break;
                    case 4:
                        UpdateIssueByadmin();
                        break;
                    case 5:
                        GetAllActiveIssues();
                        break;
                    case 6:
                        GetAllIssuesByEmployeeId();
                        break;
                    case 7:
                        GetIssue();
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Wrong Input. Try Again.");
                        break;
                }
            } while (choice != 0);
        }

        static void DepartmentMenu()
        {
            int choice;

            do
            {
                System.Console.WriteLine("\n...MENU...\n1. Get A Department\n2. Get All Departments\n0. Exit\nEnter choice : ");
                int.TryParse(System.Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        GetDepartment();
                        break;
                    case 2:
                        GetAllDepartments();
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Wrong Input. Try Again.");
                        break;
                }
            } while (choice != 0);
        }
        #endregion

        #region EmployeeMethods
        static void CreateEmployeeBySProc()
        {
            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            userDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);

            System.Console.WriteLine("First Name : ");
            userDTO.EmployeeDTO.FirstName = System.Console.ReadLine();

            System.Console.WriteLine("Last Name : ");
            userDTO.EmployeeDTO.LastName = System.Console.ReadLine();

            System.Console.WriteLine("Date of Joining : ");
            DateTime doj;
            DateTime.TryParse(System.Console.ReadLine(), out doj);
            userDTO.EmployeeDTO.DateOfJoining = doj;

            System.Console.WriteLine("Email : ");
            userDTO.EmployeeDTO.Email = System.Console.ReadLine();

            System.Console.WriteLine("Department Id : ");
            userDTO.EmployeeDTO.DepartmentId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Password : ");
            userDTO.Password = System.Console.ReadLine();

            System.Console.WriteLine("IsAdmin : ");
            userDTO.IsAdmin = Convert.ToBoolean(System.Console.ReadLine());

            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
            OperationResult<IUserDTO> createEmployeeRetVal = userFacade.CreateEmployeeBySProc(userDTO);
            if (createEmployeeRetVal.IsValid())
            {
                System.Console.WriteLine("Inserted!!  Emp Id : {0}   User Id : {1}", createEmployeeRetVal.Data.EmployeeId, createEmployeeRetVal.Data.UserId);
            }
        }

        static void CreateEmployeeByTransaction()
        {
            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            userDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);

            System.Console.WriteLine("First Name : ");
            userDTO.EmployeeDTO.FirstName = System.Console.ReadLine();

            System.Console.WriteLine("Last Name : ");
            userDTO.EmployeeDTO.LastName = System.Console.ReadLine();

            System.Console.WriteLine("Date of Joining : ");
            DateTime doj;
            DateTime.TryParse(System.Console.ReadLine(), out doj);
            userDTO.EmployeeDTO.DateOfJoining = doj;

            System.Console.WriteLine("Email : ");
            userDTO.EmployeeDTO.Email = System.Console.ReadLine();

            System.Console.WriteLine("Department Id : ");
            userDTO.EmployeeDTO.DepartmentId = Convert.ToInt32(System.Console.ReadLine());

            System.Console.WriteLine("Password : ");
            userDTO.Password = System.Console.ReadLine();

            System.Console.WriteLine("IsAdmin : ");
            userDTO.IsAdmin = Convert.ToBoolean(0);

            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
            OperationResult<IUserDTO> createEmployeeRetVal = userFacade.CreateEmployeeByTransaction(userDTO);
            if (createEmployeeRetVal.IsValid())
            {
                System.Console.WriteLine("Inserted!!  Emp Id : {0}   User Id : {1}", createEmployeeRetVal.Data.EmployeeId, createEmployeeRetVal.Data.UserId);
            }
        }

        static void UpdateEmployee()
        {
            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            userDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);

            #region commented
            //System.Console.WriteLine("User Id");
            //userDTO.UserId = Convert.ToInt32(System.Console.ReadLine());

            //System.Console.WriteLine("Employee Id");
            //userDTO.EmployeeDTO.EmployeeId = Convert.ToInt32(System.Console.ReadLine());

            //System.Console.WriteLine("First Name : ");
            //userDTO.EmployeeDTO.FirstName = System.Console.ReadLine();

            //System.Console.WriteLine("Last Name : ");
            //userDTO.EmployeeDTO.LastName = System.Console.ReadLine();

            //System.Console.WriteLine("Date of Joining : ");
            //DateTime doj;
            //DateTime.TryParse(System.Console.ReadLine(), out doj);
            //userDTO.EmployeeDTO.DateOfJoining = doj;

            //System.Console.WriteLine("Termination Date : ");
            //DateTime termDate;
            //DateTime.TryParse(System.Console.ReadLine(), out termDate);
            //userDTO.EmployeeDTO.DateOfJoining = termDate;

            //System.Console.WriteLine("Email : ");
            //userDTO.EmployeeDTO.Email = System.Console.ReadLine();

            //System.Console.WriteLine("Department Id : ");
            //userDTO.EmployeeDTO.DepartmentId = Convert.ToInt32(System.Console.ReadLine());

            //System.Console.WriteLine("Password : ");
            //userDTO.Password = System.Console.ReadLine();

            //System.Console.WriteLine("IsAdmin : ");
            //userDTO.IsAdmin = Convert.ToBoolean(System.Console.ReadLine());

            //IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            //userDTO.employeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO); 
            #endregion


            userDTO.IsAdmin = true;
            userDTO.Password = "metoo";
            userDTO.UserId = 6;
            userDTO.EmployeeId = 6;
            userDTO.EmployeeDTO.EmployeeId = 6;
            userDTO.EmployeeDTO.FirstName = "gv";
            userDTO.EmployeeDTO.LastName = "ar";
            userDTO.EmployeeDTO.Email = "gaurav@gmail.com";

            userDTO.EmployeeDTO.DateOfJoining = DateTime.Now.Date;
            userDTO.EmployeeDTO.TerminationDate = DateTime.Now.AddDays(2);
            userDTO.EmployeeDTO.DepartmentId = 1;

            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
            OperationResult<IUserDTO> createEmployeeRetVal = userFacade.UpdateEmployee(userDTO);
            if (createEmployeeRetVal.IsValid())
            {
                System.Console.WriteLine("Updated!!  Emp Id : {0}   User Id : {1}", createEmployeeRetVal.Data.EmployeeId, createEmployeeRetVal.Data.UserId);
            }
        }

        static void SearchEmployeeByRawQuery()
        {
            ISearchEmployeeDTO employeeDTO = (ISearchEmployeeDTO)DTOFactory.Instance.Create(DTOType.SearchEmployeeDTO);
            //employeeDTO.Firstname = "kan";
            DateTime d;
            DateTime.TryParse("01/01/2017", out d);
            employeeDTO.BeginDate = d;
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
            OperationResult<IList<IEmployeeDTO>> employeeDTOList = userFacade.SearchEmployeeByRawQuery(employeeDTO, true);
            if (employeeDTOList.IsValid())
            {
                foreach (IEmployeeDTO employee in employeeDTOList.Data)
                {
                    System.Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", employee.EmployeeId, employee.FirstName,
                        employee.LastName, employee.DateOfJoining, employee.DepartmentId);
                }
            }
        }

        static void SearchEmployeeBySProc()
        {
            ISearchEmployeeDTO employeeDTO = (ISearchEmployeeDTO)DTOFactory.Instance.Create(DTOType.SearchEmployeeDTO);
            employeeDTO.Firstname = "kan";
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
            OperationResult<IList<IEmployeeDTO>> employeeDTOList = userFacade.SearchEmployeeBySProc(employeeDTO, true);
            if (employeeDTOList.IsValid())
            {
                foreach (IEmployeeDTO employee in employeeDTOList.Data)
                {
                    System.Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", employee.EmployeeId, employee.FirstName,
                        employee.LastName, employee.DateOfJoining, employee.DepartmentId);
                }
            }
        }

        #endregion

        #region NoticeMethods
        static void GetActiveNotices()
        {
            INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
            OperationResult<IList<INoticeDTO>> getNoticesRetValue = noticeFacade.GetActiveNotices();
            if (getNoticesRetValue.IsValid())
            {
                foreach (var notice in getNoticesRetValue.Data)
                {
                    System.Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", notice.NoticeId, notice.Title, notice.Description, notice.PostedBy, notice.StartDate, notice.ExpirationDate);
                }
            }
        }

        static void GetCurrentNotices()
        {
            INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
            OperationResult<IList<INoticeDTO>> getNoticesRetValue = noticeFacade.GetCurrentNotices();
            if (getNoticesRetValue.IsValid())
            {
                foreach (var notice in getNoticesRetValue.Data)
                {
                    System.Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", notice.NoticeId, notice.Title, notice.Description, notice.PostedBy, notice.StartDate, notice.ExpirationDate);
                }
            }
        }

        static void UpdateNotice()
        {
            INoticeDTO noticeDTO = (INoticeDTO)DTOFactory.Instance.Create(DTOType.NoticeDTO);

            int noticeId;
            System.Console.WriteLine("Notice Id : ");
            int.TryParse(System.Console.ReadLine(), out noticeId);
            noticeDTO.NoticeId = noticeId;

            System.Console.WriteLine("Title : ");
            noticeDTO.Title = System.Console.ReadLine();

            System.Console.WriteLine("Description : ");
            noticeDTO.Description = System.Console.ReadLine();

            System.Console.WriteLine("Posted By : ");
            int postedBy;
            int.TryParse(System.Console.ReadLine(), out postedBy);
            noticeDTO.PostedBy = postedBy;

            System.Console.WriteLine("Start Date : ");
            DateTime startDate;
            DateTime.TryParse(System.Console.ReadLine(), out startDate);
            noticeDTO.StartDate = startDate;

            System.Console.WriteLine("Expiration Date : ");
            DateTime expirationDate;
            DateTime.TryParse(System.Console.ReadLine(), out expirationDate);
            noticeDTO.ExpirationDate = expirationDate;

            INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
            OperationResult<INoticeDTO> updateNoticesRetValue = noticeFacade.UpdateNotice(noticeDTO);
            if (updateNoticesRetValue.IsValid())
            {
                System.Console.WriteLine("Notice updated!!  Id  : ");
            }
        }

        static void DeleteNotice()
        {
            int noticeId;
            System.Console.WriteLine("Notice Id : ");
            int.TryParse(System.Console.ReadLine(), out noticeId);
            INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
            OperationResult<bool> deleteNoticesRetValue = noticeFacade.DeleteNotice(noticeId);
            if (deleteNoticesRetValue.IsValid())
            {
                System.Console.WriteLine("Notice Deleted!!");
            }
            else
            {
                System.Console.WriteLine("Notice Not Deleted");
            }
        }

        static void CreateNotice()
        {
            INoticeDTO noticeDTO = (INoticeDTO)DTOFactory.Instance.Create(DTOType.NoticeDTO);
            System.Console.WriteLine("Title : ");
            noticeDTO.Title = System.Console.ReadLine();

            System.Console.WriteLine("Description : ");
            noticeDTO.Description = System.Console.ReadLine();

            System.Console.WriteLine("Posted By : ");
            int postedBy;
            int.TryParse(System.Console.ReadLine(), out postedBy);
            noticeDTO.PostedBy = postedBy;

            System.Console.WriteLine("Start Date : ");
            DateTime startDate;
            DateTime.TryParse(System.Console.ReadLine(), out startDate);
            noticeDTO.StartDate = startDate;

            System.Console.WriteLine("Expiration Date : ");
            DateTime expirationDate;
            DateTime.TryParse(System.Console.ReadLine(), out expirationDate);
            noticeDTO.ExpirationDate = expirationDate;

            INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
            OperationResult<INoticeDTO> createNoticesRetValue = noticeFacade.CreateNotice(noticeDTO);
            if (createNoticesRetValue.IsValid())
            {
                System.Console.WriteLine("Notice created!!  Id  : " + createNoticesRetValue.Data.NoticeId);
            }
            else
            {
                System.Console.WriteLine(createNoticesRetValue.Data + "   " + createNoticesRetValue.Message);
            }
        }
        #endregion

        #region IssueMethods
        static IIssueDTO GetIssue()
        {
            int issueId;
            System.Console.WriteLine("Issue Id : ");
            int.TryParse(System.Console.ReadLine(), out issueId);

            IIssueFacade issueFacade = (IIssueFacade)FacadeFactory.Instance.Create(FacadeType.IssueManagerFacade);
            OperationResult<IIssueDTO> issueDTO = issueFacade.GetIssue(issueId);
            if (issueDTO.IsValid())
            {
                System.Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", issueDTO.Data.IssueId, issueDTO.Data.Title, issueDTO.Data.Description, issueDTO.Data.PostedBy, issueDTO.Data.Priority);
                foreach (IComplexIssueHistoryDTO issueHistoryDTO in issueDTO.Data.IssueHistories)
                {
                    System.Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}", issueHistoryDTO.Comments, issueHistoryDTO.AssignedTo, issueHistoryDTO.AssignedToName, issueHistoryDTO.Status, issueHistoryDTO.ModifiedBy, issueHistoryDTO.ModifiedOn);
                }
            }
            return issueDTO.Data;
        }

        static void GetAllIssuesByEmployeeId()
        {
            int employeeId;
            System.Console.WriteLine("Employee Id : ");
            int.TryParse(System.Console.ReadLine(), out employeeId);

            IIssueFacade issueFacade = (IIssueFacade)FacadeFactory.Instance.Create(FacadeType.IssueManagerFacade);
            OperationResult<IList<IComplexIssueDTO>> issueDTOList = issueFacade.GetAllIssuesByEmployeeId(employeeId);
            if (issueDTOList.IsValid())
            {
                foreach (IComplexIssueDTO issueDTO in issueDTOList.Data)
                {
                    System.Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", issueDTO.IssueId, issueDTO.Title,
                        issueDTO.Description, issueDTO.PostedByName, issueDTO.Priority, issueDTO.AssignedTo, issueDTO.AssignedToName);
                }
            }
        }

        static void GetAllActiveIssues()
        {
            IIssueFacade issueFacade = (IIssueFacade)FacadeFactory.Instance.Create(FacadeType.IssueManagerFacade);
            OperationResult<IList<IComplexIssueDTO>> issueDTOList = issueFacade.GetAllActiveIssues();
            if (issueDTOList.IsValid())
            {
                foreach (IComplexIssueDTO issueDTO in issueDTOList.Data)
                {
                    System.Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}", issueDTO.IssueId, issueDTO.Title, 
                        issueDTO.Description, issueDTO.PostedByName, issueDTO.Priority, issueDTO.AssignedTo, issueDTO.AssignedToName);
                }
            }
        }

        static void UpdateIssueByadmin()
        {
            IIssueHistoryDTO issueHDTO = (IIssueHistoryDTO)DTOFactory.Instance.Create(DTOType.IssueHistoryDTO);

            int issueId;
            System.Console.WriteLine("Issue Id : ");
            int.TryParse(System.Console.ReadLine(), out issueId);
            issueHDTO.IssueId = issueId;

            System.Console.WriteLine("Comments : ");
            issueHDTO.Comments = System.Console.ReadLine();

            System.Console.WriteLine("Modified By : ");
            int modifiedBy;
            int.TryParse(System.Console.ReadLine(), out modifiedBy);
            issueHDTO.ModifiedBy = modifiedBy;

            issueHDTO.ModifiedOn = DateTime.Now;

            System.Console.WriteLine("AssignedTo : ");
            int assigned;
            int.TryParse(System.Console.ReadLine(), out assigned);
            issueHDTO.AssignedTo = assigned;

            System.Console.WriteLine("Status : ");
            int status;
            int.TryParse(System.Console.ReadLine(), out status);
            issueHDTO.Status = status;

            IIssueFacade issueFacade = (IIssueFacade)FacadeFactory.Instance.Create(FacadeType.IssueManagerFacade);
            OperationResult<IIssueHistoryDTO> issueDTO = issueFacade.UpdateIssueByAdmin(issueHDTO);
            if (issueDTO.IsValid())
            {
                System.Console.WriteLine("Issue Updated. ");
            }
        }

        static void UpdateIssue()
        {
            IIssueDTO issueDTO = (IIssueDTO)DTOFactory.Instance.Create(DTOType.IssueDTO);

            int issueId;
            System.Console.WriteLine("Issue Id : ");
            int.TryParse(System.Console.ReadLine(), out issueId);
            issueDTO.IssueId = issueId;

            System.Console.WriteLine("Title : ");
            issueDTO.Title = System.Console.ReadLine();

            System.Console.WriteLine("Description : ");
            issueDTO.Description = System.Console.ReadLine();

            System.Console.WriteLine("Posted By : ");
            int postedBy;
            int.TryParse(System.Console.ReadLine(), out postedBy);
            issueDTO.PostedBy = postedBy;

            System.Console.WriteLine("Priority : ");
            int priority;
            int.TryParse(System.Console.ReadLine(), out priority);
            issueDTO.Priority = priority;

            IIssueFacade issueFacade = (IIssueFacade)FacadeFactory.Instance.Create(FacadeType.IssueManagerFacade);
            OperationResult<IIssueDTO> issueDTORetVal = issueFacade.UpdateIssue(issueDTO);
            if (issueDTORetVal.IsValid())
            {
                System.Console.WriteLine("Issue Updated. ");
            }
        }

        static void DeleteIssue()
        {
            int issueId;
            System.Console.WriteLine("Issue Id : ");
            int.TryParse(System.Console.ReadLine(), out issueId);
            IIssueFacade issueFacade = (IIssueFacade)FacadeFactory.Instance.Create(FacadeType.IssueManagerFacade);
            OperationResult<bool> deleteIssueRetValue = issueFacade.DeleteIssue(issueId);
            if (deleteIssueRetValue.IsValid())
            {
                System.Console.WriteLine("Issue Deleted!!");
            }
            else
            {
                System.Console.WriteLine("Issue Not Deleted");
            }
        }

        static void CreateIssue()
        {
            IIssueDTO issueDTO = (IIssueDTO)DTOFactory.Instance.Create(DTOType.IssueDTO);
            System.Console.WriteLine("Title : ");
            issueDTO.Title = System.Console.ReadLine();

            System.Console.WriteLine("Description : ");
            issueDTO.Description = System.Console.ReadLine();

            System.Console.WriteLine("Posted By : ");
            int postedBy;
            int.TryParse(System.Console.ReadLine(), out postedBy);
            issueDTO.PostedBy = postedBy;

            System.Console.WriteLine("Priority : ");
            IssuePriority priority;
            Enum.TryParse<IssuePriority>(System.Console.ReadLine(), out priority);
            issueDTO.Priority = (int)priority;

            IIssueFacade issueFacade = (IIssueFacade)FacadeFactory.Instance.Create(FacadeType.IssueManagerFacade);
            OperationResult<IIssueDTO> issueDTORetVal = issueFacade.CreateIssue(issueDTO);
            if (issueDTORetVal.IsValid())
            {
                System.Console.WriteLine("Issue Created.  Id : " + issueDTORetVal.Data.IssueId);
            }
        }
        #endregion

        #region DepartmentMethods
        static void GetDepartment()
        {
            System.Console.WriteLine("Department Id : ");
            int departmentId;
            int.TryParse(System.Console.ReadLine(), out departmentId);
            IDepartmentFacade departmentFacade = (IDepartmentFacade)FacadeFactory.Instance.Create(FacadeType.DepartmentManagerFacade);
            OperationResult<IDepartmentDTO> departmentDTO = departmentFacade.GetADepartment(departmentId);
            if (departmentDTO.IsValid())
            {
                System.Console.WriteLine(departmentDTO.Data.DepartmentId + "\t" + departmentDTO.Data.DepartmentName);
            }
        }

        static void GetAllDepartments()
        {
            IDepartmentFacade departmentFacade = (IDepartmentFacade)FacadeFactory.Instance.Create(FacadeType.DepartmentManagerFacade);
            OperationResult<IList<IDepartmentDTO>> departmentDTOList = departmentFacade.GetAllDepartments();
            if (departmentDTOList.IsValid())
            {
                foreach (var department in departmentDTOList.Data)
                {
                    System.Console.WriteLine(department.DepartmentId + "\t" + department.DepartmentName);
                }
            }
        }
        #endregion

        #region UserMethods
        static void UpdateProfile()
        {
            IUserDTO userDTO = (IUserDTO)DTOFactory.Instance.Create(DTOType.UserDTO);
            userDTO.EmployeeDTO = (IEmployeeDTO)DTOFactory.Instance.Create(DTOType.EmployeeDTO);

            userDTO.IsAdmin = true;
            userDTO.Password = "metoo";
            userDTO.UserId = 6;
            userDTO.EmployeeId = 6;
            userDTO.EmployeeDTO.EmployeeId = 6;
            userDTO.EmployeeDTO.FirstName = "Gaurav";
            userDTO.EmployeeDTO.LastName = "Arora";
            userDTO.EmployeeDTO.Email = "gaurav@gmail.com";

            userDTO.EmployeeDTO.DateOfJoining = DateTime.Now.Date;
            //userDTO.EmployeeDTO.TerminationDate = DateTime.Now.AddDays(2);
            userDTO.EmployeeDTO.DepartmentId = 1;

            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
            OperationResult<IUserDTO> createEmployeeRetVal = userFacade.UpdateProfile(userDTO);
            if (createEmployeeRetVal.IsValid())
            {
                System.Console.WriteLine("Updated!!  Emp Id : {0}   User Id : {1}", createEmployeeRetVal.Data.EmployeeId, createEmployeeRetVal.Data.UserId);
            }
        }

        static void Login()
        {
            System.Console.WriteLine("Username : ");
            string username = System.Console.ReadLine();
            System.Console.WriteLine("Password : ");
            string password = System.Console.ReadLine();
            IUserFacade userFacade = (IUserFacade)FacadeFactory.Instance.Create(FacadeType.UserManagerFacade);
            OperationResult<IUserDTO> loginEmployeeRetVal = userFacade.Login(username,password);
            if (loginEmployeeRetVal.IsValid())
            {
                System.Console.WriteLine("logged in!!  Emp Id : {0}   Name : {1}", loginEmployeeRetVal.Data.EmployeeId, loginEmployeeRetVal.Data.EmployeeDTO.FirstName);
            }
        }
        #endregion

        static void Main(string[] args)
        {

            int choice;

            do
            {
                System.Console.WriteLine("\n...MENU...\n1. Employee\n2. User\n3. Notice\n4. Issue\n5. Department\n0. Exit\nEnter choice : ");
                int.TryParse(System.Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        EmployeeMenu();
                        break;
                    case 2:
                        UserMenu();
                        break;
                    case 3:
                        NoticeMenu();
                        break;
                    case 4:
                        IssueMenu();
                        break;
                    case 5:
                        DepartmentMenu();
                        break;
                    case 0:
                        break;
                    default:
                        System.Console.WriteLine("Wrong Input. Try Again.");
                        break;
                }
            } while (choice != 0);
        }

    }

}


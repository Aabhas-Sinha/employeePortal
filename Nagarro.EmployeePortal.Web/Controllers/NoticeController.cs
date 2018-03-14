using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nagarro.EmployeePortal.Shared;
using Nagarro.EmployeePortal.Web.Shared;

namespace Nagarro.EmployeePortal.Web
{
    public class NoticeController : Controller
    {
        // GET: Notice
       
        public ActionResult Index()
        {
            ActionResult retVal = null;
           
                retVal = RedirectToAction("GetCurrentNotices");
            
            return retVal;
        }

        
        [HttpGet]
        public ActionResult GetActiveNotices()
        {
            ActionResult retVal = null;
            INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
            OperationResult<IList<INoticeDTO>> result = noticeFacade.GetActiveNotices();

            IList<NoticeModel> noticeModelList = null;

            if (result.IsValid())
            {
                noticeModelList = new List<NoticeModel>();
                NoticeModel noticeModel = null;
                foreach (INoticeDTO noticeDTO in result.Data)
                {
                    noticeModel = new NoticeModel();
                    DTOConverter.FillViewModelFromDTO(noticeModel, noticeDTO);
                    noticeModel.NotifierEmployeeName = noticeDTO.PostedByEmployee.FirstName + " " + noticeDTO.PostedByEmployee.LastName;
                    noticeModelList.Add(noticeModel);
                }
                retVal = View("~/Views/Notice/GetNotices.cshtml", noticeModelList);
            }
            else if (result.HasFailed())
            {
                retVal = RedirectToAction("Index", "Notice");
            }
            else
            {
                retVal = View("~/Views/Shared/Error.cshtml");
            }
            return retVal;
        }

        
        [HttpGet]
        public ActionResult GetCurrentNotices()
        {
            ActionResult retVal = null;
            INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
            OperationResult<IList<INoticeDTO>> result = noticeFacade.GetCurrentNotices();

            IList<NoticeModel> noticeModelList = null;

            if (result.IsValid())
            {
                noticeModelList = new List<NoticeModel>();
                NoticeModel noticeModel = null;
                foreach (INoticeDTO noticeDTO in result.Data)
                {
                    noticeModel = new NoticeModel();
                    DTOConverter.FillViewModelFromDTO(noticeModel, noticeDTO);
                    noticeModel.NotifierEmployeeName = noticeDTO.PostedByEmployee.FirstName + " " + noticeDTO.PostedByEmployee.LastName;
                    noticeModelList.Add(noticeModel);
                }
                retVal = View("~/Views/Notice/GetNotices.cshtml", noticeModelList);
            }
            else if (result.HasFailed())
            {
                retVal = RedirectToAction("Index", "Notice");
            }
            else
            {
                retVal = View("~/Views/Shared/Error.cshtml");
            }
            return retVal;
        }

       
        [HttpGet]
        public ActionResult CreateNotice()
        {
            ViewBag.Create = true;
            return PartialView("~/Views/Notice/_EditNotice.cshtml", new NoticeModel());
        }

        
        [HttpPost]
        public ActionResult CreateNotice(NoticeModel notice)
        {
            ActionResult retVal = null;
            if (ModelState.IsValid)
            {
                notice.PostedBy = SessionStateManager<UserInfo>.Data.Employee.EmployeeId;
                INoticeDTO noticeDTO = (INoticeDTO)DTOFactory.Instance.Create(DTOType.NoticeDTO);
                DTOConverter.FillDTOFromViewModel(noticeDTO, notice);

                INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
                OperationResult<INoticeDTO> result = noticeFacade.CreateNotice(noticeDTO);

                if (result.IsValid())
                {
                    retVal = new JsonResult()
                    {
                        Data = new
                        {
                            Message = "Notice created Successfully",
                            Success = true,
                            RedirectUrl = Url.Action("GetActiveNotices", "Notice")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else if (result.HasValidationFailed() && (result.ValidationResult != null))
                {
                    foreach (EmployeePortalValidationFailure error in result.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    retVal = PartialView("~/Views/Notice/_EditNotice.cshtml", notice);
                    //retVal = PartialView("~/Views/Shared/_CreateNotice.cshtml",notice);
                }
                else if (result.HasFailed())
                {
                    //retVal = RedirectToAction("GetActiveNotices", "Notice");
                    retVal = new JsonResult()
                    {
                        Data = new
                        {
                            Message = "Notice Creation failed",
                            Success = false,
                            RedirectUrl = Url.Action("GetActiceNotices")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    retVal = View("~/Views/Shared/Error.cshtml");
                }
            }
            return retVal;
        }

        
        [HttpGet]
        public ActionResult EditNotice(int noticeId)
        {
            ActionResult retVal = null;
            INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
            OperationResult<INoticeDTO> result = noticeFacade.GetNotice(noticeId);
            if (result.IsValid())
            {
                NoticeModel notice = new NoticeModel();
                DTOConverter.FillViewModelFromDTO(notice, result.Data);
                ViewBag.Create = false;
                retVal = PartialView("~/Views/Notice/_EditNotice.cshtml", notice);
            }
            else if (result.HasFailed())
            {
                retVal = RedirectToAction("GetActiveNotices", "Notice");
            }
            else
            {
                retVal = View("~/Views/Shared/Error.cshtml");
            }
            return retVal;
        }

        
        [HttpPost]
        public ActionResult EditNotice(NoticeModel notice)
        {
            ActionResult retVal = null;

            if (ModelState.IsValid)
            {
                INoticeDTO noticeDTO = (INoticeDTO)DTOFactory.Instance.Create(DTOType.NoticeDTO);
                DTOConverter.FillDTOFromViewModel(noticeDTO, notice);

                INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
                OperationResult<INoticeDTO> result = noticeFacade.UpdateNotice(noticeDTO);

                if (result.IsValid())
                {
                    retVal = new JsonResult()
                    {
                        Data = new
                        {
                            Message = "Notice Updated Successfully",
                            Success = true,
                            RedirectUrl = Url.Action("GetActiveNotices","Notice")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else if (result.HasValidationFailed() && (result.ValidationResult != null))
                {
                    foreach (EmployeePortalValidationFailure error in result.ValidationResult.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }

                    retVal = PartialView("~/Views/Notice/_EditNotice.cshtml", notice);
                }
                else if (result.HasFailed())
                {
                    retVal = new JsonResult()
                    {
                        Data = new
                        {
                            Message = "Notice Updation failed",
                            Success = false,
                            RedirectUrl = Url.Action("GetActiceNotices")
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    retVal = View("~/Views/Shared/Error.cshtml");
                }
            }

            return retVal;
        }

  
        [HttpGet]
        public ActionResult DeleteNotice(int noticeId)
        {
            ActionResult retVal = null;
            INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
            OperationResult<bool> result = noticeFacade.DeleteNotice(noticeId);

            if (result.IsValid())
            {
                //retVal = RedirectToAction("GetActiveNotices", "Notice");
                retVal = new JsonResult
                {
                    Data = new
                    {
                        Message = "Notice deletely successfully",
                        Success = true
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else if (result.HasFailed())
            {
                //retVal = RedirectToAction("GetActiveNotices", "Notice");
                retVal = new JsonResult
                {
                    Data = new
                    {
                        Message = "Notice could not be deleted",
                        Success = false
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                retVal = View("~/Views/Shared/Error.cshtml");
            }
            return retVal;
        }

      
        [HttpGet]
        public ActionResult NoticeDetails(int noticeId)
        {
            ActionResult retVal = null;
            INoticeFacade noticeFacade = (INoticeFacade)FacadeFactory.Instance.Create(FacadeType.NoticeManagerFacade);
            OperationResult<INoticeDTO> result = noticeFacade.GetNotice(noticeId);
            if (result.IsValid())
            {
                NoticeModel notice = new NoticeModel();
                DTOConverter.FillViewModelFromDTO(notice, result.Data);
                notice.NotifierEmployeeName = result.Data.PostedByEmployee.FirstName + " " + result.Data.PostedByEmployee.LastName;
                retVal = PartialView("~/Views/Notice/_NoticeDetails.cshtml", notice);
            }
            else if (result.HasFailed())
            {
                retVal = RedirectToAction("GetActiveNotices", "Notice");
            }
            else
            {
                retVal = View("~/Views/Shared/Error.cshtml");
            }
            return retVal;
        }
    }
}
function EmployeePortalNotice(initOptions)
{
    var context = this;
    var noticeUtility = new utility();
    var noticeDataService = new dataService();

    function init()
    {
        noticeUtility.attachEvent("div[data-noticeId]", "click", "a[data-action='delete']", OnDeleteClick);
        noticeUtility.attachEvent("div[data-noticeId]", "click", "a[data-action='edit']", OnEditClick);
        noticeUtility.attachEvent("div[data-noticeId]", "click", "a[data-action='details']", OnDetailClick);
        noticeUtility.attachEvent("p", "click", "a[data-action='create']", OnCreateClick);
    }

    function OnDeleteClick()
    {
        var noticeId = $(this).closest('div').attr('data-noticeId');
        if (confirm("Are you sure you want to delete this notice ?"))
        {
            var options = {
                ajaxActionUrl: initOptions.deleteUrl,
                data: { noticeId: noticeId },
                success: function (result) { OnDeleteSuccess(result, noticeId); },
                failure: OnDeleteError
            };
            noticeDataService.ajax(options);
        }        
    }

    function OnDeleteSuccess(result, noticeId)
    {
        if(result.Success)
        {
            $("div[data-noticeId = '" + noticeId + "']").closest('.row').remove();
        }
        alert(result.Message);
    }

    function OnDeleteError(message)
    {
        OnErrorCallBack(message);
    }

    function OnEditClick() {
        var noticeId = $(this).closest('div').attr('data-noticeId');

        var options = {
            selector: '#divNotice',
            ajaxActionUrl: decodeURI(initOptions.editUrl).replace(initOptions.noticeIdPlaceholder, noticeId),
            data: null,
            success: OnEditSuccess,
            failure: OnEditError
        };
        noticeDataService.load(options.selector, options.ajaxActionUrl, options.data, options.success, options.failure);
    }

    function OnEditSuccess() {
        $('#divNotice > .modal').modal('show');
        $.validator.unobtrusive.parse('#noticeForm');
    }

    function OnEditError(message) {
        OnErrorCallBack(message);
    }

    function OnCreateClick() {

        var options = {
            selector: '#divNotice',
            ajaxActionUrl: initOptions.createUrl,
            data: null,
            success: OnCreateSuccess,
            failure: OnCreateError
        };
        noticeDataService.load(options.selector, options.ajaxActionUrl, options.data, options.success, options.failure);
    }

    function OnCreateSuccess() {
        $('#divNotice > .modal').modal('show');
        $.validator.unobtrusive.parse('#noticeForm');
    }

    function OnCreateError(message) {
        OnErrorCallBack(message);
    }

    function OnDetailClick() {
        var noticeId = $(this).closest('div').attr('data-noticeId');

        var options = {
            selector: '#divNotice',
            ajaxActionUrl: decodeURI(initOptions.detailUrl).replace(initOptions.noticeIdPlaceholder, noticeId),
            data: null,
            success: OnDetailSuccess,
            failure: OnDetailError
        };
        noticeDataService.load(options.selector, options.ajaxActionUrl, options.data, options.success, options.failure);
    }

    function OnDetailSuccess() {
        $('#divNotice > .modal').modal('show');
    }

    function OnDetailError(message) {
        OnErrorCallBack(message);
    }

    function OnErrorCallBack(message)
    {
        alert(message);
    }

    init();
}
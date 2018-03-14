function EmployeePortalIssue(initOptions) {
    var context = this;
    var issueUtility = new utility();
    var issueDataService = new dataService();

    function init() {
        issueUtility.attachEvent("tr[data-issueId]", "click", "a[data-action='delete']", OnDeleteClick);
        issueUtility.attachEvent("tr[data-issueId]", "click", "a[data-action='edit']", OnEditClick);
        issueUtility.attachEvent("tr[data-issueId]", "click", "a[data-action='details']", OnDetailClick);
        issueUtility.attachEvent("p", "click", "a[data-action='create']", OnCreateClick);
    }

    function OnDeleteClick() {
        var issueId = $(this).closest('tr').attr('data-issueId');
        if (confirm("Are you sure you want to delete this issue ?")) {
            var options = {
                ajaxActionUrl: initOptions.deleteUrl,
                data: { issueId: issueId },
                success: function (result) { OnDeleteSuccess(result, issueId); },
                failure: OnDeleteError
            };
            issueDataService.ajax(options);
        }
    }

    function OnDeleteSuccess(result, issueId) {
        if (result.Success) {
            $("tr[data-issueId = '" + issueId + "']").remove();
        }
        alert(result.Message);
    }

    function OnDeleteError(message) {
        OnErrorCallBack(message);
    }

    function OnEditClick() {
        var issueId = $(this).closest('tr').attr('data-issueId');

        var options = {
            selector: '#divIssue',
            ajaxActionUrl: decodeURI(initOptions.editUrl).replace(initOptions.issueIdPlaceholder, issueId),
            data: null,
            success: OnEditSuccess,
            failure: OnEditError
        };
        issueDataService.load(options.selector, options.ajaxActionUrl, options.data, options.success, options.failure);
    }

    function OnEditSuccess() {
        $('#divIssue > .modal').modal('show');
        $.validator.unobtrusive.parse('#issueForm');
    }

    function OnEditError(message) {
        OnErrorCallBack(message);
    }

    function OnCreateClick() {

        var options = {
            selector: '#divIssue',
            ajaxActionUrl: initOptions.createUrl,
            data: null,
            success: OnCreateSuccess,
            failure: OnCreateError
        };
        issueDataService.load(options.selector, options.ajaxActionUrl, options.data, options.success, options.failure);
    }

    function OnCreateSuccess() {
        $('#divIssue > .modal').modal('show');
        $.validator.unobtrusive.parse('#issueForm');
    }

    function OnCreateError(message) {
        OnErrorCallBack(message);
    }

    function OnDetailClick() {
        var issueId = $(this).closest('tr').attr('data-issueId');

        var options = {
            selector: '#divIssue',
            ajaxActionUrl: decodeURI(initOptions.detailUrl).replace(initOptions.issueIdPlaceholder, issueId),
            data: null,
            success: OnDetailSuccess,
            failure: OnDetailError
        };
        issueDataService.load(options.selector, options.ajaxActionUrl, options.data, options.success, options.failure);
    }

    function OnDetailSuccess() {
        $('#divIssue > .modal').modal('show');
    }

    function OnDetailError(message) {
        OnErrorCallBack(message);
    }

    function OnErrorCallBack(message) {
        alert(message);
    }

    init();
}
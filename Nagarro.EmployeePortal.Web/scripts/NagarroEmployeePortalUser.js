function EmployeePortalUser(initOptions) {
    var context = this;
    var userUtility = new utility();
    var userDataService = new dataService();

    function init() {
        userUtility.attachEvent("#divSearchEmployee", "click", "a[data-action='edit']", OnEditClick);
        userUtility.attachEvent("#pCreateButton", "click", "a[data-action='create']", OnCreateClick);
    }

    function OnEditClick() {
        var employeeEmail = $(this).closest('tr').attr('data-employeeEmail');

        var options = {
            selector: '#divUser',
            ajaxActionUrl: decodeURI(initOptions.editUrl).replace(initOptions.employeeEmailPlaceholder, employeeEmail),
            data: null,
            success: OnEditSuccess,
            failure: OnEditError
        };
        userDataService.load(options.selector, options.ajaxActionUrl, options.data, options.success, options.failure);
    }

    function OnEditSuccess() {
        $('#divUser > .modal').modal('show');
        $.validator.unobtrusive.parse('#userForm');
    }

    function OnEditError(message) {
        OnErrorCallBack(message);
    }

    function OnCreateClick() {
        var options = {
            selector: '#divUser',
            ajaxActionUrl: initOptions.createUrl,
            data: null,
            success: OnCreateSuccess,
            failure: OnCreateError
        };
        userDataService.load(options.selector, options.ajaxActionUrl, options.data, options.success, options.failure);
    }

    function OnCreateSuccess() {
        $('#divUser > .modal').modal('show');
        $.validator.unobtrusive.parse('#userForm');
    }

    function OnCreateError(message) {
        OnErrorCallBack(message);
    }

    function OnErrorCallBack(message) {
        alert(message);
    }

    init();
}
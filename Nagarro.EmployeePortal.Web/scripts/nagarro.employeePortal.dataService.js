function dataService() {
    var defaults = {
        selector: document,
        ajaxActionUrl: "#",
        data: "",
        method: 'GET',
        success: function (result) {
            alert(result.message);
        },
        error: function (message) {
            alert(message);
        },
        dataType: 'JSON'
    };

    this.ajax = function (options) {
        this.options = $.extend({}, defaults, options);
        $.ajax({
            url: options.ajaxActionUrl,
            data: options.data,
            method: options.method,
            success: options.success,
            error: options.failure,
            dataType: options.dataType
        });
    };

    this.getJSONData = function (options) {
        this.options = $.extend({}, defaults, options);

        $.getJSON(options.ajaxActionUrl, options.data, function (result) {
            options.success(result);
        }).error(function (message) {
            options.failure(message);
        });
    };

    this.postData = function (ajaxActionUrl, data, success, failure) {
        $.ajax({
            url: ajaxActionUrl,
            type: 'POST',
            data: data,
            success: function (data) {
                success(data);
            },
            error: function (e) {
                console.log(e.message);
            }
        });
    };

    this.load = function (selector, ajaxActionUrl, data, success, failure) {
        $(selector).load(ajaxActionUrl, data, function (result) {
            success(result);
        });
    };
};
// ajax method call for form submits
// ajax-form id sine sahip form lar genel olarak grid  vs. refresh ederek content basar
$('#ajax-form').submit(function (event) {
    event.preventDefault();
    if ($(this).valid()) {
        var target = $('div.ajax-request-target');
        var button = $("button[type=submit]");
        beforeInvoke(target);
        $.ajax({
            cache: false,// ie makes problem if not used
            url: this.action,
            type: this.method,
            async: true,
            data: $(this).serialize(),
            success: function (result) {
                afterSuccess(result, target, button);
            },
            error: function () {
                afterError('An unhandled client-side error occured at AjaxRequest.prototype.sendRequest()', 'error', target, button);
            }
        });
    }
    return false;
});

function beforeInvoke(target) {
    var button = $("button[type=submit]");
    button.addClass("disabled");
    target.block({
        message: 'Lütfen bekleyiniz..',
        css: {
            width: '150px',
            height: '30px'
        }
    });
    $(".user-message").empty();
}

function afterSuccess(result, target, button) {
    console.log('div.ajax-request-target successfully loaded');
    if (typeof result.messageArray != 'undefined') {
        afterError(result.messageArray, result.type, target, button);
    }
    else {
        target.html(result);
        target.unblock();
        button.removeClass('disabled');
        var targetElementId = "div.ajax-request-target";
        setPreviousPageTargetContent(targetElementId, result); //result ve etkilenen target elementini previousPage değişkenine ata (_layout.js )
    }
}

function afterError(message, type, target, button) {
    console.log(message, type);
    console.log('div.ajax-request-target loaded with some errors:', message);
    $('div.ajax-request-target table').dataTable().fnClearTable(); //clear the ajax-request table
    var messageElementSelector = '.user-message';
    showMessage(type, message, messageElementSelector);  //show error to user with append option
    target.unblock();
    button.removeClass('disabled');
}

// Definition of AjaxRequest class - this class used for classical XmlHttpRequests
function AjaxRequest(type, data, controller, action, callback_beforeRequestSent, callBack_afterRequestSent) { //e.g: 'div.main-content','div.#renderedBody', debtor,limit,54043
    /*SAMPLE 
     $.ajax({
            url: '/FSIS/creditor/Loadxx',
            type: 'POST',
            data: test,
            content: 'application/json; charset=utf-8',
            dataType: "json",
            success: function (data) {
                alert(data.success);
            },
            error: function () {
                alert("error");
            }
        });
    */
    this.type = type;
    this.data = data;
    this.controller = controller;
    this.action = action;
    this.callback_beforeRequestSent = callback_beforeRequestSent;  // fire this event before method sent if implemented
    this.callBack_afterRequestSent = callBack_afterRequestSent; // fire this event after method sent if implemented

    if (typeof (callback_beforeRequestSent) == "function") { // is callback_BeforeRerquestSent method implemented?
        callback_beforeRequestSent();   //fire the default beforeSuccess  event method
    }
    else
        console.log('callback_BeforeRequestSent method not implemented!');
}
AjaxRequest.prototype.sendRequest = function () {
    console.log("AjaxRequest.sendRequest: type:" + this.type + " data: " + this.data + "  controller:" + this.controller + " action:" + this.action);
    var callBack_afterReqSent = this.callBack_afterRequestSent;
    var resultType = "";
    $.ajax({
        url: ROOT_DIR + '/' + this.controller + '/' + this.action,
        type: this.type,
        data: this.data,
        content: 'application/json; charset=utf-8',
        //  dataType: "json", //if uncommented request body always must be json typed
        success: function (result) {
            console.log("AjaxRequest.sendRequest: method successfully ended");
            resultType = "success";
            if (typeof result.messageArray != 'undefined') {
                resultType = result.type;
            }
            if (typeof (callBack_afterReqSent) == "function") { // is onAjaxRequestSuccess method implemented?
                callBack_afterReqSent(result, resultType);   //fire the default xhrequest success  event method
            }
            else
                console.log('callBack_afterRequestSent method not implemented!');
        },
        error: function (e, settings, exception) {
            resultType = "server-error";
            var message;
            if (e.status) {
                message = STATUS_ERROR_MAP[e.status];
                if (!message) {
                    message = "Unknown Error.";
                }
            } else if (exception == 'parsererror') {
                message = "Error. Parsing JSON Request failed.";
            } else if (exception == 'timeout') {
                message = "Request Time out.";
            } else if (exception == 'abort') {
                message = "Request was aborted by the server";
            } else {
                message = "Unknown Error.";
            }
            if (typeof (callBack_afterReqSent) == "function") { // is onAjaxRequestSuccess method implemented?
                var result = {
                    type: resultType,
                    messageArray: message
                }
                callBack_afterReqSent(result, resultType);   //fire the default xhrequest success  event method
            }
            else
                console.log('callBack_afterRequestSent method not implemented!');
        }
    });

}

// for submission of a spesific form
AjaxRequest.prototype.submitForm = function (form) {
    console.log("AjaxRequest.submitForm: type:" + form.type + " data: " + form.data + " url:" + form.action);
    var callBack_afterReqSent = this.callBack_afterRequestSent;

    if ($(form).valid()) {
        $.ajax({
            cache: false,// ie makes problem if not used
            url: form.action,
            type: form.method,
            async: true,
            data: $(form).serialize(),
            success: function (result) {
                console.log("AjaxRequest.submitForm: method successfully ended");
                resultType = "success";
                if (typeof result.messageArray != 'undefined') { // json data returned from server
                    resultType = result.type;
                }
                if (typeof (callBack_afterReqSent) == "function") { // is onAjaxRequestSuccess method implemented?
                    callBack_afterReqSent(result, resultType);   //fire the default xhrequest success  event method
                }
                else
                    console.log('callBack_afterRequestSent method not implemented!');
            },
            error: function (e, settings, exception) {
                resultType = "server-error";
                var message;
                if (e.status) {
                    message = STATUS_ERROR_MAP[e.status];
                    if (!message) {
                        message = "Unknown Error.";
                    }
                } else if (exception == 'parsererror') {
                    message = "Error. Parsing JSON Request failed.";
                } else if (exception == 'timeout') {
                    message = "Request Time out.";
                } else if (exception == 'abort') {
                    message = "Request was aborted by the server";
                } else {
                    message = "Unknown Error.";
                }
                if (typeof (callBack_afterReqSent) == "function") { // is onAjaxRequestSuccess method implemented?
                    var result = {
                        type: resultType,
                        messageArray: message
                    }
                    callBack_afterReqSent(result, resultType);   //fire the default xhrequest success  event method
                }
                else
                    console.log('callBack_afterRequestSent method not implemented!');
            }
        });
    }
    return false;
}
//End of AjaxRequest class
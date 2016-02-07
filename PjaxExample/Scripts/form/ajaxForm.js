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
                afterSuccessfulSubmission(result, target, button);
            },
            error: function () {
                afterErrorOccured('An unhandled client-side error occured at AjaxRequest.prototype.sendRequest()', 'error', target, button);
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

function afterSuccessfulSubmission(result, target, button) {
    console.log('div.ajax-request-target successfully loaded');
    if (typeof result.messageArray != 'undefined') {
        afterError(result.messageArray, result.type, target, button);
    }
    else {
        target.html(result);
        target.unblock();
        button.removeClass('disabled');
        //var targetElementId = "div.ajax-request-target";
        //setPreviousPageTargetContent(targetElementId, result); //result ve etkilenen target elementini previousPage değişkenine ata (_layout.js )
    }
}

function afterErrorOccured(message, type, target, button) {
    console.log(message, type);
    console.log('div.ajax-request-target loaded with some errors:', message);
    $('div.ajax-request-target table').dataTable().fnClearTable(); //clear the ajax-request table
    var messageElementSelector = '.user-message';
    showMessage(type, message, messageElementSelector);  //show error to user with append option
    target.unblock();
    button.removeClass('disabled');
}

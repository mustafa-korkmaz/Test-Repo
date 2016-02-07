// Define UserMessage class 
function UserMessage(messageType, messageArray) { //e.g: error,Something went wrong. Please try again later.

    this.messageType = messageType;
    this.messageArray = messageArray;
}

// Shows a message to current user
UserMessage.prototype.showMessage = function (elementSelector) {
    console.log(this.messageType + "-" + this.messageArray);
    var messageHtml;
    if ((typeof this.messageArray != 'undefined') && (typeof this.messageType != 'undefined')) {
        switch (this.messageType.toLowerCase()) {
            case 'server-error':
                messageHtml = getServerErrorHtml(this.messageArray);
                break;
            case 'error':
                messageHtml = getErrorHtml(this.messageArray);
                break;
            case 'warning':
                messageHtml = getWarningHtml(this.messageArray);
                break;
            case 'success':
                messageHtml = getSuccessHtml(this.messageArray);
                break;
            case 'info':
                messageHtml = getInfoHtml(this.messageArray);
                break;
            default:
                break;
        }
    }
    else {
        messageHtml = getServerErrorHtml("An unhandled client-side error occured at UserMessage.prototype.showMessage()");
    }
    $(elementSelector).append(messageHtml);
}

function getServerErrorHtml(message) {
    /*
        <div class="alert alert-danger">
                            <button type="button" class="close" data-dismiss="alert">
                                <i class="icon-remove"></i>
                            </button>

                            <strong>Hata:</strong>

                            Change a few things up and try submitting again.
                            <br />
        </div>
    */
    var _array = [];
    _array.push(message)
    var html = '<div class="alert alert-danger">';
    html += '<button type="button" class="close" data-dismiss="alert">';
    html += '<i class="icon-remove"></i>';
    html += '</button>';
    html += '<strong>Sistem Hatası:</strong>';
    _array.forEach(function (element, index, array) {
        html += " " + array[index] + ' <br/>';
    });
    html += '   </div>';

    return html;
}

function getErrorHtml(messageArray) {
    /*
        <div class="alert alert-danger">
                            <button type="button" class="close" data-dismiss="alert">
                                <i class="icon-remove"></i>
                            </button>

                            <strong>Hata:</strong>

                            Change a few things up and try submitting again.
                            <br />
        </div>
    */
    var _array = [];
    _array = JSON.parse(messageArray);
    var html = '<div class="alert alert-danger">';
    html += '<button type="button" class="close" data-dismiss="alert">';
    html += '<i class="icon-remove"></i>';
    html += '</button>';
    html += '<strong>Hata:</strong>';
    _array.forEach(function (element, index, array) {
        html += " " + array[index] + ' <br/>';
    });
    html += '   </div>';

    return html;
}

function getWarningHtml(messageArray) {
    /*
    <div class="alert alert-warning">
											<button type="button" class="close" data-dismiss="alert">
												<i class="icon-remove"></i>
											</button>
											<strong>Warning!</strong>

											Best check yo self, you're not looking too good.
											<br />
										</div>
    */
    var _array = [];
    _array = JSON.parse(messageArray);
    var html = ' <div class="alert alert-warning">';
    html += '<button type="button" class="close" data-dismiss="alert">';
    html += '<i class="icon-remove"></i>';
    html += '</button>';
    html += '<strong>Uyarı:</strong>';
    _array.forEach(function (element, index, array) {
        html += " " + array[index] + ' <br/>';
    });
    html += '  </div>';

    return html;
}

function getSuccessHtml(messageArray) {
    /*
    <div class="alert alert-block alert-success">
											<button type="button" class="close" data-dismiss="alert">
												<i class="icon-remove"></i>
											</button>

												<strong>
													<i class="icon-ok"></i>
													Well done!
												</strong>
												You successfully read this important alert message.
											<br />
										</div>
    */
    var _array = [];
    _array = JSON.parse(messageArray);
    var html = '<div class="alert alert-block alert-success">';
    html += '<button type="button" class="close" data-dismiss="alert">';
    html += '<i class="icon-remove"></i>';
    html += '</button>';
    html += '<strong>	<i class="icon-ok"></i>Başarılı:</strong>';
    _array.forEach(function (element, index, array) {
        html += " " + array[index] + ' <br/>';
    });
    html += '  </div>';

    return html;
}

function getInfoHtml(messageArray) {
    /*<div class="alert alert-info">
											<button type="button" class="close" data-dismiss="alert">
												<i class="icon-remove"></i>
											</button>
											<strong>Heads up!</strong>

											This alert needs your attention, but it's not super important.
											<br />
										</div>
*/
    var _array = [];
    _array = JSON.parse(messageArray);
    var html = '<div class="alert alert-info">';
    html += '<button type="button" class="close" data-dismiss="alert">';
    html += '<i class="icon-remove"></i>';
    html += '</button>';
    html += '<strong>Bilgi:</strong>';
    _array.forEach(function (element, index, array) {
        html += " " + array[index] + ' <br/>';
    });
    html += '  </div>';

    return html;
}

// bottbox.js messages
//$("#bootbox-regular").on(ace.click_event, function () {
//    bootbox.prompt("What is your name?", function (result) {
//        if (result === null) {
//            //Example.show("Prompt dismissed");
//        } else {
//            //Example.show("Hi <b>"+result+"</b>");
//        }
//    });
//});

function confirmMessage(type, callBack_afterConfirm) {

    var message = "";
    switch (type) {
        case "delete":
            message = "Kaydı silmek istediğinizden emin misiniz?";
            break;
        case "pledgeRedeemRequest":
            message = "Rehin kaldırma başlatılacaktır. Devam etmek istediğinizden emin misiniz?";
            break;
        default:
            break;
    }
    bootbox.dialog({
        message: "<span class='bigger-110'>" + message + "</span>",
        buttons:
        {
            "success":
             {
                 "label": "<i class='icon-ok'></i> Evet",
                 "className": "btn-sm btn-success",
                 "callback": function () {
                     callBack_afterConfirm(true);
                 }
             },
            "danger":
            {
                "label": "İptal",
                "className": "btn-sm btn-danger",
                "callback": function () {
                    callBack_afterConfirm(false);
                }
            }
        }
    });
}

//$("#bootbox-confirm").on(ace.click_event, function () {
//    bootbox.confirm("Are you sure?", function (result) {
//        if (result) {
//            //
//        }
//    });
//});
//$("#bootbox-regular").on(ace.click_event, function () {
//    bootbox.dialog({
//        message: "<span class='bigger-110'>I am a custom dialog with smaller buttons</span>",
//        buttons:
//        {
//            "success":
//             {
//                 "label": "<i class='icon-ok'></i> Success!",
//                 "className": "btn-sm btn-success",
//                 "callback": function () {
//                     //Example.show("great success");
//                 }
//             },
//            "danger":
//            {
//                "label": "Danger!",
//                "className": "btn-sm btn-danger",
//                "callback": function () {
//                    //Example.show("uh oh, look out!");
//                }
//            },
//            "click":
//            {
//                "label": "Click ME!",
//                "className": "btn-sm btn-primary",
//                "callback": function () {
//                    //Example.show("Primary button");
//                }
//            },
//            "button":
//            {
//                "label": "Just a button...",
//                "className": "btn-sm"
//            }
//        }
//    });
//});
// end of bootbox.js messages
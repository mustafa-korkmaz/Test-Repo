jQuery(function ($) {
    $(' a.page-link').click(function () {
        //load menu item from side bar
        var view_link = $(this).attr('id').split('-');
        var controller_name = view_link[0];
        var action_name = view_link[1];

        //now load view as partial and scroll top of the page
        loadContent('#page-content', '#rendered-body', controller_name, action_name, '');
    });

    $('.root-link').click(function () {
        if ($(this).attr('id') != '') {
            var view_link = $(this).attr('id').split('-');
            var controller_name = view_link[0];
            var action_name = view_link[1];
            loadContent('div.main-content', '#rendered-body', controller_name, action_name, '');
        }
    });

});

function loadContent(wrapperElement, matchedElement, controller, action, routeValues) { //e.g: 'div.main-content','div.#renderedBody',/VDFFactoring, debtor,limit,54043

    var contentLoader = new ContentLoader(wrapperElement, matchedElement, controller, action, routeValues);

    contentLoader.loadContent();
}

/*
//when a  breadcrumb clicked
function loadPageFromBreadcrumb(controllerName, actionName) {
    loadContent('div.main-content', '#rendered-body', controllerName, actionName, '');
}


// show a message to current user
function showMessage(messageType, message, messageElementSelector, appendMessage) {
    appendMessage = typeof appendMessage !== 'undefined' ? appendMessage : false;  // append new message to message section or only print this message
    if (appendMessage == false) {
        $(messageElementSelector).empty();
    }
    var userMessage = new UserMessage(messageType, message);
    userMessage.showMessage(messageElementSelector);
}

//previousPage değişkeni içerisindeki html contenti önceki sayfa olarak ekrana basar
function goToPreviousPage() {
    console.log("layout.js.goToPreviousPage()");
    blockContent(PREVIOUS_PAGE.wrappedElementId);
    var fullpage = PREVIOUS_PAGE.fullPageContent;
    var target = PREVIOUS_PAGE.targetContent;
    $(PREVIOUS_PAGE.fullPageContentId).html(fullpage); // önce page load ile gelen dataları al
    $(PREVIOUS_PAGE.targetElementId).html(target); // eger güncellenen veri varsa onları da replace et
    unBlockContent(PREVIOUS_PAGE.wrappedElementId);
}
//targetElementId içindeki html contenti  previousPage değişkenine atar. Sayfa içindeki serverdan gelen verileri tablo, vs.. tutmak için kullanıcaz
function setPreviousPageTargetContent(targetElementId, result) {
    console.log("layout.js.setPreviousPageTargetContent()");
    PREVIOUS_PAGE.targetElementId = targetElementId;
    PREVIOUS_PAGE.targetContent = result;
}
//result içindeki html contenti  previousPage değişkenine atar - sadece previousPage.fullPageContent = result; yazılarak da kullanılabilir
function setPreviousPageFullContent(result) {
    console.log("layout.js.setPreviousPageFullContent()");
    //previousPage.fullPageContentId = fullPageContentId; - defined in GLOBAL.js 
    PREVIOUS_PAGE.fullPageContent = result;
}


*/
function closeModalBox() {
    $('div.modal-box-header button.close').trigger('click');
}

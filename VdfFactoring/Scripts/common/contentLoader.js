// Define contentLoader class 
function ContentLoader(wrapperElement, matchedElement, controller, action, routeValues) { //e.g: 'div.main-content','div.#renderedBody',/VDFFactoring, debtor,limit,54043

    this.wrapperElement = wrapperElement;
    this.matchedElement = matchedElement;
    this.controller = controller;
    this.action = action;
    this.routeValues = routeValues;

}

//this method loads the content of an element via jQuery load method
ContentLoader.prototype.loadContent = function () {
    console.log("ContentLoader.loadContent: blocked object:" + this.wrapperElement + " loading object:" + this.matchedElement + " URL: " + ROOT_DIR + '/' + this.controller + '/' + this.action + '/' + this.routeValues);
    var loadingElement = this.matchedElement;
    var blockedElement = this.wrapperElement;
    var routeValues = this.routeValues;
    var controller = this.controller;
    var action = this.action;

    blockContent(blockedElement);

    $.ajax({
        cache: false,// ie makes problem if not used
        url: ROOT_DIR + '/' + this.controller + '/' + this.action,
        content: 'application/json; charset=utf-8',
        type: 'GET',
        async: true,
        data: this.routeValues,
        success: function (result) {
            afterLoad(loadingElement, result, blockedElement, controller, action);
        },
        error: function (result) {
            contentLoaderError(result.message, result.type, blockedElement);
        }
    });
}

//this global method loads the given content of an element via jQuery load method
function loadGivenContent(loadingElementSelector, content) {
    console.log("ContentLoader.loadGivenContent()");
    $(loadingElementSelector).html(content);
}

// this method loads the given option list into a select element
function loadSelectOptions(selectElement, optionList) {
    console.log("loadSelectOptions()");
    if (optionList.length < 1) // no need to update anything
        return;

    // Clear the old options
    selectElement
      .find('option')
      .remove();

    // add option values and texts
    $.each(optionList, function (index) {
        var value = optionList[index].Value;
        var text = optionList[index].Text;
        selectElement.append($("<option></option>")
           .attr("value", value).text(text));
    });

    // now update select element option list (this is needed to implement chosen.js functionallity like in-search)
    selectElement.trigger("chosen:updated");
}

//this method blocks the given element of an element via blockUI plug-in
function blockContent(elementSelector) {
    console.log("ContentLoader.blockContent: blockUI blocked object: " + elementSelector);
    App.blockUI({
        target: elementSelector,
        iconOnly: true
    });

}

function unBlockContent(blockedElementSelector) {
    App.unblockUI(blockedElementSelector);
    //  $(window).scrollTop(0);
}

//fired when content loaded successfully
function afterLoad(loadingElement, result, blockedElement, controller, action) {
    console.log("contentLoader.afterLoad()");
    if (typeof result.message != 'undefined') {
        contentLoaderError(result.message, result.type, blockedElement);
    }
    else {
        $(loadingElement).html(result);
        unBlockContent(blockedElement);
        //History.pushState({ state: controller + "-" + action, rand: Math.random() }, controller + "-aa" + action, "/" + action);
    }
}

function contentLoaderError(message, type, blockedElement) {
    console.log('contentLoader.contentLoaderError: object loaded with some errors:', message);
    var userMessage = new UserMessage(type, message);  //show error to user
    var messageElementSelector = '.user-message';
    userMessage.showMessage(messageElementSelector);
    unBlockContent(blockedElement);
}
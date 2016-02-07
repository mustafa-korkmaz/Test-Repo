//GLOBAL VARIABLES START
var ROOT_DIR = "";  // root direction for site eg: /vdfFactoring
var PREVIOUS_PAGE = {  // variable that contents back button html
    fullPageContentId: "#rendered-body", // whole page id
    fullPageContent: "", // whole page content
    targetElementId: "",     // target to be load or replace
    wrappedElementId: "div.main-content",  // dom element that wraps the target
    targetContent: ""  //html content of target element
};
var STATUS_ERROR_MAP = {
    '400': "Server understood the request, but request content was invalid.",
    '401': "Unauthorized access.",
    '403': "Forbidden resource can't be accessed.",
    '404': "Page can not be found.",
    '500': "Internal server error.",
    '503': "Service unavailable."
};

var REQUEST_TOKEN_SELECTOR = 'input[name="__RequestVerificationToken"]';  //mvc post verirfication token input selector
//GLOBAL VARIABLES END
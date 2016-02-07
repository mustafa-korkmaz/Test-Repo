/*

jQuery(function ($) {

    $('#rendered-body').on('pjax:start', function () {
        var blockedElementSelector = "#page-content";
        console.log("pjaxHandler blocked object: " + this.id);
        App.blockUI({
            target: blockedElementSelector,
            iconOnly: true
        });
    });

    $('#rendered-body').on('pjax:end', function () {
        var blockedElementSelector = "#page-content";
        console.log("pjaxHandler unblocked object: " + this.id);
        App.unblockUI(blockedElementSelector);
    });
});

*/
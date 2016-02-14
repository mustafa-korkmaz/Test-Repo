// Define contentLoader class 
function DataGrid(tableSelector, bodyColumns, summaryColumns, url, rowActions) {
    /*sample bodyColumns:
    "columns":
    [
        { "data": "Salary", "orderable": true },
        { "data": "Name", "orderable": false },
        { "data": "Gender", "orderable": true },
        { "data": "Id", "orderable": false },
        { "data": "BirthDate", "orderable": true },
        { "data": "ModifiedDate", "orderable": true }
    ]

    sample summaryColumns:
     {"0","2,"4"}

    sample rowActions:
    {"deletable":"false","editable":"true"}*/

    this.tableSelector = tableSelector;
    this.bodyColumns = bodyColumns;
    this.summaryColumns = summaryColumns;
    this.url = url;
    this.rowActions = rowActions;
}

//initializes a dataTable object
DataGrid.prototype.initialize = function () {

    console.log("DataGrid.initiliazeDataTable:" + this.tableSelector + " bodyColumns object:" + this.bodyColumns + " summaryColumns object:" + this.summaryColumns + " URL: " + this.url + "actions:" + this.rowActions);

    var summaryColumns = this.summaryColumns;
    var rowActions = this.rowActions;

    if (rowActions["deletable"] === true || rowActions["editable"] === true) {

        var oColumn = { "data": "Actions", "orderable": false }
        this.bodyColumns.push(oColumn);

        // set actions column default content
        rowActions["defaultContent"] = getActionsColumnDefaultContent(rowActions);
    }

    function getActionsColumnDefaultContent(rowActions) {

        var content = "";

        if (rowActions["editable"] === true) {
            content += "<button class='edit-row' onClick='javascript:onActionsClicked(this);'>Edit!</button>";
        }
        if (rowActions["deletable"] === true) {
            content += "<button class='delete-row' onClick='javascript:onActionsClicked(this);'>Delete!</button>";
        }
        return content;
    }

    $(this.tableSelector).DataTable({
        "emptyTable": "No data available in table",
        "zeroRecords": "No matching records found",
        "bFilter": false, //remove search text box
        // "bStateSave": true,
        // "iCookieDuration": 1000, //expiration of cookies for state saving
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": this.url
            //"data": function (d) {
            //    d.playWith = $("#data-count").val().trim();
            //}
        },
        "footerCallback": function (row, data, start, end, display) {
            var api = this.api(), data;

            // Remove the formatting to get integer data for summation
            var getFloatValue = function (input) {
                var s = String(input);
                var result = parseFloat(s.replace(",", "."));
                return result;
            }

            if (summaryColumns.length > 0) { // start to generate summary columns

                summaryColumns.forEach(
                    function CalculateFooter(value) {
                        // Total over this page
                        pageTotal = api
                            .column(value, { page: 'current' })
                            .data()
                            .reduce(function (a, b) {
                                return getFloatValue(a) + getFloatValue(b);
                            }, 0);

                        // Update footer
                        pageTotal = parseFloat(Math.round(pageTotal * 100) / 100).toFixed(2); // only two digits after comma
                        $(api.column(value).footer()).html(
                            pageTotal
                        );
                    });
            }
        },
        "columns": this.bodyColumns,
        "columnDefs": [{
            "targets": -1,
            "data": null,
            "defaultContent": rowActions["defaultContent"]
        }]
    });
}


jQuery(document).ready(function () {

    $("#bb").click(function (event) {
        event.preventDefault();
        init('#aa');
    });
});

function onActionsClicked(actionButton) {
    
    var td_element = actionButton.closest('td');

    if ($(td_element).hasClass('link-button')) { // link button clicked- we will use this click event  in linkButton.js
        return true;
    }
    //if (!$(td_element).hasClass('row-actions')) {
    //    return false;
    //}
    var tr_element = $(td_element).parent('tr');
    var tableId = $(tr_element).closest('table').attr('id');
    var selectedRow = []; //get selected row html
    var rowItemArray = [];
    var rowId = tr_element.attr('id');
    var columns = tr_element.find('td');

    for (var i = 0; i < columns.length; i++) {
        var column = columns[i];
        if (column) {
            rowItemArray.push(column.innerHTML);
        }
    }
    selectedRow = rowItemArray;

    if ($(actionButton).hasClass('edit-row')) {  //this is a row edit button click action
        if (typeof (rowEditButtonClick) == "function") { // is function implemented?
            console.log('rowEditButtonClick()');
            rowEditButtonClick(tableId, rowId, selectedRow); //fire the default row click event function
        }
        else {
            console.log('rowEditButtonClick not implemented!');
            alert("you have forgotten to implement rowEditButtonClick() event!\ntableId: " + tableId + "\nrowId: " + rowId + "\nselectedRow: " + selectedRow);
        }
    }
    else if ($(actionButton).hasClass('delete-row')) {//this is a row delete button click action
        if (typeof (rowDeleteButtonClick) == "function") { // is function implemented?
            console.log('rowDeleteButtonClick()');
            rowDeleteButtonClick(tableId, rowId, selectedRow); //fire the default row click event function
        }
        else {
            console.log('rowDeleteButtonClick not implemented!');
            alert("you have forgotten to implement rowDeleteButtonClick() event!\ntableId: " + tableId + "\nrowId: " + rowId + "\nselectedRow: " + selectedRow);
        }
    }
}


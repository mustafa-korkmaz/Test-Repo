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
    {"delete":"false","edit":"true"}*/

    this.tableSelector = tableSelector;
    this.bodyColumns = bodyColumns;
    this.summaryColumns = summaryColumns;
    this.url = url;
    this.rowActions = rowActions;
}

//initializes a dataTable object
DataGrid.prototype.initialize = function () {

    console.log("DataGrid.initiliazeDataTable:" + this.tableSelector + " bodyColumns object:" + this.bodyColumns + " summaryColumns object:" + this.summaryColumns + " URL: " + this.url);

    var tableSelector = this.tableSelector;
    var bodyColumns = this.bodyColumns;
    var summaryColumns = this.summaryColumns;
    var url = this.url;
    var rowActions = this.rowActions;

    $(tableSelector).DataTable({
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

            // Total over this page
            pageTotal = api
                .column(5, { page: 'current' })
                .data()
                .reduce(function (a, b) {
                    return getFloatValue(a) + getFloatValue(b);
                }, 0);

            // Update footer
            $(api.column(5).footer()).html(
                pageTotal.toFixed(2)
            );
        },
        "columns": this.bodyColumns
    });

}


jQuery(document).ready(function () {

    function init(tableSelector) {
        $(tableSelector).DataTable({
            "emptyTable": "No data available in table",
            "zeroRecords": "No matching records found",
            "bFilter": false, //remove search text box
            // "bStateSave": true,
            // "iCookieDuration": 1000, //expiration of cookies for state saving
            "processing": true,
            "serverSide": true,
            "ajax": {
                "url": "/DataGrid/FilldataGrid"
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

                // Total over this page
                pageTotal = api
                    .column(5, { page: 'current' })
                    .data()
                    .reduce(function (a, b) {
                        return getFloatValue(a) + getFloatValue(b);
                    }, 0);

                // Update footer
                $(api.column(5).footer()).html(
                    pageTotal.toFixed(2)
                );
            },
            "columns":
        [
            { "data": "Salary", "orderable": true },
            { "data": "Name", "orderable": false },
            { "data": "Gender", "orderable": true },
            { "data": "Id", "orderable": false },
            { "data": "BirthDate", "orderable": true },
            { "data": "ModifiedDate", "orderable": true }
        ]
        });
    }

    $("#bb").click(function (event) {
        event.preventDefault();
        init('#aa');
    });


    //$("#bb").click(function () {
    //    var table = $('#aa').DataTable();
    //    table.destroy();
    //    $('#first-sample tbody,#first-sample tfoot tr th').empty();
    //});

});

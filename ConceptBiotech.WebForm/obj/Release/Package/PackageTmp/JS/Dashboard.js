$(function () {
        $.ajax({
            type: "POST",
            url: "../WebMethods/Dashboard.asmx/NumberofClient",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('#numclient').text(response.d)
            },
            failure: function (response) {
                alert(response);
            }
        });

        $.ajax({
            type: "POST",
            url: "../WebMethods/Dashboard.asmx/NumberofVendor",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('#numvendor').text(response.d)
            },
            failure: function (response) {
                alert(response);
            }
        });
        $.ajax({
            type: "POST",
            url: "../WebMethods/Dashboard.asmx/NumberofMaterial",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('#nummaterial').text(response.d)
            },
            failure: function (response) {
                alert(response);
            }
        });
        $.ajax({
            type: "POST",
            url: "../WebMethods/Dashboard.asmx/NumberofInvoice",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('#numinvoice').text(response.d)
            },
            failure: function (response) {
                alert(response);
            }
        });
        $.ajax({
            type: "POST",
            url: "../WebMethods/Dashboard.asmx/NumberofPurchaseInvoice",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('#numpurchaseinvoice').text(response.d)
            },
            failure: function (response) {
                alert(response);
            }
        });
        $.ajax({
            type: "POST",
            url: "../WebMethods/Dashboard.asmx/TotalofPayIn",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var payin = "£" + " " + response.d;
                $('#numpayin').text(payin);
            },
            failure: function (response) {
                alert(response);
            }
        });
        $.ajax({
            type: "POST",
            url: "../WebMethods/Dashboard.asmx/TotalofPayout",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var payout = "£" + " " + response.d;
                $('#numpayout').text(payout);
            },
            failure: function (response) {
                alert(response);
            }
        });

});

$('#customer').click(function (e) {
    window.location.href = "Client.aspx";
});
$('#vendor').click(function (e) {
    window.location.href = "Vendor.aspx";
});
$('#rights').click(function (e) {
    window.location.href = "Rights.aspx";
});
$('#invoice').click(function (e) {
    window.location.href = "Bill.aspx";
});
$('#purchaseinvoice').click(function (e) {
    window.location.href = "PurchaseInvoice.aspx";
});
$('#material').click(function (e) {
    window.location.href = "Material.aspx";
});
$('#payin').click(function (e) {
    window.location.href = "PayIn.aspx";
});
$('#payout').click(function (e) {
    window.location.href = "PayOut.aspx";
});
$('#invoicereport').click(function (e) {
    window.location.href = "../ReportUI/ClientWiseBillReport.aspx";
});
$('#payinreport').click(function (e) {
    window.location.href = "../ReportUI/PayInReport.aspx";
});
$('#payoutreport').click(function (e) {
    window.location.href = "../ReportUI/PayOutReport.aspx";
});
$('#stockreport').click(function (e) {
    window.location.href = "../ReportUI/CurrentStockReport.aspx";
});
$('#StockIn').click(function (e) {
    window.location.href = "PurchaseInvoice.aspx";
});
$('#StockOut').click(function (e) {
    window.location.href = "SimStockOut.aspx";
});
$('#SimCardActivation').click(function (e) {
    window.location.href = "SIMCardActivation.aspx";
});
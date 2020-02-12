$(document).ready(function () {
    if ($("#CMATPC_MPC_ClientOrigination").val() == '8') {
        $('#showClientother').show();
        $("#CMATPC_MPC_ClientOrigination_Other").data("required", true);
    }
    else {
        $('#showClientother').hide();
        $("#CMATPC_MPC_ClientOrigination_Other").data("required", false);
    }
    //$('#reasonnotplaced').hide();
    //$('#showreasonother').hide();


    $("#CMATPC_MPC_ReasonNotPlaced_Other").data("required", false);
    if ($("#CMATPC_MPC_DischargeDest").val() == '9') {
        $('#showDischargeother').show();
        $("#CMATPC_MPC_DischargeDest_Other").data("required", true);
    }
    else {
        $('#showDischargeother').hide();
        $("#CMATPC_MPC_DischargeDest_Other").data("required", false);
    }


    if ($("#CMATPC_MPC_ReasonNotPlaced").val() == '8') /*&& ($("#clientplacedNo").is(':checked')))*/ {
        $('#showreasonother').show();
        $("#CMATPC_MPC_ReasonNotPlaced_Other").data("required", true);
    }
    else {
        $('#showreasonother').hide();
        $("#CMATPC_MPC_ReasonNotPlaced_Other").data("required", false);
    }

    if ($("#clientplacedYes").is(':checked')) {
        $('#reasonnotplaced').hide();
        $('#clientorganizationhide').show();
        $('#admitdatehide').show();
        $('#admitlochide').show();
        $('#dischargedatehide').show();
        $('#dischargelochide').show();
        $('#dischargedesthide').show();
        $("#CMATPC_MPC_ReasonNotPlaced").data("required", false);
        if ($("#CMATPC_MPC_ClientOrigination").val() == '8') {
            $('#showClientother').show();
            $("#CMATPC_MPC_ClientOrigination_Other").data("required", true);
        }
        else {
            $('#showClientother').hide();
            $("#CMATPC_MPC_ClientOrigination_Other").data("required", false);
        }

        if ($("#CMATPC_MPC_DischargeDest").val() == '9') {
            $('#showDischargeother').show();
            $("#CMATPC_MPC_DischargeDest_Other").data("required", true);
        }
        else {
            $('#showDischargeother').hide();
            $("#CMATPC_MPC_DischargeDest_Other").data("required", false);
        }
        $('#showreasonother').hide();
        $("#CMATPC_MPC_ReasonNotPlaced_Other").data("required", false);
    }
    if ($("#clientplacedNo").is(':checked')) {
        $('#reasonnotplaced').show();
        $('#clientorganizationhide').hide();
        $('#admitdatehide').hide();
        $('#admitlochide').hide();
        $('#dischargedatehide').hide();
        $('#dischargelochide').hide();
        $('#dischargedesthide').hide();
        $('#showDischargeother').hide();
        $("#CMATPC_MPC_ReasonNotPlaced").data("required", true);
        $("#CMATPC_MPC_AdmitDt").data("required", false);
        $("#CMATPC_MPC_DischargeDest_Other").data("required", false);
        $('#showClientother').hide();
        $("#CMATPC_MPC_ClientOrigination_Other").data("required", false);
        if ($("#CMATPC_MPC_ReasonNotPlaced").val() == '8') {
            $('#showreasonother').show();
            $("#CMATPC_MPC_ReasonNotPlaced_Other").data("required", true);
        }
        else {
            $('#showreasonother').hide();
            $("#CMATPC_MPC_ReasonNotPlaced_Other").data("required", false);
        }
    }

    $("#mfcform").submit(function () {
        if (($("#clientplacedYes").is(':checked')) || ($("#clientplacedNo").is(':checked'))) {
            $("#clientplaced").find("ul").html("");
            return true;
        }
        else {
            $("#clientplaced").find("ul").html("<li>Was Client Placed is required</li>");
            return false;
        }
    });
});




$("#CMATPC_MPC_ClientOrigination").change(function (e) {

    $('span[id^="validate"]').remove();
    if ($("#CMATPC_MPC_ClientOrigination").val() == '8') {
        $('#showClientother').show();
        $("#CMATPC_MPC_ClientOrigination_Other").data("required", true);
    }
    else {
        $("#CMATPC_MPC_ClientOrigination_Other").data("required", false);
        $('#showClientother').hide();
    }

});

$("#CMATPC_MPC_DischargeDest").change(function (e) {

    $('span[id^="validate"]').remove();
    if ($("#CMATPC_MPC_DischargeDest").val() == '9') {
        $('#showDischargeother').show();
        $("#CMATPC_MPC_DischargeDest_Other").data("required", true);
    }
    else {
        $('#showDischargeother').hide();
        $("#CMATPC_MPC_DischargeDest_Other").data("required", false);
    }

});

$("#CMATPC_MPC_ReasonNotPlaced").change(function (e) {

    $('span[id^="validate"]').remove();
    if ($("#CMATPC_MPC_ReasonNotPlaced").val() == '8') {
        $('#showreasonother').show();
        $("#CMATPC_MPC_ReasonNotPlaced_Other").data("required", true);
    }
    else {
        $('#showreasonother').hide();
        $("#CMATPC_MPC_ReasonNotPlaced_Other").data("required", false);
    }

});


$("#clientplacedYes").change(function () {
    $('span[id^="validate"]').remove();
    if ($("#clientplacedYes").is(':checked')) {
        $('#reasonnotplaced').hide();
        $('#clientorganizationhide').show();
        $('#admitdatehide').show();
        $('#admitlochide').show();
        $('#dischargedatehide').show();
        $('#dischargelochide').show();
        $('#dischargedesthide').show();
        $("#CMATPC_MPC_ReasonNotPlaced").data("required", false);
        $("#CMATPC_MPC_AdmitDt").data("required", true);
        if ($("#CMATPC_MPC_ClientOrigination").val() == '8') {
            $('#showClientother').show();
            $("#CMATPC_MPC_ClientOrigination_Other").data("required", true);
        }
        if ($("#CMATPC_MPC_DischargeDest").val() == '9') {
            $('#showDischargeother').show();
            $("#CMATPC_MPC_DischargeDest_Other").data("required", true);
        }
        if ($("#CMATPC_MPC_ReasonNotPlaced").val() == '8') {
            $('#showreasonother').hide();
            $("#CMATPC_MPC_ReasonNotPlaced_Other").data("required", false);
        }
    }
    else {
        $('#reasonnotplaced').show();
        $('#clientorganizationhide').hide();
        $('#admitdatehide').hide();
        $('#admitlochide').hide();
        $('#dischargedatehide').hide();
        $('#dischargelochide').hide();
        $('#dischargedesthide').hide();

    }
});


$("#clientplacedNo").change(function () {
    $('span[id^="validate"]').remove();

    if ($("#clientplacedNo").is(':checked')) {
        $('#reasonnotplaced').show();
        $('#clientorganizationhide').hide();
        $('#admitdatehide').hide();
        $('#admitlochide').hide();
        $('#dischargedatehide').hide();
        $('#dischargelochide').hide();
        $('#dischargedesthide').hide();
        $('#showClientother').hide();
        $('#showDischargeother').hide();
        $("#CMATPC_MPC_AdmitDt").data("required", false);
        $("#CMATPC_MPC_ReasonNotPlaced").data("required", true);
        if ($("#CMATPC_MPC_ClientOrigination").val() == '8') {
            $('#showClientother').hide();
            $("#CMATPC_MPC_ClientOrigination_Other").data("required", false);
        }
        if ($("#CMATPC_MPC_DischargeDest").val() == '9') {
            $('#showDischargeother').hide();
            $("#CMATPC_MPC_DischargeDest_Other").data("required", false);
        }
        if ($("#CMATPC_MPC_ReasonNotPlaced").val() == '8') {
            $('#showreasonother').show();
            $("#CMATPC_MPC_ReasonNotPlaced_Other").data("required", true);
        }
    }
    else {
        $('#reasonnotplaced').hide();
        $('#clientorganizationhide').show();
        $('#admitdatehide').show();
        $('#admitlochide').show();
        $('#dischargedatehide').show();
        $('#dischargelochide').show();
        $('#dischargedesthide').show();
    }
});




$(document).ready(function () {
    if ($("#CMATPC_MPC_DischargeDt").val() == "") {

        $("#CMATPC_MPC_L_Care").prop("disabled", true);
    }
   
});

$('#CMATPC_MPC_DischargeDt').change(function () {
    if ($("#CMATPC_MPC_DischargeDt").val() == "") {

        $("#CMATPC_MPC_L_Care").prop("disabled", true);
    } else {
        $("#CMATPC_MPC_L_Care").prop("disabled", false);
    }
});





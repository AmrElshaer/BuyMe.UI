$(function () {
    console.log("Loader script");
    $(document).bind('ajaxStart', function () {
        console.log("Loader start");
        $("#loaderbody").removeClass('hidden');
    }).bind('ajaxStop', function () {
        console.log("Loader end");
        $("#loaderbody").addClass('hidden');
    });
});
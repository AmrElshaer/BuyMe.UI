$(function () {
    console.log("Loader script");
    $(document).bind('ajaxStart', function () {
        $("#loaderbody").removeClass('hidden');
    }).bind('ajaxStop', function () {
        $("#loaderbody").addClass('hidden');
    });
});
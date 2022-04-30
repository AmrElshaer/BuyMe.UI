function additionColDisplay(ctl) {
    let _row = $(ctl).parents("tr");
    let cols = _row.children("td");
    $('#additionId').val($(cols[0]).text());
    $('#additionFieldName').val($(cols[1]).text());
    $('#additionFieldType').val($(cols[2]).text());
    $('#additionCategory').val($(cols[3]).text());
    $('#addEditBtn').text('Edit');
}

function deleteAddionCol(additionColId) {
    $.ajax({
        url: `/CustomField/DeleteCustomField`,
        data: { CustomFieldId: additionColId },
        type: 'POST',
        success: function (result) {
            location.reload();
        }
    })
}

$(document).ready(function () {
    $('#addNewField').on('click', function () {
        $('#additionId').val('');
        $('#additionFieldName').val('');
        $('#additionFieldType').val('');
        $('#addEditBtn').text('Add');

    });
    $('#addColumn').on('submit', function (e) {
        e.preventDefault();
        const data = $(this).serialize();
        $.ajax({
            url: `/CustomField/UpSertCustomField`,
            data: data,
            type: 'POST',
            success: function (result) {
                location.reload();
            }
        })
    });

});
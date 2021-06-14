function LoadData() {
    $("#tblStudent tbody tr").remove();
    $.ajax({
        type: 'POST',
        url: '/Home/getEmployees',
        dataType: 'json',
        data: { id: '' },
        success: function (data) {
            var items = '';
            $.each(data, function (i, item) {
                var rows = "<tr>"
                    + "<td class='prtoducttd'>" + item.Id + "</td>"
                    + "<td class='prtoducttd'>" + item.Name + "</td>"
                    + "<td class='prtoducttd'>" + item.Email + "</td>"
                    + "<td class='prtoducttd'>" + item.Phone + "</td>"
                    + "</tr>";
                $('#tblStudent tbody').append(rows);
            });
        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });
    return false;
}
function disableTable() {
    $('#tblStudent tbody tr').remove();
}

function enableTable() {
    LoadData();
    document.getElementbyId('tblStudent').disableTable = false;
}
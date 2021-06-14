function createEmployee() {
    var emp = {};
    emp.Name = $("#employee-name").val();
    emp.Phone = $("#phone").val();
    emp.email = $("#email").val();
    $.ajax({
        type: "POST",
        url: "/Home/createEmployee",
        data: JSON.stringify(emp),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            debugger;
            if (Object.keys(result).length === 0)
                alert("Employee is already present");
            else {
                $('#exampleModal').modal('hide');
                alert("Employee added successfully");
            }
        },
        error: function () {
            alert("Employee is already present");
        }
    });
}
$('#exampleModal').on('hidden.bs.modal', function () {
    $('#createEmployeeForm')[0].reset();
});
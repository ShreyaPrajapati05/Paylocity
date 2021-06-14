const SalaryPerPayCheck = 2000;
$(document).ready(function () {
    $("form").submit(function (event) {
        var emp = {};
        emp.Name = $("#name").val();
        emp.NumberOfChild = $("#children").val();
        emp.spouse = $('#spouse').is(':checked');

        $.ajax({
            type: "POST",
            url: "/Home/getEmployee",
            data: JSON.stringify(emp),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                if (Object.keys(result).length === 0) {
                    alert(emp.Name + " employee is not present. Please create employee before fetching data");
                    document.getElementById("form").reset();
                }
                else {
                    $("#empName").html(result.Name);
                    $("#PerPayCheck").html(SalaryPerPayCheck);
                    $("#totalDeductedAmount").html(result.DeductableSalary);
                    $("#PerpaydeductableSalary").html(result.TotalPerPayCheckSalary);
                    $("#totalAnualSalary").html(result.TotalAnualSalary);
                    document.getElementById("form").reset();
                }
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
        event.preventDefault();
    });
});




$(document).ready(function () {
    getall();


})
function timkiem() {
    var abc = {
        timkiem: $("input[name='timkiem']").val().toLowerCase()
    }


    $.ajax({
        url: "api/Test/timkiem?timkiem="+abc.timkiem,
        type: "Get",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {

            console.log(result);
            var str = "";
            $.each(result, function (index, value) {
                str += '<tr>';
                str += "<td>" + (value.id) + "</td>";
                str += "<td>" + value.tenSp + "</td>";
                str += "<td>" + value.giaSp + "</td>";
                str += '<td><a href="#" onclick="return _getById(' + (value.id) + ')">Edit</a> </td>';
                str += '</tr>';
            });
            $('#list .Loads').html(str);
           

        },
        error: function (errormessage) {
            alert("loi");
        }
    });
}
function getall() {

    $.ajax({
        url: "api/Test",
        type: "Get",

        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {
            console.log(result);
            var str = "";
            $.each(result, function (index, value) {
                str += '<tr>';
                str += "<td>" + (value.id) + "</td>";
                str += "<td>" + value.tenSp + "</td>";
                str += "<td>" + value.giaSp + "</td>";
                str += '<td><a href="#" onclick="return _getById(' + (value.id) + ')">Edit</a> </td>';
                str += '</tr>';
            });
            $('#list .Loads').html(str);
        }
    }

)
}
function _getById(id) {
    $.ajax({
        url: 'api/Test/' + id,

        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {

            $('#id').val(result.id);
            $('#tenSp').val(result.tenSp);
            $('#giaSp').val(result.giaSp);
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Update() {

    var empObj = {
        id: $("#id").val(),
        tenSp: $("#tenSp").val(),
        giaSp: $("#giaSp").val()
    };

    $.ajax({
        url: "api/Test/update",
        data: JSON.stringify(empObj),
        type: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            getall();
            $('#myModal').modal('hide');
            $('#id').val("");
            $('#tenSp').val("");
            $('#giaSp').val("");

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function _delete() {

    var empObj = {
        id: $("#id").val(),
        tenSp: $("#tenSp").val(),
        giaSp: $("#giaSp").val()
    };

    $.ajax({
        url: "api/Test/delete",
        data: JSON.stringify(empObj),
        type: "Post",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            getall();
            $('#myModal').modal('hide');
            $('#id').val("");
            $('#tenSp').val("");
            $('#giaSp').val("");

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function insert() {

    $.ajax({

        data: JSON.stringify({
            id: $("input[name='Id']").val(),
            tenSp: $("input[name='tenSp']").val(),
            giaSp: $("input[name='giaSp']").val()
        }),
        url: 'api/Test/insert',

        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            getall();
            $('#myModal').modal('show');
        },

    });

}

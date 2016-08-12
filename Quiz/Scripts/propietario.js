$(document).on("ready", function () {
    GetAll();
})
 
// GET: api/Propietarios
function GetAll() {
    var item = "";
    $('#tblListProp tbody').html('');
    $.getJSON("http://localhost:52743/api/Propietarios", function (data) {
        $.each(data, function (key, value) {
            item += "" + value.Name + "" + value.Telefono + "" + value.Direccion + "";
        });
        $('#tblListProp tbody').append(item);
    });
};

function GetPropById(propietarioId) {
    var url = "http://localhost:52743/api/Propietarios" + propietarioId;
    $.getJSON(url)
        .done(function (data) {
            $('#txtName').val(data.Name);
            $('#txtTelefono').val(data.Telefono);
            $('#txtDireccion').val(data.Direccion);
        })
        .fail(function (erro) {
            ClearForm();
        });
};

$('#btnSearch').on('click', function () {
    GetPropById($('#txtIdSearch').val());
})

function DeletePropById(IdPropietario) {
    var url = "http://localhost:52743/api/Propietarios" + IdPropietario;
    $.ajax({
        url: url,
        type: 'DELETE',
        dataType: 'jsonp',
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            200: function () {
                GetAll();
                ClearForm();
                alert('Owner with id: ' + IdPropietario + ' was deleted');
            },
            404: function () {
                alert('Owner with id: ' + IdPropietario + ' was not found');
            }
        }
    });
}

$('#btnDelete').on('click', function () {
    DeletePropById($('#txtIdSearch').val());
})

function UpdateProp(IdPropietario, propietario) {
    var url = "http://localhost:52743/api/Propietarios" + IdPropietario;
    $.ajax({
        url: url,
        type: 'PUT',
        dataType: 'jsonp',
        data: propietario,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            200: function () {
                GetAll();
                ClearForm();
                alert('Owner with id: ' + IdPropietario + ' was updated');
            },
            404: function () {
                ClearForm();
                alert('Owner with id: ' + IdPropietario + ' was not found');
            },
            400: function () {
                ClearForm();
                alert('Error');
            }
        }
    });
}

$('#btnUpdate').on('click', function () {
    var propietario = new Object();
    propietario.id = $('#txtIdSearch').val();
    propietario.Name = $('#txtName').val();
    propietario.Telefono = $('#txtTelefono').val();
    propietario.Direccion = $('#txtDireccion').val();
    UpdateProp(propietario.id, JSON.stringify(propietario));
})

function CreateProp(propietario) {
    var url = "http://localhost:52743/api/Propietarios";
    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'jsonp',
        data: propietario,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            201: function () {
                GetAll();
                ClearForm();
                alert('Owner with id: ' + propietario.Id + ' was updated');
            },
            400: function () {
                ClearForm();
                alert('Error');
            }
        }
    });
}

$('#btnCreate').on('click', function () {
    var owner = new Object();
    owner.Name = $('#txtName').val();
    owner.Telefono = $('#txtTelefono').val();
    owner.Direccion = $('#txtDireccion').val();
    CreateProp(JSON.stringify(owner));
})
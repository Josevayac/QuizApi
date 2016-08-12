$(document).on("ready", function () {
    GetAll();
})

// GET: api/Mascotas
function GetAll() {
    var item = "";
    $('#tblListPets tbody').html('');
    $.getJSON("http://localhost:52743/api/Mascotas", function (data) {
        $.each(data, function (key, value) {
            item += "" + value.PetName + "" + value.Raza + "";
        });
        $('#tblListPets tbody').append(item);
    });
};

function GetPetById(Id) {
    var url = "http://localhost:52743/api/Mascotas" + Id;
    $.getJSON(url)
        .done(function (data) {
            $('#txtPetName').val(data.PetName);
            $('#txtRaza').val(data.Raza);
        })
        .fail(function (erro) {
            ClearForm();
        });
};

$('#btnSearch').on('click', function () {
    GetPetById($('#txtIdSearch').val());
})

function DeletePetById(Id) {
    var url = "http://localhost:52743/api/Mascotas" + Id;
    $.ajax({
        url: url,
        type: 'DELETE',
        dataType: 'jsonp',
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            200: function () {
                GetAll();
                ClearForm();
                alert('Pet with id: ' + Id + ' was deleted');
            },
            404: function () {
                alert('Pet with id: ' + Id + ' was not found');
            }
        }
    });
}

$('#btnDelete').on('click', function () {
    DeletePetById($('#txtIdSearch').val());
})

function UpdatePet(Id, mascota) {
    var url = "http://localhost:52743/api/Mascotas" + Id;
    $.ajax({
        url: url,
        type: 'PUT',
        dataType: 'jsonp',
        data: mascota,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            200: function () {
                GetAll();
                ClearForm();
                alert('Pet with id: ' + Id + ' was updated');
            },
            404: function () {
                ClearForm();
                alert('Pet with id: ' + Id + ' was not found');
            },
            400: function () {
                ClearForm();
                alert('Error');
            }
        }
    });
}

$('#btnUpdate').on('click', function () {
    var pet = new Object();
    pet.id = $('#txtIdSearch').val();
    pet.Name = $('#txtPetName').val();
    pet.Raza = $('#txtRaza').val();
    UpdatePet(pet.id, JSON.stringify(pet));
})

function CreatePet(pet) {
    var url = "http://localhost:52743/api/Mascotas";
    $.ajax({
        url: url,
        type: 'POST',
        dataType: 'jsonp',
        data: pet,
        contentType: "application/json;chartset=utf-8",
        statusCode: {
            201: function () {
                GetAll();
                ClearForm();
                alert('Pet with id: ' + pet.Id + ' was updated');
            },
            400: function () {
                ClearForm();
                alert('Error');
            }
        }
    });
}

$('#btnCreate').on('click', function () {
    var pet = new Object();
    pet.PetName = $('#txtPetName').val();
    pet.Raza = $('#txtRaza').val();
    CreatePet(JSON.stringify(pet));
})
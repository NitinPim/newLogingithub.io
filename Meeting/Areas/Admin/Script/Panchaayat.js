$(document).ready(function () {


    getPanchayatList();

    //==========code for edit==============

    $(document).on('click', '#editdtp', function () {
        Edit($(this).attr('data'));
    })

    function Edit(Id) {
        var requestUrl = '/Panchaayat/getPanchayatbyid?paanid=' + Id;
        $.ajax({
            url: requestUrl,
            type: 'GET',
            success: function (response) {
                renderdata(response);
            },
            error: function () {

            }
        });
        function renderdata(response) {
            $('#id').val(response.P_ID);
            $('#dis').val(response.P_District);
            $('#taluka').val(response.P_Taluka);
            $('#pancha').val(response.P_Panchayat);
            $('#btnSubmit').text("Update"); ///change submit button to update
        }
    }



    //---------Submit Button Validations------------
    $('#btnSubmit').click(function () {
        if (checkValidations()) {
            $('#btnSubmit').text('Processing..');
            $('#btnSubmit').prop('disabled', true);
            AddPanchayat();
        }
    })




    //==validation=============
    function checkValidations() {
        var validFlag = true;


        if ($('#dis').val().trim() == '') {
            alert('Please enter Dis');
            $('#dis').focus();
            validFlag = false;
        }
        else if ($('#taluka').val().trim() == '') {
            alert('Please enter taluka');
            $('#taluka').focus();
            validFlag = false;
        }
        else if ($('#pancha').val().trim() == '') {
            alert('Please enter Panchayat');
            $('#pancha').focus();
            validFlag = false;
        }
            return validFlag;
        }




    //===========Addition code============
    function AddPanchayat() {
        var requestUrl = '/Panchaayat/AddPanchayat/';
        var PannViewModel = getPannViewModel();
        $.ajax({
            url: requestUrl,
            type: 'POST',
            data: PannViewModel,
            success: function (status) {
                alert(status.message)
                window.location.reload();
            },
            error: function () {

            }
        })
    }
    function getPannViewModel() {
        var PaanViewModel = {
            P_ID: $('#id').val(),
            P_District: $('#dis').val(),
            P_Taluka: $('#taluka').val(),
            P_Panchayat: $('#pancha').val(),
     


            CreatedBy: 1,
        }
        return PaanViewModel;
    }

    function getPanchayatList() {
        var requestUrl = '/Panchaayat/getPanchayatList';
        $.ajax({
            url: requestUrl,
            type: 'GET',
            success: function (response) {
                LoadData(response);
            },
            error: function () {

            }
        })
    }








})

function LoadData(response) {
    var html = '';
    $.each(response, function (i, row) {
        var Srno = parseInt(i) + 1;
        html += '<tr style="margin:50px">';
        html += '<td style="font-weight:600">' + Srno + '</td>';
        html += '<td>' + row.P_District + '</td>';
        html += '<td>' + row.P_Taluka + '</td>';
        html += '<td>' + row.P_Panchayat + '</td>';
        html += '<td> <button style="padding:8px 38px" class="btn btn-primary" id="editdtp" data=' + row.P_ID + '>Edit</button></td>';
        html += '<td> <button style="padding:8px 35px" class="btn btn-primary" id="deletedtp" data=' + row.P_ID + '>Delete</button></td>';
        html += '</tr>';
    });
    $('#getlist').html(html);
}




////============code for delete==========
$(document).on('click', '#deletedtp', function () {
    Delete($(this).attr('data'));
})
function Delete(Id) {
    if (confirm("Are you sure you want to delete this Record ?")) {
        var requestUrl = '/Panchaayat/deletePanchayat?id=' + Id;
        $.ajax({
            url: requestUrl,
            type: 'POST',
            success: function (response) {
                alert(response.message);
                window.location.reload();
            }
        })
    }
}
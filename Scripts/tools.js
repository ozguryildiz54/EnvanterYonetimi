$(document).ready(function () {
    $('#datepicker').datepicker();
});
$(document).ready(function () {
    $('#terminId').datepicker();
});

$(function () {
    $("#btnSubmit").click(function () {
        var ddlFruits = $("#ddlFruits");
        if (ddlFruits.val() == "") {
            //If the "Please Select" option is selected display error.
            alert("Please select an option!");
            return false;
        }
        return true;
    });
});

function validateForm() {
    var garantiBas = document.forms["urunKaydi"]["garantiBas"].value;
    var envNo = document.forms["urunKaydi"]["envNo"].value;
    var seriNo = document.forms["urunKaydi"]["seriNo"].value;

    var ddlFruits = $("#cihazTuruId");
    if (ddlFruits.val() == "") {
        //If the "Please Select" option is selected display error.
        alert("Lütfen Cihaz Türü seçin!");
        return false;
    }

    var ddlFruits = $("#modelId");
    if (ddlFruits.val() == "") {
        //If the "Please Select" option is selected display error.
        alert("Lütfen Cihaz Modeli seçin!");
        return false;
    }
    if (garantiBas == "" || garantiBas == null) {
        alert("Lütfen Garanti Başlangıcı için seçim yapın!");
        return false;
    }
    if (envNo == "" || envNo == null) {
        alert("Lütfen Envanter No bilgisi girin!");
        return false;
    }
    if (seriNo == "" || seriNo == null) {
        alert("Lütfen Seri No bilgisi girin!");
        return false;
    }
    var ddlFruits = $("#cihazDurumu");
    if (ddlFruits.val() == "") {
        //If the "Please Select" option is selected display error.
        alert("Lütfen Cihaz Durumu seçin!");
        return false;
    }

    var ddlFruits = $("#sifirIkinciEl");
    if (ddlFruits.val() == "") {
        //If the "Please Select" option is selected display error.
        alert("Lütfen Sıfır/İkinci el durumunu seçin!");
        return false;
    }

}

function arama() {
    var copyText = document.getElementById("ara");
    copyText.select();
    copyText.setSelectionRange(0, 99999)
    document.execCommand("copy");
    if (copyText.value != "") {
        alert("Aradığınız kelime kopyalandı:    " + copyText.value);
    } else {
        alert("Bir şey Yazmadınız!");
    }

}
function aramaDegerKontrol() {
    var copyText = document.getElementById("ara");

    if (copyText.value == "" || copyText.value == null) {
        alert("Bir şey Yazmadınız!");
    } else{
        document.getElementById("form1").submit();
    }
    
}



$('#overlay').modal('show');

$(document).on('click', '.accept', function (e) {
    $(".modal-fade").modal("hide");
    $(".modal-backdrop").remove();
});

$('#termin').change(function () {
    if ($(this).val() == '2') {
        $('#terminId').show();
    } else {
        $('#terminId').hide();
    }
    if ($(this).val() == '2') {
        $('#terminLabel').show();
    } else {
        $('#terminLabel').hide();
    }


});

onComplete = "$('#myModal').modal('hide');$('body').removeClass('modal-open');$('.modal-backdrop').remove();"


$(document).ready(function () {
    $("#modalBtnClick").on("click", function () {
        $('#myModal').modal('hide');
        $('body').removeClass('modal-open');
        $('.modal-backdrop').remove();
    });
});

window.setTimeout(function () {
    $(".alert").fadeTo(500, 0).slideUp(500, function () {
        $(this).remove();
    });
}, 1500);


$(document).ready(function () {
    $("#cihazTuruId").change(function () {
        $.get("/cihazTuruGetir", { cihazTuruId: $("#cihazTuruId").val() }, function (data) {
            $("#modelId").prop("disabled", false);
            $("#modelId").empty();
            $.each(data, function (index, row) {
                $("#modelId").append("<option value='" + row.modelId + "'>" + row.model + "</option>")
            });
        });
    })
});
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


    var kullaniciAdi = document.forms["KullaniciyaUrunAtama"]["kullaniciAdi"].value;
    var kullaniciSoyadi = document.forms["KullaniciyaUrunAtama"]["kullaniciSoyadi"].value;
    var sirketId = document.forms["KullaniciyaUrunAtama"]["sirketId"].value;
    var lokasyonId = document.forms["KullaniciyaUrunAtama"]["lokasyonId"].value;
    var envNo2 = document.forms["KullaniciyaUrunAtama"]["envNo"].value;
    var cihazModeliId = document.forms["KullaniciyaUrunAtama"]["cihazModeliId"].value; var garantiBas = document.forms["urunKaydi"]["garantiBas"].value;
    var garantiBas2 = document.forms["KullaniciyaUrunAtama"]["garantiBas"].value;
    var seriNo2 = document.forms["KullaniciyaUrunAtama"]["seriNo"].value; var garantiBas = document.forms["urunKaydi"]["garantiBas"].value;
    var durum = document.forms["KullaniciyaUrunAtama"]["durum"].value;
    var aciklama = document.forms["KullaniciyaUrunAtama"]["aciklama"].value; var garantiBas = document.forms["urunKaydi"]["garantiBas"].value;
    var sifir_ikinci_el = document.forms["KullaniciyaUrunAtama"]["sifir_ikinci_el"].value;
    var cihazTuruId = document.forms["KullaniciyaUrunAtama"]["cihazTuruId"].value;

    if (kullaniciAdi == "" || kullaniciAdi == null) {
        alert("Lütfen kullanıcı adı bilgisi girin!");
        return false;
    } if (kullaniciSoyadi == "" || kullaniciSoyadi == null) {
        alert("Lütfen kullanici soyadi bilgisi girin!");
        return false;
    } if (sirketId == "" || sirketId == null) {
        alert("Lütfen Seri No bilgisi girin!");
        return false;
    } if (lokasyonId == "" || lokasyonId == null) {
        alert("Lütfen lokasyon bilgisi girin!");
        return false;
    } if (envNo2 == "" || envNo2 == null) {
        alert("Lütfen Envanter No bilgisi girin!");
        return false;
    } if (cihazModeliId == "" || cihazModeliId == null) {
        alert("Lütfen cihaz modeli bilgisi girin!");
        return false;
    } if (garantiBas2 == "" || garantiBas2 == null) {
        alert("Lütfen garanti bilgisi girin!");
        return false;
    } if (seriNo2 == "" || seriNo2 == null) {
        alert("Lütfen Seri No bilgisi girin!");
        return false;
    } if (durum == "" || durum == null) {
        alert("Lütfen durum bilgisi girin!");
        return false;
    } if (aciklama == "" || aciklama == null) {
        alert("Lütfen açıklama bilgisi girin!");
        return false;
    } if (sifir_ikinci_el == "" || sifir_ikinci_el == null) {
        alert("Lütfen sıfır/ikinci el bilgisi girin!");
        return false;
    } if (cihazTuruId == "" || cihazTuruId == null) {
        alert("Lütfen cihaz türü bilgisi girin!");
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
    $("#CihazTuruId").change(function () {
        $.get("/cihazTuruGetir", { cihazTuruId: $("#CihazTuruId").val() }, function (data) {
            //$("#modelId").prop("disabled", false);
            $("#ModelId").empty();
            $.each(data, function (index, row) {
                $("#ModelId").append("<option value='" + row.modelId + "'>" + row.model + "</option>")
            });
        });
    })
});


$('#exampleModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('whatever') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-title').text('New message to ' + recipient)
    modal.find('.modal-body input').val(recipient)
});

$('#myTable54').on('click', '.clickable-row', function (event) {
    $(this).addClass('bg-success').siblings().removeClass('bg-success');
    //satirsec();
    //$('#exampleModal').modal('hide');
    //$('body').removeClass('modal-open');
    //$('.modal-backdrop').remove();
    
});

//$(document).ready(function () {
//    $("#myInput").on("keyup", function () {
//        var value = $(this).val().toLowerCase();
//        $("#myTable2 tr").filter(function () {
//            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
//        });
//    });
//});

//$("#search").on("keyup", function () {
//    var value = $(this).val();
//    value = value.toUpperCase();
//    $("table tr").each(function (index) {
//        if (index !== 0) {

//            $row = $(this);

//            var id = $row.find("td:first").text();
//            id = id.toUpperCase();
//            if (id.indexOf(value) !== 0) {
//                $row.hide();
//            }
//            else {
//                $row.show();
//            }
//        }
//    });
//});

$("#search").keyup(function () {
    var value = this.value.toLowerCase().trim();

    $("table tr").each(function (index) {
        if (!index) return;
        $(this).find("td").each(function () {
            var id = $(this).text().toLowerCase().trim();
            var not_found = (id.indexOf(value) == -1);
            $(this).closest('tr').toggle(!not_found);
            return not_found;
        });
    });
});

$(document).ready(function () {
    $('#example').DataTable();
});




getPagination('#myTable54');
//getPagination('.table-class');
//getPagination('table');

/*					PAGINATION 
- on change max rows select options fade out all rows gt option value mx = 5
- append pagination list as per numbers of rows / max rows option (20row/5= 4pages )
- each pagination li on click -> fade out all tr gt max rows * li num and (5*pagenum 2 = 10 rows)
- fade out all tr lt max rows * li num - max rows ((5*pagenum 2 = 10) - 5)
- fade in all tr between (maxRows*PageNum) and (maxRows*pageNum)- MaxRows 
*/


function getPagination(table) {
    var lastPage = 1;

    $('#maxRows')
        .on('change', function (evt) {
            //$('.paginationprev').html('');						// reset pagination

            lastPage = 1;
            $('.pagination')
                .find('li')
                .slice(1, -1)
                .remove();
            var trnum = 0; // reset tr counter
            var maxRows = parseInt($(this).val()); // get Max Rows from select option

            if (maxRows == 5000) {
                $('.pagination').hide();
            } else {
                $('.pagination').show();
            }

            var totalRows = $(table + ' tbody tr').length; // numbers of rows
            $(table + ' tr:gt(0)').each(function () {
                // each TR in  table and not the header
                trnum++; // Start Counter
                if (trnum > maxRows) {
                    // if tr number gt maxRows

                    $(this).hide(); // fade it out
                }
                if (trnum <= maxRows) {
                    $(this).show();
                } // else fade in Important in case if it ..
            }); //  was fade out to fade it in
            if (totalRows > maxRows) {
                // if tr total rows gt max rows option
                var pagenum = Math.ceil(totalRows / maxRows); // ceil total(rows/maxrows) to get ..
                //	numbers of pages
                for (var i = 1; i <= pagenum;) {
                    // for each page append pagination li
                    $('.pagination #prev')
                        .before(
                            '<li data-page="' +
                            i +
                            '">\
								  <span>' +
                            i++ +
                            '<span class="sr-only">(current)</span></span>\
								</li>'
                        )
                        .show();
                } // end for i
            } // end if row count > max rows
            $('.pagination [data-page="1"]').addClass('active'); // add active class to the first li
            $('.pagination li').on('click', function (evt) {
                // on click each page
                evt.stopImmediatePropagation();
                evt.preventDefault();
                var pageNum = $(this).attr('data-page'); // get it's number

                var maxRows = parseInt($('#maxRows').val()); // get Max Rows from select option

                if (pageNum == 'prev') {
                    if (lastPage == 1) {
                        return;
                    }
                    pageNum = --lastPage;
                }
                if (pageNum == 'next') {
                    if (lastPage == $('.pagination li').length - 2) {
                        return;
                    }
                    pageNum = ++lastPage;
                }

                lastPage = pageNum;
                var trIndex = 0; // reset tr counter
                $('.pagination li').removeClass('active'); // remove active class from all li
                $('.pagination [data-page="' + lastPage + '"]').addClass('active'); // add active class to the clicked
                // $(this).addClass('active');					// add active class to the clicked
                limitPagging();
                $(table + ' tr:gt(0)').each(function () {
                    // each tr in table not the header
                    trIndex++; // tr index counter
                    // if tr index gt maxRows*pageNum or lt maxRows*pageNum-maxRows fade if out
                    if (
                        trIndex > maxRows * pageNum ||
                        trIndex <= maxRows * pageNum - maxRows
                    ) {
                        $(this).hide();
                    } else {
                        $(this).show();
                    } //else fade in
                }); // end of for each tr in table
            }); // end of on click pagination list
            limitPagging();
        })
        .val(5)
        .change();

    // end of on select change

    // END OF PAGINATION
}

function limitPagging() {
    // alert($('.pagination li').length)

    if ($('.pagination li').length > 7) {
        if ($('.pagination li.active').attr('data-page') <= 3) {
            $('.pagination li:gt(5)').hide();
            $('.pagination li:lt(5)').show();
            $('.pagination [data-page="next"]').show();
        } if ($('.pagination li.active').attr('data-page') > 3) {
            $('.pagination li:gt(0)').hide();
            $('.pagination [data-page="next"]').show();
            for (let i = (parseInt($('.pagination li.active').attr('data-page')) - 2); i <= (parseInt($('.pagination li.active').attr('data-page')) + 2); i++) {
                $('.pagination [data-page="' + i + '"]').show();

            }

        }
    }
}

$(function () {
    // Just to append id number for each row
    $('table tr:eq(0)').prepend('<th> ID </th>');

    var id = 0;

    $('table tr:gt(0)').each(function () {
        id++;
        $(this).prepend('<td>' + id + '</td>');
    });
});

//  Developed By Yasser Mas
// yasser.mas2@gmail.com


//$(document).ready(function () {
//    var table = document.getElementById('myTable54');

//    for (var i = 1; i < table.rows.length; i++) {
//        table.rows[i].onclick = function () {
//            //rIndex = this.rowIndex;
//            document.getElementById("cihazTuruId").value = this.cells[1].innerHTML;
//            document.getElementById("cihazModeliId").value = this.cells[2].innerHTML;
//            document.getElementById("envNo").value = this.cells[3].innerHTML;
//            document.getElementById("seriNo").value = this.cells[4].innerHTML;
//            document.getElementById("garantiBas").value = this.cells[5].innerHTML;
//            document.getElementById("durum").value = this.cells[6].innerHTML;
//            document.getElementById("aciklama").value = this.cells[7].innerHTML;
//            document.getElementById("sifirIkinciEl").value = this.cells[8].innerHTML;
//            document.getElementById("islemiYapan").value = this.cells[9].innerHTML;
//            document.getElementById("islemZaman").value = this.cells[10].innerHTML;

//        };
//    }
//});


//function satirsec() {
//    //var table = document.getElementById('myTable54'),
//    //    inputHash = {
//    //        '1': 'cihazTuruID',
//    //        '2': 'cihazModeliId2',
//    //        '3': 'envNo',
//    //        '4': 'seriNo', 
//    //        '5': 'garantiBas',
//    //        '6': 'durum',
//    //        '7': 'aciklama',
//    //        '8': 'sifirIkinciEl',
//    //        '9': 'islemiYapan',
//    //        '10': 'islemZaman'
//    //    };

//    //for (var i in inputHash)
//    //    inputHash[i] = document.getElementById(inputHash[i]);

//    //table.addEventListener('click', function (evt) {
//    //    var target = evt.target;

//    //    if (target.nodeName != 'TD')
//    //        return;

//    //    var columns = target.parentNode.getElementsByTagName('td');

//    //    var sonuc = "";
//    //    for (var i = columns.length; i--;) {
//    //        inputHash[i].value = columns[i].innerHTML;
//    //        sonuc = sonuc +" "+ columns[i].innerHTML;
//    //    }
//    //    uyari()
//    //});

//    var table = document.getElementById('myTable54');

//    for (var i = 1; i < table.rows.length; i++) {
//        table.rows[i].onclick = function () {
//            //rIndex = this.rowIndex;
//            document.getElementById("cihazTuruId").value = this.cells[1].innerHTML;
//            document.getElementById("cihazModeliId").value = this.cells[2].innerHTML;
//            document.getElementById("envNo").value = this.cells[3].innerHTML;
//            document.getElementById("seriNo").value = this.cells[4].innerHTML;
//            document.getElementById("garantiBas").value = this.cells[5].innerHTML;
//            document.getElementById("durum").value = this.cells[6].innerHTML;
//            document.getElementById("aciklama").value = this.cells[7].innerHTML;
//            document.getElementById("sifirIkinciEl").value = this.cells[8].innerHTML;
//            document.getElementById("islemiYapan").value = this.cells[9].innerHTML;
//            document.getElementById("islemZaman").value = this.cells[10].innerHTML;

//        };
//    }
//}



function temizle() {
    document.getElementById("cihazTuruId").value = "";
    document.getElementById("cihazModeliId").value = "";
    document.getElementById("envNo").value = "";
    document.getElementById("seriNo").value = "";
    document.getElementById("garantiBas").value = "";
    document.getElementById("durum").value = "";
    document.getElementById("aciklama").value = "";
    document.getElementById("sifirIkinciEl").value = "";
    document.getElementById("islemiYapan").value = "";
    document.getElementById("islemZaman").value = "";
}

function cihazAra() {
    aramaDegerKontrol();
    var param=document.getElementById("ara").value;

    window.location.href = "@Url.Action(Ara,KullaniciyaUrunAtama, new { @searchString = "+param+"})";

    //$.get("/CihazAra", { searchString: $("#ara").val() }, function (data) {
    //    window.location.href = "@Url.Action('Ara', 'KullaniciyaUrunAtama', new { @searchString = " + $("#ara").val()+"})";
    //});

}

function yukle() {
    temizle();
    // açılışta çalışmasını istediğin kodlar...
    var table = document.getElementById('myTable54');

    for (var i = 1; i < table.rows.length; i++) {
        table.rows[i].onclick = function () {
            //rIndex = this.rowIndex;
            document.getElementById("cihazTuruId").value = this.cells[1].innerHTML;
            document.getElementById("cihazModeliId").value = this.cells[2].innerHTML;
            document.getElementById("envNo").value = this.cells[3].innerHTML;
            document.getElementById("seriNo").value = this.cells[4].innerHTML;
            document.getElementById("garantiBas").value = this.cells[5].innerHTML;
            document.getElementById("durum").value = this.cells[6].innerHTML;
            document.getElementById("aciklama").value = this.cells[7].innerHTML;
            document.getElementById("sifirIkinciEl").value = this.cells[8].innerHTML;
            document.getElementById("islemiYapan").value = this.cells[9].innerHTML;
            document.getElementById("islemZaman").value = this.cells[10].innerHTML;
        };
    }
}

window.onload = () => {
    document.getElementById('dene').addEventListener("click", function () {
        yukle();
    });
};




//function kayit() {
//    $(document).ready(function () {
//        $("#cihazTuruId").change(function () {
//            $.get("/cihazTuruGetir", { cihazTuruId: $("#cihazTuruId").val() }, function (data) {
                
//                });
//            });
//        })
//    });
//}
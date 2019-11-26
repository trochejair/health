Dropzone.options.myAwesomeDropzone = false;
Dropzone.autoDiscover = false;
var dropzoneImages;



$(document).ready(function () {

    var selectSupplies = $('#Supplies');
    var inpQuantity = $('#inp-quantity');
    var inpUnit = $('#inp-unit');
    var count = 0;

    url = $("#inp-url-image").val();
    dropzoneImages = new Dropzone("#zdrop", {
        url: url,
        maxFilesize: 5,
        autoProcessQueue: false,
    });

    $(document).on('submit', '#form-upsert', function (e) {
        e.preventDefault();
        if (dropzoneImages.files.length > 0 ) {
            var data = $('#form-upsert').serialize();
            console.log(data);
            var url = $('#form-upsert').attr('action');
            $.ajax({
                url: url,
                method: 'post',
                data: data,
                success: function (response) {
                    console.log(response)
                    if (response.success) {
                        var urlForm = $('').val();

                        $.ajax({
                            url: ,
                            method: 'post',
                            data: formula,
                            success: function (response) {

                            }
                        });


                        dropzoneImages.options.url = $("#inp-url-image").val() +"/"+ response.data; 
                        dropzoneImages.processQueue();
                        console.log(dropzoneImages);


                    } else {

                        console.log("No entra")
                        errors = response.errors;
                        if (errors) {
                            for (var x = 0; x < errors.length; x++) {
                                var input = errors[x][0];
                                var message = errors[x][1];
                                $("span[data-valmsg-for=" + input + "]").html(message);
                            }
                        }

                    }
                }
            });
        } else {
            Swal.fire({
                icon: 'error',
                title: 'Sin imagenes',
                text: 'Aun no seleccionas ninguna image',
            })

        }
    });

    dropzoneImages.on("complete", function (file) {
        dropzoneImages.removeFile(file);
        dropzoneImages.processQueue()
    });
    dropzoneImages.on('queuecomplete', function () {
        Swal.fire({
            icon: 'success',
            title: 'Producto creado',
            text: 'El producto fue creado',
        })
        location.reload;
    });

    $(document).on('click', '.fa-plus-circle', function () {
        if (selectSupplies.val().length > 0 && inpQuantity.val().length > 0 && inpUnit.val().length > 0) {
            count++;
            var selectSuppliesHidden = $('<input>', {
                type: 'hidden',
                name: "arrayInsumos[" + count + "][name]",
                id: "arrayInsumos[" + count + "][]"
            }).val(selectSupplies.val());

            var inpUnitHiden = $('<input>', {
                type: 'hidden',
                name: "arrayInsumos[" + count + "][unit]",
                id: "arrayInsumos[" + count + "][]"
            }).val(inpUnit.val());
            var inpQuantityHiden = $('<input>', {
                type: 'hidden',
                name: "arrayInsumos[" + count + "][quantity]",
                id: "arrayInsumos[" + count + "][]"
            }).val(inpQuantity.val());


            var divNam = $('<div>', { class: 'col-md-3' }).html($('#Supplies option:selected').text());
            var divUnit = $('<div>', { class: 'col-md-3' }).html(inpUnit.val());
            var divQuantity = $('<div>', { class: 'col-md-2' }).html(inpQuantity.val());
            var divDelete = $('<div>', { class: 'col-md-1' })
                .append($('<span>', { class: "fas fa-trash" }));

            var divParent = $('<div>', { class: 'row' })
                .append(divNam)
                .append(divUnit)
                .append(divQuantity)
                .append(divDelete)
                .append(selectSuppliesHidden)
                .append(inpUnitHiden)
                .append(inpQuantityHiden);

            $('#content-formula').append(
                $('<div>', {
                    class: "col-md-12"
                }).append(divParent));

            clearInps();
        }
    });
    function clearInps() {
        inpUnit.val("");
        inpQuantity.val("");
    }
});
Dropzone.options.myAwesomeDropzone = false;
Dropzone.autoDiscover = false;
var coutImages = 0;
var dropzoneImages;
var urlDeleteImages;
$(document).ready(function () {

    url = $("#inp-url-image").val();
    coutImages = $("#image-count").val() * 1;
    urlDeleteImages = $("#inp-url-delete-img").val();

    dropzoneImages = new Dropzone("#zdrop", {
        url: url,
        maxFilesize: 5,
        autoProcessQueue: false,
    });

    $(document).on('submit', '#form-upsert', function (e) {
        e.preventDefault();
        if (coutImages > 0 || dropzoneImages.files.length > 0) {
            var data = $('#form-upsert').serialize();
            var url = $('#form-upsert').attr('action');
            $.ajax({
                url: url,
                method: 'post',
                data: data,
                success: function (response) {
                    if (response.success) {
                        var imagesDelete = $('input[delete-image="true"]');
                        dataImages = {};

                        console.log(imagesDelete);
                        for (var x = 0; x < imagesDelete.length; x++) {
                            var indexImage = 'image' + x;
                            console.log(imagesDelete[x]);
                            dataImages[indexImage] = $(imagesDelete[x]).val();

                        }
                        console.log(dataImages);
                        ajaxSubmit(urlDeleteImages, dataImages,
                            function (response) {
                                console.log(response);
                                if (response.success) {
                                    dropzoneImages.options.url = $("#inp-url-image").val();
                                    if (dropzoneImages.files.length > 0) {
                                        console.log(dropzoneImages);
                                        dropzoneImages.processQueue();
                                    } else {
                                        Swal.fire({
                                            icon: 'success',
                                            title: 'Producto Editado',
                                            text: 'El producto fue actualizado',
                                        })
                                    }
                                }
                            }
                        );
                    } else {
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
        //location.reload();
    });

    $(document).on('click', '.fa-trash', function () {
        var trashDiv = $(this).parent()
        var divParent = trashDiv.parent().parent();
        
        divParent.append($('<input>', { 'delete-image': "true" }).val($(this).data('delete-image')));
        trashDiv.parent().remove();
        coutImages--;
        console.log(coutImages);
    });

});


function ajaxSubmit(url, data, fuctionSuccess) {
    $.ajax({
        url: url,
        method: 'post',
        data: data,
        success: function (response) {
            if (fuctionSuccess) {
                fuctionSuccess(response);
            }
        }
    });
}
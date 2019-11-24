Dropzone.options.myAwesomeDropzone = false;
Dropzone.autoDiscover = false;
var dropzoneImages;
$(document).ready(function () {

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
   
});
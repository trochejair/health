$(document).ready(function () {
    var $title = "¿Eliminar Insumo?";
    var $text = "Se eliminaran los datos del insumo";
    var $icon = 'warning';
    $(document).on('click', '.fa-trash', function (e) {
        e.preventDefault();
        Swal.fire({
            title: $title,
            text: $text,
            icon: $icon,
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Sí, Eliminar'
        }).then((result) => {
            if (result.value) {
                var url = $(this).attr('href');
                $.ajax({
                    url: url,
                    success: function (response) {
                        if (response.success) {  
                            location.reload();
                        }
                    }
                });
            }
        })




    });

});
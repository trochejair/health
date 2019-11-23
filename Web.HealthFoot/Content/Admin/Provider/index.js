$(document).ready(function () {
    var $title = "¿Desactivar proveedor?";
    var $text = "No podras hacer pedidos a proveedores desactivados";
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
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            }
        })




    });

});
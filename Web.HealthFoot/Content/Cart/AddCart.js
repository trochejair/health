$(document).ready(function () {
    var inputUrlAddCart = $('#inp-url-add-cart')
    $(document).on('click', '.btn-add-cart', function (e) {
        e.preventDefault();
        var url = inputUrlAddCart.val();
        var data = {
            'product-id': $(this).data('product')
        }

        $.ajax({
            url: url,
            data: data,
            method: 'POST',
            success: function (response) {
                console.log(response);
                if (response.success) {
                    Swal.fire({
                        title: 'Agregado al carrito',
                        text: 'Puedes ver los detalles en el carrito',
                        icon: 'success',
                    })
                } else {
                    Swal.fire({
                        text: '',
                        title: response.message,
                        icon: 'error',
                    })
                }

            }
        })

    });

});
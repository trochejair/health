$(document).ready(function () {
    var inpName = $('#Supplies');
    var inpQuantity = $('#inp-quantity');
    var inpPrice = $('#inp-price');
    var inpUnit = $('#inp-unit');
    var count = 0;
    $(document).on('click', '.fa-plus-circle', function () {
        if (inpName.val().length > 0 && inpPrice.val().length > 0 && inpUnit.val().length > 0) {

            count++;
            var inpNameHidden = $('<input>', {
                type: 'hidden',
                name: "arrayInsumos[" + count + "][name]",
                id: "arrayInsumos[" + count + "][]"
            }).val(inpName.val());
            var inpPriceHiden = $('<input>', {
                type: 'hidden',
                name: "arrayInsumos[" + count + "][price]",
                id: "arrayInsumos[" + count + "][]"
            }).val(inpPrice.val());

            var inpUnitHiden = $('<input>', { type: 'hidden',
                name: "arrayInsumos[" + count + "][unit]",
                id: "arrayInsumos[" + count + "][]"
            }).val(inpUnit.val());
            var inpQuantityHiden = $('<input>', {
                type: 'hidden',
                name: "arrayInsumos[" + count + "][quantity]",
                id: "arrayInsumos[" + count + "][]"
            }).val(inpQuantity.val());


            var divNam = $('<div>', { class: 'col-md-3' }).html($('#Supplies option:selected').text());
            var divPrice = $('<div>', { class: 'col-md-3' }).html(inpPrice.val());
            var divUnit = $('<div>', { class: 'col-md-3' }).html(inpUnit.val());
            var divQuantity = $('<div>', { class: 'col-md-2' }).html(inpQuantity.val());
            var divDelete = $('<div>', { class: 'col-md-1' })
                .append($('<span>', { class: "fas fa-trash" }));

            var divParent = $('<div>', { class: 'row' })
                .append(divNam)
                .append(divPrice)
                .append(divUnit)
                .append(divQuantity)
                .append(divDelete)
                .append(inpNameHidden)
                .append(inpPriceHiden)
                .append(inpUnitHiden)
                .append(inpQuantityHiden);

            $('#content-products').append(
                $('<div>', {
                    class: "col-md-12"
                }).append(divParent));

            clearInps();
        }
    });

    $(document).on('click', '.fa-trash', function () {
        $(this).parent('div')
            .parent('div')
            .parent('div')
            .remove();

    });
    function clearInps() {
        inpPrice.val("");
        inpUnit.val("");
    }
});






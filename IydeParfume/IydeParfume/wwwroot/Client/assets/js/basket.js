$(document).on("click", ".add-product-to-basket-single-btn", function (e) {
    e.preventDefault();


    let aHref = e.target.href;
    let size = e.target.parentElement.parentElement.firstElementChild.children[0];

    let SizeId = size.value;

    let quantity = e.target.previousElementSibling.children[1];
    let Quantity = quantity.value;
    console.log(Quantity)

    $.ajax(
        {
            type: "POST",
            url: aHref,
            data: {
                SizeId: SizeId,
                Quantity: Quantity
            },
            error: function (err) {
                $(".product-details-modal").html(err.responseText);

            }

        });


    //fetch(e.target.href, {
    //    method:"POST"
    //})
    //    .then(response => response.text())
    //    .then(data => {
    //        $('.cart-block').html(data);
    //    })
})
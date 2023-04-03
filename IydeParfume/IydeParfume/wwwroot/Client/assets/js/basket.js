//$(document).on("click", ".add-product-to-basket-single-btn", function (e) {
//    e.preventDefault();


//    let aHref = e.target.href;
//    let size = e.target.parentElement.parentElement.firstElementChild.children[0];

//    let SizeId = size.value;

//    let quantity = e.target.previousElementSibling.children[1];
//    let Quantity = quantity.value;
//    console.log(Quantity)

//    $.ajax(
//        {
//            type: "POST",
//            url: aHref,
//            data: {
//                SizeId: SizeId,
//                Quantity: Quantity
//            },
//            error: function (err) {
//                $(".product-details").html(err.responseText);

//            }

//        });



//})

//$(document).on("click", ".add-product-to-basket-single-btn", function (e) {
//    e.preventDefault();

//    document.getElementById('toaster').style.opacity = '1'
//    setTimeout(() => {
//        document.getElementById('toaster').style.opacity = '0'
//    }, 2000);

//    let aHref = e.target.href;
//    let size = e.target.parentElement.parentElement.firstElementChild.children[0];

//    let SizeId = size.value;

//    let quantity = e.target.previousElementSibling.children[1];
//    let Quantity = quantity.value;
//    console.log(quantity)

//    $.ajax(
//        {
//            type: "POST",
//            url: aHref,
//            data: {
//                SizeId: SizeId,
//                Quantity: Quantity
//            },

//            error: function (err) {
//                $(".product-details-modal").html(err.responseText);

//            }

//        });

//})

//let btns = document.querySelectorAll(".add-to-basket")

//btns.forEach(x => x.addEventListener("click", function (e) {
//    e.preventDefault()

//    let aHref = e.target.parentElement.href;


//    document.getElementById('toaster').style.opacity = '1'
//    setTimeout(() => {
//        document.getElementById('toaster').style.opacity = '0'
//    }, 1000);

//    $.ajax(
//        {
//            type: "POST",
//            url: aHref,

//            error: function (err) {
//                $(".product-details-modal").html(err.responseText);

//            }

//        });

//}))


//$(document).on("click", ".plus-btn", function (e) {
//    e.preventDefault();

//    var aHref = e.target.href;

//    let size = e.target.nextElementSibling;
//    console.log(size);
//    let SizeId = size.value;

//    $.ajax(
//        {
//            type: "POST",
//            url: aHref,
//            data: {
//                SizeId: SizeId,
//            },
//            success: function (response) {

//                $('.basket-block').html(response);

//                $.ajax(
//                    {
//                        type: "GET",
//                        url: updateHref,
//                        success: function (response) {

//                            $('.cart-block').html(response);


//                        },
//                        error: function (err) {
//                            $(".product-details-modal").html(err.responseText);

//                        }

//                    });

//            },
//            error: function (err) {
//                $(".product-details-modal").html(err.responseText);

//            }

//        });

//})


$(document).on("click", ".minus-btn", function (e) {
    e.preventDefault();

    var aHref = e.target.href;

    let size = e.target.parentElement.children[3];
    let SizeId = size.value;
    console.log(SizeId)

    let updateHref = e.target.nextElementSibling.nextElementSibling.nextElementSibling.href;
    //$.ajax(
    //    {
    //        type: "GET",
    //        url: aHref,
    //        data: {
    //            SizeId: SizeId,
    //        },
    //        success: function (response) {

    //            $('.basket-block').html(response);

    //            $.ajax(
    //                {
    //                    type: "GET",
    //                    url: updateHref,
    //                    success: function (response) {

    //                        $('.cart-block').html(response);


    //                    },
    //                    error: function (err) {
    //                        $(".product-details-modal").html(err.responseText);

    //                    }

    //                });

    //        },
    //        error: function (err) {
    //            $(".product-details-modal").html(err.responseText);

    //        }

    //    });

})


$(document).on("click", ".add-product-to-basket-single-btn", function (e) {
    e.preventDefault();


    let aHref = e.target.href;
    let size = e.target.parentElement.parentElement.firstElementChild.children[1];
    let SizeId = size.value;
    console.log(SizeId);



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
            success: function (response) {

                alert("Məhsul Əlavə Edildi");


            },
            error: function (err) {
                $(".product-details-modal").html(err.responseText);

            }

        });
})

$(document).on("click", ".plus-btn", function (e) {
    e.preventDefault();

    fetch(e.target.href)
        .then(response => response.text())
        .then(data => {
            $('.cartPageJs').html(data);

            fetch(e.target.nextElementSibling.href)
                .then(response => response.text())
                .then(data => {
                    $('.quantity-display').html(data);
                })
        })
})

$(document).on("click", ".minus-btn", function (e) {
    e.preventDefault();

    fetch(e.target.href)
        .then(response => response.text())
        .then(data => {
            $('.cartPageJs').html(data);

            fetch(e.target.nextElementSibling.href)
                .then(response => response.text())
                .then(data => {
                    $('.quantity-display').html(data);
                })
        })
})
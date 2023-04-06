


$(document).on("click", ".add-product-to-basket-single-btn", function (e) {
    e.preventDefault();


    let aHref = e.target.href;
    let size = e.target.parentElement.previousElementSibling.children[1];
    let SizeId = size.value;
    console.log(SizeId)

    $.ajax(
        {
            type: "POST",
            url: aHref,
            data: {
                SizeId: SizeId,
            },
            success: function (response) {

                alert("Məhsul Əlavə Edildi");


            },
            error: function (err) {
                $(".product-details-modal").html(err.responseText);

            }

        });
})



//$(document).on("click", ".plus-btn", function (e) {
//    e.preventDefault();
//    console.log(e.target)

//    fetch(e.target.href)
//        .then(response => response.text())
//        .then(data => {
//            $('.right-card').html(data);


//        })
//})

$(document).on("click", ".minus-btn", function (e) {
    e.preventDefault();

    var aHref = e.target.href;
    let size = e.target.nextElementSibling.nextElementSibling.nextElementSibling;
    let SizeId = size.value;

    $.ajax(
        {
            type: "GET",
            url: aHref,
            data: {
                SizeId: SizeId,
            },
            success: function (response) {

                $('.revan').html(response);

            }

        });
})

$(document).on("click", ".plus-btn", function (e) {
    e.preventDefault();

    var aHref = e.target.href;
    let size = e.target.nextElementSibling;
    let SizeId = size.value;
    console.log(aHref)

    $.ajax(
        {
            type: "POST",
            url: aHref,
            data: {
                SizeId: SizeId,
            },
            success: function (response) {

             
                $('.revan').html(response);
            }
        });

})    
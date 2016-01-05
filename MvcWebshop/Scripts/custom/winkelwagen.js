//function addToCart(productId) {
//    $.ajax({
//        type: "POST",
//        url: "../../WinkelWagen/ProductToevoegen",
//        data: "{ productId: '" + productId + "'}",
//        contentType: "application/json; charset=utf-8",
//        dataType: "json",
//        async: "true",
//        cache: "false",
//        success: function (msg) {
//            // On success
//            alert(msg);
//            //$("#winkelwagenmenu").html(msg['temp']);
//        },
//        Error: function (x, e) {
//            // On Error
//            alert("error");
//        }
//    });
//}

function addToCart(productId) {
    $.post("@Url.Action('ProductToevoegen', 'Winkelwagen')", { ProductID: productId }, function (data) {
        alert(data);
    });
}